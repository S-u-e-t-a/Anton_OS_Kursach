using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringSystem
{
    class WorkWithFiles
    {
        public List<double> xCoord = new List<double>();
        public List<double> y1Coord = new List<double>(); 
        public List<double> y2Coord = new List<double>();

        public void InputFromFile(string path)
        {
            string[] separator = { " " };
            string arr;

            try
            {
                arr = System.IO.File.ReadAllLines(path).Skip(0).First();
                xCoord = arr.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToList();

                arr = System.IO.File.ReadAllLines(path).Skip(1).First();
                y1Coord = arr.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToList();

                arr = System.IO.File.ReadAllLines(path).Skip(2).First();
                y2Coord = arr.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToList();
                
                if(xCoord.Count < 5 || y1Coord.Count < 5 || y2Coord.Count < 5)
                {
                    throw new CountParametrException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Указанный Вами файл содержит символы, отличные от чисел и знака запятой. Проверьте правильность указанных в файле данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Указанный Вами файл содержит недостаточно данных. Проверьте правильность указанных в файле данных", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CountParametrException)
            {
                MessageBox.Show("Количество элементов в каждой строке должно быть более 5. Проверьте правильность указанных в файле данных", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public class CountParametrException : ApplicationException
        {
            public CountParametrException() : base() { }
        }
    }
}