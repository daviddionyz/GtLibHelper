using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GtLibHelper.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// View model base initial
        /// </summary>
        protected ViewModelBase() { }

        /// <summary>
        /// Property change event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property change with check
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}