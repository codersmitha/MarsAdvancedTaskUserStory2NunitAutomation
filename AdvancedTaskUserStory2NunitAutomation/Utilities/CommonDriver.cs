using AdvancedTaskUserStory2NunitAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Utilities
{
    [SetUpFixture]
    public class CommonDriver
    {


        public static IWebDriver driver;

        HomePage? homePageObj;
        LoginWindowPage? loginWindowPageObj;

        [SetUp]

        public void beforeTest()
        {
            homePageObj = new HomePage();
            loginWindowPageObj = new LoginWindowPage();
            Initialize();
            homePageObj.SignInActions();
            loginWindowPageObj.LoginActions();

            Thread.Sleep(2000);
            
        }

        public void Initialize()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }

        public void close()
        {
            driver?.Quit();
        }
            



    }
}
