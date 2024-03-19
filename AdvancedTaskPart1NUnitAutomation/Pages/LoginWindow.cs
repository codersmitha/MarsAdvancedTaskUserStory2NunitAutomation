﻿using AdvancedTaskPart1NUnitAutomation.DataModel;
using AdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1NUnitAutomation.Pages
{
    public class LoginWindow : CommonDriver
    {
        LoginDM loginData;
        JSONReader jsonObj;
        IWebElement? emailIdTextBox;
        IWebElement? passWordTextBox;
        IWebElement? loginButton;
        public LoginWindow()
        {
            loginData = new LoginDM();
            jsonObj = new JSONReader();
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
