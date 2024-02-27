namespace pract1bmm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            SuspendLayout();
            // 
            // gMapControl1
            // 
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(-8, -4);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 2;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(1360, 808);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 0D;
            gMapControl1.Load += gMapControl1_Load_1;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Lower;
            textBox1.Location = new Point(120, 840);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 822);
            label1.Name = "label1";
            label1.Size = new Size(226, 15);
            label1.TabIndex = 2;
            label1.Text = "Прямоугольные координаты самолёта:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 822);
            label2.Name = "label2";
            label2.Size = new Size(240, 15);
            label2.TabIndex = 3;
            label2.Text = "Прямоугольные координаты радиомаяка:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 843);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 4;
            label3.Text = "lat:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 872);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 6;
            label4.Text = "lon:";
            // 
            // textBox2
            // 
            textBox2.CharacterCasing = CharacterCasing.Lower;
            textBox2.Location = new Point(120, 869);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.CharacterCasing = CharacterCasing.Lower;
            textBox3.Location = new Point(120, 898);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 901);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 8;
            label5.Text = "heading:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(433, 872);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 12;
            label6.Text = "lon:";
            // 
            // textBox4
            // 
            textBox4.CharacterCasing = CharacterCasing.Lower;
            textBox4.Location = new Point(462, 869);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 11;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(433, 843);
            label7.Name = "label7";
            label7.Size = new Size(23, 15);
            label7.TabIndex = 10;
            label7.Text = "lat:";
            // 
            // textBox5
            // 
            textBox5.CharacterCasing = CharacterCasing.Lower;
            textBox5.Location = new Point(462, 840);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 9;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(971, 822);
            label8.Name = "label8";
            label8.Size = new Size(201, 15);
            label8.TabIndex = 13;
            label8.Text = "Выходные данные модуля расчета:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(971, 898);
            label9.Name = "label9";
            label9.Size = new Size(154, 15);
            label9.TabIndex = 16;
            label9.Text = "Пеленг (азимут) самолета:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(971, 872);
            label10.Name = "label10";
            label10.Size = new Size(180, 15);
            label10.TabIndex = 15;
            label10.Text = "Пеленг (азимут) радиостанции:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(971, 848);
            label11.Name = "label11";
            label11.Size = new Size(172, 15);
            label11.TabIndex = 14;
            label11.Text = "Курсовой угол радиостанции:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 985);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(gMapControl1);
            Name = "Form1";
            Text = "pract1bmm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}