using UserManagementModelNS.Interfaces;

namespace UserManagementModelNS.Factories
{
    public class ModelFactory : BaseFactory
    {
        public ModelFactory()
        {
            Register<ILoader, Loader>();
        }
    }
}
