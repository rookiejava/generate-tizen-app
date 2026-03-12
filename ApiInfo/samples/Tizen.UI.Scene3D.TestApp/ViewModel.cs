using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Scene3DTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        Dictionary<string, object> _propertyBag = new Dictionary<string, object>();
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(T value, [CallerMemberName] string name = "")
        {
            if (!_propertyBag.ContainsKey(name) || !_propertyBag[name].Equals(value))
            {
                _propertyBag[name] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        protected T Get<T>([CallerMemberName] string name = "")
        {
            if (_propertyBag.TryGetValue(name, out object value))
            {
                return (T)value;
            }
            return default;
        }
    }
}
