using UserManagementModelNS.Domain;
using UserManagementModelNS.Factories;
using UserManagementViewsNS.Interfaces;
using UserManagementViewsNS.Views;


namespace UserManagementViewsNS.Factories
{
    public class GuiFactory : BaseFactory
    {
        public GuiFactory()
        {
            Register<IView<Authorize>, LoginPanel>();
            Register<IView<Users>, ControlPanel>();
            Register<IView<User>, EditPanel>();
        }
    }
}
