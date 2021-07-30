using BDD_Implementation.WebDriver;
using OpenQA.Selenium;
using BDD_Implementation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace BDD_Implementation.PageObjects
{
    public class HomePage
    {
        private static HomePage currentInstance;
        private readonly By loginFieldLocator = By.XPath("//input[@name = 'login']");
        private readonly By enterPasswordButtonLocator = By.XPath("//button[@data-testid= 'enter-password']");
        private readonly By passwordFieldLocator = By.XPath("//input[@name= 'password']");
        private readonly By enterButtonLocator = By.XPath("//button[@data-testid= 'login-to-mail']");
        private readonly By createAccountButtonLocator = By.XPath("//a[@href = '//account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=52848']");
        private readonly By errorMessageLocator = By.XPath("//div[@class = 'error svelte-1eyrl7y']");
        private readonly By domainsListLocator = By.Name("domain");

        private HomePage()
        {

        }

        public static HomePage Instance => currentInstance ?? (currentInstance = new HomePage());

        public void EnterLogin(string login)
        {
            Browser.Instance.GetDriver().FindElement(loginFieldLocator).WaitAndSendKeys(login);
        }

        public void ClickOnEnterPasswordButton()
        {
            Browser.Instance.GetDriver().FindElement(enterPasswordButtonLocator).WaitAndClick();
        }

        public void EnterPassword(string password)
        {
            Browser.Instance.GetDriver().FindElement(passwordFieldLocator).WaitAndSendKeys(password);
        }

        public void ClickOnEnterButton()
        {
            Browser.Instance.GetDriver().FindElement(enterButtonLocator).WaitAndClick();
        }

        public void Login(string login, string password)
        {
            EnterLogin(login);
            ClickOnEnterPasswordButton();
            EnterPassword(password);
            ClickOnEnterButton();
        }

        public void SelectDomain(string domain)
        {
            IWebElement domainsList = Browser.Instance.GetDriver().FindElement(domainsListLocator);
            SelectElement domains = new SelectElement(domainsList);
            switch (domain)
            {
                case "mail.ru":
                    domains.SelectByIndex(0);
                    break;
                case "inbox.ru":
                    domains.SelectByIndex(1);
                    break;
                case "list.ru":
                    domains.SelectByIndex(2);
                    break;
                case "bk.ru":
                    domains.SelectByIndex(3);
                    break;
                case "internet.ru":
                    domains.SelectByIndex(4);
                    break;
                default:
                    domains.SelectByIndex(0);
                    break;
            }
        }

        public bool VerifySuccessfullLogout()
        {
            return Wait.GetWait().Until(WaitConditions.IsElementDisplayed(Browser.Instance.GetDriver().WaitAndFindElement(createAccountButtonLocator)));
        }

        public bool VerifyErrorMessage(string message)
        {
            return Browser.Instance.GetDriver().WaitAndFindElement(errorMessageLocator).Text.Equals(message);
        }
    }
}
