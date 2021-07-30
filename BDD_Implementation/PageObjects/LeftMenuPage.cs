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
    public class LeftMenuPage
    {
        private static LeftMenuPage currentInstance;
        private readonly By composeButtonLocator = By.XPath("//span[@class = 'compose-button__wrapper']");
        private readonly By draftsFolderLocator = By.XPath("//div[text() = 'Черновики']");
        private readonly By sentFolderLocator = By.XPath("//a[@href = '/sent/']");
        private readonly By activeFolderLocator = By.XPath("//a[@class = 'nav__item js-shortcut nav__item_active nav__item_shortcut nav__item_expanded_true nav__item_child-level_0']");

        private LeftMenuPage()
        {

        }

        public static LeftMenuPage Instace => currentInstance ?? (currentInstance = new LeftMenuPage());

        public void ClickOnComposeButton()
        {
            Wait.GetWait().Until(WaitConditions.ElementToBoClickable(composeButtonLocator)).Click();
        }

        public void OpenDraftsFolder()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(draftsFolderLocator).WaitAndClick();
            Wait.GetWait().Until(WaitConditions.ElementDisplayed(activeFolderLocator));
        }

        public void OpenSentFolder()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(sentFolderLocator).WaitAndClick();
            Wait.GetWait().Until(WaitConditions.ElementDisplayed(activeFolderLocator));
        }
    }
}
