using System.Collections.Generic;

namespace UserManagementModelNS.Domain
{
    public class Authorize : List<User>
    {
        public Users Users { get; set; }

        public bool IsValid( string login, string password )
        {
            foreach ( User u in Users )
            {
                if ( login == u.Name && Hash.GetHash( password ) == u.Hash )
                {
                    u.IsActive = true;
                    return true;
                }
            }
            return false;
        }
    }
}
