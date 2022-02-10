using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagementModelNS.Domain;

namespace UserManagementModelNS.Interfaces
{
    /// <summary>
    /// Can save and load RegisteredUsers
    /// </summary>
    public interface ILoader
    {
        Users Load();
        //void Save(Groups groups);
    }
}
