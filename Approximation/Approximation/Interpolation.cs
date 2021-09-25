using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approximation
{
    public class Interpolation
    {
        public List<double> lagrangeX = new List<double>();
        public List<double> lagrangeY = new List<double>();

        public Interpolation()
        {

        }
        public Interpolation(List<double> lagrangeX, List<double> lagrangeY)
        {
            this.lagrangeX = lagrangeX;
            this.lagrangeY = lagrangeY;
        }

        public Interpolation Calc_Lagrange(List<double> x, List<double> y)
        {
           

            //Работа с БАЗИСНЫМ полиномом:
            for (int X = Convert.ToInt32(y.Min()); X <= Convert.ToInt32(y.Max()); X++)
            {
                double Y = 0.0;
                for (int i = 0; i < y.Count; i++)
                {
                    //Вычисляем х для базисного полинома
                    double basis = 1.0;
                    for (int j = 0; j < y.Count; j++)
                        if (j != i)
                            basis *= (X - y[j]) / (y[i] - y[j]);
                    //Вычисляем y
                    Y += basis * y[i];
                }

                //Записываем координаты полученной точки в массив
                lagrangeX.Add(X);
                lagrangeY.Add(Y);
            }
            return new Interpolation(lagrangeX, lagrangeY);
        }
    }
}
