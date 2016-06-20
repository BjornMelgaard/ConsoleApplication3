using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace Test
{
    /// <summary>
    /// 
    /// </summary>
    /*
    public static class MyProcess
    {
        static class Program
        {
        const string DIR = @"C:\Users\user.000\Documents\osu_samples\";
        const string OSU_VIDEO_FILE = @"C:\Users\user.000\Documents\osu_samples\out.avi";
        const string IMAGE_FILE = @"C:\Users\user.000\Documents\osu_samples\playground7.jpg";
        const string ERROR_MASK_FILE = @"C:\Users\user.000\Documents\osu_samples\error_mask.jpg";

        private static void Main(string[] args)
        {
            Mat error_mask = new Mat(ERROR_MASK_FILE, ImreadModes.GrayScale).Threshold(0, 255, ThresholdTypes.Otsu).PyrDown();

            Rect button = new Rect(235, 317, 114, 120);
            Rect playground = new Rect(200, 275, 954, 210);

            Scalar blue_lower = new Scalar(110, 100, 100);
            Scalar blue_upper = new Scalar(120, 255, 255);

            Scalar red_lower = new Scalar(0, 100, 100);
            Scalar red_upper = new Scalar(15, 255, 255);

            using (var window = new Window("window"))
            {
                Mat image;
                Mat prev_image = OpenCvHelp.Screenshot(playground);

                Size size = new Size(9, 9);
                while (true)
                {
                    image = OpenCvHelp.Screenshot(playground);

                    Mat dst = image.Clone();
                    var threshold_output = image.Threshold(170, 255, ThresholdTypes.Binary);

                    var threshold_output_prev = prev_image.Threshold(170, 255, ThresholdTypes.Binary);

                    dst = threshold_output_prev.Absdiff(threshold_output);

                    prev_image = image;
                    window.ShowImage(dst);
                    Cv2.WaitKey(1);
                    GC.Collect();
                }
            }
            
        }
        public class ColorCircle
        {
            Point2f center;
            float radius;
            Scalar color;
            bool isActive; 

            public ColorCircle(Point2f center, float radius, Scalar color, bool isActive)
            {
                this.center = center;
                this.radius = radius;
                this.color = color;
            }
        }
        static List<ColorCircle> circles = new List<ColorCircle>();
        private static void arrange_circles(CircleSegment[] blue, CircleSegment[] red)
        {
            var c = new List<ColorCircle>();
            //blue.Select(b => c.Add(new ColorCircle(b.Center, b.Radius, Scalar.Blue ));

            //c.OrderBy();

        }

        /*
        private static void Analize(Mat screenshot)
        {

        var hsv = threshold_output.CvtColor(ColorConversionCodes.BGR2HSV);
            var blue_mask = hsv.InRange(blue_lower, blue_upper);
        var blue_dst = new Mat();
        threshold_output.CopyTo(blue_dst, blue_mask);
                    blue_dst = blue_dst.Dilate(2).Erode(2);

        var red_mask = hsv.InRange(red_lower, red_upper) ^ error_mask;
        var red_dst = new Mat();
        threshold_output.CopyTo(red_dst, red_mask);
                    red_dst = red_dst.Dilate(2).Erode(2);

        var grey = blue_dst.CvtColor(ColorConversionCodes.BGR2GRAY);
        grey *= 10;
                    CircleSegment[] circles = grey.GaussianBlur(size, 2, 2).HoughCircles(HoughMethods.Gradient, 2, blue_dst.Rows / 8, 100, 100, 0, 130);
                    foreach (var circle in circles)
                    {
                        dst.Circle(circle.Center, (int)circle.Radius, Scalar.Blue, 3);
                    }

    grey = red_dst.CvtColor(ColorConversionCodes.BGR2GRAY);
                    grey *= 10;
                    circles = grey.HoughCircles(HoughMethods.Gradient, 3, red_dst.Rows / 8, 100, 115, 15, 35);
                    foreach (var circle in circles)
                    {
                        dst.Circle(circle.Center, (int)circle.Radius, Scalar.Red, 3);
                    }
        }
    
    
        func (){
    
                var chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                chartArea1.Name = "ChartArea1";
                chart1.ChartAreas.Add(chartArea1);
                legend1.Name = "Legend1";
                chart1.Legends.Add(legend1);
                chart1.Location = new System.Drawing.Point(296, 23);
                chart1.Name = "chart1";
                series1.ChartArea = "ChartArea1";
                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series1.Legend = "Legend1";
                series1.Name = "Series1";
                chart1.Series.Add(series1);
                chart1.Size = new System.Drawing.Size(300, 300);
                chart1.TabIndex = 8;
                chart1.Text = "chart1";
                for (int i = 0; i < chart_list.Count; i++)
                {
                    series1.Points.AddXY(i, chart_list[i]);
                }
                chart1.SaveImage(@"C:\Users\user.000\Documents\osu_samples\chart.jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);    
    
    
    }
    
    */

}
