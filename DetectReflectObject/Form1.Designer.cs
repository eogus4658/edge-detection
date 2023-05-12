
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
            this.runButton.Location = new System.Drawing.Point(914, 247);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(914, 286);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 12);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 620);
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
    }
}

