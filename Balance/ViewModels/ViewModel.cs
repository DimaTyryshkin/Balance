using System; 
using System.ComponentModel; 
using System.Runtime.CompilerServices; 

namespace Balance.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;
         
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
