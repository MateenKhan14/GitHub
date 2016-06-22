using System.ComponentModel;

namespace PostApiCore.Model
{
     public abstract class ModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string propertyname)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler.Invoke(this, new PropertyChangedEventArgs(propertyname));
                }
            }

        }
    }

