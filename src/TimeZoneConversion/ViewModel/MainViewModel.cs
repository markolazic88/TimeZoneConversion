using System;
using GalaSoft.MvvmLight;

namespace TimeZoneConversion.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private DateTime time;

        public MainViewModel()
        {
            this.Time = DateTime.UtcNow;
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.Set(() => this.Time, ref this.time, value);
            }
        }
    }
}