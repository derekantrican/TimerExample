using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerExample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private INotifyPropertyChanged targetModel;

        /// <summary>
        /// Default parameterless constructor for design time data only
        /// </summary>
        public BaseViewModel()
        {

        }

        public BaseViewModel(INotifyPropertyChanged aTargetModel)
        {
            SetTargetModel(aTargetModel);
        }
        public INotifyPropertyChanged TargetModel
        {
            get
            {
                return targetModel;
            }
        }

        protected virtual void SetTargetModel(INotifyPropertyChanged aTargetModel)
        {
            if (aTargetModel != null)
            {
                targetModel = aTargetModel;
                targetModel.PropertyChanged +=
                    ((object sender, PropertyChangedEventArgs e) => FirePropertyChanged(e.PropertyName));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">(optional) The name of the property that
        /// changed.</param>
        public void FirePropertyChanged([CallerMemberName] string aPropertyName = null)
        {
            //// Only raise property changed events if there's a UI dispatcher (null here means we're in silent (no UI) mode).
            //if (DispatcherUtils.UIDispatcher != null)
            //{
            //    DispatcherUtils.CheckInvokeOnUI(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)));
            //}
            //else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
            }
        }

        /// <summary>
        /// Occurs after a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
