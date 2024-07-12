using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityTask.pages
{
    internal class AddNewUserPage : BasePage
    {
        public static By EmailInputLocator
        {
            get { return By.Id("txtUserEmails"); }
        }
        public static By RoleSelectorDropdownButtonLocator
        {
            get { return By.Id("roleselectdropdownbutton"); }
        }
        public static By UserRoleLocator
        {
            get { return By.CssSelector("//li[text()='User']"); }
        }
        public By GlobalAdministratorRoleLocator
        {
            get { return By.CssSelector("//li[text()='Global Administrator']"); }
        }

        public By NextButtonUserEmailLocator
        {
            get { return By.Id("nextButtonUserEmails"); }
        }
        public By NextButtonGroupMemebershipLocator
        {
            get { return By.Id("nextButtonGroupMembership"); }
        }
        private By VeiwEditExistingUsersLocator { get { return By.LinkText("View and edit existing users"); } }
        public By NextButtonFoldersLocator
        {
            get { return By.Id("nextButtonUserFolders"); }
        }
        public string AccountInfoSubPage
        {
            get { return "AddUser.aspx#users"; }
        }
        public string GroupMembershipPage
        {
            get { return "AddUser.aspx#groups"; }
        }
        public string SyncplicityFoldersPage
        {
            get { return "AddUser.aspx#folders"; }
        }
        public string SuccessfullyCreatedUserPage
        {
            get { return "AddUser.aspx#congratulations"; }
        }

        public AddNewUserPage(IWebDriver driver) : base(driver)
        { }
        public void SelectRole(By role)
        {
            this.Wrapper.ClickElement(RoleSelectorDropdownButtonLocator);
            this.Wrapper.ClickElement(role);
        }
        public void ClickNextButton(By NextButtonLocator)
        {
            this.Wrapper.ClickElement(NextButtonLocator);
        }
        public void EnterEmail(string email)
        {
            this.Wrapper.EnterValue(EmailInputLocator, email);
        }
        public void FastGoLastUserCreationPage()
        {
            this.ClickNextButton(this.NextButtonUserEmailLocator);
            this.Wrapper.WaitElementToBeVisible(NextButtonGroupMemebershipLocator);
            this.ClickNextButton(this.NextButtonGroupMemebershipLocator);
            this.Wrapper.WaitElementToBeVisible(this.NextButtonFoldersLocator);
            this.ClickNextButton(this.NextButtonFoldersLocator);
            this.Wrapper.WaitElementToBeVisible(VeiwEditExistingUsersLocator);
        }
        public void CreateNewUser(string newEmail,By roleLocator )
        {
            this.EnterEmail(newEmail);
            this.SelectRole(roleLocator);
            this.FastGoLastUserCreationPage();
        }
    }
}
