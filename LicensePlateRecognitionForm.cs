﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
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

namespace LicensePlateRecognition
{
    public partial class LicensePlateRecognitionForm : Form
    {
        private LicensePlateDetector _licensePlateDetector;

        public LicensePlateRecognitionForm()
        {
            InitializeComponent();
            
            _licensePlateDetector = new LicensePlateDetector("");
            Mat m = new Mat(@"..\..\license-plate.jpg", LoadImageType.AnyColor);
            UMat um = m.ToUMat(AccessType.ReadWrite);
            ibImageSource.Image = um;
            ProcessImage(m);
            ibImageSource.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ProcessImage(IInputOutputArray image)
        {
            Stopwatch watch = Stopwatch.StartNew(); // time the detection process

            List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
            List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
            List<RotatedRect> licenseBoxList = new List<RotatedRect>();
            List<string> words = _licensePlateDetector.DetectLicensePlate(
               image,
               licensePlateImagesList,
               filteredLicensePlateImagesList,
               licenseBoxList);

            watch.Stop(); //stop the timer
            processTimeLabel.Text = String.Format("License Plate Recognition time: {0} milli-seconds", watch.Elapsed.TotalMilliseconds);

            panel1.Controls.Clear();
            Point startPoint = new Point(10, 10);
            for (int i = 0; i < words.Count; i++)
            {
                Mat dest = new Mat();
                CvInvoke.VConcat(licensePlateImagesList[i], filteredLicensePlateImagesList[i], dest);
                AddLabelAndImage(
                   ref startPoint,
                   String.Format("License: {0}", words[i]),
                   dest);
                PointF[] verticesF = licenseBoxList[i].GetVertices();
                Point[] vertices = Array.ConvertAll(verticesF, Point.Round);
                using (VectorOfPoint pts = new VectorOfPoint(vertices))
                    CvInvoke.Polylines(image, pts, true, new Bgr(Color.Red).MCvScalar, 2);

            }
        }

        private void AddLabelAndImage(ref Point startPoint, String labelText, IImage image)
        {
            Label label = new Label();
            panel1.Controls.Add(label);
            label.Text = labelText;
            label.Width = 100;
            label.Height = 30;
            label.Location = startPoint;
            startPoint.Y += label.Height;

            ImageBox box = new ImageBox();
            panel1.Controls.Add(box);
            box.ClientSize = image.Size;
            box.Image = image;
            box.Location = startPoint;
            startPoint.Y += box.Height + 10;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                Mat img;
                try
                {
                    img = CvInvoke.Imread(openFile.FileName, LoadImageType.AnyColor);
                }
                catch
                {
                    MessageBox.Show(String.Format("Invalide File: {0}", openFile.FileName));
                    return;
                }
                tbPath.Text = openFile.FileName;
                UMat uImg = img.ToUMat(AccessType.ReadWrite);
                ibImageSource.Image = uImg;
                ProcessImage(uImg);
            }
        }

        private void tbPath_Click(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }
    }
}
