using System.Windows.Forms.DataVisualization.Charting;
using CalculateExpressions.NewExpression;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Recognitions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace GraphInterface
{
    public partial class Form1 : Form
    {
        LinkedList<Chart> ListChart = new LinkedList<Chart>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var step = Double.Parse(StepBox.Text);
            var mseries = new MSeries(Double.Parse(StartBox.Text) + step, int.Parse(FinishBox.Text),ExpressionBox.Text, step);

            var series = mseries.MakeSeries();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Red;
            series.MarkerBorderWidth = 3;

            var chart = new Chart();
            chart.Location = new Point(150,label3.Bottom+50);
            chart.Width = 600;
            chart.ChartAreas.Add(new ChartArea("MyGraphic"));
            chart.ChartAreas[0].AxisX.Interval = 1;
            //chart.Dock = DockStyle.Right;
            chart.Series.Add(series);

            if (ListChart.Count != 0)
            {
                Controls.Remove(ListChart.Last.Value);
                ListChart.RemoveLast();
            }

            ListChart.AddLast(chart);
            Controls.Add(chart);
        }
    }



    public class MSeries
    {
        public double Start { get; protected set; }
        public int Finish { get; protected set; }
        public string Expression { get; protected set; }
        public double Step { get; set; }

        public MSeries(double start, int finish, string expression, double step)
        {
            Finish = finish;
            Start = start;
            Expression = expression;
            Step = step;
        }

        public Series MakeSeries()
        {
            var count = Start;
            var series = new Series();
            var stringrecognizer = VariedExpression.Change(Expression, Start, Finish, Step);
            foreach (var recognation in stringrecognizer)
            {
                var recognizer = new Recognizer();
                var exp = new CalculableExpression(recognizer.Recognize(recognation));
                series.Points.Add(new DataPoint(count, exp.Result()));
                count += Step;
            }
            return series;
        }
    }
}



