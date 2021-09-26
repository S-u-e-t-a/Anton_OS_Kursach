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

        public CreateGraphs(List<double> x, List<double> y1, List<double> y2, Chart c, Chart d)
        {
            concentration = c;
            deviantion = d;
            xCoord = x;
            yConcCoord = y1;
            yDevCoord = y2;
        }

        public void MakeUsualGraph()
        {
            concentration.Series["Graph"].Points.Clear();
            for (int i = 0; i < xCoord.Count; i++)
            {
                concentration.Series["Graph"].Points.AddXY(xCoord[i], yConcCoord[i]);
            }

            deviantion.Series["Graph"].Points.Clear();
            for (int i = 0; i < xCoord.Count; i++)
            {
                deviantion.Series["Graph"].Points.AddXY(xCoord[i], yDevCoord[i]);
            }
        }

        public void MakeLSMGraph(int degree)
        {
            concentration.Series["Graph"].Points.Clear();

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
            for (int i = 0; i < xCoord.Count; i++)
            {
                concentration.Series["Graph"].Points.AddXY(xCoord[i], newYCons[i]);
            }


            deviantion.Series["Graph"].Points.Clear();

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
            for (int i = 0; i < xCoord.Count; i++)
            {
                deviantion.Series["Graph"].Points.AddXY(xCoord[i], newYDev[i]);
            }

        }
    }
}
