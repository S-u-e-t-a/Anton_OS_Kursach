
namespace MonitoringSystem
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.chartConcentration = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GraphDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDeviation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MakeGraphButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLagrange = new System.Windows.Forms.RadioButton();
            this.radioButtonEmpty = new System.Windows.Forms.RadioButton();
            this.degreeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConcentration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeviation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.degreeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.InfoToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1363, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputDataToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // InputDataToolStripMenuItem
            // 
            this.InputDataToolStripMenuItem.Name = "InputDataToolStripMenuItem";
            this.InputDataToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.InputDataToolStripMenuItem.Text = "Загрузить данные из файла";
            this.InputDataToolStripMenuItem.Click += new System.EventHandler(this.InputDataToolStripMenuItem_Click);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.InfoToolStripMenuItem.Text = "Справка";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutToolStripMenuItem.Text = "О программе";
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(1087, 468);
            this.axWindowsMediaPlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(264, 183);
            this.axWindowsMediaPlayer.TabIndex = 3;
            // 
            // chartConcentration
            // 
            chartArea5.Name = "ChartArea1";
            this.chartConcentration.ChartAreas.Add(chartArea5);
            this.chartConcentration.Location = new System.Drawing.Point(297, 79);
            this.chartConcentration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartConcentration.Name = "chartConcentration";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Graph";
            this.chartConcentration.Series.Add(series5);
            this.chartConcentration.Size = new System.Drawing.Size(784, 267);
            this.chartConcentration.TabIndex = 4;
            this.chartConcentration.Text = "chart1";
            // 
            // GraphDataGrid
            // 
            this.GraphDataGrid.AllowUserToAddRows = false;
            this.GraphDataGrid.AllowUserToDeleteRows = false;
            this.GraphDataGrid.AllowUserToResizeColumns = false;
            this.GraphDataGrid.AllowUserToResizeRows = false;
            this.GraphDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GraphDataGrid.Location = new System.Drawing.Point(13, 57);
            this.GraphDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GraphDataGrid.Name = "GraphDataGrid";
            this.GraphDataGrid.ReadOnly = true;
            this.GraphDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.GraphDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GraphDataGrid.Size = new System.Drawing.Size(278, 594);
            this.GraphDataGrid.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans Cond", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Таблица значений";
            // 
            // chartDeviation
            // 
            chartArea6.Name = "ChartArea1";
            this.chartDeviation.ChartAreas.Add(chartArea6);
            this.chartDeviation.Location = new System.Drawing.Point(297, 384);
            this.chartDeviation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartDeviation.Name = "chartDeviation";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Graph";
            this.chartDeviation.Series.Add(series6);
            this.chartDeviation.Size = new System.Drawing.Size(784, 267);
            this.chartDeviation.TabIndex = 7;
            this.chartDeviation.Text = "chart2";
            // 
            // MakeGraphButton
            // 
            this.MakeGraphButton.Location = new System.Drawing.Point(3, 114);
            this.MakeGraphButton.Name = "MakeGraphButton";
            this.MakeGraphButton.Size = new System.Drawing.Size(255, 30);
            this.MakeGraphButton.TabIndex = 8;
            this.MakeGraphButton.Text = "Построить графики";
            this.MakeGraphButton.UseVisualStyleBackColor = true;
            this.MakeGraphButton.Click += new System.EventHandler(this.MakeGraphButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans Cond", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(297, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Зависимость концентрации от расхода";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans Cond", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(297, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Зависимость отклонения от расхода";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.degreeUpDown);
            this.groupBox1.Controls.Add(this.radioButtonLagrange);
            this.groupBox1.Controls.Add(this.radioButtonEmpty);
            this.groupBox1.Controls.Add(this.MakeGraphButton);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(1087, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 150);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Построение функции";
            // 
            // radioButtonLagrange
            // 
            this.radioButtonLagrange.AutoSize = true;
            this.radioButtonLagrange.Location = new System.Drawing.Point(6, 50);
            this.radioButtonLagrange.Name = "radioButtonLagrange";
            this.radioButtonLagrange.Size = new System.Drawing.Size(188, 21);
            this.radioButtonLagrange.TabIndex = 10;
            this.radioButtonLagrange.TabStop = true;
            this.radioButtonLagrange.Text = "Метод наименьших квадратов\r\n";
            this.radioButtonLagrange.UseVisualStyleBackColor = true;
            // 
            // radioButtonEmpty
            // 
            this.radioButtonEmpty.AutoSize = true;
            this.radioButtonEmpty.Location = new System.Drawing.Point(6, 23);
            this.radioButtonEmpty.Name = "radioButtonEmpty";
            this.radioButtonEmpty.Size = new System.Drawing.Size(130, 21);
            this.radioButtonEmpty.TabIndex = 9;
            this.radioButtonEmpty.TabStop = true;
            this.radioButtonEmpty.Text = "Без аппроксимации";
            this.radioButtonEmpty.UseVisualStyleBackColor = true;
            // 
            // degreeUpDown
            // 
            this.degreeUpDown.Location = new System.Drawing.Point(128, 76);
            this.degreeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.degreeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.degreeUpDown.Name = "degreeUpDown";
            this.degreeUpDown.Size = new System.Drawing.Size(120, 24);
            this.degreeUpDown.TabIndex = 11;
            this.degreeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.degreeUpDown.ValueChanged += new System.EventHandler(this.degreeUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans Cond", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Степень полинома";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 664);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartDeviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GraphDataGrid);
            this.Controls.Add(this.chartConcentration);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Noto Sans Cond", 9F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConcentration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeviation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.degreeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConcentration;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView GraphDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDeviation;
        private System.Windows.Forms.ToolStripMenuItem InputDataToolStripMenuItem;
        private System.Windows.Forms.Button MakeGraphButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLagrange;
        private System.Windows.Forms.RadioButton radioButtonEmpty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown degreeUpDown;
    }
}

