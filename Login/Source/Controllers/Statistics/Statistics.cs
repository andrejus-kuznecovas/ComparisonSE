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
        public static PlotModel pieChart(Dictionary<string, float> value)
        {
            PlotModel model = new PlotModel { Title = "Išlaidos" };
            var series = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.7, AngleSpan = 360, StartAngle = 0 };
            
           
            foreach(var key in value.Keys)
            {
                series.Slices.Add(new PieSlice(key, value[key]) { IsExploded = true });
            }

            model.Series.Add(series);
            return model;

        }
        /// <summary>
        /// displays linear diagram rom dictionary
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PlotModel linearChart(Dictionary<DateTime, float> data)
        {
            PlotModel model = new PlotModel { Title = "Kainų kitimas" };
            model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0, IsPanEnabled = false });

            var series = new LineSeries
            {
                Color = OxyColors.Aqua,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Black,
                MarkerStrokeThickness = 4.0

            };
            
            foreach (var dataPoint in data)
            {
                DateTime date = dataPoint.Key;
                float value = dataPoint.Value;
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), value));
            }

            model.Series.Add(series);
            return model;

        }
    }
}