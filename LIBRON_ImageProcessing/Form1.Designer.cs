using System.Windows.Forms;
using System.Drawing;

namespace LIBRON_ImageProcessing
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            editingPanel = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBoxHistogram = new PictureBox();
            pictureBoxOriginal = new PictureBox();
            pictureBoxProcessed = new PictureBox();
            btnLoad = new Button();
            btnSave = new Button();
            btnCopy = new Button();
            btnReset = new Button();
            btnGray = new Button();
            btnInvert = new Button();
            btnSepia = new Button();
            btnHistogram = new Button();
            btnApplyConvolution = new Button();
            comboBoxFilters = new ComboBox();
            lblConvolution = new Label();
            label1 = new Label();
            label2 = new Label();
            subtractionPanel = new Panel();
            lblSubtractionTitle = new Label();
            btnLoadForeground = new Button();
            btnLoadBackground = new Button();
            btnSubtract = new Button();
            picForeground = new PictureBox();
            picBackground = new PictureBox();
            picSubtractionResult = new PictureBox();
            lblForeground = new Label();
            lblBackground = new Label();
            lblResult = new Label();
            webcamPanel = new Panel();
            lblWebcam = new Label();
            pictureBoxWebcam = new PictureBox();
            lblWebcamProcessed = new Label();
            pictureBoxWebcamProcessed = new PictureBox();
            lblWebcamBackground = new Label();
            pictureBoxWebcamBackground = new PictureBox();
            btnStartWebcam = new Button();
            btnCapture = new Button();
            btnLoadWebcamBackground = new Button();
            btnApplyGreenScreen = new Button();
            chkRealTimeProcessing = new CheckBox();
            lblGreenSensitivity = new Label();
            trackBarGreenSensitivity = new TrackBar();
            mainMenu = new MenuStrip();
            modeMenu = new ToolStripMenuItem();
            editingModeItem = new ToolStripMenuItem();
            subtractionModeItem = new ToolStripMenuItem();
            webcamModeItem = new ToolStripMenuItem();
            editingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHistogram).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).BeginInit();
            subtractionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picForeground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSubtractionResult).BeginInit();
            webcamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamProcessed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreenSensitivity).BeginInit();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // editingPanel
            // 
            editingPanel.Controls.Add(label5);
            editingPanel.Controls.Add(label4);
            editingPanel.Controls.Add(label3);
            editingPanel.Controls.Add(pictureBoxHistogram);
            editingPanel.Controls.Add(pictureBoxOriginal);
            editingPanel.Controls.Add(pictureBoxProcessed);
            editingPanel.Controls.Add(btnLoad);
            editingPanel.Controls.Add(btnSave);
            editingPanel.Controls.Add(btnCopy);
            editingPanel.Controls.Add(btnReset);
            editingPanel.Controls.Add(btnGray);
            editingPanel.Controls.Add(btnInvert);
            editingPanel.Controls.Add(btnSepia);
            editingPanel.Controls.Add(btnHistogram);
            editingPanel.Controls.Add(btnApplyConvolution);
            editingPanel.Controls.Add(comboBoxFilters);
            editingPanel.Controls.Add(lblConvolution);
            editingPanel.Controls.Add(label1);
            editingPanel.Controls.Add(label2);
            editingPanel.Location = new Point(0, 30);
            editingPanel.Name = "editingPanel";
            editingPanel.Size = new Size(780, 797);
            editingPanel.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(521, 7);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 23;
            label5.Text = "Processed Image";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 7);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 22;
            label4.Text = "Original Image";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 527);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 21;
            label3.Text = "Histogram";
            // 
            // pictureBoxHistogram
            // 
            pictureBoxHistogram.BackColor = Color.White;
            pictureBoxHistogram.Location = new Point(30, 550);
            pictureBoxHistogram.Name = "pictureBoxHistogram";
            pictureBoxHistogram.Size = new Size(730, 150);
            pictureBoxHistogram.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHistogram.TabIndex = 18;
            pictureBoxHistogram.TabStop = false;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.BackColor = Color.LightGray;
            pictureBoxOriginal.Location = new Point(20, 20);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(350, 300);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 5;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxProcessed
            // 
            pictureBoxProcessed.BackColor = Color.LightGray;
            pictureBoxProcessed.Location = new Point(400, 20);
            pictureBoxProcessed.Name = "pictureBoxProcessed";
            pictureBoxProcessed.Size = new Size(350, 300);
            pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProcessed.TabIndex = 6;
            pictureBoxProcessed.TabStop = false;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(255, 224, 192);
            btnLoad.Location = new Point(35, 388);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 30);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load Image";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.PaleGoldenrod;
            btnSave.Location = new Point(165, 388);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Image";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.MistyRose;
            btnCopy.Location = new Point(295, 388);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(120, 30);
            btnCopy.TabIndex = 9;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(192, 255, 192);
            btnReset.Location = new Point(425, 388);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(120, 30);
            btnReset.TabIndex = 10;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnGray
            // 
            btnGray.Location = new Point(35, 424);
            btnGray.Name = "btnGray";
            btnGray.Size = new Size(120, 30);
            btnGray.TabIndex = 11;
            btnGray.Text = "Grayscale";
            // 
            // btnInvert
            // 
            btnInvert.Location = new Point(165, 424);
            btnInvert.Name = "btnInvert";
            btnInvert.Size = new Size(120, 30);
            btnInvert.TabIndex = 12;
            btnInvert.Text = "Invert";
            // 
            // btnSepia
            // 
            btnSepia.Location = new Point(295, 424);
            btnSepia.Name = "btnSepia";
            btnSepia.Size = new Size(120, 30);
            btnSepia.TabIndex = 13;
            btnSepia.Text = "Sepia";
            // 
            // btnHistogram
            // 
            btnHistogram.Location = new Point(425, 424);
            btnHistogram.Name = "btnHistogram";
            btnHistogram.Size = new Size(120, 30);
            btnHistogram.TabIndex = 14;
            btnHistogram.Text = "Histogram";
            // 
            // btnApplyConvolution
            // 
            btnApplyConvolution.BackColor = Color.FromArgb(192, 255, 255);
            btnApplyConvolution.Location = new Point(600, 452);
            btnApplyConvolution.Name = "btnApplyConvolution";
            btnApplyConvolution.Size = new Size(150, 30);
            btnApplyConvolution.TabIndex = 15;
            btnApplyConvolution.Text = "Apply Convolution";
            btnApplyConvolution.UseVisualStyleBackColor = false;
            // 
            // comboBoxFilters
            // 
            comboBoxFilters.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilters.Items.AddRange(new object[] { "", "Smooth", "Gaussian", "Sharpen", "Mean Removal", "Emboss" });
            comboBoxFilters.Location = new Point(600, 406);
            comboBoxFilters.Name = "comboBoxFilters";
            comboBoxFilters.Size = new Size(150, 28);
            comboBoxFilters.TabIndex = 16;
            // 
            // lblConvolution
            // 
            lblConvolution.AutoSize = true;
            lblConvolution.Location = new Point(600, 375);
            lblConvolution.Name = "lblConvolution";
            lblConvolution.Size = new Size(136, 20);
            lblConvolution.TabIndex = 17;
            lblConvolution.Text = "Select Convolution:";
            // 
            // label1
            // 
            label1.Location = new Point(162, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 19;
            label1.Text = "Original";
            // 
            // label2
            // 
            label2.Location = new Point(547, 20);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 20;
            label2.Text = "Edited";
            // 
            // subtractionPanel
            // 
            subtractionPanel.Controls.Add(lblSubtractionTitle);
            subtractionPanel.Controls.Add(btnLoadForeground);
            subtractionPanel.Controls.Add(btnLoadBackground);
            subtractionPanel.Controls.Add(btnSubtract);
            subtractionPanel.Controls.Add(picForeground);
            subtractionPanel.Controls.Add(picBackground);
            subtractionPanel.Controls.Add(picSubtractionResult);
            subtractionPanel.Controls.Add(lblForeground);
            subtractionPanel.Controls.Add(lblBackground);
            subtractionPanel.Controls.Add(lblResult);
            subtractionPanel.Location = new Point(0, 27);
            subtractionPanel.Name = "subtractionPanel";
            subtractionPanel.Size = new Size(780, 573);
            subtractionPanel.TabIndex = 1;
            subtractionPanel.Visible = false;
            // 
            // lblSubtractionTitle
            // 
            lblSubtractionTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblSubtractionTitle.Location = new Point(261, 1);
            lblSubtractionTitle.Name = "lblSubtractionTitle";
            lblSubtractionTitle.Size = new Size(100, 23);
            lblSubtractionTitle.TabIndex = 0;
            lblSubtractionTitle.Text = "Image Subtraction Mode";
            // 
            // btnLoadForeground
            // 
            btnLoadForeground.Location = new Point(47, 249);
            btnLoadForeground.Name = "btnLoadForeground";
            btnLoadForeground.Size = new Size(200, 30);
            btnLoadForeground.TabIndex = 1;
            btnLoadForeground.Text = "Load Foreground Image";
            // 
            // btnLoadBackground
            // 
            btnLoadBackground.Location = new Point(512, 249);
            btnLoadBackground.Name = "btnLoadBackground";
            btnLoadBackground.Size = new Size(200, 30);
            btnLoadBackground.TabIndex = 2;
            btnLoadBackground.Text = "Load Background Image";
            // 
            // btnSubtract
            // 
            btnSubtract.Location = new Point(282, 504);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(200, 30);
            btnSubtract.TabIndex = 3;
            btnSubtract.Text = "Subtract Background";
            // 
            // picForeground
            // 
            picForeground.BackColor = Color.LightGray;
            picForeground.BorderStyle = BorderStyle.FixedSingle;
            picForeground.Location = new Point(12, 43);
            picForeground.Name = "picForeground";
            picForeground.Size = new Size(300, 200);
            picForeground.SizeMode = PictureBoxSizeMode.Zoom;
            picForeground.TabIndex = 4;
            picForeground.TabStop = false;
            // 
            // picBackground
            // 
            picBackground.BackColor = Color.LightGray;
            picBackground.BorderStyle = BorderStyle.FixedSingle;
            picBackground.Location = new Point(450, 43);
            picBackground.Name = "picBackground";
            picBackground.Size = new Size(300, 200);
            picBackground.SizeMode = PictureBoxSizeMode.Zoom;
            picBackground.TabIndex = 5;
            picBackground.TabStop = false;
            // 
            // picSubtractionResult
            // 
            picSubtractionResult.BackColor = Color.LightGray;
            picSubtractionResult.BorderStyle = BorderStyle.FixedSingle;
            picSubtractionResult.Location = new Point(230, 298);
            picSubtractionResult.Name = "picSubtractionResult";
            picSubtractionResult.Size = new Size(300, 200);
            picSubtractionResult.SizeMode = PictureBoxSizeMode.Zoom;
            picSubtractionResult.TabIndex = 6;
            picSubtractionResult.TabStop = false;
            // 
            // lblForeground
            // 
            lblForeground.Location = new Point(112, 23);
            lblForeground.Name = "lblForeground";
            lblForeground.Size = new Size(100, 23);
            lblForeground.TabIndex = 7;
            lblForeground.Text = "Foreground";
            // 
            // lblBackground
            // 
            lblBackground.Location = new Point(550, 23);
            lblBackground.Name = "lblBackground";
            lblBackground.Size = new Size(100, 23);
            lblBackground.TabIndex = 8;
            lblBackground.Text = "Background";
            // 
            // lblResult
            // 
            lblResult.Location = new Point(315, 275);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(100, 23);
            lblResult.TabIndex = 9;
            lblResult.Text = "Subtraction Result";
            // 
            // webcamPanel
            // 
            webcamPanel.Controls.Add(lblWebcam);
            webcamPanel.Controls.Add(pictureBoxWebcam);
            webcamPanel.Controls.Add(lblWebcamProcessed);
            webcamPanel.Controls.Add(pictureBoxWebcamProcessed);
            webcamPanel.Controls.Add(lblWebcamBackground);
            webcamPanel.Controls.Add(pictureBoxWebcamBackground);
            webcamPanel.Controls.Add(btnStartWebcam);
            webcamPanel.Controls.Add(btnCapture);
            webcamPanel.Controls.Add(btnLoadWebcamBackground);
            webcamPanel.Controls.Add(btnApplyGreenScreen);
            webcamPanel.Controls.Add(chkRealTimeProcessing);
            webcamPanel.Controls.Add(lblGreenSensitivity);
            webcamPanel.Controls.Add(trackBarGreenSensitivity);
            webcamPanel.Location = new Point(0, 27);
            webcamPanel.Name = "webcamPanel";
            webcamPanel.Size = new Size(780, 573);
            webcamPanel.TabIndex = 2;
            webcamPanel.Visible = false;
            // 
            // lblWebcam
            // 
            lblWebcam.Location = new Point(20, 10);
            lblWebcam.Name = "lblWebcam";
            lblWebcam.Size = new Size(100, 23);
            lblWebcam.TabIndex = 0;
            lblWebcam.Text = "Webcam Feed";
            // 
            // pictureBoxWebcam
            // 
            pictureBoxWebcam.BackColor = Color.Black;
            pictureBoxWebcam.Location = new Point(20, 30);
            pictureBoxWebcam.Name = "pictureBoxWebcam";
            pictureBoxWebcam.Size = new Size(220, 180);
            pictureBoxWebcam.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxWebcam.TabIndex = 1;
            pictureBoxWebcam.TabStop = false;
            // 
            // lblWebcamProcessed
            // 
            lblWebcamProcessed.Location = new Point(280, 10);
            lblWebcamProcessed.Name = "lblWebcamProcessed";
            lblWebcamProcessed.Size = new Size(100, 23);
            lblWebcamProcessed.TabIndex = 2;
            lblWebcamProcessed.Text = "Processed Output";
            // 
            // pictureBoxWebcamProcessed
            // 
            pictureBoxWebcamProcessed.BackColor = Color.LightGray;
            pictureBoxWebcamProcessed.Location = new Point(280, 30);
            pictureBoxWebcamProcessed.Name = "pictureBoxWebcamProcessed";
            pictureBoxWebcamProcessed.Size = new Size(220, 180);
            pictureBoxWebcamProcessed.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxWebcamProcessed.TabIndex = 3;
            pictureBoxWebcamProcessed.TabStop = false;
            // 
            // lblWebcamBackground
            // 
            lblWebcamBackground.Location = new Point(540, 10);
            lblWebcamBackground.Name = "lblWebcamBackground";
            lblWebcamBackground.Size = new Size(100, 23);
            lblWebcamBackground.TabIndex = 4;
            lblWebcamBackground.Text = "Background Image";
            // 
            // pictureBoxWebcamBackground
            // 
            pictureBoxWebcamBackground.BackColor = Color.LightGray;
            pictureBoxWebcamBackground.Location = new Point(540, 30);
            pictureBoxWebcamBackground.Name = "pictureBoxWebcamBackground";
            pictureBoxWebcamBackground.Size = new Size(220, 180);
            pictureBoxWebcamBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxWebcamBackground.TabIndex = 5;
            pictureBoxWebcamBackground.TabStop = false;
            // 
            // btnStartWebcam
            // 
            btnStartWebcam.Location = new Point(20, 230);
            btnStartWebcam.Name = "btnStartWebcam";
            btnStartWebcam.Size = new Size(120, 30);
            btnStartWebcam.TabIndex = 6;
            btnStartWebcam.Text = "Start Webcam";
            // 
            // btnCapture
            // 
            btnCapture.Enabled = false;
            btnCapture.Location = new Point(150, 230);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(120, 30);
            btnCapture.TabIndex = 7;
            btnCapture.Text = "Capture Frame";
            // 
            // btnLoadWebcamBackground
            // 
            btnLoadWebcamBackground.Location = new Point(540, 230);
            btnLoadWebcamBackground.Name = "btnLoadWebcamBackground";
            btnLoadWebcamBackground.Size = new Size(150, 30);
            btnLoadWebcamBackground.TabIndex = 8;
            btnLoadWebcamBackground.Text = "Load Background";
            // 
            // btnApplyGreenScreen
            // 
            btnApplyGreenScreen.Enabled = false;
            btnApplyGreenScreen.Location = new Point(280, 230);
            btnApplyGreenScreen.Name = "btnApplyGreenScreen";
            btnApplyGreenScreen.Size = new Size(120, 30);
            btnApplyGreenScreen.TabIndex = 9;
            btnApplyGreenScreen.Text = "Apply Green Screen";
            // 
            // chkRealTimeProcessing
            // 
            chkRealTimeProcessing.Location = new Point(20, 270);
            chkRealTimeProcessing.Name = "chkRealTimeProcessing";
            chkRealTimeProcessing.Size = new Size(150, 20);
            chkRealTimeProcessing.TabIndex = 10;
            chkRealTimeProcessing.Text = "Real-time Processing";
            // 
            // lblGreenSensitivity
            // 
            lblGreenSensitivity.Location = new Point(20, 330);
            lblGreenSensitivity.Name = "lblGreenSensitivity";
            lblGreenSensitivity.Size = new Size(100, 23);
            lblGreenSensitivity.TabIndex = 11;
            lblGreenSensitivity.Text = "Green Sensitivity: 0";
            // 
            // trackBarGreenSensitivity
            // 
            trackBarGreenSensitivity.Location = new Point(20, 300);
            trackBarGreenSensitivity.Maximum = 50;
            trackBarGreenSensitivity.Minimum = -50;
            trackBarGreenSensitivity.Name = "trackBarGreenSensitivity";
            trackBarGreenSensitivity.Size = new Size(200, 56);
            trackBarGreenSensitivity.TabIndex = 12;
            // 
            // mainMenu
            // 
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { modeMenu });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(782, 33);
            mainMenu.TabIndex = 0;
            // 
            // modeMenu
            // 
            modeMenu.BackColor = Color.FromArgb(255, 255, 128);
            modeMenu.DropDownItems.AddRange(new ToolStripItem[] { editingModeItem, subtractionModeItem, webcamModeItem });
            modeMenu.Font = new Font("Segoe UI", 11F);
            modeMenu.Name = "modeMenu";
            modeMenu.Size = new Size(75, 29);
            modeMenu.Text = "Mode";
            // 
            // editingModeItem
            // 
            editingModeItem.Checked = true;
            editingModeItem.CheckState = CheckState.Checked;
            editingModeItem.Name = "editingModeItem";
            editingModeItem.Size = new Size(214, 26);
            editingModeItem.Text = "Image Editing";
            // 
            // subtractionModeItem
            // 
            subtractionModeItem.Name = "subtractionModeItem";
            subtractionModeItem.Size = new Size(214, 26);
            subtractionModeItem.Text = "Image Subtraction";
            // 
            // webcamModeItem
            // 
            webcamModeItem.Name = "webcamModeItem";
            webcamModeItem.Size = new Size(214, 26);
            webcamModeItem.Text = "Webcam Mode";
            // 
            // Form1
            // 
            ClientSize = new Size(782, 773);
            Controls.Add(editingPanel);
            Controls.Add(subtractionPanel);
            Controls.Add(webcamPanel);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "Form1";
            Text = "LIBRON Digital Image Processing";
            editingPanel.ResumeLayout(false);
            editingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHistogram).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).EndInit();
            subtractionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picForeground).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSubtractionResult).EndInit();
            webcamPanel.ResumeLayout(false);
            webcamPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcam).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamProcessed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreenSensitivity).EndInit();
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        // ====== DECLARATIONS ======
        private MenuStrip mainMenu;
        private ToolStripMenuItem modeMenu;
        private ToolStripMenuItem editingModeItem;
        private ToolStripMenuItem subtractionModeItem;
        private ToolStripMenuItem webcamModeItem;

        // Editing panel
        private Panel editingPanel;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxProcessed;
        private PictureBox pictureBoxHistogram;
        private Button btnLoad;
        private Button btnSave;
        private Button btnCopy;
        private Button btnReset;
        private Button btnGray;
        private Button btnInvert;
        private Button btnSepia;
        private Button btnHistogram;
        private Button btnApplyConvolution;
        private ComboBox comboBoxFilters;
        private Label lblConvolution;
        private Label label1;
        private Label label2;

        // Subtraction panel
        private Panel subtractionPanel;
        private Label lblSubtractionTitle;
        private Button btnLoadForeground;
        private Button btnLoadBackground;
        private Button btnSubtract;
        private PictureBox picForeground;
        private PictureBox picBackground;
        private PictureBox picSubtractionResult;
        private Label lblForeground;
        private Label lblBackground;
        private Label lblResult;

        // Webcam panel
        private Panel webcamPanel;
        private PictureBox pictureBoxWebcam;
        private PictureBox pictureBoxWebcamProcessed;
        private PictureBox pictureBoxWebcamBackground;
        private Button btnStartWebcam;
        private Button btnCapture;
        private Button btnLoadWebcamBackground;
        private Button btnApplyGreenScreen;
        private CheckBox chkRealTimeProcessing;
        private TrackBar trackBarGreenSensitivity;
        private Label lblWebcam;
        private Label lblWebcamProcessed;
        private Label lblWebcamBackground;
        private Label lblGreenSensitivity;
        private Label label3;
        private Label label5;
        private Label label4;
    }
}
