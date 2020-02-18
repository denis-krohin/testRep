using Autodesk.Revit.UI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIScript356346436
{
    class Regedit
    {
        public void CreateRegeditKey()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey LocalRegister = currentUserKey.CreateSubKey("Local Register");
            LocalRegister = currentUserKey.OpenSubKey("Local Register", true);
            RegistryKey SetupControlSet = LocalRegister.CreateSubKey("SetupControlSet");
            SetupControlSet.SetValue("Setup", "F16_DR8E_154B311AF5C");
            SetupControlSet.Close();
            LocalRegister.Close();
        }

        public bool getAcceess()
        {
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"Local Register\SetupControlSet\"))
            if (Key != null)
            {
                string val = Key.GetValue("Setup").ToString();
                if (val != null)
                { return true; }
                else
                { return false;  }
            }
            else
            { return false; }
        }
    }
}
