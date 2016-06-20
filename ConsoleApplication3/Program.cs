using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.Gpu;
using OpenCvSharp.Extensions;

namespace ConsoleApplication3
{
    static class Program
    {
        const string DIR = @"C:\Users\user.000\Documents\osu_samples\";
        const string OSU_VIDEO_FILE = @"C:\Users\user.000\Documents\osu_samples\out.avi";
        const string IMAGE_FILE = @"C:\Users\user.000\Documents\osu_samples\playground7.jpg";
        const string ERROR_MASK_FILE = @"C:\Users\user.000\Documents\osu_samples\error_mask3.jpg";

        private static void Main(string[] args)
        {
            Mat error_mask = new Mat(ERROR_MASK_FILE, ImreadModes.GrayScale).Threshold(0, 255, ThresholdTypes.Otsu);

            Rect r_button = new Rect(235, 317, 114, 120);

            Scalar blue_lower = new Scalar(110, 100, 100);
            Scalar blue_upper = new Scalar(120, 255, 255);

            Scalar red_lower = new Scalar(0, 100, 100);
            Scalar red_upper = new Scalar(15, 255, 255);

            Scalar white_lower_brg = new Scalar(240, 240, 240);
            Scalar white_upper_brg = new Scalar(255, 255, 255);

            using (var window = new Window("window"))
            {
                {
                    Mat image;
                    TapTypes tap = TapTypes.None;

                    while (true)
                    {
                        image = OpenCvHelp.Screenshot(r_button);

                        Mat dst = new Mat(image.Size(), image.Type(), Scalar.Black); //make baskground
                        image.CopyTo(dst, error_mask);
                        var threshold_output = dst.Threshold(170, 255, ThresholdTypes.Binary);


                        var white_mask = threshold_output.InRange(white_lower_brg, white_upper_brg);
                        var white_dst = new Mat();
                        threshold_output.CopyTo(white_dst, white_mask);

                        var gray = white_dst.CvtColor(ColorConversionCodes.BGR2GRAY);
                        //int total = gray.Rows * gray.Cols;
                        int white = gray.CountNonZero();
                        //string text = ((int)Math.Round((double)(100 * non_zero) / total)).ToString();
                        //text += "%";
                        string text = white.ToString();
                        threshold_output.PutText(text, new Point(0, 15), HersheyFonts.HersheyComplex, 0.5, Scalar.Red);

                        window.ShowImage(threshold_output);

                        if (white > 400)
                        {
                            var hsv = threshold_output.CvtColor(ColorConversionCodes.BGR2HSV);

                            var blue_mask = hsv.InRange(blue_lower, blue_upper);
                            var red_mask = hsv.InRange(red_lower, red_upper);
                            //первая проверка - на желтый
                            if (blue_mask.CountNonZero() > 100) tap = TapTypes.Blue;
                            else if (red_mask.CountNonZero() > 100) tap = TapTypes.Red;
                            else tap = TapTypes.Yellow;
                        }

                        if (tap != TapTypes.None && tap != TapTypes.Yellow)
                        {
                            if (tap == TapTypes.Blue) BotSuite.Input.Keyboard.PressKey(System.Windows.Forms.Keys.V);
                            if (tap == TapTypes.Red) BotSuite.Input.Keyboard.PressKey(System.Windows.Forms.Keys.X);
                            tap = TapTypes.None;
                            Cv2.WaitKey(50);
                        }
                        else Cv2.WaitKey(1);

                        //if ( Cv2.WaitKey(1) == 27) break;
                        GC.Collect();
                    }

                }
            }
            
        }

        enum TapTypes
        {
            None, Blue, Red, Yellow
        }
    }
}