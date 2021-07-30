﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Implementation.WebDriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("disable-infobars");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    driver = new ChromeDriver(options);
                    break;
                case "FF":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    break;
            }
            return driver;
        }
    }
}
