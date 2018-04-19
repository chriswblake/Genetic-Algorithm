namespace Ch6_Genetic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 10D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 7D);
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 5D);
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbPopulationStart = new System.Windows.Forms.TextBox();
            this.tbCrossoverFactor = new System.Windows.Forms.TextBox();
            this.tbMutationFactor = new System.Windows.Forms.TextBox();
            this.tbCyclesMax = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbSolution = new System.Windows.Forms.TextBox();
            this.tbEquation = new System.Windows.Forms.TextBox();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.layoutMain.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(2, 0);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 24);
            label1.TabIndex = 2;
            label1.Text = "Start Population";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(2, 24);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 24);
            label2.TabIndex = 4;
            label2.Text = "Crossover Factor";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(2, 48);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 24);
            label3.TabIndex = 6;
            label3.Text = "Mutation Factor";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(2, 72);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(87, 24);
            label4.TabIndex = 8;
            label4.Text = "Max Cycles";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(2, 222);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 13);
            label5.TabIndex = 11;
            label5.Text = "VM Solution";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(0, 150);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(57, 13);
            label6.TabIndex = 12;
            label6.Text = "Equation";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(2, 3);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(126, 13);
            label7.TabIndex = 14;
            label7.Text = "Algorithm Parameters";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(0, 186);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(124, 13);
            label8.TabIndex = 15;
            label8.Text = "Equation Parameters";
            // 
            // chartResults
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.Title = "Cycle";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.Title = "Fitness (avg, max, min)";
            chartArea1.AxisY2.Title = "Fitness (total)";
            chartArea1.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea1);
            this.chartResults.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartResults.Legends.Add(legend1);
            this.chartResults.Location = new System.Drawing.Point(156, 2);
            this.chartResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartResults.Name = "chartResults";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerBorderWidth = 0;
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.MarkerSize = 3;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "fitMax";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.Black;
            series2.MarkerBorderWidth = 0;
            series2.MarkerColor = System.Drawing.Color.DarkGray;
            series2.MarkerSize = 3;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "fitAverage";
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            series2.Points.Add(dataPoint7);
            series2.Points.Add(dataPoint8);
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.LightGray;
            series3.MarkerSize = 3;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "fitMin";
            series3.Points.Add(dataPoint9);
            series3.Points.Add(dataPoint10);
            series3.Points.Add(dataPoint11);
            series3.Points.Add(dataPoint12);
            this.chartResults.Series.Add(series1);
            this.chartResults.Series.Add(series2);
            this.chartResults.Series.Add(series3);
            this.chartResults.Size = new System.Drawing.Size(508, 421);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chartResults";
            this.chartResults.DoubleClick += new System.EventHandler(this.chartResults_DoubleClick);
            // 
            // tbPopulationStart
            // 
            this.tbPopulationStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPopulationStart.Location = new System.Drawing.Point(93, 2);
            this.tbPopulationStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPopulationStart.Name = "tbPopulationStart";
            this.tbPopulationStart.Size = new System.Drawing.Size(46, 20);
            this.tbPopulationStart.TabIndex = 1;
            this.tbPopulationStart.Text = "100";
            // 
            // tbCrossoverFactor
            // 
            this.tbCrossoverFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCrossoverFactor.Location = new System.Drawing.Point(93, 26);
            this.tbCrossoverFactor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCrossoverFactor.Name = "tbCrossoverFactor";
            this.tbCrossoverFactor.Size = new System.Drawing.Size(46, 20);
            this.tbCrossoverFactor.TabIndex = 3;
            this.tbCrossoverFactor.Text = "0.1";
            // 
            // tbMutationFactor
            // 
            this.tbMutationFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMutationFactor.Location = new System.Drawing.Point(93, 50);
            this.tbMutationFactor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMutationFactor.Name = "tbMutationFactor";
            this.tbMutationFactor.Size = new System.Drawing.Size(46, 20);
            this.tbMutationFactor.TabIndex = 5;
            this.tbMutationFactor.Text = "0.1";
            // 
            // tbCyclesMax
            // 
            this.tbCyclesMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCyclesMax.Location = new System.Drawing.Point(93, 74);
            this.tbCyclesMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCyclesMax.Name = "tbCyclesMax";
            this.tbCyclesMax.Size = new System.Drawing.Size(46, 20);
            this.tbCyclesMax.TabIndex = 7;
            this.tbCyclesMax.Text = "500";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbPopulationStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbCrossoverFactor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbCyclesMax, 1, 3);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMutationFactor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(141, 121);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(93, 98);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(46, 21);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSolution
            // 
            this.tbSolution.Location = new System.Drawing.Point(2, 238);
            this.tbSolution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSolution.Multiline = true;
            this.tbSolution.Name = "tbSolution";
            this.tbSolution.Size = new System.Drawing.Size(144, 164);
            this.tbSolution.TabIndex = 10;
            // 
            // tbEquation
            // 
            this.tbEquation.Location = new System.Drawing.Point(2, 164);
            this.tbEquation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEquation.Name = "tbEquation";
            this.tbEquation.ReadOnly = true;
            this.tbEquation.Size = new System.Drawing.Size(141, 20);
            this.tbEquation.TabIndex = 13;
            this.tbEquation.Text = "x^3 + y^2 + z";
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.panelControls, 0, 0);
            this.layoutMain.Controls.Add(this.chartResults, 1, 0);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Size = new System.Drawing.Size(666, 425);
            this.layoutMain.TabIndex = 14;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.textBox1);
            this.panelControls.Controls.Add(label8);
            this.panelControls.Controls.Add(label7);
            this.panelControls.Controls.Add(this.tableLayoutPanel1);
            this.panelControls.Controls.Add(label5);
            this.panelControls.Controls.Add(this.tbEquation);
            this.panelControls.Controls.Add(this.tbSolution);
            this.panelControls.Controls.Add(label6);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(2, 2);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(150, 421);
            this.panelControls.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 200);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "2, 3, 4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(666, 425);
            this.Controls.Add(this.layoutMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Ch6 - Genetic Evolution of a Virtual Machine";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.layoutMain.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.TextBox tbPopulationStart;
        private System.Windows.Forms.TextBox tbCrossoverFactor;
        private System.Windows.Forms.TextBox tbMutationFactor;
        private System.Windows.Forms.TextBox tbCyclesMax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbSolution;
        private System.Windows.Forms.TextBox tbEquation;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.TextBox textBox1;
    }
}

