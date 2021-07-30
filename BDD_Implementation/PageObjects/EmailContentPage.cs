using BDD_Implementation.WebDriver;
using OpenQA.Selenium;
using BDD_Implementation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDD_Implementation.PageObjects
{
    public class EmailContentPage
    {
        private static EmailContentPage currentInstance;
        private static int emailsCount;
        private readonly By firstemailLocator = By.XPath("(//a[@class = 'llct js-letter-list-item'])[1]");
        private readonly By sentEmailsSubjectLocator = By.XPath("//h2[@class = 'thread__subject']");
        private readonly By sentEmailsRecipientLocator = By.XPath("(//span[@class = 'letter-contact'])[2]");
        private readonly By sentEmailsBodyLocator = By.XPath("//div[@data-signature-widget= 'container']/../div[1]");
        private readonly By trashFolderLocator = By.XPath("//div[@class = 'nav__folder-clear']");
        private readonly By draftsFolderLocator = By.XPath("//a[@href = '/drafts/']");
        private readonly By sentFolderLocator = By.XPath("//a[@href = '/sent/']");
        private readonly By checkboxLocator = By.XPath("(//div[@class = 'checkbox__box checkbox__box_disabled'])[1]");

        private EmailContentPage()
        {

        }

        public static EmailContentPage Instance => currentInstance ?? (currentInstance = new EmailContentPage());

        public void OpenTheFirstEmailFormTheList()
        {
            int.TryParse(Regex.Match(Browser.Instance.GetDriver().WaitAndFindElement(draftsFolderLocator).GetAttribute("title"), @"\d+").Value, out emailsCount);
            Browser.Instance.GetDriver().FindElement(firstemailLocator).WaitAndClick();
        }

        public bool VerifyThatEmailDisappearsFromDraftsFolder()
        {
            Browser.Instance.Refresh();
            int.TryParse(Regex.Match(Browser.Instance.GetDriver().WaitAndFindElement(draftsFolderLocator).GetAttribute("title"), @"\d+").Value, out int emailsCountAfter);
            return emailsCountAfter == 0 || emailsCountAfter == emailsCount - 1;
        }

        public bool VerifySentEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = Browser.Instance.GetDriver().FindElement(sentEmailsRecipientLocator).GetAttribute("title").Equals(recipient);
            bool assertSubject = Browser.Instance.GetDriver().FindElement(sentEmailsSubjectLocator).Text.Equals(subject);
            bool assertBody = Browser.Instance.GetDriver().FindElement(sentEmailsBodyLocator).Text.Equals(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }
    }
}
