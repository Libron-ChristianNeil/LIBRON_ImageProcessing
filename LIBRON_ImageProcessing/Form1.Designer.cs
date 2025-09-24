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
            components = new System.ComponentModel.Container();

            // ====== Panels ======
            editingPanel = new Panel();
            subtractionPanel = new Panel();
            webcamPanel = new Panel();

            // ====== Menu ======
            mainMenu = new MenuStrip();
            modeMenu = new ToolStripMenuItem();
            editingModeItem = new ToolStripMenuItem();
            subtractionModeItem = new ToolStripMenuItem();
            webcamModeItem = new ToolStripMenuItem();

            // ========== Editing Panel Controls ==========
            pictureBoxOriginal = new PictureBox();
            pictureBoxProcessed = new PictureBox();
            pictureBoxHistogram = new PictureBox();
            btnLoad = new Button();
            btnSave = new Button();
            btnCopy = new Button();
            btnReset = new Button();
            btnGray = new Button();
            btnInvert = new Button();
            btnSepia = new Button();
            btnHistogram = new Button();
            label1 = new Label();
            label2 = new Label();

            // ========== Subtraction Panel Controls ==========
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

            // ========== Webcam Panel Controls ==========
            pictureBoxWebcam = new PictureBox();
            pictureBoxWebcamProcessed = new PictureBox();
            pictureBoxWebcamBackground = new PictureBox();
            btnStartWebcam = new Button();
            btnCapture = new Button();
            btnLoadWebcamBackground = new Button();
            btnApplyGreenScreen = new Button();
            chkRealTimeProcessing = new CheckBox();
            trackBarGreenSensitivity = new TrackBar();
            lblWebcam = new Label();
            lblWebcamProcessed = new Label();
            lblWebcamBackground = new Label();
            lblGreenSensitivity = new Label();

            // ====== MENU ======
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { modeMenu });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(782, 28);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";

            modeMenu.Text = "Mode";
            modeMenu.DropDownItems.AddRange(new ToolStripItem[] { editingModeItem, subtractionModeItem, webcamModeItem });

            editingModeItem.Text = "Image Editing";
            editingModeItem.Checked = true;

            subtractionModeItem.Text = "Image Subtraction";

            webcamModeItem.Text = "Webcam Mode";

            // ====== EDITING PANEL ======
            editingPanel.Location = new Point(0, 27);
            editingPanel.Name = "editingPanel";
            editingPanel.Size = new Size(780, 573);

            // pictureBoxOriginal
            pictureBoxOriginal.BackColor = Color.LightGray;
            pictureBoxOriginal.Location = new Point(20, 20);
            pictureBoxOriginal.Size = new Size(350, 300);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;

            // pictureBoxProcessed
            pictureBoxProcessed.BackColor = Color.LightGray;
            pictureBoxProcessed.Location = new Point(400, 20);
            pictureBoxProcessed.Size = new Size(350, 300);
            pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;

            // Buttons for editing panel
            btnLoad.Location = new Point(64, 340);
            btnLoad.Size = new Size(150, 30);
            btnLoad.Text = "Load Image";

            btnSave.Location = new Point(224, 340);
            btnSave.Size = new Size(150, 30);
            btnSave.Text = "Save Image";

            btnCopy.Location = new Point(380, 340);
            btnCopy.Size = new Size(150, 30);
            btnCopy.Text = "Copy";

            btnReset.Location = new Point(536, 340);
            btnReset.Size = new Size(150, 30);
            btnReset.Text = "Reset to Original";

            btnGray.Location = new Point(64, 376);
            btnGray.Size = new Size(150, 30);
            btnGray.Text = "Grayscale";

            btnInvert.Location = new Point(224, 376);
            btnInvert.Size = new Size(150, 30);
            btnInvert.Text = "Invert";

            btnSepia.Location = new Point(380, 376);
            btnSepia.Size = new Size(150, 30);
            btnSepia.Text = "Sepia";

            btnHistogram.Location = new Point(536, 376);
            btnHistogram.Size = new Size(150, 30);
            btnHistogram.Text = "Histogram";

            pictureBoxHistogram.BackColor = Color.White;
            pictureBoxHistogram.Location = new Point(20, 420);
            pictureBoxHistogram.Size = new Size(730, 150);
            pictureBoxHistogram.SizeMode = PictureBoxSizeMode.StretchImage;

            label1.Text = "Original";
            label1.Location = new Point(162, 20);

            label2.Text = "Edited";
            label2.Location = new Point(547, 20);

            editingPanel.Controls.AddRange(new Control[] {
                pictureBoxOriginal, pictureBoxProcessed, btnLoad, btnSave, btnCopy,
                btnReset, btnGray, btnInvert, btnSepia, btnHistogram, pictureBoxHistogram,
                label1, label2
            });

            // ====== SUBTRACTION PANEL ======
            subtractionPanel.Location = new Point(0, 27);
            subtractionPanel.Size = new Size(780, 573);
            subtractionPanel.Visible = false;

            lblSubtractionTitle.Text = "Image Subtraction Mode";
            lblSubtractionTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblSubtractionTitle.Location = new Point(261, 1);
            lblSubtractionTitle.Size = new Size(261, 1);

            btnLoadForeground.Location = new Point(47, 249);
            btnLoadForeground.Size = new Size(200, 30);
            btnLoadForeground.Text = "Load Foreground Image";

            btnLoadBackground.Location = new Point(512, 249);
            btnLoadBackground.Size = new Size(200, 30);
            btnLoadBackground.Text = "Load Background Image";

            btnSubtract.Location = new Point(282, 504);
            btnSubtract.Size = new Size(200, 30);
            btnSubtract.Text = "Subtract Background";

            picForeground.BackColor = Color.LightGray;
            picForeground.BorderStyle = BorderStyle.FixedSingle;
            picForeground.Location = new Point(12, 43);
            picForeground.Size = new Size(300, 200);
            picForeground.SizeMode = PictureBoxSizeMode.Zoom;

            picBackground.BackColor = Color.LightGray;
            picBackground.BorderStyle = BorderStyle.FixedSingle;
            picBackground.Location = new Point(450, 43);
            picBackground.Size = new Size(300, 200);
            picBackground.SizeMode = PictureBoxSizeMode.Zoom;

            picSubtractionResult.BackColor = Color.LightGray;
            picSubtractionResult.BorderStyle = BorderStyle.FixedSingle;
            picSubtractionResult.Location = new Point(230, 298);
            picSubtractionResult.Size = new Size(300, 200);
            picSubtractionResult.SizeMode = PictureBoxSizeMode.Zoom;

            lblForeground.Text = "Foreground";
            lblForeground.Location = new Point(112, 23);

            lblBackground.Text = "Background";
            lblBackground.Location = new Point(550, 23);

            lblResult.Text = "Subtraction Result";
            lblResult.Location = new Point(315, 275);

            subtractionPanel.Controls.AddRange(new Control[] {
                lblSubtractionTitle, btnLoadForeground, btnLoadBackground, btnSubtract,
                picForeground, picBackground, picSubtractionResult,
                lblForeground, lblBackground, lblResult
            });

            // ====== WEBCAM PANEL ======
            webcamPanel.Location = new Point(0, 27);
            webcamPanel.Size = new Size(780, 573);
            webcamPanel.Visible = false;

            lblWebcam.Text = "Webcam Feed";
            lblWebcam.Location = new Point(20, 10);

            pictureBoxWebcam.BackColor = Color.Black;
            pictureBoxWebcam.Location = new Point(20, 30);
            pictureBoxWebcam.Size = new Size(220, 180);
            pictureBoxWebcam.SizeMode = PictureBoxSizeMode.StretchImage;

            lblWebcamProcessed.Text = "Processed Output";
            lblWebcamProcessed.Location = new Point(280, 10);

            pictureBoxWebcamProcessed.BackColor = Color.LightGray;
            pictureBoxWebcamProcessed.Location = new Point(280, 30);
            pictureBoxWebcamProcessed.Size = new Size(220, 180);
            pictureBoxWebcamProcessed.SizeMode = PictureBoxSizeMode.StretchImage;

            lblWebcamBackground.Text = "Background Image";
            lblWebcamBackground.Location = new Point(540, 10);

            pictureBoxWebcamBackground.BackColor = Color.LightGray;
            pictureBoxWebcamBackground.Location = new Point(540, 30);
            pictureBoxWebcamBackground.Size = new Size(220, 180);
            pictureBoxWebcamBackground.SizeMode = PictureBoxSizeMode.StretchImage;

            btnStartWebcam.Location = new Point(20, 230);
            btnStartWebcam.Size = new Size(120, 30);
            btnStartWebcam.Text = "Start Webcam";

            btnCapture.Location = new Point(150, 230);
            btnCapture.Size = new Size(120, 30);
            btnCapture.Text = "Capture Frame";
            btnCapture.Enabled = false;

            btnLoadWebcamBackground.Location = new Point(540, 230);
            btnLoadWebcamBackground.Size = new Size(150, 30);
            btnLoadWebcamBackground.Text = "Load Background";

            btnApplyGreenScreen.Location = new Point(280, 230);
            btnApplyGreenScreen.Size = new Size(120, 30);
            btnApplyGreenScreen.Text = "Apply Green Screen";
            btnApplyGreenScreen.Enabled = false;

            chkRealTimeProcessing.Location = new Point(20, 270);
            chkRealTimeProcessing.Size = new Size(150, 20);
            chkRealTimeProcessing.Text = "Real-time Processing";

            trackBarGreenSensitivity.Location = new Point(20, 300);
            trackBarGreenSensitivity.Size = new Size(200, 45);
            trackBarGreenSensitivity.Minimum = -50;
            trackBarGreenSensitivity.Maximum = 50;
            trackBarGreenSensitivity.Value = 0;

            lblGreenSensitivity.Text = "Green Sensitivity: 0";
            lblGreenSensitivity.Location = new Point(20, 330);

            webcamPanel.Controls.AddRange(new Control[] {
                lblWebcam, pictureBoxWebcam,
                lblWebcamProcessed, pictureBoxWebcamProcessed,
                lblWebcamBackground, pictureBoxWebcamBackground,
                btnStartWebcam, btnCapture, btnLoadWebcamBackground,
                btnApplyGreenScreen, chkRealTimeProcessing,
                lblGreenSensitivity, trackBarGreenSensitivity
            });

            // ====== FORM CONFIG ======
            this.ClientSize = new Size(782, 600);
            this.Controls.Add(editingPanel);
            this.Controls.Add(subtractionPanel);
            this.Controls.Add(webcamPanel);
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
            this.Text = "LIBRON Digital Image Processing";
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
    }
}
