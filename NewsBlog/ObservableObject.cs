using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog
{
    [Serializable]
    public class ObservableObject : INotifyPropertyChanged
    {
        [NonSerialized]
        private PropertyChangedEventHandler _PropertyChanged;

        public virtual event PropertyChangedEventHandler PropertyChanged
        {
            add { _PropertyChanged += value; }
            remove { _PropertyChanged -= value; }
        }

        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            _PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName]string prop = "")
        {
            field = value;
            OnPropertyChanged(prop);
        }
    }
}
