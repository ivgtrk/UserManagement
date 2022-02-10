using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UserManagementModelNS.Domain;
using UserManagementViewsNS.Factories;
using UserManagementViewsNS.Interfaces;

namespace UserManagementViewsNS.Views
{
    public partial class ControlPanel : UserControl, IView<Users>
    {
        public event EventHandler Changed = delegate { };
        private Users users;
        private Control currentControl;
        private BindingList<User> DvgUsers;
        private int currSelect;

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
                    currentControl.Parent = pnEditor;
                    currentControl.BringToFront();
                }
            }
        }


        public ControlPanel()
        {
            InitializeComponent();
            DvgUsers = new BindingList<User>();
            dgv1.DataSource = DvgUsers;
            dgv1.Columns[ 2 ].Visible = false;
            dgv1.Columns[ 3 ].Visible = false;
        }


        public void Build( Users users )
        {
            this.users = users;
            label1.Text = $"{users.Where( u => u.IsActive == true ).Select( n => n.Name ).FirstOrDefault()} : " +
                            $"{users.Where( u => u.IsActive == true ).Select( n => n.Role ).FirstOrDefault()}";

            DvgUsers.Clear();
            foreach ( User u in users )
                DvgUsers.Add( new User() 
                    { 
                        Name = u.Name,
                        Role = u.Role,
                        Hash = u.Hash,
                        IsActive = u.IsActive
                    } );
        }


        private void dgv1_SelectionChanged( object sender, EventArgs e )
        {
            if ( dgv1.SelectedRows.Count > 0 )
            {
                currSelect = dgv1.SelectedRows[ 0 ].Index;
                var obj = DvgUsers[ currSelect ];
                var view = AppLocator.GuiFactory.Create<IView<User>>();
                view.Changed += view_Changed;
                CurrentControl = view as Control;
                view.Build( obj );
                return;
            }

            CurrentControl = null;
        }


        void view_Changed( object sender, EventArgs e )
        {
            users[ currSelect ] = DvgUsers[ currSelect ];

            label1.Text = $"{users.Where( u => u.IsActive == true ).Select( n => n.Name ).FirstOrDefault()} : " +
                            $"{users.Where( u => u.IsActive == true ).Select( n => n.Role ).FirstOrDefault()}";
            //Build( users );
            Changed( null, EventArgs.Empty );
        }


        private void ControlPanel_Load( object sender, EventArgs e )
        {
            dgv1.ClearSelection();
            dgv1.SelectionChanged += dgv1_SelectionChanged;
        }
    }
}
