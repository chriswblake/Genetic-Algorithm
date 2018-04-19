#define DUP              0x00
#define SWAP             0x01
#define MUL              0x02
#define ADD              0x03
#define OVER             0x04
#define NOP              0x05
#define MAX_INSTRUCTION          (NOP+1)

#define NONE                     0
#define STACK_VIOLATION          1
#define MATH_VIOLATION           2
#define STACK_DEPTH				25

int stack[STACK_DEPTH];
int stackPointer;

#define ASSERT_STACK_ELEMENTS(x) \
     if (stackPointer < x) { error = STACK_VIOLATION ; break; }

#define ASSERT_STACK_NOT_FULL \
     if (stackPointer == STACK_DEPTH) { error = STACK_VIOLATION ; break; }

#define SPUSH(x) (stack[stackPointer++] = x)
#define SPOP     (stack[--stackPointer])
#define SPEEK    (stack[stackPointer-1])

// interpretSTM
//
//  program    - sequence of simple instructions
//  progLength - length of program
//  args       - arguments on the virtual stack
//  argsLength - number of arguments on the virtual stack
int interpretSTM(const int *program, int progLength, const int *args, int argsLength)
{
	int pc = 0;
	int i, error = NONE;
	int a, b;

	stackPointer = 0;

	/* Load the arguments onto the stack */
	for (i = argsLength - 1; i >= 0; i--) {
		SPUSH(args[i]);
	}

	/* Execute the program */
	while ((error == NONE) && (pc < progLength)) {

		switch (program[pc++]) {

		case DUP:
			ASSERT_STACK_ELEMENTS(1);
			ASSERT_STACK_NOT_FULL;
			SPUSH(SPEEK);
			break;

		case SWAP:
			ASSERT_STACK_ELEMENTS(2);
			a = stack[stackPointer - 1];
			stack[stackPointer - 1] = stack[stackPointer - 2];
			stack[stackPointer - 2] = a;
			break;

		case MUL:
			ASSERT_STACK_ELEMENTS(2);
			a = SPOP; b = SPOP;
			SPUSH(a * b);
			break;

		case ADD:
			ASSERT_STACK_ELEMENTS(2);
			a = SPOP; b = SPOP;
			SPUSH(a + b);
			break;

		case OVER:
			ASSERT_STACK_ELEMENTS(2);
			SPUSH(stack[stackPointer - 2]);
			break;

		} /* Switch opcode */

	} /* Loop */
	return(error);
}


int main()
{
	int generation = 0, i;
	FILE *fp;
	extern float minFitness, maxFitness, avgFitness;
	extern int curCrossovers, curMutations;
	extern int curPop;

	void printProgram(int, int);

	/* Seed the random number generator */
	srand(time(NULL));

	curPop = 0;

	fp = fopen("stats.txt", "w");

	if (fp == NULL) exit(-1);

	/* Initialize the initial population and check each element's
	* fitness.
	*/
	initPopulation();
	performFitnessCheck(fp);

	// Loop for the maximum number of allowable generations
	while (generation < MAX_GENERATIONS)
	{
		curCrossovers = curMutations = 0;

		/* Select two parents and recombine to create two children */
		performSelection();

		/* Switch the populations */
		curPop = (curPop == 0) ? 1 : 0;

		/* Calculate the fitness of the new population */
		performFitnessCheck(fp);

		/* Emit statistics every 100 generations */
		if ((generation++ % 100) == 0) {
			printf("Generation %d\n", generation - 1);
			printf("\tmaxFitness = %f (%g)\n", maxFitness, MAX_FIT);
			printf("\tavgFitness = %f\n", avgFitness);
			printf("\tminFitness = %f\n", minFitness);
			printf("\tCrossovers = %d\n", curCrossovers);
			printf("\tMutation  = %d\n", curMutations);
			printf("\tpercentage = %f\n", avgFitness / maxFitness);
		}

		// Check the diversity of the population after _ number of
		// generations has completed. If the population has prematurely
		// converged, exit out to allow the user to restart.
		if (generation > (MAX_GENERATIONS * 0.25)) {
			if ((avgFitness / maxFitness) > 0.98) {
				printf("converged\n");
				break;
			}
		}

		if (maxFitness == MAX_FIT) {
			printf("found solution\n");
			break;
		}

	}

	// Emit final statistics
	printf("Generation %d\n", generation - 1);
	printf("\tmaxFitness = %f (%g)\n", maxFitness, MAX_FIT);
	printf("\tavgFitness = %f\n", avgFitness);
	printf("\tminFitness = %f\n", minFitness);
	printf("\tCrossovers = %d\n", curCrossovers);
	printf("\tMutation = %d\n", curMutations);
	printf("\tpercentage = %f\n", avgFitness / maxFitness);

	//Emit the highest fit chromosome from the population
	for (i = 0; i < MAX_CHROMS; i++) {

		if (populations[curPop][i].fitness == maxFitness) {
			int index;
			printf("Program %3d : ", i);

			for (index = 0; index < populations[curPop][i].progSize;
				index++) {
				printf("%02d ", populations[curPop][i].program[index]);
			}
			printf("\n");
			printf("Fitness %f\n", populations[curPop][i].fitness);
			printf("ProgSize %d\n\n", populations[curPop][i].progSize);

			printProgram(i, curPop);

			break;
		}

	}

	return 0;
}
typedef struct population {
	float fitness;
	int   progSize;
	int   program[MAX_PROGRAM];
} POPULATION_TYPE;

POPULATION_TYPE populations[2][MAX_CHROMS];

int curPop;

