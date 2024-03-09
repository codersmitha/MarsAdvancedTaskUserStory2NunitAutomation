using AdvancedTaskUserStory2NunitAutomation.DataModel;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages
{
    public class LoginWindowPage : CommonDriver
    {
        LoginDataModel loginData;
        JSONDataReader jsonObj;
        IWebElement? emailIdTextBox;
        IWebElement? passWordTextBox;
        IWebElement? loginButton;
        public LoginWindowPage()
        {
            loginData = new LoginDataModel();
            jsonObj = new JSONDataReader();
        }

        public void RenderComponents()
        {
            try
            {
                Wait.WaitToBeClickable("XPath", "//*[@placeholder='Email address']", 2);
                emailIdTextBox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passWordTextBox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GetLoginData()
        {
            jsonObj.SetDataPath("login");
            loginData = jsonObj.ReadLoginJsonData();
        }
        public void LoginActions()
        {

            RenderComponents();
            GetLoginData();


            emailIdTextBox?.Click();
            emailIdTextBox?.Clear();
            emailIdTextBox?.SendKeys(loginData.email);


            passWordTextBox?.Click();
            passWordTextBox?.Clear();
            passWordTextBox?.SendKeys(loginData.password);


            loginButton?.Click();

        }
    }
}
