using System.Linq;
using System.Windows.Forms;
using UserManagementModelNS.Domain;
using UserManagementViewsNS.Factories;
using UserManagementViewsNS.Interfaces;


namespace UserManagementViewsNS
{
    public partial class ControlForm : Form
    {
        private readonly Users users;
        private Control currentControl;

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

        public ControlForm( Users users )
        {
            InitializeComponent();
            Select( false, false );
            this.users = users;
            CreateNewControl();
        }

        private void ControlForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            foreach ( User u in users )
                u.IsActive = false;
            LoginForm loginForm = Owner as LoginForm;
            loginForm.Show();
        }

        void CreateNewControl()
        {
            CurrentControl = ( Control ) AppLocator.GuiFactory.Create<IView<Users>>();
            ( CurrentControl as IView<Users> ).Build( users );
        }
    }
}
