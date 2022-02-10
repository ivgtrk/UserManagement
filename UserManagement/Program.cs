using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementViewsNS;
using System.Windows.Forms;
using UserManagementModelNS.Factories;
using UserManagementViewsNS.Factories;

namespace UserManagementNS
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //start error handler
            ExceptionHandler.Init();


            //create standard factories
            AppLocator.GuiFactory = new GuiFactory();
            AppLocator.ModelFactory = new ModelFactory();


            //run app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new LoginForm() );
        }
    }
}
