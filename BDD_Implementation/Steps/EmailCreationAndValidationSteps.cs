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
    public class EmailCreationAndValidationSteps
    {
        [Given(@"I logged in to the system with login '(.*)' and password '(.*)'")]
        public void ILoggedInToTheSystemWithLoginAndPassword(string login, string password)
        {
            HomePage.Instance.Login(login, password);
        }

        [Given(@"I open create new email form")]
        public void OpenCreateNewEmailForm()
        {
            LeftMenuPage.Instace.ClickOnComposeButton();
        }

        [Given(@"I fille the Recipient, Subject and Body fileds with values '(.*)', '(.*)' and '(.*)'")]
        public void FilleTheRecipientSubjectAndBodyFiledsWithValuesAnd(string recipient, string subject, string body)
        {
            CreateEmailPage.Instance.FillRecipient(recipient);
            CreateEmailPage.Instance.FillSubject(subject);
            CreateEmailPage.Instance.FillBody(body);
        }

        [Given(@"I click on Save button")]
        public void ClickOnSaveButton()
        {
            CreateEmailPage.Instance.ClickOnSaveButton();
        }

        [Given(@"I close new email form")]
        public void CloseNewEmailForm()
        {
            CreateEmailPage.Instance.CloseNewEmailForm();
        }

        [Given(@"I open Drafts folder")]
        public void OpenDraftsFolder()
        {
            LeftMenuPage.Instace.OpenDraftsFolder();
        }

        [When(@"I open the first email from the lsit")]
        public void OpenTheFirstEmailFromTheLsit()
        {
            EmailContentPage.Instance.OpenTheFirstEmailFormTheList();
        }

        [Then(@"I see the Recipient, Subject and Body values eqaul to '(.*)', '(.*)' and '(.*)'")]
        public void VerifyTheContentOfTheOpenedEmail(string recipient, string subject, string body)
        {
            Assert.IsTrue(CreateEmailPage.Instance.VerifyDraftEmailsContent(recipient, subject, body));
        }

        [When(@"I send the email")]
        public void SendTheEmail()
        {
            CreateEmailPage.Instance.ClickOnSendButton();
        }

        [When(@"I close the opened window after sending the email")]
        public void CloseTheOpenedWindowAfterSendingTheEmail()
        {
            CreateEmailPage.Instance.ClickOnCloseButtonAfterSendingEmail();
        }

        [Then(@"I don't see that email in drafts folder")]
        public void VerifyThatEmailDisappearsFromDraftsFolder()
        {
            Assert.IsTrue(EmailContentPage.Instance.VerifyThatEmailDisappearsFromDraftsFolder());
        }
    }
}
