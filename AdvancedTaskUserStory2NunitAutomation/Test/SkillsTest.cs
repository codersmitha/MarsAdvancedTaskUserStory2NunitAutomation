using AdvancedTaskUserStory2NunitAutomation.DataModel;
using AdvancedTaskUserStory2NunitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponent;
using AdvancedTaskUserStory2NunitAutomation.ReportClass;
using AdvancedTaskUserStory2NunitAutomation.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Test
{
    [TestFixture]
    public class SkillsTest : CommonDriver
    {

        List<SkillsDataModel> skillList;
        SkillspageFeatures skillsPageFeaturesObj;
        ProfilePageNavigationTabs profilePageNavigationTabsObj;
        ReportGeneration? reportGenerate;
        public SkillsTest()
        {
            skillList = new List<SkillsDataModel>();
            skillsPageFeaturesObj = new SkillspageFeatures();
            profilePageNavigationTabsObj = new ProfilePageNavigationTabs();
        }


        [OneTimeSetUp]
        public void ReadJSON()
        {
            reportGenerate = new ReportGeneration();
            reportGenerate?.GenerateExtentReport(@"Reports\SkillsExtentReport.html");
            JSONDataReader jsonObj = new JSONDataReader();
            jsonObj.SetDataPath("skills");
            skillList = jsonObj.ReadSJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            reportGenerate?.CreateTest();
            profilePageNavigationTabsObj?.SelectSkillsTab();
        }


        [Test, Order(1), Description("This test deletes all Skill Records")]
        public void TestDeleteAllSkillRecords()
        {

            skillsPageFeaturesObj.DeleteAllSkillRecords();

        }
        [Test, Order(2), Description("This test adds a new Skill Record")]
        public void TestCreateNewSkillRecord()
        {
            string s1 = skillList[0].skillName;
            string l = skillList[0].skillLevel;
            Console.WriteLine(s1);
            Console.WriteLine(l);
            skillsPageFeaturesObj.AddNewSkill(skillList[0]);

        }
        [Test, Order(3), Description("This test adds new Skill Record with NULL data in both fields")]
        public void TestCreateNewSkillRecordWithAllNullData()
        {

            skillsPageFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[1]);
        }
        [Test, Order(4), Description("This test adds new Skill Record without selecting any level and providing valid data in skill text box")]
        public void TestCreateNewSkillRecordWithLevelNotSelected()
        {

            skillsPageFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[2]);

        }
        [Test, Order(5), Description("This test adds new Skill Record without entering any skill in text box and selecting a valid level from dropdown")]
        public void TestCreateNewSkillRecordWithValidLevelAndEmptyTextBox()
        {


            skillsPageFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[3]);

        }
        [Test, Order(6), Description("This test adds an already existing Skill Record")]
        public void TestCreateAlreadyExistingSkillRecord()
        {

            skillsPageFeaturesObj.AddAlreadyExistingSkillRecord(skillList[0]);

        }
        [Test, Order(7), Description("This test adds a duplicate Skill with different level")]
        public void TestCreateDuplicateSkillWithDifferentLevel()
        {

            skillsPageFeaturesObj.AddDuplicateSkillWithDifferentLevel(skillList[4]);

        }
        [Test, Order(8), Description("This test adds a new Skill Name with Special Characters and Numbers")]
        public void TestCreateSkillRecordWithSpecialCharactersAndNumbers()
        {

            skillsPageFeaturesObj.AddNewSkill(skillList[5]);

        }
        [Test, Order(9), Description("This test adds a new Skill with more than 500 characters")]
        public void TestCreateSkillRecordWithlLongName()
        {

            skillsPageFeaturesObj.AddNewSkill(skillList[6]);

        }
        [Test, Order(10), Description("This test adds a new Skill with Only Spaces")]
        public void TestCreateLanguageRecordWithOnlySpacesInSkillTextBox()
        {

            skillsPageFeaturesObj.AddNewSkill(skillList[7]);

        }
        [Test, Order(11), Description("This test Cancels a Skill record before adding")]
        public void TestCancelAddSkillRecord()
        {

            skillsPageFeaturesObj.CancelAddNewSkillRecord(skillList[8]);

        }
        [Test, Order(12), Description("This test updates an existing Skill Record with both fields edited")]
        public void TestUpdateSkillRecordWithBothFieldsEdited()
        {

            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[8]);

        }
        [Test, Order(13), Description("This test updates an existing Skill Record without editing any fields")]
        public void TestUpdateSkillRecordWithNoFieldsEdited()
        {

            skillsPageFeaturesObj.UpdateExistingSkillRecordWithNoFieldsEdited();

        }
        [Test, Order(14), Description("This test updates existing Skill Record with NULL data in both fields")]
        public void TestUpdateSkillRecordWithAllNullData()
        {

            skillsPageFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[1]);
        }
        [Test, Order(15), Description("This test updates existing Skill Record by deleting the skill in text box and not changing the level")]
        public void TestUpdateSkillRecordWithValidLevelAndEmptyTextBox()
        {


            skillsPageFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[9]);

        }
        [Test, Order(16), Description("This test updates existing Skill Record without editing skill in text box and not selecting any level")]
        public void TestUpdateSkillRecordWithoutSelectingLevel()
        {


            skillsPageFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[10]);

        }
        [Test, Order(17), Description("This test updates existing Skill Record by changing only the skill")]
        public void TestUpdateSkillRecordByChangingOnlySkill()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[11]);

        }
        [Test, Order(18), Description("This test updates existing Skill Record by changing only level")]
        public void TestUpdateSkillRecordByChangingOnlyLevel()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[12]);

        }
        [Test, Order(19), Description("This test updates existing Skill Record with an existing skill name with different level")]
        public void TestUpdateSkillRecordWithExistingSkillName()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithExistingSkillName(skillList[13], skillList[14]);

        }
        [Test, Order(20), Description("This test updates existing Skill Record with Special Characters and Numbers")]
        public void TestUpdateSkillRecordWithSpecialCharacters()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[15]);

        }
        [Test, Order(21), Description("This test updates existing Skill Record with more than 500 characters")]
        public void TestUpdateLanguageRecordWithLongLanguageName()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[16]);

        }
        [Test, Order(22), Description("This test updates existing Skill Record with only Spaces")]

        public void TestUpdateSkillRecordWithOnlySpacesInSkill()
        {


            skillsPageFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[17]);

        }
        [Test, Order(23), Description("This test Cancels a Skill record before updating")]
        public void TestCancelUpdateSkillRecord()
        {

            skillsPageFeaturesObj.CancelUpdateSkillRecord(skillList[18]); 

        }

        [TearDown]

        public void AfterTest()
        {
            reportGenerate?.UpdateTest();
            close();

        }
    }
}
