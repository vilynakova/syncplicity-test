using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.Menus
{
    public static class AdminSubMenus
    {
        public static By UserAccounts
        {
            get { return By.LinkText("User Accounts"); }
        }
        public static By Groups
        {
            get { return By.LinkText("Groups"); }
        }
    }
}

