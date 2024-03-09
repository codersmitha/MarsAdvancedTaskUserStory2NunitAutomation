using AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.AboutMeComponent;
using AdvancedTaskUserStory2NunitAutomation.ReportClass;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Test
{
    [TestFixture]
    public class AboutMeTest : CommonDriver
    {
        
        
        AboutmePageFeatures aboutmePageFeaturesObj;
        ReportGeneration? reportGenerate;
        public AboutMeTest()
        {
            aboutmePageFeaturesObj = new AboutmePageFeatures();
        }


        [OneTimeSetUp]
        public void ReportMethod()
        {
            reportGenerate = new ReportGeneration();
            reportGenerate?.GenerateExtentReport(@"Reports\AboutMeExtentReport.html");

        }


        [SetUp]
        public void SetUp()
        {
            reportGenerate?.CreateTest();
        }


        [Test, Order(1), Description("This test selects an availability option from the dropdown")]
        public void TestSelectAvailabilityOption()
        {

            aboutmePageFeaturesObj.SelectAvailabilityOption("Part Time", 0);

        }
        [Test, Order(2), Description("This test changes the availability option already selected")]
        public void TestChangeSelectedAvailabilityOption()
        {

            aboutmePageFeaturesObj.SelectAvailabilityOption("Full Time", 0);

        }
        [Test, Order(3), Description("This test cancels the availability selection")]
        public void TestCancelSelectedAvailabilityOption()
        {

            aboutmePageFeaturesObj.SelectAvailabilityOption("", 1);

        }
        [Test, Order(4), Description("This test selects an hours option from the dropdown")]
        public void TestSelectHoursOption()
        {

            aboutmePageFeaturesObj.SelectHoursOption("Less than 30hours a week", 0);

        }
        [Test, Order(5), Description("This test changes the hours option already selected")]
        public void TestChangeSelectedHoursOption()
        {

            aboutmePageFeaturesObj.SelectHoursOption("As needed", 0);

        }
        [Test, Order(6), Description("This test cancels the hours selection")]
        public void TestCancelSelectedHoursOption()
        {

            aboutmePageFeaturesObj.SelectHoursOption("", 1);

        }
        [Test, Order(7), Description("This test selects a target option from the dropdown")]
        public void TestSelectTargetOption()
        {

            aboutmePageFeaturesObj.SelectTargetOption("Between $500 and $1000 per month", 0);

        }
        [Test, Order(8), Description("This test changes the target option already selected")]
        public void TestChangeTargetHoursOption()
        {

            aboutmePageFeaturesObj.SelectTargetOption("More than $1000 per month", 0);

        }
        [Test, Order(9), Description("This test cancels the target selection")]
        public void TestCancelSelectedTargetOption()
        {

            aboutmePageFeaturesObj.SelectTargetOption("", 1);

        }

        [TearDown]

        public void AfterTest()
        {
            reportGenerate?.UpdateTest();
            close();

        }
    }
}

