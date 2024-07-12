using OpenQA.Selenium;
using SyncplicityTask.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.pages
{
    internal abstract class BasePage
    {
        public readonly SeleniumWrapper Wrapper;
        protected BasePage(IWebDriver driver)
        {
            this.Wrapper = new SeleniumWrapper(driver);
        }
        public void WaitPageToLoad(By locator)
        {
            this.Wrapper.WaitElementToBeVisible(locator);
        }
        public void NavigateTo(By mainMenu, By subMenu)
        {
            this.Wrapper.ClickElement(mainMenu);
            this.Wrapper.ClickElement(subMenu);
        }
    }
}
