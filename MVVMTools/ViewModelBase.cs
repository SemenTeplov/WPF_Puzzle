using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMTools
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnChanged<T>(out T prop, T value, [CallerMemberName] string proName = "")
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proName));
        }
    }
}
