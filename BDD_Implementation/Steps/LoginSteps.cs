using BDD_Implementation.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDD_Implementation.Steps
{
    [Binding]
    public class LoginSteps
    {
        [When(@"I enter '(.*)' to the login field")]
        public void EnterToTheLoginField(string login)
        {
            HomePage.Instance.EnterLogin(login);
        }

        [When(@"I click on Enter Password Button")]
        public void ClickOnEnterPasswordButton()
        {
            HomePage.Instance.ClickOnEnterPasswordButton();
        }

        [When(@"I enter '(.*)' to the password field")]
        public void EnterToThePasswordField(string password)
        {
            HomePage.Instance.EnterPassword(password);
        }

        [When(@"I click on Enter button")]
        public void ClickOnEnterButton()
        {
            HomePage.Instance.ClickOnEnterButton();
        }

        [Then(@"I see the user with '(.*)' is successfully logged in")]
        public void VerifySuccessfullyLogin(string username)
        {
            Assert.IsTrue(HeaderPage.Instance.VerifySuccessfullLogin(username));
        }

        [When(@"I login to the system with login '(.*)' and password '(.*)'")]
        public void LoginToTheSystemWithLoginAndPassword(string login, string password)
        {
            HomePage.Instance.Login(login, password);
        }

        [When(@"I open profile menu")]
        public void OpenProfileMenu()
        {
            HeaderPage.Instance.OpenProfileMenu();
        }

        [When(@"I click on logout button")]
        public void ClickOnLogoutButton()
        {
            ProfileMenuPage.Instance.ClickOnLogoutButton();
        }

        [Then(@"I can logout from the system successgully")]
        public void VerifySuccessfullLogout()
        {
            Assert.IsTrue(HomePage.Instance.VerifySuccessfullLogout());
        }

        [When(@"I select (.*)")]
        public void SelectDomain(string domain)
        {
            HomePage.Instance.SelectDomain(domain);
        }

        [Then(@"I see '(.*)' error message")]
        public void VerifyErrorMessage(string errorMessage)
        {
            Assert.IsTrue(HomePage.Instance.VerifyErrorMessage(errorMessage));
        }

    }
}
