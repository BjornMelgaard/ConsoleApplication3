using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ConsoleApplication3
{
    static class OpenCvHelp
    {
        private static IntPtr windowHandle = BotSuite.Window.FindWindowByProcessName("osu!");
        public static Mat Screenshot(Rect screenshotArea)
        {
            var screenshot = BotSuite.ScreenShot.Create(windowHandle);
            var screenshot_mat = screenshot.ToMat();
            var image = new Mat(screenshot_mat, screenshotArea);
            screenshot.Dispose();
            screenshot_mat.Dispose();
            return image;
        }

        public static void CopyTo(this Mat src, Mat dst, Rect rect)
        {
            var mask = new Mat(src.Rows, src.Cols, MatType.CV_8UC1);
            mask.Rectangle(rect, new Scalar(255), -1);
            src.CopyTo(dst, mask);
        }
        public static Mat Absdiff(this Mat src, Mat src2)
        {
            var dst = new Mat();
            Cv2.Absdiff(src, src2, dst);
            return dst;
        }
        public static Mat CvtColor(this Mat src, ColorConversionCodes code)
        {
            var dst = new Mat();
            Cv2.CvtColor(src, dst, code);
            return dst;
        }
        public static Mat Threshold(this Mat src, double thresh, double maxval, ThresholdTypes type)
        {
            var dst = new Mat();
            Cv2.Threshold(src, dst, thresh, maxval, type);
            return dst;
        }

        public static Mat ThresholdStairs(this Mat src)
        {
            var dst = new Mat(src.Rows, src.Cols, src.Type());

            var partCount = 10;
            var partWidth = src.Width / partCount;

            for (var i = 0; i < partCount; ++i)
            {
                var th_mat = new Mat();
                Cv2.Threshold(src, th_mat, 255 / 10 * (i + 1), 255, ThresholdTypes.Binary);
                th_mat.Rectangle(new Rect(0, 0, partWidth * i, src.Height), new Scalar(0), -1);
                th_mat.Rectangle(new Rect(partWidth * (i + 1), 0, src.Width - partWidth * (i + 1), src.Height), new Scalar(0), -1);

                Cv2.Add(dst, th_mat, dst);
            }
            var color_dst = new Mat();
            Cv2.CvtColor(dst, color_dst, ColorConversionCodes.GRAY2RGB);
            for (var i = 0; i < partCount; ++i)
            {
                color_dst.Line(partWidth * i, 0, partWidth * i, src.Height, new Scalar(50, 200, 50), thickness: 2);
            }
            return color_dst;
        }

        public static Mat With_Title(this Mat mat, string text)
        {
            var res = mat.Clone();
            res.Rectangle(new Rect(res.Width / 2 - 10, 30, 20 + text.Length * 15, 25), new Scalar(0), -1);
            res.PutText(text, new Point(res.Width / 2, 50), HersheyFonts.HersheyComplex, 0.7, new Scalar(150, 200, 150));
            return res;
        }
        public static Mat Resize(this Mat src, double k)
        {
            var dst = new Mat();
            Cv2.Resize(src, dst, new Size((int)(src.Width * k), (int)(src.Height * k)));
            return dst;
        }
        public static Mat Cut(this Mat src, Rect rect)
        {
            return new Mat(src, rect);
        }
        public static Mat[] Split(this Mat hsv_background)
        {
            Mat[] hsv_background_channels;
            Cv2.Split(hsv_background, out hsv_background_channels);
            return hsv_background_channels;
        }
    }
}