void initMember(pop, index)
{
	int progIndex;

	populations[pop][index].fitness = 0.0;
	populations[pop][index].progSize = MAX_PROGRAM - 1;

	//Randomly create a new program
	progIndex = 0;
	while (progIndex < MAX_PROGRAM)
	{
		populations[pop][index].program[progIndex++] = getRand(MAX_INSTRUCTION);
	}

}
void initPopulation(void)
{
	int index;

	/* Initialize each member of the population */
	for (index = 0; index < MAX_CHROMS; index++) {
		initMember(curPop, index);
	}
}

float maxFitness;
float avgFitness;
float minFitness;

extern int stackPointer;
extern int stack[];

static int x = 0;
float totFitness;

int performFitnessCheck(FILE *outP)
{
	int chrom, result, i;
	int args[10], answer;

	maxFitness = 0.0;
	avgFitness = 0.0;
	minFitness = 1000.0;

	for (chrom = 0; chrom < MAX_CHROMS; chrom++) {
		populations[curPop][chrom].fitness = 0.0;

		for (i = 0; i < COUNT; i++) {

			args[0] = (rand() & 0x1f) + 1;
			args[1] = (rand() & 0x1f) + 1;
			args[2] = (rand() & 0x1f) + 1;

			// Sample Problem: x^3 + y^2 + z
			answer = (args[0] * args[0] * args[0]) +
				(args[1] * args[1]) + args[2];

			// Call the virtual stack machine to check the program
			result = interpretSTM(
				populations[curPop][chrom].program,
				populations[curPop][chrom].progSize,
				args, 3);

			// If no error occurred, add this to the fitness value
			if (result == NONE)
			{
				populations[curPop][chrom].fitness += TIER1;
			}

			// If only one element is on the stack, add this to the fitness value.
			if (stackPointer == 1)
			{
				populations[curPop][chrom].fitness += TIER2;
			}

			// If the stack contains the correct answer, add this to the fitness value.
			if (stack[0] == answer)
			{
				populations[curPop][chrom].fitness += TIER3;
			}

		}

		//If this chromosome exceeds our last highest fitness, update
		//the statistics for this new record.
		if (populations[curPop][chrom].fitness > maxFitness) {
			maxFitness = populations[curPop][chrom].fitness;
		}
		else if (populations[curPop][chrom].fitness < minFitness) {
			minFitness = populations[curPop][chrom].fitness;
		}

		// Update the total fitness value (sum of all fitnesses)
		totFitness += populations[curPop][chrom].fitness;

	}

	/* Calculate our average fitness */
	avgFitness = totFitness / (float)MAX_CHROMS; '

		if (outP) {
			/* Emit statistics if we have an output file pointer */
			fprintf(outP, "%d %6.4f %6.4f %6.4f\n",
				x++, minFitness, avgFitness, maxFitness);
		}

	return 0;
}
int performSelection(void)
{
	int par1, par2;
	int child1, child2;
	int chrom;

	//Walk through the chromosomes, two at a time
	for (chrom = 0; chrom < MAX_CHROMS; chrom += 2) {

		//Select two parents, randomly
		par1 = selectParent();
		par2 = selectParent();

		//The children are loaded at the current index points
		child1 = chrom;
		child2 = chrom + 1;

		//Recombine the parents to the children
		performReproduction(par1, par2, child1, child2); ]

	}
	return 0;
}
int selectParent(void)
{
	static int chrom = 0;
	int ret = -1;
	float retFitness = 0.0;

	/* Roulette-wheel selection process */
	do {

		/* Select the target fitness value */
		retFitness = (populations[curPop][chrom].fitness / maxFitness);

		if (chrom == MAX_CHROMS) chrom = 0;

		// If we've walked through the population and have reached our target fitness value, select this member.
		if (populations[curPop][chrom].fitness > minFitness) {
			if (getSRand() < retFitness) {
				ret = chrom++;
				retFitness = populations[curPop][chrom].fitness;
				break;
			}
		}
		chrom++;

	} while (1);

	return ret;
}
int performReproduction(int parentA, int parentB, int childA, int childB)
{
	int crossPoint, i;
	int nextPop = (curPop == 0) ? 1 : 0;

	int mutate(int);

	//If we meet the crossover probability, perform crossover of the
	//two parents by selecting the crossover point.
	if (getSRand() > XPROB) {
		crossPoint = getRand(MAX(populations[curPop][parentA].progSize - 2, populations[curPop][parentB].progSize - 2)) + 1;
		curCrossovers++;
	}
	else {
		crossPoint = MAX_PROGRAM;
	}

	//Perform the actual crossover, in addition to random mutation
	for (i = 0; i < crossPoint; i++) {
		populations[nextPop][childA].program[i] =
			mutate(populations[curPop][parentA].program[i]);
		populations[nextPop][childB].program[i] =
			mutate(populations[curPop][parentB].program[i]);
	}

	for (; i < MAX_PROGRAM; i++) {
		populations[nextPop][childA].program[i] =
			mutate(populations[curPop][parentB].program[i]);
		populations[nextPop][childB].program[i] =
			mutate(populations[curPop][parentA].program[i]);
	}

	//Update the program sizes for the children (based upon the parents).
	populations[nextPop][childA].progSize =
		populations[curPop][parentA]
		progSize; populations[nextPop][childB].progSize =
		populations[curPop][parentB].progSize;

	return 0;
}
int mutate(int gene)
{
	float temp = getSRand();

	// If we've met the mutation probability, randomly mutate this gene to a new instruction.
	if (temp > MPROB) {
		gene = getRand(MAX_INSTRUCTION);
		curMutations++;
	}

	return gene;
}