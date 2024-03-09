using AdvancedTaskUserStory2NunitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent.RenderingComponents
{
    public class AboutMeRenderingComponents : CommonDriver
    {
        IWebElement? editAvailability;
        IWebElement? editHours;
        IWebElement? editEarnTarget;

        IWebElement? chooseDropDown;

        IWebElement? removeIcon;
        public void RenderAvailabilityComponents()
        {
            try
            {
                editAvailability = driver.FindElement(By.XPath("//div[2][@class='item']//i[@class='right floated outline small write icon']"));
                editAvailability?.Click();
                Thread.Sleep(1000);

                chooseDropDown = driver.FindElement(By.Name("availabiltyType"));

                removeIcon = driver.FindElement(By.XPath("//div[2][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderHourComponents()
        {
            try
            {
                editHours = driver.FindElement(By.XPath("//div[3][@class='item']//i[@class='right floated outline small write icon']"));
                editHours?.Click();
                Thread.Sleep(1000);

                chooseDropDown = driver.FindElement(By.Name("availabiltyHour"));

                removeIcon = driver.FindElement(By.XPath("//div[3][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderTargetComponents()
        {
            try
            {
                editEarnTarget = driver.FindElement(By.XPath("//div[4][@class='item']//i[@class='right floated outline small write icon']"));
                editEarnTarget?.Click();
                Thread.Sleep(1000);

                chooseDropDown = driver.FindElement(By.Name("availabiltyTarget"));

                removeIcon = driver.FindElement(By.XPath("//div[4][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void EditAvailabilityProfile(string option, int flag)
        {
            RenderAvailabilityComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                chooseDropDown?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                removeIcon?.Click();
            }
        }
        public void EditHoursProfile(string option, int flag)
        {
            RenderHourComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                chooseDropDown?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                removeIcon?.Click();
            }

        }
        public void EditTargetProfile(string option, int flag)
        {
            RenderTargetComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                chooseDropDown?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                removeIcon?.Click();
            }

        }
    }
}
