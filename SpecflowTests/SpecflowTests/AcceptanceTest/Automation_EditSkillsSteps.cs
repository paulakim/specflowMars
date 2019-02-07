using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using SpecflowTests.Pages;

namespace SpecflowTests
{
    [Binding]
    public class EditSkillsSteps
    {
        SkillsPage sp = new SkillsPage();

        [Given(@"I am on profile page\.")]
        public void GivenIAmOnProfilePage_()
        {
            //Wait
            Thread.Sleep(1500);
            sp.ttabProfile();
        }
        
        [When(@"I click on Skills tab button\.")]
        public void WhenIClickOnSkillsTabButton_()
        {
            sp.ttabSkills();
        }
        
        [When(@"I click Add New button")]
        public void WhenIClickAddNewButton()
        {
            sp.bbtnAddNewSkill();
        }
        
        [When(@"I have completed the form with (.*) and (.*)\.")]
        public void WhenIHaveCompletedTheFormWithEnglishAndIntermediate_(string skill, string level)
        {
            sp.ttxtSkill(skill);
            sp.chooseLevel(level);
        }
        
        [When(@"I click on Add button\.")]
        public void WhenIClickOnAddButton_()
        {
            sp.bbtnAddSkill();
        }
        [Then(@"I should see (.*) and (.*)\.")]
        public void ThenIShouldSeeEnglishAndIntermediate_(string skill, string level)
        {
            sp.validationSkill(skill,level);
        }
        [When(@"I click write small icon for Skills\.")]
        public void WhenIClickWriteSmallIconForSkills_()
        {
            sp.swriteIconSkill();
        }
        
        [When(@"I have changed with (.*) and (.*)\.")]
        public void WhenIHaveChangedWithKoreanAndExpert_(string updatedSkill, string updatedLevel)
        {
            sp.ttxtUpdatedSkill(updatedSkill);
            sp.chooseUpdatedLevel(updatedLevel);
        }
        
        [When(@"I click Update button\.")]
        public void WhenIClickUpdateButton_()
        {
            sp.bbtnUpdatedSkill();
        }        
        [Then(@"(.*) and (.*) should be updated\.")]
        public void ThenKoreanAndExpertShouldBeUpdated_(string updatedSkill, string updatedLevel)
        {
            Thread.Sleep(2000);
            sp.validationUpdatedSkill(updatedSkill, updatedLevel);
        }
    }
}
