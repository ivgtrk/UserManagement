using System;

namespace UserManagementViewsNS.Interfaces
{
    interface IView<T>
    {
        event EventHandler Changed;
        void Build( T obj );
    }
}
