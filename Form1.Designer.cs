namespace KR
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
            components = new System.ComponentModel.Container();
            imageBoxOriginal = new Emgu.CV.UI.ImageBox();
            imageBoxResult = new Emgu.CV.UI.ImageBox();
            loadImageButton = new Button();
            brightnessSlider = new TrackBar();
            contrastSlider = new TrackBar();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            radiusBlur = new TrackBar();
            comboBox1 = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)imageBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageBoxResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contrastSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radiusBlur).BeginInit();
            SuspendLayout();
            // 
            // imageBoxOriginal
            // 
            imageBoxOriginal.Location = new Point(13, 47);
            imageBoxOriginal.Name = "imageBoxOriginal";
            imageBoxOriginal.Size = new Size(304, 305);
            imageBoxOriginal.TabIndex = 2;
            imageBoxOriginal.TabStop = false;
            // 
            // imageBoxResult
            // 
            imageBoxResult.Location = new Point(339, 47);
            imageBoxResult.Name = "imageBoxResult";
            imageBoxResult.Size = new Size(304, 305);
            imageBoxResult.TabIndex = 2;
            imageBoxResult.TabStop = false;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(13, 16);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(163, 25);
            loadImageButton.TabIndex = 4;
            loadImageButton.Text = "Загрузить изображение";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += loadImageButton_Click;
            // 
            // brightnessSlider
            // 
            brightnessSlider.Location = new Point(730, 60);
            brightnessSlider.Maximum = 20;
            brightnessSlider.Name = "brightnessSlider";
            brightnessSlider.Size = new Size(171, 45);
            brightnessSlider.TabIndex = 9;
            brightnessSlider.Scroll += brightnessSlider_Scroll;
            // 
            // contrastSlider
            // 
            contrastSlider.Location = new Point(730, 115);
            contrastSlider.Maximum = 20;
            contrastSlider.Name = "contrastSlider";
            contrastSlider.Size = new Size(171, 45);
            contrastSlider.TabIndex = 11;
            contrastSlider.Value = 10;
            contrastSlider.Scroll += contrastSlider_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(664, 60);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 8;
            label3.Text = "Яркость:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(664, 115);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 10;
            label4.Text = "Контраст:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(730, 163);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 3;
            label1.Text = "Радиус размытия:";
            // 
            // radiusBlur
            // 
            radiusBlur.Location = new Point(695, 181);
            radiusBlur.Maximum = 20;
            radiusBlur.Name = "radiusBlur";
            radiusBlur.Size = new Size(167, 45);
            radiusBlur.TabIndex = 9;
            radiusBlur.Scroll += radiusBlur_Scroll;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(695, 257);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 23);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(755, 239);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 13;
            label2.Text = "Маски:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 369);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(contrastSlider);
            Controls.Add(imageBoxOriginal);
            Controls.Add(label4);
            Controls.Add(imageBoxResult);
            Controls.Add(brightnessSlider);
            Controls.Add(label3);
            Controls.Add(loadImageButton);
            Controls.Add(radiusBlur);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)imageBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageBoxResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)contrastSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)radiusBlur).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private Emgu.CV.UI.ImageBox imageBoxResult;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar brightnessSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar contrastSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar radiusBlur;
        private ComboBox comboBox1;
        private Label label2;
    }
}
