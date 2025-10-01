using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WebCamLib;

namespace LIBRON_ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap? originalImage;
        private Bitmap processedImage;
        private Bitmap foreground;
        private Bitmap background;
        private Bitmap webcamBackground;

        private Device[] webcamDevices;
        private Device currentDevice;
        private bool isWebcamRunning = false;
        private Bitmap latestWebcamFrame;
        private System.Windows.Forms.Timer webcamTimer;

        public Form1()
        {
            InitializeComponent();
            AttachEventHandlers();
            SwitchToMode("Editing");
            InitializeWebcam();
        }

        private void AttachEventHandlers()
        {
            btnLoad.Click += btnLoad_Click;
            btnSave.Click += btnSave_Click;
            btnCopy.Click += btnCopy_Click;
            btnReset.Click += btnReset_Click;
            btnGray.Click += btnGray_Click;
            btnInvert.Click += btnInvert_Click;
            btnSepia.Click += btnSepia_Click;
            btnHistogram.Click += btnHistogram_Click;

            btnLoadForeground.Click += BtnLoadForeground_Click;
            btnLoadBackground.Click += BtnLoadBackground_Click;
            btnSubtract.Click += BtnSubtract_Click;

            btnStartWebcam.Click += BtnStartWebcam_Click;
            btnCapture.Click += BtnCapture_Click;
            btnLoadWebcamBackground.Click += BtnLoadWebcamBackground_Click;
            btnApplyGreenScreen.Click += BtnApplyGreenScreen_Click;

            btnApplyConvolution.Click += (s, e) =>
            {
                if (comboBoxFilters.SelectedItem != null)
                {
                    string filterName = comboBoxFilters.SelectedItem.ToString();
                    ApplyConvolutionFilter(filterName, iterations: 3);
                }
                else
                {
                    MessageBox.Show("Please select a convolution filter from the list.");
                }
            };


            // Menu
            editingModeItem.Click += (s, e) => SwitchToMode("Editing");
            subtractionModeItem.Click += (s, e) => SwitchToMode("Subtraction");
            webcamModeItem.Click += (s, e) => SwitchToMode("Webcam");
        }

        // -------------------------------
        // CONVOLUTION SUPPORT
        // -------------------------------
        public class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;

            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
                          BottomLeft = BottomMid = BottomRight = nVal;
            }
        }

        public static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            if (m.Factor == 0) return false;

            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                                 ImageLockMode.ReadWrite,
                                 PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            IntPtr Scan0 = bmData.Scan0;
            IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        // Blue
                        nPixel = (((pSrc[2] * m.TopLeft) +
                                   (pSrc[5] * m.TopMid) +
                                   (pSrc[8] * m.TopRight) +
                                   (pSrc[2 + stride] * m.MidLeft) +
                                   (pSrc[5 + stride] * m.Pixel) +
                                   (pSrc[8 + stride] * m.MidRight) +
                                   (pSrc[2 + stride2] * m.BottomLeft) +
                                   (pSrc[5 + stride2] * m.BottomMid) +
                                   (pSrc[8 + stride2] * m.BottomRight))
                                   / m.Factor) + m.Offset;

                        nPixel = Math.Min(Math.Max(nPixel, 0), 255);
                        p[5 + stride] = (byte)nPixel;

                        // Green
                        nPixel = (((pSrc[1] * m.TopLeft) +
                                   (pSrc[4] * m.TopMid) +
                                   (pSrc[7] * m.TopRight) +
                                   (pSrc[1 + stride] * m.MidLeft) +
                                   (pSrc[4 + stride] * m.Pixel) +
                                   (pSrc[7 + stride] * m.MidRight) +
                                   (pSrc[1 + stride2] * m.BottomLeft) +
                                   (pSrc[4 + stride2] * m.BottomMid) +
                                   (pSrc[7 + stride2] * m.BottomRight))
                                   / m.Factor) + m.Offset;

                        nPixel = Math.Min(Math.Max(nPixel, 0), 255);
                        p[4 + stride] = (byte)nPixel;

                        // Red
                        nPixel = (((pSrc[0] * m.TopLeft) +
                                   (pSrc[3] * m.TopMid) +
                                   (pSrc[6] * m.TopRight) +
                                   (pSrc[0 + stride] * m.MidLeft) +
                                   (pSrc[3 + stride] * m.Pixel) +
                                   (pSrc[6 + stride] * m.MidRight) +
                                   (pSrc[0 + stride2] * m.BottomLeft) +
                                   (pSrc[3 + stride2] * m.BottomMid) +
                                   (pSrc[6 + stride2] * m.BottomRight))
                                   / m.Factor) + m.Offset;

                        nPixel = Math.Min(Math.Max(nPixel, 0), 255);
                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }

        // Filters
        public static bool Smooth(Bitmap b, int weight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = 2;
            m.Factor = 2 + 8;
            return Conv3x3(b, m);
        }

        public static bool GaussianBlur(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = 1;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Pixel = 4;
            m.Factor = 16;
            return Conv3x3(b, m);
        }

        public static bool Sharpen(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.Pixel = 11;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
            m.Factor = 3;
            return Conv3x3(b, m);
        }

        public static bool MeanRemoval(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = 9;
            m.Factor = 1;
            return Conv3x3(b, m);
        }

        public static bool Emboss(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(0);
            m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = -1;
            m.Pixel = 4;
            m.Offset = 127;
            m.Factor = 1;
            return Conv3x3(b, m);
        }

        private void ApplyConvolutionFilter(string filterType, int iterations = 1)
        {
            if (processedImage == null) return;

            Bitmap temp = (Bitmap)processedImage.Clone();
            bool success = true;

            try
            {
                for (int i = 0; i < iterations; i++)
                {
                    switch (filterType)
                    {
                        case "Smooth":
                            success &= Smooth(temp);
                            break;
                        case "Gaussian":
                            success &= GaussianBlur(temp);
                            break;
                        case "Sharpen":
                            success &= Sharpen(temp);
                            break;
                        case "Mean Removal":
                            success &= MeanRemoval(temp);
                            break;
                        case "Emboss":
                            success &= Emboss(temp);
                            break;
                        default:
                            success = false;
                            break;
                    }
                }

                if (success)
                {
                    processedImage.Dispose();
                    processedImage = temp;

                    var old = pictureBoxProcessed.Image as Bitmap;
                    pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
                    old?.Dispose();
                }
                else
                {
                    temp.Dispose();
                    MessageBox.Show("Unknown or failed convolution filter.");
                }
            }
            catch (Exception ex)
            {
                temp.Dispose();
                MessageBox.Show($"Error applying convolution filter: {ex.Message}");
            }
        }


        private void InitializeWebcam()
        {
            try
            {
                webcamDevices = DeviceManager.GetAllDevices();
                if (webcamDevices != null && webcamDevices.Length > 0)
                {
                    currentDevice = webcamDevices[0];
                }
                else
                {
                    MessageBox.Show("No webcam devices found.");
                    btnStartWebcam.Enabled = false;
                    btnCapture.Enabled = false;
                    btnApplyGreenScreen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing webcam: {ex.Message}");
                btnStartWebcam.Enabled = false;
                btnCapture.Enabled = false;
                btnApplyGreenScreen.Enabled = false;
            }
        }

        private void SwitchToMode(string mode)
        {
            editingModeItem.Checked = (mode == "Editing");
            subtractionModeItem.Checked = (mode == "Subtraction");
            webcamModeItem.Checked = (mode == "Webcam");

            editingPanel.Visible = (mode == "Editing");
            subtractionPanel.Visible = (mode == "Subtraction");
            webcamPanel.Visible = (mode == "Webcam");

            if (mode != "Webcam" && isWebcamRunning)
                StopWebcam();

            this.Text = $"LIBRON Digital Image Processing - {mode} Mode";
        }

        // =================== WEBCAM ===================
        private void BtnStartWebcam_Click(object sender, EventArgs e)
        {
            if (currentDevice == null)
            {
                MessageBox.Show("No webcam device available.");
                return;
            }

            if (!isWebcamRunning) StartWebcam();
            else StopWebcam();
        }

        private void StartWebcam()
        {
            try
            {
                currentDevice.ShowWindow(pictureBoxWebcam);

                isWebcamRunning = true;
                btnStartWebcam.Text = "Stop Webcam";
                btnCapture.Enabled = true;
                btnApplyGreenScreen.Enabled = true;

                if (webcamTimer == null)
                {
                    webcamTimer = new System.Windows.Forms.Timer();
                    webcamTimer.Interval = 50; // ~20 FPS; tune as needed
                    webcamTimer.Tick += WebcamTimer_Tick;
                }
                webcamTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting webcam: {ex.Message}");
            }
        }

        private void StopWebcam()
        {
            try
            {
                if (webcamTimer != null) webcamTimer.Stop();

                try
                {
                    currentDevice?.Stop();
                }
                catch
                {

                }

                isWebcamRunning = false;
                btnStartWebcam.Text = "Start Webcam";
                btnCapture.Enabled = false;
                btnApplyGreenScreen.Enabled = false;

                if (pictureBoxWebcam.Image != null) { pictureBoxWebcam.Image.Dispose(); pictureBoxWebcam.Image = null; }
                if (pictureBoxWebcamProcessed.Image != null) { pictureBoxWebcamProcessed.Image.Dispose(); pictureBoxWebcamProcessed.Image = null; }
                latestWebcamFrame?.Dispose();
                latestWebcamFrame = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping webcam: {ex.Message}");
            }
        }

        private void WebcamTimer_Tick(object sender, EventArgs e)
        {
            if (!isWebcamRunning) return;

            try
            {
                Bitmap captured = CaptureControlBitmap(pictureBoxWebcam);

                if (captured == null) return;

                latestWebcamFrame?.Dispose();
                latestWebcamFrame = captured;


                if (webcamBackground != null)
                {
                    Bitmap preview = ApplyGreenScreenFast(latestWebcamFrame, webcamBackground, GetSensitivity());
                    var old = pictureBoxWebcamProcessed.Image as Bitmap;
                    pictureBoxWebcamProcessed.Image = preview;
                    old?.Dispose();
                }
                else
                {
                    var old = pictureBoxWebcamProcessed.Image as Bitmap;
                    pictureBoxWebcamProcessed.Image = null;
                    old?.Dispose();
                }

                var rawOld = pictureBoxWebcam.Image as Bitmap;
                pictureBoxWebcam.Image = (Bitmap)latestWebcamFrame.Clone();
                rawOld?.Dispose();
            }
            catch
            {
                
            }
        }


        private Bitmap CaptureControlBitmap(Control ctl)
        {
            if (ctl.Width <= 0 || ctl.Height <= 0) return null;

            Bitmap bmp = new Bitmap(ctl.Width, ctl.Height, PixelFormat.Format24bppRgb);

            try
            {
                ctl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                return bmp;
            }
            catch
            {
                try
                {
                    Point screenP = ctl.PointToScreen(Point.Empty);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(screenP, Point.Empty, bmp.Size);
                    }
                    return bmp;
                }
                catch
                {
                    bmp.Dispose();
                    return null;
                }
            }
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isWebcamRunning || latestWebcamFrame == null)
                {
                    MessageBox.Show("Webcam is not running or no frame captured.");
                    return;
                }
                Bitmap toUse = null;
                if (pictureBoxWebcamProcessed.Image != null)
                    toUse = new Bitmap(pictureBoxWebcamProcessed.Image);
                else
                    toUse = new Bitmap(latestWebcamFrame);

                originalImage?.Dispose();
                processedImage?.Dispose();

                originalImage = toUse;
                processedImage = new Bitmap(originalImage);

                var oldOrig = pictureBoxOriginal.Image as Bitmap;
                pictureBoxOriginal.Image = originalImage;
                oldOrig?.Dispose();

                var oldProc = pictureBoxProcessed.Image as Bitmap;
                pictureBoxProcessed.Image = processedImage;
                oldProc?.Dispose();

                MessageBox.Show("Frame captured and loaded for editing!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing frame: {ex.Message}");
            }
        }

        private void BtnLoadWebcamBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    webcamBackground?.Dispose();
                    webcamBackground = new Bitmap(ofd.FileName);

                    var old = pictureBoxWebcamBackground.Image as Bitmap;
                    pictureBoxWebcamBackground.Image = (Bitmap)webcamBackground.Clone();
                    old?.Dispose();

                    btnApplyGreenScreen.Enabled = true;
                }
            }
        }

        private void BtnApplyGreenScreen_Click(object sender, EventArgs e)
        {
            if (!isWebcamRunning)
            {
                MessageBox.Show("Please start the webcam first.");
                return;
            }
            if (webcamBackground == null)
            {
                MessageBox.Show("Please load a background image first.");
                return;
            }
            if (latestWebcamFrame == null)
            {
                MessageBox.Show("No webcam frame available yet.");
                return;
            }

            var result = ApplyGreenScreenFast(latestWebcamFrame, webcamBackground, GetSensitivity());

            var old = pictureBoxWebcamProcessed.Image as Bitmap;
            pictureBoxWebcamProcessed.Image = result;
            old?.Dispose();
        }

        // =================== GREEN SCREEN (fast LockBits implementation) ===================
        private int GetSensitivity()
        {
            try
            {
                return trackBarGreenSensitivity?.Value ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        private Bitmap ApplyGreenScreen(Bitmap foreground, Bitmap background)
        {
            return ApplyGreenScreenFast(foreground, background, GetSensitivity());
        }

        private Bitmap ApplyGreenScreenFast(Bitmap fg, Bitmap bg, int sensitivity)
        {
            if (fg == null || bg == null) return null;

            int width = Math.Min(fg.Width, bg.Width);
            int height = Math.Min(fg.Height, bg.Height);

            using (Bitmap fg24 = ConvertTo24bpp(fg))
            using (Bitmap bg24 = ConvertTo24bpp(bg))
            {
                Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);

                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData fgData = fg24.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData bgData = bg24.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData resData = result.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                int bytes = Math.Abs(fgData.Stride) * height;
                byte[] fgBuf = new byte[bytes];
                byte[] bgBuf = new byte[bytes];
                byte[] resBuf = new byte[bytes];

                Marshal.Copy(fgData.Scan0, fgBuf, 0, bytes);
                Marshal.Copy(bgData.Scan0, bgBuf, 0, bytes);

                int greenThreshold = 120 + sensitivity;
                int redBlueThreshold = 120 - sensitivity;

                int stride = fgData.Stride;
                for (int y = 0; y < height; y++)
                {
                    int offset = y * stride;
                    for (int x = 0; x < width; x++)
                    {
                        int idx = offset + x * 3;
                        byte b = fgBuf[idx + 0];
                        byte g = fgBuf[idx + 1];
                        byte r = fgBuf[idx + 2];

                        bool isGreen = (g > greenThreshold) && (r < redBlueThreshold) && (b < redBlueThreshold);

                        if (isGreen)
                        {
                            // copy bg pixel
                            resBuf[idx + 0] = bgBuf[idx + 0];
                            resBuf[idx + 1] = bgBuf[idx + 1];
                            resBuf[idx + 2] = bgBuf[idx + 2];
                        }
                        else
                        {
                            // copy fg pixel
                            resBuf[idx + 0] = b;
                            resBuf[idx + 1] = g;
                            resBuf[idx + 2] = r;
                        }
                    }
                }

                Marshal.Copy(resBuf, 0, resData.Scan0, bytes);

                fg24.UnlockBits(fgData);
                bg24.UnlockBits(bgData);
                result.UnlockBits(resData);

                return result;
            }
        }

        private Bitmap ConvertTo24bpp(Bitmap src)
        {
            if (src.PixelFormat == PixelFormat.Format24bppRgb)
                return (Bitmap)src.Clone();

            Bitmap clone = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(clone))
            {
                g.DrawImage(src, 0, 0, src.Width, src.Height);
            }
            return clone;
        }

        // =================== SUBTRACTION MODE ===================


        private void BtnLoadForeground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreground = new Bitmap(ofd.FileName);
                    picForeground.Image = foreground;
                }
            }
        }

        private void BtnLoadBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    background = new Bitmap(ofd.FileName);
                    picBackground.Image = background;
                }
            }
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            if (foreground == null || background == null)
            {
                MessageBox.Show("Please load both foreground and background images first.");
                return;
            }

            Bitmap result = SimpleImageSubtraction(foreground, background);
            picSubtractionResult.Image = result;
            MessageBox.Show("Background subtraction completed!");
        }

        private Bitmap SimpleImageSubtraction(Bitmap foreground, Bitmap background)
        {
            int width = Math.Min(foreground.Width, background.Width);
            int height = Math.Min(foreground.Height, background.Height);

            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color fgColor = foreground.GetPixel(x, y);
                    Color bgColor = background.GetPixel(x, y);

                    bool isGreen = fgColor.G > 120 && fgColor.R < 120 && fgColor.B < 120;

                    if (isGreen)
                        result.SetPixel(x, y, bgColor); // replace with background
                    else
                        result.SetPixel(x, y, fgColor); // keep foreground
                }
            }

            return result;
        }


        // =================== FAST PIXEL METHODS ===================
        private Bitmap ProcessBitmap(Bitmap bmp, Func<byte, byte, byte, (byte r, byte g, byte b)> processor)
        {
            if (bmp == null) return null;

            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap newBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            using (Bitmap src24 = ConvertTo24bpp(bmp))
            {
                BitmapData srcData = src24.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = newBmp.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                int bytes = Math.Abs(srcData.Stride) * height;
                byte[] srcBuffer = new byte[bytes];
                byte[] dstBuffer = new byte[bytes];

                Marshal.Copy(srcData.Scan0, srcBuffer, 0, bytes);

                for (int y = 0; y < height; y++)
                {
                    int offset = y * srcData.Stride;
                    for (int x = 0; x < width; x++)
                    {
                        int idx = offset + x * 3;
                        byte b = srcBuffer[idx + 0];
                        byte g = srcBuffer[idx + 1];
                        byte r = srcBuffer[idx + 2];

                        (byte nr, byte ng, byte nb) = processor(r, g, b);

                        dstBuffer[idx + 0] = nb;
                        dstBuffer[idx + 1] = ng;
                        dstBuffer[idx + 2] = nr;
                    }
                }

                Marshal.Copy(dstBuffer, 0, dstData.Scan0, bytes);

                src24.UnlockBits(srcData);
                newBmp.UnlockBits(dstData);
            }

            return newBmp;
        }

        // =================== IMAGE PROCESSING ===================
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage?.Dispose();
                    processedImage?.Dispose();

                    originalImage = new Bitmap(ofd.FileName);
                    processedImage = new Bitmap(originalImage);

                    var oldOriginal = pictureBoxOriginal.Image as Bitmap;
                    pictureBoxOriginal.Image = (Bitmap)originalImage.Clone();
                    oldOriginal?.Dispose();

                    var oldProcessed = pictureBoxProcessed.Image as Bitmap;
                    pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
                    oldProcessed?.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("No image to save.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG|*.png|JPEG|*.jpg|Bitmap|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    processedImage.Save(sfd.FileName);
                    MessageBox.Show("Image saved successfully.");
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (processedImage == null) return;
            Clipboard.SetImage(processedImage);
            MessageBox.Show("Processed image copied to clipboard.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            processedImage?.Dispose();
            processedImage = new Bitmap(originalImage);

            var old = pictureBoxProcessed.Image as Bitmap;
            pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
            old?.Dispose();
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage?.Dispose();
            processedImage = ProcessBitmap(originalImage, (r, g, b) =>
            {
                byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                return (gray, gray, gray);
            });

            var old = pictureBoxProcessed.Image as Bitmap;
            pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
            old?.Dispose();
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage?.Dispose();
            processedImage = ProcessBitmap(originalImage, (r, g, b) =>
            {
                return ((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
            });

            var old = pictureBoxProcessed.Image as Bitmap;
            pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
            old?.Dispose();
        }

        private void btnSepia_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage?.Dispose();
            processedImage = ProcessBitmap(originalImage, (r, g, b) =>
            {
                int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);
                return ((byte)Math.Min(255, tr),
                        (byte)Math.Min(255, tg),
                        (byte)Math.Min(255, tb));
            });

            var old = pictureBoxProcessed.Image as Bitmap;
            pictureBoxProcessed.Image = (Bitmap)processedImage.Clone();
            old?.Dispose();
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            if (processedImage == null) return;

            int[] histogram = new int[256];
            int width = processedImage.Width;
            int height = processedImage.Height;

            BitmapData data = processedImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(data.Stride) * height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(data.Scan0, buffer, 0, bytes);

            for (int y = 0; y < height; y++)
            {
                int offset = y * data.Stride;
                for (int x = 0; x < width; x++)
                {
                    int idx = offset + x * 3;
                    byte b = buffer[idx];
                    byte g = buffer[idx + 1];
                    byte r = buffer[idx + 2];
                    int gray = (r + g + b) / 3;
                    histogram[gray]++;
                }
            }

            processedImage.UnlockBits(data);

            int max = 1;
            for (int i = 0; i < 256; i++) if (histogram[i] > max) max = histogram[i];

            int w = pictureBoxHistogram.Width;
            int h = pictureBoxHistogram.Height;
            Bitmap histBmp = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(histBmp))
            {
                g.Clear(Color.White);
                float scaleX = w / 256f;
                float scaleY = (float)h / max;
                for (int i = 0; i < 256; i++)
                {
                    float x = i * scaleX;
                    float y = h - histogram[i] * scaleY;
                    g.DrawLine(Pens.Black, x, h, x, y);
                }
            }

            var oldHist = pictureBoxHistogram.Image as Bitmap;
            pictureBoxHistogram.Image = histBmp;
            oldHist?.Dispose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (webcamTimer != null) webcamTimer.Stop();
            }
            catch { }

            try
            {
                if (isWebcamRunning)
                {
                    currentDevice?.Stop();
                    isWebcamRunning = false;
                }
            }
            catch { }

            // Dispose bitmaps
            originalImage?.Dispose();
            processedImage?.Dispose();
            foreground?.Dispose();
            background?.Dispose();
            webcamBackground?.Dispose();
            latestWebcamFrame?.Dispose();

            base.OnFormClosing(e);
        }
    }
}
