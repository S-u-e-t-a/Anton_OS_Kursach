using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitoringSystem
{
    class DrawGraph
    {
        #region исходные данные
        public List<int> consumption = new List<int>();
        public List<double> concentration = new List<double> { 0.00379, 0.00268, 0.0002989, 0.001, 0.0012, 0.088, 0.226, 0.475, 0.875, 1.421, 2.111, 2.875, 3.731, 4.564, 5.299, 5.855, 6.154, 6.158, 5.844, 5.236, 4.801, 4.227, 3.774, 3.539, 3.327 };
        public List<double> deviation = new List<double> { 2.248, 5.966, 12.025, 20.042, 28.614, 35.421, 37.450, 31.500, 14.841, -14.082, -55.088, -105.078, -161.787, -216.663, -263.094, -293.732, -302.452, -285.542, -242.640, -177.237, -96.604, -60.723, -44.623, -25.078, -15.078 };
        #endregion

        //Основные объекты для рисования
        private Bitmap _bmp = null;
        private Graphics _graph = null;
        private Font _objFont = new Font("Arial", 8, FontStyle.Bold);
        private Brush _objBrush = Brushes.Black;
        private Pen _objPenLine = new Pen(Color.Black, 1);
        //Размеры холста
        private int _wight = 200;
        private int _height = 100;
        //Отступы
        private int _deltaAxisL = 50;
        private int _deltaAxisR = 50;
        private int _deltaAxisH = 20;

        #region Конструкторы
        public DrawGraph()
        {

        }
        public DrawGraph(int a, int b)
        {
            _bmp = new Bitmap(a, b);
            //Создаем объект Graphics на основе битовой матрицы 
            _graph = Graphics.FromImage(_bmp);
            //Запоминаем размеры холста
            _wight = a;
            _height = b;
        }
        #endregion

        #region Установка цвет фона диаграммы 
        public void vSetBackground(Color bcl)
        {
            _graph.Clear(bcl);
        }
        #endregion

        #region Доступ к переменным класса
        public Bitmap Bmp
        {
            get { return _bmp; }
        }
        #endregion

        #region Рисование Осей
        //Параметры вызоыва: отступы слева - deltaaxisL, справа - deltaaxisR, 
        //сверху(снизу) - deltaaxisH, Цвет осей - colorpenaxis, толщина пера - widthpen, 
        //нужны ли стрелки - fArrow (true - да)
        public void vDravAxis(int deltaaxisL, int deltaaxisR,
                     int deltaaxisH, Color colorpenaxis, int widthpen)
        {
            //Запоминаем отступы                        
            _deltaAxisL = deltaaxisL;
            _deltaAxisR = deltaaxisR;
            _deltaAxisH = deltaaxisH;
            //Запоминаем цвет осей и толщину
            vSetPenColorLine(colorpenaxis);
            if (widthpen > 0) vSetPenWidthLine(widthpen);
            //Точка начала рисования по х и y           
            int x = deltaaxisL;
            int y = _height - deltaaxisH;
            int x1 = _wight - deltaaxisR;
            int y1 = deltaaxisH;
            //Оси на d пикселей длинней для стрелок
            _graph.DrawLine(_objPenLine, x, _height/2, x1, _height/2);
            _graph.DrawLine(_objPenLine, x, y, x, y1);
            _graph.DrawLine(_objPenLine, x1 + 1, y, x1 + 1, y1);
            //Надо рисовать стрелки
            
        }
        #endregion

        #region Карандаш, шрифт, кисть
        //Цвет карандаша
        public void vSetPenColorLine(Color pcl)
        {
            if (_objPenLine == null)
            {
                _objPenLine = new Pen(Color.Black, 1);
            }
            _objPenLine.Color = pcl;
        }
        //Установка толщина карандаша        
        public void vSetPenWidthLine(int penwidth)
        {
            if (_objPenLine == null)
            {
                _objPenLine = new Pen(Color.Black, 1);
            }
            _objPenLine.Width = penwidth;
        }
        #endregion


        //Максимальный размер массива
        private int _maxRg = 20;

        public int MaxRg
        {
            set { _maxRg = value; }
        }

        #region Рисование сетки
        public void vDravGrid()
        {
            for (int i = 0; i < 25; i++)
            {
                consumption.Add(i);
            }

            float x = _deltaAxisL;
            float y = _height - _deltaAxisH;
            float x1 = _wight - _deltaAxisR;
            float y1 = _deltaAxisH;
            //Сдвиг линий сетки на один отсчет по Y
            float f = (y - y1) / _maxRg;
            //Рисуем горизонтальные линии
            for (int i = 1; i < _maxRg + 1; i++)
            {
                _graph.DrawLine(_objPenLine, x, y - f * i, x1, y - f * i);
            }
            //Сдвиг линий сетки на один отсчет по X
            f = (x - x1) / (float)(_maxRg - 1);
            //Рисуем вертикальные линии
            for (int i = 1; i < _maxRg; i++)
            {
                _graph.DrawLine(_objPenLine, x - f * i, y, x - f * i, y1);
            }
        }
        #endregion

        #region Рисование линий графика для линейного графика
        public void vDrawGraphLines()
        {

            float f = 0;
            float x = _deltaAxisL;
            float y = _height - _deltaAxisH;

            float f1 = 0;
            float x1 = 0;
            float x2 = 0;

            //Пикселей для рисования по оси х
            float fDeltaX = _wight - _deltaAxisL - _deltaAxisR;
            //Пикселей на одну единицу массива значения по X
            fDeltaX = fDeltaX / (_maxRg - 1);
            //Пикселей для рисования по оси y
            float fDeltaY = _height - 2 * _deltaAxisH;
            //Пикселей на одну единицу массива значений по Y
            fDeltaY = (float)(fDeltaY / concentration.Max());

            for (int i = 0; i < _maxRg; i++)
            {
                if(i == 0)
                {
                    f = (float)(y - concentration[0] * fDeltaY);
                    x1 = x;
                }
                else
                {
                    f1 = (float)(y - concentration[i] * fDeltaY);
                    x2 = x + (int)fDeltaX * i;
                    _graph.DrawLine(_objPenLine, x1, f, x2, f1);
                    f = f1;
                    x1 = x + (int)(i * fDeltaX);
                }
            }
        }
        #endregion
    }


}
