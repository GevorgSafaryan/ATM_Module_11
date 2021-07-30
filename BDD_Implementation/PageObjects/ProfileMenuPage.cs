using BDD_Implementation.WebDriver;
using OpenQA.Selenium;
using BDD_Implementation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Implementation.PageObjects
{
    public class ProfileMenuPage
    {
        private static ProfileMenuPage currentInstance;
        private static readonly By logoutButtonLocator = By.XPath("//div[text()= 'Выйти']");

        private ProfileMenuPage()
        {

        }

        public static ProfileMenuPage Instance => currentInstance ?? (currentInstance = new ProfileMenuPage());

        public void ClickOnLogoutButton()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(logoutButtonLocator).WaitAndClick();
        }
    }
}
