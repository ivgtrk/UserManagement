using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserManagementModelNS.Domain
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        private UserRole role;
        private string hash;
        private bool isactive;


        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public UserRole Role
        {
            get => role;
            set { role = value; OnPropertyChanged(); }
        }
        public string Hash
        {
            get => hash;
            set { hash = value; OnPropertyChanged(); }
        }

        public bool IsActive
        {
            get => isactive;
            set { isactive = value; OnPropertyChanged(); }
        }

        public override string ToString()
        {
            return Name ?? "<NewUser>";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
