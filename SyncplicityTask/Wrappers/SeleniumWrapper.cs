using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SyncplicityTask.Wrappers
{
    internal class SeleniumWrapper
    {
        public IWebDriver driver;
        public SeleniumWrapper(IWebDriver WebDriver)
        {
            this.driver = WebDriver;
        }
        public void WaitElementToBeVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitUserToBeRedirected(string url)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
        }
        public void ClickElement(By locator)
        {
            this.WaitElementToBeVisible(locator);
            IWebElement element = this.driver.FindElement(locator);
            element.Click();
        }
        public void EnterValue(By locator, string text)
        {
            this.WaitElementToBeVisible(locator);
            IWebElement passwordInputField = this.driver.FindElement(locator);
            passwordInputField.SendKeys(text);
        }
        public bool TryFindElement(By by, out IWebElement element)
        {

            try
            {
                element = driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                element = null;
                return false;
            }
            return true;
        }
        public bool IsElementVisible(By locator)
        {
            if (TryFindElement(locator, out IWebElement element))
            {

                return element.Displayed && element.Enabled;
            }
            else { return false; }
        }
        public string GetTextFromElement(By locator)
        {
            this.WaitElementToBeVisible(locator);
            return this.driver.FindElement(locator).Text;
        }

        public void PressEnterButton()
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Return);
        }       
    }
}
