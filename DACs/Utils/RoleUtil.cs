using DACs.Controls;
using DACs.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Utils
{
    public static class RoleUtil
    {
        public static Dictionary<Role, List<string>> Permissions = new Dictionary<Role, List<string>>()
        {
            { Role.Admin, new List<string> {
                "btnMenuHome",
                "btnMenuSale",
                "btnMenuProduct",
                "btnMenuStore",
                "btnMenuSupplier",
                "btnMenuReport",
                "btnMenuAccount",
                "btnMenuCustomer"} },
            { Role.Staff, new List<string> {
                "btnMenuHome",
                "btnMenuSale",
                "btnMenuSupplier",
                "btnMenuProduct",
                "btnMenuCustomer"
            } },
            { Role.StoreStaff, new List<string> { 
                "btnMenuHome",
                "btnMenuProduct",
                "btnMenuStore",
                "btnMenuSupplier" } }
        };

        public static bool Accessible(Role role, string feature)
        {
            return Permissions.ContainsKey(role) && Permissions[role].Contains(feature);
        }

        public static void ApplyRole(Role currentRole, Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Button btn)
                {
                    btn.Enabled = Accessible(currentRole, btn.Name);
                }
            }
        }

    }
}
