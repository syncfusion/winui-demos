#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;
    using Syncfusion.UI.Xaml.Core;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarDashboard : Page, IDisposable
    {
        Random random;
        private bool reverse;
        private DispatcherTimer timer;
        private ViewModel viewModel;
        private double speed;
        private double gear;
        private double rpm;

        public CarDashboard()
        {
            this.InitializeComponent();
            this.random = new Random();
            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50)
            };
            timer.Tick += timer_Tick;
            viewModel = new ViewModel();
            this.DataContext = viewModel;
        }

        void ReverseTimer_Tick()
        {
            speed -= .25 * gear * 2;
            viewModel.Speed = speed;
            if (viewModel.Speed <= 80)
            {
                reverse = false;
                gear = 2;
            }
        }

        void timer_Tick(object sender, object e)
        {
            if (viewModel.Fuel > 0 && viewModel.Temperature < 80)
            {
                if (viewModel.Temperature > 35)
                {
                    viewModel.Temperature += .05;
                }
                else
                {
                    viewModel.Temperature += 1;
                }

                if (viewModel.RPM >= 6.2)
                {
                    if (gear < 5)
                    {
                        gear += 1;
                        rpm -= 3;
                        viewModel.RPM = rpm;
                    }
                    else if (viewModel.RPM > 6.5)
                    {
                        rpm = 6.2;
                        viewModel.RPM = rpm;
                    }
                    else
                    {
                        rpm += 0.1;
                        viewModel.RPM = rpm;
                    }
                }
                else
                {
                    rpm += 0.1;
                    viewModel.RPM = rpm;
                }

                if (viewModel.Speed >= 80)
                {

                    if (viewModel.Speed >= 140 || reverse == true)
                    {
                        reverse = true;
                        ReverseTimer_Tick();

                    }
                    else
                    {
                        speed += .25 * gear;
                        viewModel.Speed = speed;
                    }
                }
                else if (!reverse)
                {
                    speed += .25 * gear;
                    viewModel.Speed = speed;
                }


            }
            else
            {
                speed = 0;
                viewModel.Speed = 0;
                rpm = 0;
                viewModel.RPM = 0;
                gear = 1;
                viewModel.Temperature = 0;
                viewModel.Torque = 0;
                reverse = false;
                if (viewModel.Fuel == 0 || viewModel.Temperature == 85)
                {
                    viewModel.Fuel = 100;
                    viewModel.Temperature = 0;
                }
            }

            viewModel.Fuel -= .25;
            int TorqueMedium = random.Next(40, 50);
            var _torque = viewModel.Speed / (2 * TorqueMedium);
            viewModel.Torque = Math.Round(_torque, 1, MidpointRounding.AwayFromZero);
        }

        private void RadialAxis_LabelPrepared(object sender, LabelPreparedEventArgs e)
        {
            e.LabelText = e.LabelText.Substring(0, 3);
        }

        private void DisposeObjects()
        {
            this.timer.Stop();
            this.timer.Tick -= timer_Tick;
            this.timer = null;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            timer.Start();
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            DisposeObjects();
            this.TorqueAxis.LabelPrepared -= this.RadialAxis_LabelPrepared;

#if WinUI_Desktop
            this.SpeedGauge.Dispose();
            this.RpmGauge.Dispose();
            this.TempGauge.Dispose();
            this.FuelGauge.Dispose();
            this.TorqueGauge.Dispose();
#endif
            this.DataContext = this.viewModel = null;
        }
    }

    public class ViewModel : NotificationObject
    {
        private double _speed;
        private double _torque;
        private double _RPM;
        private double _temperature;
        private double _fuel;
        public ViewModel()
        {
            Fuel = 100;
            Speed = 0;
            RPM = 0;
            Temperature = 0;
            _torque = 0.3;
        }
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                this.RaisePropertyChanged(nameof(Speed));
            }
        }

        public double RPM
        {
            get
            {
                return _RPM;
            }
            set
            {
                _RPM = value;
                this.RaisePropertyChanged(nameof(RPM));
            }
        }

        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                this.RaisePropertyChanged(nameof(Temperature));
            }
        }

        public double Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                _fuel = value;
                this.RaisePropertyChanged(nameof(Fuel));
            }
        }

        public double Torque
        {
            get
            {
                return _torque;
            }
            set
            {
                _torque = value;
                this.RaisePropertyChanged(nameof(Torque));
            }
        }
    }
}