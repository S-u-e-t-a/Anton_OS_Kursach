using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonitoringSystem
{
    public partial class MainWindow : Form
    {
        List<double> xCoord;
        List<double> yConcCoord;
        List<double> yDevCoord;
        public MainWindow()
        {
            InitializeComponent();
            MaximizeBox = false;
            chartConcentration.Series["Graph"].Points.AddXY(0, 0);
            chartConcentration.ChartAreas[0].AxisX.Minimum = 0;
            chartConcentration.ChartAreas[0].AxisX.Maximum = 100;
            chartConcentration.ChartAreas[0].AxisY.Minimum = 0;
            chartConcentration.ChartAreas[0].AxisY.Maximum = 100;


            chartDeviation.Series["Graph"].Points.AddXY(0, 0);
            chartDeviation.ChartAreas[0].AxisX.Minimum = 0;
            chartDeviation.ChartAreas[0].AxisX.Maximum = 100;
            chartDeviation.ChartAreas[0].AxisY.Minimum = 0;
            chartDeviation.ChartAreas[0].AxisY.Maximum = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            axWindowsMediaPlayer.URL = @"C:\Users\anton\Desktop\OS\MonitoringSystem\MonitoringSystem\video\stock.mp4";
            axWindowsMediaPlayer.Ctlcontrols.play();
            
        }

        private void InputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string fileInputPath = openFileDialog.FileName;
            WorkWithFiles workWithFiles = new WorkWithFiles();
            workWithFiles.InputFromFile(fileInputPath);
            openFileDialog.FileName = string.Empty;
            xCoord = workWithFiles.xCoord;
            yConcCoord = workWithFiles.y1Coord;
            yDevCoord = workWithFiles.y2Coord;

            if (xCoord.Count == yConcCoord.Count && xCoord.Count == yDevCoord.Count)
            {
                FillingTable();
                SetupGraphs();
            }
            else
            {
                MessageBox.Show("Указанный Вами файл содержит разное количество значений Х и Y. Проверьте правильность указанных в файле данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            

        }

        private void FillingTable()
        {
            GraphDataGrid.Columns.Add("x", "Расход, кг/сек");
            GraphDataGrid.Columns.Add("y1", "Концентрация, Кмоль/м^3");
            GraphDataGrid.Columns.Add("y2", "Отклонение уровня, мм");

            for (int i = 0; i < xCoord.Count ; i++)
            {
                GraphDataGrid.Rows.Add(xCoord[i], yConcCoord[i], yDevCoord[i]);
            }
        }

        private void SetupGraphs()
        {
            chartConcentration.ChartAreas[0].AxisX.Minimum = xCoord.Min();
            chartConcentration.ChartAreas[0].AxisX.Maximum = xCoord.Max() + 1;
            chartConcentration.ChartAreas[0].AxisY.Minimum = yConcCoord.Min();
            chartConcentration.ChartAreas[0].AxisY.Maximum = yConcCoord.Max();


            chartDeviation.ChartAreas[0].AxisX.Minimum = xCoord.Min();
            chartDeviation.ChartAreas[0].AxisX.Maximum = xCoord.Max() + 1;
            chartDeviation.ChartAreas[0].AxisY.Minimum = yDevCoord.Min();
            chartDeviation.ChartAreas[0].AxisY.Maximum = yDevCoord.Max();
        }

        private void MakeGraphButton_Click(object sender, EventArgs e)
        {
            var obj = new CreateGraphs(xCoord, yConcCoord, yDevCoord, chartConcentration, chartDeviation);
            if (radioButtonEmpty.Checked)
            {
                obj.MakeUsualGraph();
            }
            if (radioButtonLagrange.Checked)
            {
                obj.MakeLagrangeGraph();
            }
        }
    }
}
