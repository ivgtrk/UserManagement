using System;
using System.Windows.Forms;
using UserManagementModelNS.Domain;
using UserManagementModelNS.Interfaces;
using UserManagementViewsNS.Factories;
using UserManagementViewsNS.Interfaces;


namespace UserManagementViewsNS
{
    public partial class LoginForm : Form
    {
        private readonly Authorize users;
        private Control currentControl;

        /// <summary>
        /// Current control reflects top-level data object
        /// </summary>
        private Control CurrentControl
        {
            get { return currentControl; }
            set
            {
                if ( currentControl != null )
                    currentControl.Dispose();

                currentControl = value;
                if ( currentControl != null )
                {
                    currentControl.Dock = DockStyle.Fill;
                    currentControl.Parent = this;
                    currentControl.BringToFront();
                }
            }
        }


        public LoginForm()
        {
            InitializeComponent();
            Select( false, false );
            users = new Authorize();
            CreateNewControl();
        }


        void CreateNewControl()
        {
            var loader = AppLocator.ModelFactory.Create<ILoader>();
            users.Users = loader.Load();
            CurrentControl = ( Control ) AppLocator.GuiFactory.Create<IView<Authorize>>();
            // Build control
            ( CurrentControl as IView<Authorize> ).Build( users );
        }
    }
}
