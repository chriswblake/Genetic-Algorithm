using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Ch6_Genetic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (Series s in chartResults.Series)
            {
                s.Points.Clear();
            }
        }

        //For debugging
        public string showCorrectVsCalculated(Chromosome chromosome)
        {
            //Convert to program
            List<Command> program = new List<Command>();
            foreach (Gene g in chromosome.Genes)
            {
                program.Add((Command)g.Value);
            }

            //Pick parameters
            var parameters = new List<double> { 2, 3, 4 };

            //interpret
            return functionToMimic(parameters).ToString() + ":  " + String.Join(",", interpretStack(program, parameters));
        }

        //For Display
        public void addDataToSeries(Series s, List<double> values)
        {
            //Clear series
            s.Points.Clear();

            //Results list
            List<DataPoint> points = new List<DataPoint>();

            //Create list
            for (int p = 0; p< values.Count; p++)
            {
                s.Points.AddXY(p + 1, values[p]);
            }
        }

        //For genetic algorithm 
        public double functionToMimic(List<double> parameters)
        {
            //Get parameters
            double x = parameters[0];
            double y = parameters[1];
            double z = parameters[2];

            //calculate
            return (x * x * x) + (y * y) + z;
        }
        public double fitnessFunction(Chromosome chromosome, Random rand)
        {
            double points = 0;
            double maxPoints = (100+200+500)*10;

            //Convert chromosome genes into the commands
            List<Command> program = new List<Command>();
            foreach (Gene g in chromosome.Genes)
            {
                program.Add((Command)g.Value);
            }

            //Run 10 random samples along the equation
            for (int test=1; test < 10; test++)
            { 
                //Sample Problem: x^3 + y^2 + z
                //List<double> parameters = new List<double>() { 2, 3, 4 };
                List<double> parameters = new List<double>() { rand.Next(), rand.Next(), rand.Next()};

                //Solve using specified function
                double correctAnswer = functionToMimic(parameters);
                
                //Solve using stack
                List<double> results = interpretStack(program, parameters);

                //Earn Points         
                #region Earn points for most correct

                //If error
                if (results == null)
                    return 0;

                //If no error
                points += 100;

                //If only one value
                if (results.Count == 1)
                    points += 200;
                else
                {
                    //Lose points
                    for (int i = 1; i < results.Count; i++)
                        points -= 10;
                }
 
                //Check if correct solution
                if ((results.Count == 1) && (results[0] == correctAnswer))
                    points += 500;

                #endregion
            }
            //Return
            return points/maxPoints*100; //Percentage to solution
        }

        //Stack Interpreter
        public enum Command
        {
            DUP,
            SWAP,
            MUL,
            ADD,
            OVER,
            NOP
        }
        public List<double> interpretStack(List<Command> program, List<double> parameters)
        {
            //copy parameters list
            List<double> par = parameters.ToList();

            //Cycle through each program command
            foreach (Command c in program)
            {
                //Count parameters
                int pCount = par.Count;

                //Peform operation
                switch (c)
                {
                    case Command.DUP:
                        //Duplicate first entry
                        par.Insert(0, par.First());
                        break;

                    case Command.SWAP:
                        //Check that two par exist
                        if (par.Count < 2) return null; // Needs two parameters
                        //Get first item
                        double first = par[0];
                        //Copy second item to first item
                        par[0] = par[1];
                        //Overwrite second with saved value
                        par[1] = first;
                        break;

                    case Command.MUL:
                        //Check that two par exist
                        if (par.Count < 2) return null; // Needs two parameters
                        //Multiply values
                        double m = par[0] * par[1];
                        //Remove first 2 entries
                        par.RemoveRange(0, 2);
                        //Insert result into list
                        par.Insert(0, m);
                        break;

                    case Command.ADD:
                        //Check that two par exist
                        if (par.Count < 2) return null; // Needs two parameters
                        //Add values
                        double a = par[0] + par[1];
                        //Remove first 2 entries
                        par.RemoveRange(0, 2);
                        //Add result to list
                        par.Insert(0, a);
                        break;

                    case Command.OVER:
                        //Check that two par exist
                        if (par.Count < 2) return null; // Needs two parameters
                        //Copy second item to beginning
                        par.Insert(0, par[1]);
                        break;

                    //case Command.NOP:
                        //do nothing
                      //  break;
                }
            }

            //Return value or throw error
            return par;
        }

        //Controls
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Algorithm Parameters
            int populationStart = 100;
            double crossoverFactor = 0.5;
            double mutationFactor = 0.5;
            int cyclesMax = 100;

            #region Get user input
            try
            {
                populationStart = Convert.ToInt32(tbPopulationStart.Text);
                crossoverFactor = Convert.ToDouble(tbCrossoverFactor.Text);
                mutationFactor = Convert.ToDouble(tbMutationFactor.Text);
                cyclesMax = Convert.ToInt32(tbCyclesMax.Text);
            }catch
            {
                return;
            }
            #endregion

            #region Create population
            //Create list of possible gene values
            List<object> options = new List<object> {
                Command.ADD,
                Command.DUP,
                Command.MUL,
                Command.NOP,
                Command.OVER,
                Command.SWAP
            };

            //Generate population  
            List<Chromosome> origPopulation = GeneticAlgorithm.createRandPopulation(options, populationStart, 10);
            foreach (Chromosome c in origPopulation)
                c.InterpretFunction = showCorrectVsCalculated;
            #endregion

            #region Run algorithm
            //Set up algorithm
            GeneticAlgorithm genAlg = new GeneticAlgorithm(origPopulation, fitnessFunction)
            {
                CrossoverFactor = crossoverFactor,
                MutationFactor = mutationFactor,
                CyclesMax = cyclesMax
            };

            //Statistics
            List<double> fitMax = new List<double>();
            List<double> fitMin = new List<double>();
            List<double> fitAverage = new List<double>();

            //Solution
            Chromosome solution = genAlg.solve(out fitMax, out fitMin, out fitAverage);
            #endregion

            //Show on chart
            addDataToSeries(chartResults.Series["fitMax"], fitMax);
            addDataToSeries(chartResults.Series["fitMin"], fitMin);
            addDataToSeries(chartResults.Series["fitAverage"], fitAverage);

            //Show in textbox
            if (solution != null)
            {
                //Build Virtual Machine program as text
                string program = "";
                foreach (Gene g in solution.Genes)
                {
                    //Convert from gene to command
                    Command c = (Command) g.Value;
                    if (c == Command.NOP) { continue; } //NOP is a placeholder for nothing

                    //Add eaach command
                    if (program.Length > 0) { program += ", "; }
                    program += c.ToString();
                }

                tbSolution.Text = program.ToString();
            }
            else
                tbSolution.Text = "No solution found within limits. Please try again.";
        }

        private void chartResults_DoubleClick(object sender, EventArgs e)
        {
            Chart theChart = (Chart)sender;
            using (MemoryStream ms = new MemoryStream())
            {
                theChart.SaveImage(ms, ChartImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }
    }

    //Base algorithm
    public class GeneticAlgorithm
    {
        //Fields
        Random rand = new Random();
        private List<Chromosome> popParents = new List<Chromosome>();
        private List<Chromosome> popChildren = new List<Chromosome>();
        private FitnessFunction fitFunction = null;

        //Properties
        public double CrossoverFactor = 0.5;
        public double MutationFactor = 0.2;
        public int CyclesMax = 100;

        //Initialize population function
        public GeneticAlgorithm (List<Chromosome> originalParents, FitnessFunction fitFunction)
        {
            popParents = originalParents.ToList();
            this.fitFunction = fitFunction;
        }

        //Main Algorithm
        public Chromosome solve(out List<double> fitMax, out List<double> fitMin, out List<double> fitAverage)
        {
            //Stats  
            fitMax = new List<double>();
            fitMin = new List<double>();
            fitAverage = new List<double>();

            //Calculate fitness of inititial population
            foreach (Chromosome chromosome in popParents)          
                chromosome.fitness = fitFunction(chromosome, rand);
            
            //Reproduce until optimized or limit reached
            for (int cycle = 0; cycle < CyclesMax; cycle++)
            { 
                //Create Children
                popChildren = performReproduction(popParents);

                //Replace bad children (fitness = 0)
                //popChildren = popChildren.FindAll(p => p.fitness > 0).ToList();
                //int replaceAmount = popParents.Count - popChildren.Count;
                //popChildren.AddRange(popChildren.OrderByDescending(p => p.fitness).Take(replaceAmount));

                //Calculate Statistics
                double maxFitness = popChildren.Max(c => c.fitness);
                fitMax.Add(maxFitness);
                double minFitness = popChildren.Min(c => c.fitness);
                fitMin.Add(minFitness);
                double avgFitness = popChildren.Average(c => c.fitness);
                fitAverage.Add(avgFitness);

                //Check for solution
                if (maxFitness >= 95)
                    return popChildren.Find(p => p.fitness == maxFitness);

                //Remove parents and replace with children
                popParents = popChildren.ToList();
                popChildren.Clear();
            }

            return null;
        }

        //Static Methods
        public static List<Chromosome> createRandPopulation(List<object> options, int popCount, int genesCount)
        {
            //Randomizer
            Random rand = new Random();

            //Create random list of chromosomes
            List<Chromosome> population = new List<Chromosome>();
            int id = 0;
            for (int p = 0; p < popCount; p++)
            {
                //Create list of genes
                List<Gene> chGenes = new List<Gene>();
                for (int g = 0; g < genesCount; g++)
                {
                    //Pick a random gene from the options
                    int c = rand.Next(0, options.Count);

                    //Add the gene to the list
                    chGenes.Add(new Gene(options[c], options) );
                }

                //Add the chromosome to the list
                population.Add(new Chromosome(chGenes) { ID = id }); id++;
            }

            //Return list
            return population;
        }
        private List<Chromosome> performReproduction(List<Chromosome> population)
        {
            //Result list
            List<Chromosome> children = new List<Chromosome>();

            //Cycle through population and reproduce
            int id = 0;
            double minFitness = population.Min(p => p.fitness);
            double maxFitness = population.Max(p => p.fitness);
            for (int c = 0; c < popParents.Count; c = c + 2)
            {
                //Select parents
                Chromosome parent1 = null;
                Chromosome parent2 = null;
                while (parent1 == parent2)
                { 
                    parent1 = SelectParent(population, minFitness, maxFitness);
                    parent2 = SelectParent(population, minFitness, maxFitness);
                }

                #region Produce children
                //Default (no changes)
                Chromosome child1 = new Chromosome(parent1) { Parent1 = parent1 };
                Chromosome child2 = new Chromosome(parent2) { Parent1 = parent2 };

                //Randomly crossoever half of them
                if (rand.NextDouble() < CrossoverFactor)
                    CrossoverWith(parent1, parent2, out child1, out child2);

                //Randomly mutate children
                if (rand.NextDouble() < MutationFactor)
                { child1 = Mutate(child1); child1.Parent1 = null; child1.Parent2 = null; }
                if (rand.NextDouble() < MutationFactor)
                { child2 = Mutate(child2); child2.Parent1 = null; child2.Parent2 = null; }
                #endregion

                //Add children to list
                child1.ID = id; id++;
                child2.ID = id; id++;
                children.Add(child1);
                children.Add(child2);
            }

            //Return children
            return children;
        }
        private Chromosome SelectParent(List<Chromosome> population, double minFitness, double maxFitness)
        {
            //Get count of population
            int countChromosomes = population.Count;

            //Loop until a suitable parent is found
            int tryCount = population.Count;
            while (true)
            {
                //Pick random chromosome
                Chromosome parent = population[rand.Next(0, population.Count)];

                //Skip lowest performer
                if (parent.fitness > minFitness)
                {
                    //Pick parent based on fitness and probability
                    double retentionFitness = (parent.fitness / maxFitness);
                    double probabilty = rand.NextDouble();
                    if (probabilty < retentionFitness)
                    {
                        return parent;
                    }
                }

                //If tryCount exceeded, return the random parent
                if (tryCount == 0)
                    return parent;

                //Reduce trys
                tryCount--;
            }
        }

        //Methods - alter chromosomes
        private void CrossoverWith(Chromosome parent1, Chromosome parent2, out Chromosome child1, out Chromosome child2)
        {
            //Pick random crossover point
            int crossPoint = rand.Next(1, parent1.Genes.Count - 1); //Prevent first and last
            int countToCopy = parent1.Genes.Count - crossPoint;

            //Get bodies
            List<Gene> bodyP1 = parent1.Genes.ToList().GetRange(0, crossPoint);
            List<Gene> bodyP2 = parent2.Genes.ToList().GetRange(0, crossPoint);

            //Get Tails
            List<Gene> tailP1 = parent1.Genes.GetRange(crossPoint, countToCopy).ToList();
            List<Gene> tailP2 = parent2.Genes.GetRange(crossPoint, countToCopy).ToList();

            //Create Child 1
            child1 = new Chromosome(parent1) { Parent1 = parent1, Parent2 = parent2 };
            child1.Genes.Clear();
            child1.Genes.AddRange(bodyP1);
            child1.Genes.AddRange(tailP2);
            child1.fitness = fitFunction(child1, rand);

            //Create Child 2
            child2 = new Chromosome(parent2) { Parent1 = parent1, Parent2 = parent2 };
            child2.Genes.Clear();
            child2.Genes.AddRange(bodyP2);
            child2.Genes.AddRange(tailP1);
            child2.fitness = fitFunction(child2, rand);
        }
        private Chromosome Mutate(Chromosome original) {

            //Create new chromosome using existing genes
            Chromosome mutatedChromosome = new Chromosome(original);

            //Pick random gene in chromosome
            int indexGene = rand.Next(0, original.Genes.Count);

            //Create copy of the gene
            Gene g = original.Genes[indexGene];

            //Remove existing value from gene options
            List<object> options = g.Options.ToList();
            options.Remove(g.Value);

            //Pick a random option from available options
            object newValue = options[rand.Next(0, options.Count)];

            //Change the gene and save to mutated versoin
            g.Value = newValue;
            mutatedChromosome.Genes[indexGene] = g;

            //Recalculate fitness
            mutatedChromosome.fitness = fitFunction(mutatedChromosome, rand);
            mutatedChromosome.fitness *= 1.1; //Give preference to mutations (since they introduce new material)

            //Return new chromosome
            return mutatedChromosome;
        }

        //Classes
        public delegate double FitnessFunction(Chromosome chromosome, Random rand);      
    }
    public class Chromosome
    {
        //Tracking
        public int ID;
        public Chromosome Parent1 = null;
        public Chromosome Parent2 = null;

        //Fields
        public double fitness = 0;
        public List<Gene> Genes = new List<Gene>();
        public InterpretChromosomeFunction InterpretFunction = null;

        //Constructor
        public Chromosome(Chromosome orig)
        {
            this.fitness = orig.fitness;
            this.Parent1 = orig.Parent1;
            this.Parent2 = orig.Parent2;
            this.Genes = orig.Genes.ToList();
            this.InterpretFunction = orig.InterpretFunction;       
        }
        public Chromosome(List<Gene> genes)
        {
            //Transfer items into the list of genes
            this.Genes.AddRange(genes.ToList());
        }

        //Properties
        public override string ToString()
        {
            string parent1 = "  ";  if (Parent1 != null) { parent1 = Parent1.ID.ToString().PadLeft(2); }
            string parent2 = "  ";  if (Parent2 != null) { parent2 = Parent2.ID.ToString().PadLeft(2); }
            return "[" + ID.ToString().PadLeft(2) + "] = (" + parent1 + "," + parent2 + ")" //ID and parents
                    //+ ", Count:" + Genes.Count
                    + "     Fit:" + fitness.ToString("F0").PadLeft(6)
                    + "     Genes: (" +  String.Join(", ", Genes) + ")";
        }
        public object ToInterpretation
        {
            get
            { 
                if (InterpretFunction != null)
                    return InterpretFunction(this);
                else
                    return null;
            }
        }

        //Classes
        public delegate object InterpretChromosomeFunction(Chromosome chromosome);
    }
    public struct Gene
    {
        //Fields
        private object[] options;
        private object value;

        //Constructor
        public Gene(object value, List<object> options)
        {
            this.options = options.ToArray();
            this.value = value;
        }

        //Properties
        public List<object> Options
        {
            get { return options.ToList(); }
            set { options = value.ToArray(); }
        }
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
