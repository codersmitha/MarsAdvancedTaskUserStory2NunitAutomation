using AdvancedTaskUserStory2NunitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent.RenderingComponents
{
    public class LanguageRenderingComponent : CommonDriver
    {
        IWebElement? languageTextBox;
        IWebElement? chooseLevelDD;

        IWebElement? addButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        int cancelFlag = 0;
        public void RenderAddComponents()
        {
            try
            {
                languageTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void RenderUpdateComponents()
        {
            try
            {
                languageTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }


        public void AddLanguage(LanguageDataModel languageDataModel)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            RenderAddComponents();

            if (!string.IsNullOrEmpty(languageDataModel.language))
            {
                languageTextBox?.Click();
                languageTextBox?.SendKeys(languageDataModel.language);
            }
            if (!string.IsNullOrEmpty(languageDataModel.level))
            {
                chooseLevelDD?.Click();
                chooseLevelDD?.SendKeys(languageDataModel.level);
            }

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                addButton?.Click();
            }
            else
            { cancelFlag = 0; cancelButton?.Click(); }
        }

        public void EditLanguageRecord(LanguageDataModel languageDataModel)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            RenderUpdateComponents();
            if (!languageDataModel.language.Equals("No Change"))
            {
                if (string.IsNullOrEmpty(languageDataModel.language))
                {
                    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.Click(languageTextBox);
                    actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                    actions.Perform();
                }
                else
                {
                    languageTextBox?.Clear();
                    languageTextBox?.SendKeys(languageDataModel.language);
                }
            }
            if (!languageDataModel.level.Equals("No Change"))
            {
                chooseLevelDD?.Click();
                if (!string.IsNullOrEmpty(languageDataModel.level))
                    chooseLevelDD?.SendKeys(languageDataModel.level);

                else
                    chooseLevelDD?.SendKeys("Language Level");
                chooseLevelDD?.Click();
            }


            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {

                updateButton?.Click();
            }
            else
            { cancelFlag = 0; cancelButton?.Click(); }

        }
    }
}
        
    


