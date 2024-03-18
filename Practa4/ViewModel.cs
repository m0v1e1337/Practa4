using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace YourProjectNamespace
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Page currentPage;

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
