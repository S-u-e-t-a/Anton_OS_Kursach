using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Approximation;

namespace MonitoringSystem
{
    class CreateGraphs
    {
        Chart concentration;
        Chart deviantion;

        List<double> xCoord;
        List<double> yConcCoord;
        List<double> yDevCoord;

        GroupBox gr;

        public CreateGraphs(List<double> x, List<double> y1, List<double> y2, Chart c, Chart d, GroupBox groupBox)
        {
            concentration = c;
            deviantion = d;
            xCoord = x;
            yConcCoord = y1;
            yDevCoord = y2;
            gr = groupBox;
        }

        async public void MakeUsualGraph()
        {
            gr.Enabled = false;
            concentration.Series["Graph"].Points.Clear();
            deviantion.Series["Graph"].Points.Clear();

            for (int i = 0; i < xCoord.Count; i++)
            {
                concentration.Series["Graph"].Points.AddXY(xCoord[i], yConcCoord[i]);
                deviantion.Series["Graph"].Points.AddXY(xCoord[i], yDevCoord[i]);
                await Task.Delay(50);
            }
            gr.Enabled = true;
        }

        void SetupBorders(List<double> x, List<double> y1, List<double> y2)
        {
            concentration.ChartAreas[0].AxisX.Minimum = x.Min();
            concentration.ChartAreas[0].AxisX.Maximum = x.Max() + 1;
            concentration.ChartAreas[0].AxisY.Minimum = y1.Min();
            concentration.ChartAreas[0].AxisY.Maximum = y1.Max();
            concentration.ChartAreas[0].AxisY.LabelStyle.Format = String.Format("0.0000000");


            deviantion.ChartAreas[0].AxisX.Minimum = x.Min();
            deviantion.ChartAreas[0].AxisX.Maximum = x.Max() + 1;
            deviantion.ChartAreas[0].AxisY.Minimum = y2.Min();
            deviantion.ChartAreas[0].AxisY.Maximum = y2.Max();
            deviantion.ChartAreas[0].AxisY.LabelStyle.Format = String.Format("0.000");
        }

        async public void MakeLSMGraph(int degree)
        {
            gr.Enabled = false;

            concentration.Series["Graph"].Points.Clear();
            deviantion.Series["Graph"].Points.Clear();

            LSM objCons = new LSM(xCoord, yConcCoord);

            objCons.Polynomial(degree);


            List<double> newYCons = new List<double>();

            for (int i = 0; i < xCoord.Count; i++)
            {
                double num = 0.0;
                for (int j = 0; j < degree; j++)
                {
                    num += objCons.Coeff[degree - j] * Math.Pow(xCoord[i], degree - j);
                }

                newYCons.Add(num);
            }

            var objDev = new LSM(xCoord, yDevCoord);
            objDev.Polynomial(degree);


            List<double> newYDev = new List<double>();

            for (int i = 0; i < xCoord.Count; i++)
            {
                double num = 0.0;
                for (int j = 0; j < degree; j++)
                {
                    num += objDev.Coeff[degree - j] * Math.Pow(xCoord[i], degree - j);
                }

                newYDev.Add(num);

            }
            SetupBorders(xCoord, newYCons, newYDev);

            for (int i = 0; i < xCoord.Count; i++)
            {

                concentration.Series["Graph"].Points.AddXY(xCoord[i], newYCons[i]);

                deviantion.Series["Graph"].Points.AddXY(xCoord[i], newYDev[i]);

                await Task.Delay(50);
            }

            gr.Enabled = true;
        }
    }
}
