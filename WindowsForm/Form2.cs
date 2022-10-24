using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using Bl;

namespace WinFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Logic logic)
        {
            InitializeComponent();
            this.logic2 = logic;
            DrawGraph();
        }

        Logic logic2;

        private void DrawGraph()
        {
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.CurveList.Clear();

            Random r = new Random();

            var distributionOfSpecialties = logic2.DistributionOfSpecialties();

            foreach (var key in distributionOfSpecialties.Keys)
            {
                pane.AddBar(key, null, new double[] { distributionOfSpecialties[key] }, Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
            }

            pane.BarSettings.MinBarGap = 1.5f;

            Invalidate();
        }
    }
}
