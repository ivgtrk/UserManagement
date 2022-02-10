using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UserManagementModelNS.Domain;
using UserManagementViewsNS.Interfaces;


namespace UserManagementViewsNS.Views
{
    public partial class LoginPanel : UserControl, IView<Authorize>
    {
        private Authorize data;
        public event EventHandler Changed;

        public LoginPanel()
        {
            InitializeComponent();
            Changed += TextBoxReset;
        }

        public void Build( Authorize data )
        {
            this.data = data;
        }


        private void UpdateObject()
        {
            ControlForm cf = new ControlForm( data.Users ) { Owner = ParentForm };
            cf.Show();
            Parent.Hide();
            Changed( this, EventArgs.Empty );
        }


        private void btLogin_Click( object sender, EventArgs e )
        {
            if ( LoginDataValidator( tbLogin.Text, tbPassword.Text ) )
            {
                if ( data.IsValid( tbLogin.Text, tbPassword.Text ) )
                {
                    UpdateObject();
                    return;
                }

                MessageBox.Show( "Invalid Login Data!", "Authorization Fault", MessageBoxButtons.OK, MessageBoxIcon.Error );
                tbLogin.SelectAll();
                tbLogin.Focus();
            }
            else
            {
                MessageBox.Show( "Invalid character!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                tbLogin.SelectAll();
                tbLogin.Focus();
            }
        }


        private bool LoginDataValidator( string login, string passw )
        {
            char[] forbiddenChar = new char[] { '[', ']', '{', '}', ':', '<', '>', ',',
                                                ' ', '\\', '!', '@', '\'', '"', '$', '#',
                                                '%', '^', '&', '*', '(', ')', '`', '~',
                                                '+', '=', '/', '?', '|' };

            return !login.Any( c => forbiddenChar.Contains( c ) ) && login.Length > 2 && passw.Length > 4;
        }


        private void TextBoxReset( object sender, EventArgs e )
        {
            tbLogin.Text = "";
            tb_Leave( tbLogin, EventArgs.Empty );
            tbPassword.Text = "";
            tb_Leave( tbPassword, EventArgs.Empty );
        }


        #region tbInitalValue
        private void tb_Enter( object sender, EventArgs e )
        {
            var tb = sender as TextBox;
            tb.ForeColor = Color.Black;
            if ( tb.Text == "Type login" || tb.Text == "Type password" )
                tb.Text = "";
            if ( tb.Name == "tbPassword" )
                tb.PasswordChar = '*';
        }


        private void tb_Leave( object sender, EventArgs e )
        {
            var tb = sender as TextBox;
            if ( string.IsNullOrEmpty( tb.Text ) || string.IsNullOrWhiteSpace( tb.Text ) )
            {
                tb.ForeColor = Color.Gray;
                tb.Text = "Type ";
                switch ( tb.Name )
                {
                    case "tbLogin": tb.Text += "login"; break;
                    case "tbPassword": { tb.PasswordChar = '\0'; tb.Text += "password"; } break;
                }
            }
        }
        #endregion
    }
}
