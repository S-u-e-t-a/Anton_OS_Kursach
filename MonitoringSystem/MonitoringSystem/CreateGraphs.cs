using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void MakeLagrangeGraph()
        {
            var obj = new Interpolation();

            var temp = obj.Calc_Lagrange(xCoord, yConcCoord);


            concentration.Series["Graph"].Points.Clear();
            for (int i = 0; i < temp.lagrangeX.Count; i++)
            {
                concentration.Series["Graph"].Points.AddXY(temp.lagrangeX[i], temp.lagrangeY[i]);
            }


        }
    }
}
