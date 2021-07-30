using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDD_Implementation.Utils;
using BDD_Implementation.WebDriver;
using OpenQA.Selenium;

namespace BDD_Implementation.PageObjects
{
    public class HeaderPage
    {
        private static HeaderPage currentInstance;
        private readonly By emailAddressLocator = By.XPath("//span[@class = 'ph-project__user-name svelte-a0l97g']");

        private HeaderPage()
        {

        }

        public static HeaderPage Instance => currentInstance ?? (currentInstance = new HeaderPage());

        public bool VerifySuccessfullLogin(string login)
        {
            return Browser.Instance.GetDriver().WaitAndFindElement(emailAddressLocator).Text.Contains(login);
        }

        public void OpenProfileMenu()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(emailAddressLocator).WaitAndClick();
        }
    }
}
