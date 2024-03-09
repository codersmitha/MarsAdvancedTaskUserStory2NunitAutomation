using AdvancedTaskUserStory2NunitAutomation.AssertHelpers;
using AdvancedTaskUserStory2NunitAutomation.DataModel;
using AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent.RenderingComponents;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent
{
    public class SkillspageFeatures : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string skillName = string.Empty;


        int cancelFlag = 0;
        ProfilePageNavigationTabs profileNavigationObj = new ProfilePageNavigationTabs();

        //LanguageAssertHelper languageAssertHelper = new LanguageAssertHelper();
        SkillsRenderingComponents skillsRenderingComponents = new SkillsRenderingComponents();

        //To capture the pop up message
        public void CapturePopupMessage()
        {

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actualMessage = messageBox.Text;

            IWebElement closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            closeMessageIcon.Click();

            Console.WriteLine(actualMessage);

        }
        //To get the last entered Language
        public void GetLastSkillName()
        {
            IWebElement skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//td[1]"));
            skillName = skillNameTextBox.Text;
        }
        //To get the first entered Language
        public void GetFirstSkillName()
        {
            IWebElement skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//td[1]"));
            skillName = skillNameTextBox.Text;
        }
        public void AddNewSkill(SkillsDataModel skillsDataModel)
        {

            skillsRenderingComponents.AddNewSkill(skillsDataModel);

            CapturePopupMessage();

            GetLastSkillName();

            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been added to your skills";
            else
                expectedMessage = "has been added to your skills";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been added successfully");

        }
        public void DeleteAllSkillRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='second']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {
                GetLastSkillName();

                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();

                rowcount--;

                CapturePopupMessage();

                if (!string.IsNullOrEmpty(skillName))
                    expectedMessage = skillName + " has been deleted";
                else
                    expectedMessage = "has been deleted";

                Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been deleted successfully");

                Thread.Sleep(2000);

            }
        }
        //To be continued
        public void AddNewSkillRecordWithInsufficientData(SkillsDataModel skillsDataModel)
        {
            skillsRenderingComponents.AddNewSkill(skillsDataModel);

            CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been added successfully");
        }

        public void AddAlreadyExistingSkillRecord(SkillsDataModel skillsDataModel)
        {
            skillsRenderingComponents.AddNewSkill(skillsDataModel);

            CapturePopupMessage();
            expectedMessage = "Duplicated data";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been added successfully");

        }

        public void AddDuplicateSkillWithDifferentLevel(SkillsDataModel skillsDataModel)
        {
            skillsRenderingComponents.AddNewSkill(skillsDataModel);

            CapturePopupMessage();
            expectedMessage = "Duplicated data";

            Assert.That(actualMessage.Equals(expectedMessage), "The duplicate language record has been added successfully");

        }
        /*public void AddFifthLanguage()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            if (rowcount == 4)
            {
                try
                {
                    IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));
                    addNewButton.Click();
                }
                catch (Exception ex)
                {
                    Assert.Pass(ex.Message);
                }
            }

        }*/
        public void CancelAddNewSkillRecord(SkillsDataModel skillsDataModel)
        {
            cancelFlag = 1;

            ////int rowcount = driver.FindElements(By.XPath("//div[@data-tab='second']//tbody")).Count;

            ////if (rowcount == 4)
            //{
            //    IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
            //    deleteButton.Click();

            //}

            skillsRenderingComponents.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            skillsRenderingComponents.AddNewSkill(skillsDataModel);
            cancelFlag = 0;


            GetLastSkillName();

            if (!skillName.Equals("Python Programming"))
            {
                Console.WriteLine("Language record cancelled before adding");
                Assert.That(!skillName.Equals("Python Programming"), "Language record not cancelled successfully");

            }
        }
        public void UpdateExistingSkillRecordWithFieldsEdited(SkillsDataModel skillsDataModel)
        {
            skillsRenderingComponents.EditExistingSkillRecord(skillsDataModel);

            CapturePopupMessage();
            GetFirstSkillName();
            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been updated to your skills";
            else
                expectedMessage = "has been updated to your skills";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been updated successfully");

        }
        public void UpdateExistingSkillRecordWithNoFieldsEdited()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Update']"));
            updateButton.Click();

            CapturePopupMessage();

            expectedMessage = "This skill is already added to your skill list.";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been updated successfully");

        }
        public void UpdateSkillRecordWithInsufficientData(SkillsDataModel skillsDataModel)
        {
            skillsRenderingComponents.EditExistingSkillRecord(skillsDataModel);

            CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been updated successfully");
        }
        public void UpdateExistingSkillRecordWithExistingSkillName(SkillsDataModel skillsDM1, SkillsDataModel skillsDM2)
        {
            //int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            //if (rowcount == 4)
            //{
            //    IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
            //    deleteButton.Click();

            //}
            skillsRenderingComponents.AddNewSkill(skillsDM1);
            Thread.Sleep(3000);
            UpdateExistingSkillRecordWithFieldsEdited(skillsDM2);
            //CapturePopupMessage();
            //expectedMessage = skillName + " has been updated to your skills";


        }
        public void CancelUpdateSkillRecord(SkillsDataModel skillsDataModel)
        {
            cancelFlag = 1;

            skillsRenderingComponents.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            skillsRenderingComponents.EditExistingSkillRecord(skillsDataModel);
            cancelFlag = 0;


            GetLastSkillName();

            if (!skillName.Equals("Music"))
            {
                Console.WriteLine("Skill record cancelled before Updating");
                Assert.That(!skillName.Equals("Music"), "Language record not cancelled successfully");

            }
        }


    }
}
