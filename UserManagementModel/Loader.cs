using System;
using System.IO;
using System.Text;
using UserManagementModelNS.Domain;
using UserManagementModelNS.Interfaces;

namespace UserManagementModelNS
{
    public class Loader : ILoader
    {
        public string FPath { get; private set; }
        public string FName { get; private set; }

        private bool IsFileExist
        {
            get => File.Exists( Path.Combine( FPath, FName ) );
        }


        public Loader()
        {
            FPath = AppDomain.CurrentDomain.BaseDirectory;
            FName = "Users.txt";
        }


        public Users Load()
        {
            Users usr = new Users();

            // Check if the file exist ...
            // If not, create it.
            if ( !IsFileExist )
            {
                if ( !Directory.Exists( FPath ) )
                    Directory.CreateDirectory( FPath );

                using ( FileStream fs = new FileStream( Path.Combine( FPath, FName ), FileMode.OpenOrCreate, FileAccess.Write ) )
                {
                }
            }

            string[] Lines = File.ReadAllLines( Path.Combine( FPath, FName ), Encoding.Default );

            if ( Lines.Length > 0 )
            {
                foreach ( string s in Lines )
                {
                    User u = new User
                    {
                        Name = s.Split( ':' )[ 0 ],
                        Role = ( UserRole ) Enum.GetValues( typeof( UserRole ) ).GetValue( int.Parse( s.Split( ':' )[ 1 ] ) ),
                        Hash = s.Split( ':' )[ 2 ]
                    };
                    usr.Add( u );
                }
            }
            else
                // Add default Admin
                usr.Add( new User() { Name = "admin", Role = UserRole.Administrator, Hash = Hash.GetHash( "admin" ) } );
            return usr;
        }

    }
}
