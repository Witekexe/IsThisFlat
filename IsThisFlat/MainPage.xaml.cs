using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace IsThisFlat
{
    public partial class MainPage : ContentPage
    {
        private bool _isMonitoring;
        private Vector3 _currentAcceleration;

        public MainPage()
        {
            InitializeComponent();
            Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;

            _currentAcceleration = data.Acceleration;

            string zValueLabel = $" {_currentAcceleration.Z:F2}";
            string zValueStatus = "";

            if (Math.Abs(_currentAcceleration.Z - 1.00) <= 0.02)
            {
                zValueStatus = " FLAT";
            }

            else { zValueStatus = " NOT FLAT"; }

            FlatLabel.Text = zValueStatus;
            ZLabel.Text = zValueLabel;
        }

        private void StartStopButton_Clicked(object sender, EventArgs e)
        {
            if (_isMonitoring)
            {
                Accelerometer.Default.Stop();
                StartStopButton.Text = "Start";
                InitializeComponent();
            }
            else
            {
                Accelerometer.Default.Start(SensorSpeed.Game);
                StartStopButton.Text = "Stop";
            }
            _isMonitoring = !_isMonitoring;
        }
        

        private void CreditsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreditsPage());
        }

        private void RawDataButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RawDataPage());
        }


    }
}