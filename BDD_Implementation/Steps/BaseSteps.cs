using BDD_Implementation.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDD_Implementation.Steps
{
    [Binding]
    public sealed class BaseSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Browser.Instance.Navigate(Configuration.URL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Instance.Quit();
        }
    }
}
