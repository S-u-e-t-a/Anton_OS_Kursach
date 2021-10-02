using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        #region Поля
        List<double> xCoord;
        List<double> yConcCoord;
        List<double> yDevCoord;

        double oldValueCell;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            MaximizeBox = false;
            openFileDialogText.Filter = "Текстовые документы (*.txt)|*.txt";
            openFileDialogVideo.Filter = "Видеофайлы (*.mp4, *.wav, *.wmp)|*.mp4;*.wav;*.wmp";



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
            axWindowsMediaPlayer.URL = @"stock.mp4";
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private void InputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogText.ShowDialog() == DialogResult.Cancel)
                return;
            string fileInputPath = openFileDialogText.FileName;
            WorkWithFiles workWithFiles = new WorkWithFiles();
            workWithFiles.InputFromFile(fileInputPath);
            openFileDialogText.FileName = string.Empty;
            xCoord = workWithFiles.xCoord;
            yConcCoord = workWithFiles.y1Coord;
            yDevCoord = workWithFiles.y2Coord;

            if (xCoord.Count == yConcCoord.Count && xCoord.Count == yDevCoord.Count)
            {
                FillingTable();
            }
            else
            {
                MessageBox.Show("Указанный Вами файл содержит разное количество значений Х и Y. Проверьте правильность указанных в файле данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            groupBoxCreateGraph.Enabled = true;
        }

        private void FillingTable()
        {
            GraphDataGrid.Columns.Clear();

            GraphDataGrid.Columns.Add("x", "Расход, кг/сек");
            GraphDataGrid.Columns.Add("y1", "Концентрация, Кмоль/м^3");
            GraphDataGrid.Columns.Add("y2", "Отклонение уровня, мм");

            for (int i = 0; i < xCoord.Count; i++)
            {
                GraphDataGrid.Rows.Add(xCoord[i], yConcCoord[i], yDevCoord[i]);
            }

            GraphDataGrid.Columns["x"].ReadOnly = true;
        }

        private void SetupGraphs()
        {
            chartConcentration.ChartAreas[0].AxisX.Minimum = xCoord.Min();
            chartConcentration.ChartAreas[0].AxisX.Maximum = xCoord.Max() + 1;
            chartConcentration.ChartAreas[0].AxisY.Minimum = yConcCoord.Min();
            chartConcentration.ChartAreas[0].AxisY.Maximum = yConcCoord.Max();
            chartConcentration.ChartAreas[0].AxisY.LabelStyle.Format = String.Format("0.0000000");


            chartDeviation.ChartAreas[0].AxisX.Minimum = xCoord.Min();
            chartDeviation.ChartAreas[0].AxisX.Maximum = xCoord.Max() + 1;
            chartDeviation.ChartAreas[0].AxisY.Minimum = yDevCoord.Min();
            chartDeviation.ChartAreas[0].AxisY.Maximum = yDevCoord.Max();
            chartDeviation.ChartAreas[0].AxisY.LabelStyle.Format = String.Format("0.000");
        }

        private void MakeGraphButton_Click(object sender, EventArgs e)
        {
            var obj = new CreateGraphs(xCoord, yConcCoord, yDevCoord, chartConcentration, chartDeviation, groupBoxCreateGraph);
            if (radioButtonEmpty.Checked)
            {
                SetupGraphs();
                obj.MakeUsualGraph();
            }
            if (radioButtonLagrange.Checked)
            {
                obj.MakeLSMGraph(Convert.ToInt32(degreeUpDown.Value));
            }
        }

        private void degreeUpDown_ValueChanged(object sender, EventArgs e)
        {
            var obj = new CreateGraphs(xCoord, yConcCoord, yDevCoord, chartConcentration, chartDeviation, groupBoxCreateGraph);
            obj.MakeLSMGraph(Convert.ToInt32(degreeUpDown.Value));
        }

        private void GraphDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldValueCell = double.Parse(GraphDataGrid.CurrentCell.Value.ToString());
        }

        private void GraphDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string s = GraphDataGrid.CurrentCell.Value.ToString();
            double newValue;
            try
            {
                newValue = double.Parse(s);
            }
            catch (FormatException)
            {
                GraphDataGrid.CurrentCell.Value = oldValueCell;
                MessageBox.Show("Вы ввели некорректное значение. Допустим ввод только чисел и запятой.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(GraphDataGrid.CurrentCell.OwningColumn.Name == "y1")
            {
                yConcCoord[GraphDataGrid.CurrentCell.RowIndex] = newValue;
            }
            else if(GraphDataGrid.CurrentCell.OwningColumn.Name == "y2")
            {
                yDevCoord[GraphDataGrid.CurrentCell.RowIndex] = newValue;
            }

            SetupGraphs();
            MakeGraphButton_Click(null, null);
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("HelpOS.chm");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void buttonOpenVideo_Click(object sender, EventArgs e)
        {
            if (openFileDialogVideo.ShowDialog() == DialogResult.Cancel)
                return;
            string fileInputPath = openFileDialogVideo.FileName;
            axWindowsMediaPlayer.URL = fileInputPath;
        }
    }
}
