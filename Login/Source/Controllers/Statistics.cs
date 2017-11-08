using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Login.Source.UI
{
    [Activity(Theme = "@style/Theme.Brand")]
    class Statistics
    {
    
       /// <summary>
        /// loads diagram according to the selected spinner 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        /// <summary>
        /// Creates a pie chart from a dictionary
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PlotModel pieChart(Dictionary<string, int> value)
        {
            PlotModel model = new PlotModel { Title = "Statistika" };
            var series = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.7, AngleSpan = 360, StartAngle = 0 };
            series.Slices.Add(new PieSlice("lala", 523) { IsExploded = true });
            series.Slices.Add(new PieSlice("asd", 2) { IsExploded = true });
            series.Slices.Add(new PieSlice("ghh", 23) { IsExploded = true });
            series.Slices.Add(new PieSlice("qrqw", 241) { IsExploded = true });
            
            /*
             * will be usefull when dictionary will be created
            foreach(var key in value.Keys)
            {
                series.Slices.Add(new PieSlice(key, value[key]) { IsExploded = true });
            }
            */

            model.Series.Add(series);
            return model;

        }
        /// <summary>
        /// displays linear diagram rom dictionary
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PlotModel linearChart(Dictionary<string, int> value)
        {
            PlotModel model = new PlotModel { Title = "Statistika" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0, IsPanEnabled = false });

            var series = new LineSeries
            {
                Color = OxyColors.Purple,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Black,
                MarkerStrokeThickness = 4.0

            };
            series.Points.Add(new DataPoint(2.0, 4.2));
            series.Points.Add(new DataPoint(3.0, 4.2));
            series.Points.Add(new DataPoint(4.0, 4.2));
            series.Points.Add(new DataPoint(5.0, 4.2));

            /*
            foreach (var key in value.Keys)
            {
                int date;
                series.Points.Add(new DataPoint(2, value[key]));
            }
            */
                model.Series.Add(series);
            return model;

        }
    }
}