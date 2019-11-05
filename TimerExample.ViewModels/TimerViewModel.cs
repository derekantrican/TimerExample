using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ViewModelTools;

namespace TimerExample.ViewModels
{
    public class TimerViewModel : BaseViewModel
    {

        #region Private Properties
        private int timerValue = 0;
        private int timerOverrideValue = 0;
        private int incrementalValue = 0;
        #endregion Private Properties

        #region Public Properties
        /// <summary>
        /// Number of seconds since application was started
        /// </summary>
        public int TimerValue
        {
            get
            {
                return timerValue;
            }
            set
            {
                timerValue = value;
                FirePropertyChanged(nameof(TimerValue));
            }
        }

        /// <summary>
        /// The value to override the timer with
        /// </summary>
        public int TimerOverrideValue
        {
            get
            {
                return timerOverrideValue;
            }
            set
            {
                timerOverrideValue = value;
                FirePropertyChanged(nameof(TimerOverrideValue));
            }
        }

        /// <summary>
        /// A number that simply increments
        /// </summary>
        public int IncrementalValue
        {
            get
            {
                return incrementalValue;
            }
            set
            {
                incrementalValue = value;
                FirePropertyChanged(nameof(IncrementalValue));
            }
        }
        #endregion Public Properties


        #region Constructor
        public TimerViewModel(bool startTimer = true) : base(null)
        {
            if (startTimer)
                InitTimer();
        }
        #endregion Constructor


        #region Commands
        private ICommand resetTimerCommand;
        public ICommand ResetTimerCommand
        {
            get
            {
                if (resetTimerCommand == null)
                    resetTimerCommand = new RelayCommand(ResetTimer, param => { return true; });
                return resetTimerCommand;
            }
        }

        private ICommand setTimerCommand;
        public ICommand SetTimerCommand
        {
            get
            {
                if (setTimerCommand == null)
                    setTimerCommand = new RelayCommand(SetTimer, param => { return true; });
                return setTimerCommand;
            }
        }

        private ICommand incrementAmountCommand;
        public ICommand IncrementAmountCommand
        {
            get
            {
                if (incrementAmountCommand == null)
                    incrementAmountCommand = new RelayCommand(IncrementAmount, param => { return true; });
                return incrementAmountCommand;
            }
        }
        #endregion Commands


        #region Private Methods
        private void InitTimer()
        {
            Thread thread = new Thread(RunTimer);
            thread.Start();
        }

        private void RunTimer()
        {
            while (true)
            {
                TimerValue++;
                Thread.Sleep(1000);
            }
        }

        private void ResetTimer(object obj)
        {
            TimerValue = 0;
        }

        private void SetTimer(object obj)
        {
            if (TimerOverrideValue > 0)
                TimerValue = TimerOverrideValue;
        }

        private void IncrementAmount(object obj)
        {
            IncrementalValue++;
        }
        #endregion Private Methods
    }
}
