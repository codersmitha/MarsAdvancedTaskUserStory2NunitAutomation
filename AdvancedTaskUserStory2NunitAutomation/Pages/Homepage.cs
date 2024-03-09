using AdvancedTaskUserStory2NunitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages
{
    public class HomePage : CommonDriver
    {
        public void SignInActions()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            Thread.Sleep(3000);

            IWebElement SignInButton = driver.FindElement(By.XPath("//a[@class='item']"));
            SignInButton.Click();

        }
    }
}
