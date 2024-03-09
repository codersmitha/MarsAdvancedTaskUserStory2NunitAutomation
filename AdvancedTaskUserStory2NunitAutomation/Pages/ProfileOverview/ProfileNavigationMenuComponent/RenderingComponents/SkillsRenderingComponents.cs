using AdvancedTaskUserStory2NunitAutomation.DataModel;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent.RenderingComponents
{
    public class SkillsRenderingComponents :CommonDriver
    {
        IWebElement? skillNameTextBox;
        IWebElement? chooseSkillLevelDD;

        IWebElement? addButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        IWebElement? deleteButton;
        int cancelFlag = 0;
        public void RenderAddComponents()
        {
            try
            {
                skillNameTextBox = driver.FindElement(By.Name("name"));
                chooseSkillLevelDD = driver.FindElement(By.Name("level"));

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
                skillNameTextBox = driver.FindElement(By.Name("name"));
                chooseSkillLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Cancel']"));
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


        public void AddNewSkill(SkillsDataModel skillsDataModel)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            RenderAddComponents();

            if (!string.IsNullOrEmpty(skillsDataModel.skillName))
            {
                skillNameTextBox?.Click();
                skillNameTextBox?.SendKeys(skillsDataModel.skillName);
            }
            if (!string.IsNullOrEmpty(skillsDataModel.skillLevel))
            {
                chooseSkillLevelDD?.Click();
                chooseSkillLevelDD?.SendKeys(skillsDataModel.skillLevel);
            }

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                addButton?.Click();
            }
            else
            { cancelFlag = 0; cancelButton?.Click(); }
        }

        public void EditExistingSkillRecord(SkillsDataModel skillsDataModel)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            RenderUpdateComponents();
            if (!skillsDataModel.skillName.Equals("No Change"))
            {
                if (string.IsNullOrEmpty(skillsDataModel.skillName))
                {
                    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.Click(skillNameTextBox);
                    actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                    actions.Perform();
                }
                else
                {
                    skillNameTextBox?.Clear();
                    chooseSkillLevelDD?.SendKeys(skillsDataModel.skillLevel);
                }
            }
            if (!skillsDataModel.skillLevel.Equals("No Change"))
            {
                chooseSkillLevelDD?.Click();
                if (!string.IsNullOrEmpty(skillsDataModel.skillLevel))
                    chooseSkillLevelDD?.SendKeys(skillsDataModel.skillLevel);

                else
                    chooseSkillLevelDD?.SendKeys("Language Level");
                chooseSkillLevelDD?.Click();
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
