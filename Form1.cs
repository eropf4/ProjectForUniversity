using System.Windows.Forms.DataVisualization.Charting;
using CalculateExpressions.NewExpression;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Recognitions;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace GraphInterface
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var mseries = new MSeries(Int16.Parse(StartBox.Text), Int16.Parse(FinishBox.Text),ExpressionBox.Text);

            var series = mseries.MakeSeries();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Red;
            series.MarkerBorderWidth = 3;

            var chart = new Chart();
            chart.Location = new Point(0,label3.Bottom);
            chart.ChartAreas.Add(new ChartArea("MyGraphic"));
            //chart.Dock = DockStyle.Right;
            chart.Series.Add(series);

            Controls.Add(chart);
        }
    }



    public class MSeries
    {
        public int Start { get; protected set; }
        public int Finish { get; protected set; }
        public string Expression { get; protected set; }

        public MSeries(int start, int finish, string expression)
        {
            Finish = finish;
            Start = start;
            Expression = expression;
        }

        public Series MakeSeries()
        {
            var count = Start;
            var series = new Series();
            var stringrecognizer = VariedExpression.Change(Expression, Start, Finish);
            foreach (var recognation in stringrecognizer)
            {
                var recognizer = new Recognizer();
                var exp = new CalculableExpression(recognizer.Recognize(recognation));
                series.Points.Add(new DataPoint(count, exp.Result()));
                count++;
            }
            return series;
        }
    }
}



