using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.pages
{
    public static class RolesLocators
    {
        public static By UserRoleLocator
        {
            get { return By.CssSelector("//li[text()='User']"); }
        }
        public static By GlobalAdministratorRoleLocator
        {
            get { return By.XPath("//li[text()='Global Administrator']"); }
        }
    }
}

