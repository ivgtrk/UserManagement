using System;
using System.Windows.Forms;
using UserManagementModelNS;
using UserManagementModelNS.Domain;
using UserManagementViewsNS.Interfaces;

namespace UserManagementViewsNS.Views
{
    public partial class EditPanel : UserControl, IView<User>
    {
        public event EventHandler Changed;
        private User user;

        public EditPanel()
        {
            InitializeComponent();
        }

        public void Build( User user )
        {
            this.user = user;
            
            tbName.Text = user.Name;
            tbRole.Text = user.Role.ToString();
            if ( user.IsActive ) tbRole.Enabled = false;
        }

        private void UpdateObject()
        {
            user.Name = tbName.Text;
            user.Role = ( UserRole ) Enum.Parse( typeof( UserRole ), tbRole.Text );
            Changed( this, EventArgs.Empty );
        }

        private void btApply_Click( object sender, EventArgs e )
        {
            UpdateObject();
        }
    }
}
