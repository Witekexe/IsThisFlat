using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace IsThisFlat
{
    public partial class RawDataPage : ContentPage
    {
        private Vector3 _currentAcceleration;
        public RawDataPage()
        {
            InitializeComponent();
            Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;

     
        }
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;

            _currentAcceleration = data.Acceleration;

            string zValue = $" {_currentAcceleration.Z:F2}";
            string yValue = $" {_currentAcceleration.Y:F2}";
            string xValue = $" {_currentAcceleration.X:F2}";




            Label1.Text = xValue;
            Label2.Text = yValue;
            Label3.Text = zValue;
        }
    }
}