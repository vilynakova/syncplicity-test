using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.pages
{
    internal class ManageUser:BasePage
    {
        private By UserRoleLocator = By.CssSelector("[class='user-property']");
        private By UsernameLocator = By.CssSelector("[class='full-name-div']");

        public ManageUser(IWebDriver driver) : base(driver)
        { }
        public string GetUserRole()
        {
            return this.Wrapper.GetTextFromElement(UserRoleLocator);
        }
        public string GetUsername()
        {
            return this.Wrapper.GetTextFromElement(UsernameLocator);
        }
        public void WaitPageToLoad()
        {
            this.WaitPageToLoad(UserRoleLocator);
        }
    }
}
