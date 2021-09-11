using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringSystem
{
    public partial class Form1 : Form
    {
        

        private int viNumButton = 0;
        private int viNumInRg = 0; //начальное значение
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer.URL = @"C:\Users\anton\Desktop\OS\MonitoringSystem\MonitoringSystem\video\stock.mp4";
            axWindowsMediaPlayer.Ctlcontrols.play();
        }


        #region создание линейного графика
        private void button1_Click(object sender, EventArgs e)
        {
            viNumButton = 1;
            vCreateLinGr();
        }       
        
        private void vCreateLinGr()
        {
            //Создаем класс и передаем ему размер холста
            DrawGraph clPaint = new DrawGraph(pictureBox.Width, pictureBox.Height);
            //Фон холста
            clPaint.vSetBackground(Color.White);
            //Параметры вызоыва: отступы слева, справа, 
            //сверху(снизу),Цвет осей, толщина пера
            clPaint.vDravAxis(50, 50, 30, Color.Red, 2);
            //Цвет и толщина пера
            clPaint.vSetPenWidthLine(1);
            clPaint.vSetPenColorLine(Color.Silver);
            clPaint.MaxRg = 20;
            //Рисуем сетку
            clPaint.vDravGrid();
            //Цвет и толщина пера
            clPaint.vSetPenWidthLine(2);
            clPaint.vSetPenColorLine(Color.Green);
            //Рисуем линии графика
            clPaint.vDrawGraphLines();
            //Принимаем нарисованное в pictureBox
            pictureBox.Image = clPaint.Bmp;

        }
        #endregion


    }
}
