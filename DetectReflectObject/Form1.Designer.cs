
namespace DetectReflectObject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.grayButton = new System.Windows.Forms.Button();
            this.binaryButton = new System.Windows.Forms.Button();
            this.cannyButton = new System.Windows.Forms.Button();
            this.contourLabel = new System.Windows.Forms.Label();
            this.detectContourButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.binaryThreshLabel = new System.Windows.Forms.Label();
            this.canny1Label = new System.Windows.Forms.Label();
            this.canny2Label = new System.Windows.Forms.Label();
            this.lengthNoiseLabel = new System.Windows.Forms.Label();
            this.approxrateLabel = new System.Windows.Forms.Label();
            this.binaryTB = new System.Windows.Forms.TextBox();
            this.canny1TB = new System.Windows.Forms.TextBox();
            this.canny2TB = new System.Windows.Forms.TextBox();
            this.noiselenTB = new System.Windows.Forms.TextBox();
            this.approxRateTB = new System.Windows.Forms.TextBox();
            this.gaussianCheck = new System.Windows.Forms.CheckBox();
            this.gaussianTB = new System.Windows.Forms.TextBox();
            this.batchRunButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(59, 39);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(809, 545);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(914, 39);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load...";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // grayButton
            // 
            this.grayButton.Location = new System.Drawing.Point(914, 69);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(75, 23);
            this.grayButton.TabIndex = 2;
            this.grayButton.Text = "gray scale";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // binaryButton
            // 
            this.binaryButton.Location = new System.Drawing.Point(914, 98);
            this.binaryButton.Name = "binaryButton";
            this.binaryButton.Size = new System.Drawing.Size(89, 23);
            this.binaryButton.TabIndex = 3;
            this.binaryButton.Text = "binary scale";
            this.binaryButton.UseVisualStyleBackColor = true;
            this.binaryButton.Click += new System.EventHandler(this.binaryButton_Click);
            // 
            // cannyButton
            // 
            this.cannyButton.Location = new System.Drawing.Point(914, 128);
            this.cannyButton.Name = "cannyButton";
            this.cannyButton.Size = new System.Drawing.Size(89, 23);
            this.cannyButton.TabIndex = 4;
            this.cannyButton.Text = "canny edge";
            this.cannyButton.UseVisualStyleBackColor = true;
            this.cannyButton.Click += new System.EventHandler(this.cannyButton_Click);
            // 
            // contourLabel
            // 
            this.contourLabel.AutoSize = true;
            this.contourLabel.Location = new System.Drawing.Point(874, 211);
            this.contourLabel.Name = "contourLabel";
            this.contourLabel.Size = new System.Drawing.Size(100, 12);
            this.contourLabel.TabIndex = 5;
            this.contourLabel.Text = "contourCount = 0";
            // 
            // detectContourButton
            // 
            this.detectContourButton.Location = new System.Drawing.Point(914, 158);
            this.detectContourButton.Name = "detectContourButton";
            this.detectContourButton.Size = new System.Drawing.Size(96, 23);
            this.detectContourButton.TabIndex = 6;
            this.detectContourButton.Text = "detect contour";
            this.detectContourButton.UseVisualStyleBackColor = true;
            this.detectContourButton.Click += new System.EventHandler(this.detectContourButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(914, 475);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "test";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(885, 514);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 12);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "ready";
            // 
            // binaryThreshLabel
            // 
            this.binaryThreshLabel.AutoSize = true;
            this.binaryThreshLabel.Location = new System.Drawing.Point(875, 340);
            this.binaryThreshLabel.Name = "binaryThreshLabel";
            this.binaryThreshLabel.Size = new System.Drawing.Size(40, 12);
            this.binaryThreshLabel.TabIndex = 9;
            this.binaryThreshLabel.Text = "binary";
            // 
            // canny1Label
            // 
            this.canny1Label.AutoSize = true;
            this.canny1Label.Location = new System.Drawing.Point(875, 365);
            this.canny1Label.Name = "canny1Label";
            this.canny1Label.Size = new System.Drawing.Size(46, 12);
            this.canny1Label.TabIndex = 10;
            this.canny1Label.Text = "canny1";
            // 
            // canny2Label
            // 
            this.canny2Label.AutoSize = true;
            this.canny2Label.Location = new System.Drawing.Point(875, 392);
            this.canny2Label.Name = "canny2Label";
            this.canny2Label.Size = new System.Drawing.Size(46, 12);
            this.canny2Label.TabIndex = 11;
            this.canny2Label.Text = "canny2";
            // 
            // lengthNoiseLabel
            // 
            this.lengthNoiseLabel.AutoSize = true;
            this.lengthNoiseLabel.Location = new System.Drawing.Point(875, 418);
            this.lengthNoiseLabel.Name = "lengthNoiseLabel";
            this.lengthNoiseLabel.Size = new System.Drawing.Size(57, 12);
            this.lengthNoiseLabel.TabIndex = 12;
            this.lengthNoiseLabel.Text = "noise len";
            // 
            // approxrateLabel
            // 
            this.approxrateLabel.AutoSize = true;
            this.approxrateLabel.Location = new System.Drawing.Point(875, 440);
            this.approxrateLabel.Name = "approxrateLabel";
            this.approxrateLabel.Size = new System.Drawing.Size(65, 12);
            this.approxrateLabel.TabIndex = 13;
            this.approxrateLabel.Text = "approxrate";
            // 
            // binaryTB
            // 
            this.binaryTB.Location = new System.Drawing.Point(976, 331);
            this.binaryTB.Name = "binaryTB";
            this.binaryTB.Size = new System.Drawing.Size(53, 21);
            this.binaryTB.TabIndex = 14;
            // 
            // canny1TB
            // 
            this.canny1TB.Location = new System.Drawing.Point(976, 358);
            this.canny1TB.Name = "canny1TB";
            this.canny1TB.Size = new System.Drawing.Size(53, 21);
            this.canny1TB.TabIndex = 15;
            // 
            // canny2TB
            // 
            this.canny2TB.Location = new System.Drawing.Point(976, 385);
            this.canny2TB.Name = "canny2TB";
            this.canny2TB.Size = new System.Drawing.Size(53, 21);
            this.canny2TB.TabIndex = 16;
            // 
            // noiselenTB
            // 
            this.noiselenTB.Location = new System.Drawing.Point(976, 412);
            this.noiselenTB.Name = "noiselenTB";
            this.noiselenTB.Size = new System.Drawing.Size(53, 21);
            this.noiselenTB.TabIndex = 17;
            // 
            // approxRateTB
            // 
            this.approxRateTB.Location = new System.Drawing.Point(976, 439);
            this.approxRateTB.Name = "approxRateTB";
            this.approxRateTB.Size = new System.Drawing.Size(53, 21);
            this.approxRateTB.TabIndex = 18;
            // 
            // gaussianCheck
            // 
            this.gaussianCheck.AutoSize = true;
            this.gaussianCheck.Location = new System.Drawing.Point(876, 309);
            this.gaussianCheck.Name = "gaussianCheck";
            this.gaussianCheck.Size = new System.Drawing.Size(104, 16);
            this.gaussianCheck.TabIndex = 19;
            this.gaussianCheck.Text = "Gaussian Blur";
            this.gaussianCheck.UseVisualStyleBackColor = true;
            // 
            // gaussianTB
            // 
            this.gaussianTB.Location = new System.Drawing.Point(986, 304);
            this.gaussianTB.Name = "gaussianTB";
            this.gaussianTB.Size = new System.Drawing.Size(53, 21);
            this.gaussianTB.TabIndex = 20;
            // 
            // batchRunButton
            // 
            this.batchRunButton.Location = new System.Drawing.Point(887, 560);
            this.batchRunButton.Name = "batchRunButton";
            this.batchRunButton.Size = new System.Drawing.Size(75, 23);
            this.batchRunButton.TabIndex = 21;
            this.batchRunButton.Text = "Run Batch";
            this.batchRunButton.UseVisualStyleBackColor = true;
            this.batchRunButton.Click += new System.EventHandler(this.batchRunButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 620);
            this.Controls.Add(this.batchRunButton);
            this.Controls.Add(this.gaussianTB);
            this.Controls.Add(this.gaussianCheck);
            this.Controls.Add(this.approxRateTB);
            this.Controls.Add(this.noiselenTB);
            this.Controls.Add(this.canny2TB);
            this.Controls.Add(this.canny1TB);
            this.Controls.Add(this.binaryTB);
            this.Controls.Add(this.approxrateLabel);
            this.Controls.Add(this.lengthNoiseLabel);
            this.Controls.Add(this.canny2Label);
            this.Controls.Add(this.canny1Label);
            this.Controls.Add(this.binaryThreshLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.detectContourButton);
            this.Controls.Add(this.contourLabel);
            this.Controls.Add(this.cannyButton);
            this.Controls.Add(this.binaryButton);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Button binaryButton;
        private System.Windows.Forms.Button cannyButton;
        private System.Windows.Forms.Label contourLabel;
        private System.Windows.Forms.Button detectContourButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label binaryThreshLabel;
        private System.Windows.Forms.Label canny1Label;
        private System.Windows.Forms.Label canny2Label;
        private System.Windows.Forms.Label lengthNoiseLabel;
        private System.Windows.Forms.Label approxrateLabel;
        private System.Windows.Forms.TextBox binaryTB;
        private System.Windows.Forms.TextBox canny1TB;
        private System.Windows.Forms.TextBox canny2TB;
        private System.Windows.Forms.TextBox noiselenTB;
        private System.Windows.Forms.TextBox approxRateTB;
        private System.Windows.Forms.CheckBox gaussianCheck;
        private System.Windows.Forms.TextBox gaussianTB;
        private System.Windows.Forms.Button batchRunButton;
    }
}

