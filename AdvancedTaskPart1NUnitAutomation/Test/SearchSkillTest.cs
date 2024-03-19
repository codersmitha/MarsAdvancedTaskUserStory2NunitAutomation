﻿using AdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent;
using AdvancedTaskPart1NUnitAutomation.ReportClass;
using AdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart1NUnitAutomation.DataModel;
using AdvancedTaskPart1NUnitAutomation.Steps;

namespace AdvancedTaskPart1NUnitAutomation.Test
{

    [TestFixture]
    public class SearchSkill : CommonDriver
    {
        List<SearchSkillsDM>? searchSkillsList;
        SearchSkillSteps? searchSkillStepsObj;
        GenerateReport? generateReport;


        [OneTimeSetUp]
        public void ReportAndJSONDataMethod()
        {
            generateReport = new GenerateReport();
            searchSkillsList = new List<SearchSkillsDM>();
            generateReport?.GenerateExtentReport(@"Reports\SearchSkillExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("searchskills");
            searchSkillsList = jsonObj.ReadSearchSkillsJsonData()!;
        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            searchSkillStepsObj = new SearchSkillSteps();
        }


        [Test, Order(1), Description("This test searches for a specific skill")]
        public void TestSearchSkillWithSkillName()
        {

            searchSkillStepsObj?.SearchSkillWithSkillName(searchSkillsList![0]);

        }
        [Test, Order(2), Description("This test searches for a skill under a specific category")]
        public void TestSearchSkillWithCategory()
        {

            searchSkillStepsObj?.SearchSkillWithCategory(searchSkillsList![1]);

        }
        [Test, Order(3), Description("This test searches for a skill under a specific category and subcategory")]
        public void TestSearchSkillWithCategoryAndSubcategory()
        {

            searchSkillStepsObj?.SearchSkillWithCategoryAndSubcategory(searchSkillsList![2]);

        }
        [Test, Order(4), Description("This test searches for a skill under a specific category and subcategory and skill name")]
        public void TestSearchSkillWithCategoryAndSubcategoryAndSkillName()
        {

            searchSkillStepsObj?.SearchSkillWithCategoryAndSubcategoryAndSkillName(searchSkillsList![3]);

        }
        [Test, Order(5), Description("This test searches for a skill under a specific category, subcategory,skill name and user name")]

        public void TestSearchSkillWithCategoryAndSubcategoryAndSkillAndUserName()
        {

            searchSkillStepsObj?.SearchSkillWithCategoryAndSubcategoryAndSkillAndUserName(searchSkillsList![4]);

        }
        [Test, Order(6), Description("This test searches for a skill under a specific category, subcategory,skill name, user name and using filter option")]

        public void TestSearchSkillWithCategorySubcategoryUserNameFilterOptionOnline()
        {

            searchSkillStepsObj?.SearchSkillWithCategorySubcategoryUserNameFilterOptionOnline(searchSkillsList![5]);

        }
        [Test, Order(7), Description("This test searches for a skill under a specific category, subcategory,skill name, user name and using another filter option")]

        public void TestSearchSkillWithCategorySubcategoryUserNameFilterOptionOnsite()
        {

            searchSkillStepsObj?.SearchSkillWithCategorySubcategoryUserNameFilterOptionOnsite(searchSkillsList![6]);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
