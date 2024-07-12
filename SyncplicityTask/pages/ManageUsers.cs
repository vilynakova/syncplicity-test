using OpenQA.Selenium;
using SyncplicityTask.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.pages
{
    internal class ManageUsers : BasePage
    {
        private By AddUserButtonLocator = By.CssSelector("[href*='AddUser.aspx#users']");
        private By SearchInputLocator = By.CssSelector("[search='email']");
        private By MagnifierLocator = By.XPath("//*[@class='jqfilter-search-email-wrapper multi-wrapper js-changed']//i");
        // //*[@class="jqfilter-input-email js-empty js-changed"]
        public ManageUsers(IWebDriver driver) : base(driver)
        { }
        public  void WaitPageToLoad()
        {
            this.WaitPageToLoad(AddUserButtonLocator);
        }
        public void ClickAddaUser()
        {
            this.Wrapper.ClickElement(this.AddUserButtonLocator);
        }
        public void SearchForUser(string username)
        {
            this.Wrapper.EnterValue(this.SearchInputLocator, username);
            this.Wrapper.ClickElement(MagnifierLocator);
            this.Wrapper.ClickElement(By.LinkText(username));   

        }
    }
}
