using UserManagementModelNS.Factories;

namespace UserManagementViewsNS.Factories
{
    public static class AppLocator
    {
        public static GuiFactory GuiFactory { get; set; }
        public static ModelFactory ModelFactory { get; set; }
    }
}
