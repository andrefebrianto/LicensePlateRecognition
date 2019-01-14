namespace LicensePlateRecognition
{
    partial class LicensePlateRecognitionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ibImageSource = new Emgu.CV.UI.ImageBox();
            this.processTimeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibImageSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ibImageSource
            // 
            this.ibImageSource.Location = new System.Drawing.Point(274, 71);
            this.ibImageSource.Name = "ibImageSource";
            this.ibImageSource.Size = new System.Drawing.Size(677, 411);
            this.ibImageSource.TabIndex = 2;
            this.ibImageSource.TabStop = false;
            // 
            // processTimeLabel
            // 
            this.processTimeLabel.AutoSize = true;
            this.processTimeLabel.Location = new System.Drawing.Point(300, 46);
            this.processTimeLabel.Name = "processTimeLabel";
            this.processTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.processTimeLabel.TabIndex = 3;
            this.processTimeLabel.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 469);
            this.panel1.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(721, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(293, 14);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(422, 20);
            this.tbPath.TabIndex = 6;
            this.tbPath.Click += new System.EventHandler(this.tbPath_Click);
            // 
            // LicensePlateRecognitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 493);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.processTimeLabel);
            this.Controls.Add(this.ibImageSource);
            this.Name = "LicensePlateRecognitionForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ibImageSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox ibImageSource;
        private System.Windows.Forms.Label processTimeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbPath;
    }
}

