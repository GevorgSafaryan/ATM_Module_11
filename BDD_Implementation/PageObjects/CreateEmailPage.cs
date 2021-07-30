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
    public class CreateEmailPage
    {
        private static CreateEmailPage currenInstance;
        private readonly By recipientFieldLocator = By.XPath("(//input[@class = 'container--H9L5q size_s--3_M-_'])[1]");
        private readonly By subjectFieldLocator = By.XPath("(//input[@class = 'container--H9L5q size_s--3_M-_'])[2]");
        private readonly By bodyLocator = By.XPath("//div[contains(@class, 'editable-container')]/div/div[1]");
        private readonly By sendButtonLocator = By.XPath("//span[@data-title-shortcut = 'Ctrl+Enter']");
        private readonly By saveButtonLocator = By.XPath("//span[@data-title-shortcut = 'Ctrl+S']");
        private readonly By closeNewEmailFormLocator = By.XPath("(//button[@class = 'container--2lPGK type_base--rkphf color_base--hO-yz'])[3]");
        private readonly By enteredRecipientLocator = By.XPath("//div[@class = 'container--3B3Lm status_base--wsRcM']");
        private readonly By draftedEmailBodyLocator = By.XPath("//div[@class = 'js-helper js-readmsg-msg']/div/div/div/div[1]");
        private readonly By closIconAfterSendingEmailLocator = By.XPath("//div[@class = 'layer__controls']//span[@class = 'button2__wrapper']");
        private readonly By footerLocator = By.XPath("//div[@class = 'compose-app__footer']");

        private CreateEmailPage()
        {

        }

        public static CreateEmailPage Instance => currenInstance ?? (currenInstance = new CreateEmailPage());

        public void FillRecipient(string recipient)
        {
            Browser.Instance.GetDriver().WaitAndFindElement(recipientFieldLocator).WaitAndSendKeys(recipient);
        }

        public void FillSubject(string subject)
        {
            Browser.Instance.GetDriver().WaitAndFindElement(subjectFieldLocator).WaitAndSendKeys(subject);
        }

        public void FillBody(string bodyText)
        {
            Browser.Instance.GetDriver().WaitAndFindElement(bodyLocator).WaitAndSendKeys(bodyText);
        }

        public void ClickOnSendButton()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(sendButtonLocator).WaitAndClick();
        }

        public void ClickOnSaveButton()
        {
            Browser.Instance.GetDriver().FindElement(saveButtonLocator).WaitAndClick();
        }
        public void CloseNewEmailForm()
        {
            Browser.Instance.GetDriver().FindElement(closeNewEmailFormLocator).WaitAndClick();
        }

        public bool VerifyDraftEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = Browser.Instance.GetDriver().WaitAndFindElement(enteredRecipientLocator).GetAttribute("title").Equals(recipient);
            bool assertSubject = Browser.Instance.GetDriver().WaitAndFindElement(subjectFieldLocator).GetAttribute("value").Equals(subject);
            bool assertBody = Browser.Instance.GetDriver().WaitAndFindElement(draftedEmailBodyLocator).Text.Equals(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }

        public void ClickOnCloseButtonAfterSendingEmail()
        {
            Browser.Instance.GetDriver().WaitAndFindElement(closIconAfterSendingEmailLocator).WaitAndClick();
        }
    }
}
