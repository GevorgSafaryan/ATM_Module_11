using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Implementation.Utils
{
    public static class Extensions
    {
        public static void WaitAndClick(this IWebElement element)
        {
            Wait.GetWait().Until(WaitConditions.ElementToBoClickable(element)).Click();
        }

        public static void WaitAndSendKeys(this IWebElement element, string input)
        {
            Wait.GetWait().Until(WaitConditions.ElementDisplayed(element)).SendKeys(input);
        }

        public static string WaitAndGetText(this IWebElement element, By locator)
        {
            return Wait.GetWait().Until(WaitConditions.ElementDisplayed(locator)).Text;
        }

        public static IWebElement WaitAndFindElement(this IWebDriver driver, By locator)
        {
            return Wait.GetWait().Until(dr => dr.FindElement(locator));
        }
    }
}
