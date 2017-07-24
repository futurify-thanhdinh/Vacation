using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.Models;

namespace Security.Setup
{
    public class PermissionsList
    {
        public const string MANAGER_PERMISSION = "MANAGER";
        public const string STAFF_PERMISSION = "STAFF";

        static PermissionsList()
        {
            GroupsPermissions = new PermissionsGroup[]
            {
                new PermissionsGroup
                    {
                        Name = "Administrator",
                        Permissions =
                            new Permission[]
                                {
                                    new Permission("ADMINISTRATOR", "Administrator"),
                                    new Permission("MANAGE_ACCOUNTS", "Manage accounts"),
                                    new Permission("MANAGE_BOOKINGS", "Manage bookings")
                                }
                    }
            };
        }

        public static PermissionsGroup[] GroupsPermissions { get; }
    }
}
