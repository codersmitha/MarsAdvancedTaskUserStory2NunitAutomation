using AdvancedTaskUserStory2NunitAutomation.DataModel;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages.ShareSkillComponent
{
    public class ShareSKillsRenderingComponents : CommonDriver
    {


        IWebElement? title;
        IWebElement? description;
        IWebElement? category;
        IWebElement? subcategory;
        IList<IWebElement>? tagList;
        IList<IWebElement>? tagRemoveList;
        IWebElement? servicetype0;
        IWebElement? servicetype1;
        IWebElement? locationtype;
        IWebElement? startdate;
        IWebElement? enddate;
        IWebElement? skilltradeT;
        IWebElement? skilltradeF;
        IWebElement? credit;
        IWebElement? worksamples;
        IWebElement? activeT;
        IWebElement? activeF;
        IWebElement? saveButton;
        IWebElement? cancelButton;

        string titleText = string.Empty;
        string descriptionText = string.Empty;
        int cancelFlag = 0;

        public void RenderShareSkillComponents()
        {
            try
            {
                Wait.WaitToBeVisible("Name", "title", 15);
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
                servicetype0 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']"));
                servicetype1 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']"));
                locationtype = driver.FindElement(By.Name("locationType"));
                startdate = driver.FindElement(By.Name("startDate"));
                enddate = driver.FindElement(By.Name("endDate"));
                skilltradeT = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='true']"));
                skilltradeF = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']"));
                worksamples = driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
                activeT = driver.FindElement(By.XPath("//input[@name='isActive'][@value='true']"));
                activeF = driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderSubcategoryComponent()
        {
            try
            {
                subcategory = driver.FindElement(By.Name("subcategoryId"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderCreditComponent()
        {
            try
            {
                credit = driver.FindElement(By.Name("charge"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement TagLocator(int index)
        {
            try
            {
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagList[index];
        }
        public IWebElement TagRemoveLocator(int index)
        {
            try
            {
                tagRemoveList = driver.FindElements(By.XPath("//a[@class='ReactTags__remove']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagRemoveList[index];
        }

        public string GetTitle()
        {
            return titleText;
        }
        public string GetDescription()
        {
            return descriptionText;
        }
        public void SetCancelFlag(int flag)
        {
            this.cancelFlag = flag;
        }


        public void AddShareSkills(ShareSkillsDataModel shareSkillsDataModel)
        {
            RenderShareSkillComponents();

            if (!string.IsNullOrEmpty(shareSkillsDataModel.title))
                title?.SendKeys(shareSkillsDataModel.title);

            if (!string.IsNullOrEmpty(shareSkillsDataModel.description))
                description?.SendKeys(shareSkillsDataModel.description);

            if (!string.IsNullOrEmpty(shareSkillsDataModel.category))
            {
                category?.SendKeys(shareSkillsDataModel.category);
                RenderSubcategoryComponent();
                if (!string.IsNullOrEmpty(shareSkillsDataModel.subcategory))
                    subcategory?.SendKeys(shareSkillsDataModel.subcategory);
            }

            if (!string.IsNullOrEmpty(shareSkillsDataModel.tag))
            {
                tagList?[0].SendKeys(shareSkillsDataModel.tag);
                tagList?[0].SendKeys(Keys.Enter);
            }

            if (shareSkillsDataModel.servicetype.Equals("1"))
            {
                servicetype1?.Click();
            }
            else if (shareSkillsDataModel.servicetype.Equals("0"))
            {
                servicetype0?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDataModel.locationtype))
            {
                locationtype?.SendKeys(shareSkillsDataModel.locationtype);
                locationtype?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDataModel.startdate))
            {
                startdate?.SendKeys(shareSkillsDataModel.startdate);
            }

            if (!string.IsNullOrEmpty(shareSkillsDataModel.enddate))
                enddate?.SendKeys(shareSkillsDataModel.enddate);

            if (shareSkillsDataModel.skilltrade.Equals("true"))
            {
                skilltradeT?.Click();
                tagList?[1].SendKeys(shareSkillsDataModel.skillexchange);
                tagList?[1].SendKeys(Keys.Enter);
            }
            else
            {
                skilltradeF?.Click();
                RenderCreditComponent();
                credit?.SendKeys(shareSkillsDataModel.credit);
            }

            if (!string.IsNullOrEmpty(shareSkillsDataModel.worksamples))
            {
                string filePath = @"F:\sample1.txt";
                worksamples?.Click();
                worksamples?.SendKeys(filePath);
            }

            if (shareSkillsDataModel.active.Equals("true"))
            {
                activeT?.Click();
            }
            else if (shareSkillsDataModel.active.Equals("false"))
            {
                activeF?.Click();
            }

            if (!string.IsNullOrEmpty(title?.GetAttribute("value")))
                titleText = title.GetAttribute("value");

            if (!string.IsNullOrEmpty(description?.Text))
                descriptionText = description.Text;

            if (cancelFlag == 0)
                saveButton?.Click();
            else
            {
                cancelFlag = 0;
                cancelButton?.Click();
            }
        }
    }
}
