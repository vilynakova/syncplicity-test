using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SyncplicityTask.Enums;
using SyncplicityTask.Menus;
using SyncplicityTask.pages;
using SyncplicityTask.Wrappers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SyncplicityTask
{
    public class Tests
    {
        private IWebDriver driver;
        private string userName = "syncplicity-technical-interview@dispostable.com";
        private string password = "s7ncplicit@Y";

        [SetUp]
        public void Setup()
        {
            string path = @"..\..\..\..\chromedriver.exe";
            driver = new ChromeDriver(path);
            driver.Navigate().GoToUrl("https://eu.syncplicity.com/");
        }


        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterEmail(userName);
            loginPage.ClickNextButton();
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            Assert.IsFalse(loginPage.IsLoginErrorMessageVisible());

        }
        [Test]
        public void Test2()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterEmail("userName");
            loginPage.ClickNextButton();
            Assert.IsTrue(loginPage.IsUsernameErrorMessageVisible());
            string error = loginPage.GetUsernameErrorMessage();
            Assert.That(error, Is.EqualTo("Please enter a valid email address."));
        }

        [Test]
        public void Test3()
        {
            //login
            LoginPage loginPage = new LoginPage(driver);
            loginPage.QuickLogin(userName, password);
            Assert.IsFalse(loginPage.IsLoginErrorMessageVisible());
            MainPage mainPage = new MainPage(driver);
            //navigate to Add new user page
            mainPage.NavigateTo(MainMenus.Admin, AdminSubMenus.UserAccounts);
            ManageUsers usersPage = new ManageUsers(driver);
            usersPage.WaitPageToLoad();
            usersPage.ClickAddaUser();
            AddNewUserPage addNewUserPage = new AddNewUserPage(driver);
            //create new user
            string newEmail = Faker.Internet.Email();
            addNewUserPage.CreateNewUser(newEmail, RolesLocators.GlobalAdministratorRoleLocator);
            Assert.IsTrue(driver.Url.Contains(addNewUserPage.SuccessfullyCreatedUserPage));
            //search for new created user
            addNewUserPage.NavigateTo(MainMenus.Admin, AdminSubMenus.UserAccounts);
            usersPage.SearchForUser(newEmail);
            ManageUser userPage = new ManageUser(driver);
            userPage.WaitPageToLoad();
            //verifications
            string ActualUsername = userPage.GetUsername();
            string ActualUserRole = userPage.GetUserRole();
            Assert.IsTrue(ActualUsername.Equals(newEmail));
            string userRole = Extension.GetDescription(Roles.GlobalAdministrator);
            Assert.IsTrue(ActualUserRole.Equals(userRole));
        }      

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}