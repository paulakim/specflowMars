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
    public class AddEducationSteps
    {
        EducatinPage ep = new EducatinPage();
        [Given(@"I am on the Profile page\.")]
        public void GivenIAmOnTheProfilePage_()
        {
            //Wait
            Thread.Sleep(1500);
            ep.ttabProfile();
        }
        
        [When(@"I click on Education tab button\.")]
        public void WhenIClickOnEducationTabButton_()
        {
           ep.ttabEducation();
        }
        
        [When(@"I click Add New button\.")]
        public void WhenIClickAddNewButton_()
        {
            ep.bbtnAddNewEdu();

        }
        
        [When(@"I enter (.*) and (.*) and (.*) and (.*) and (.*) in the form for Education\.")]
        public void WhenIEnterAISAndNewZealandAndB_AAndSoftwareAndInTheFormForEducation_(string name, string country, string title, string degree, int year)
        {
            ep.txtNameUni(name);
            ep.chooseCountry(country);
            ep.chooseTitle(title);
            ep.txtbDegree(degree);
            ep.chooseYear(year.ToString());
        }
        
        [When(@"I click the Add button\.")]
        public void WhenIClickTheAddButton_()
        {
            ep.bbtnAddEdu();
        }
        
        [Then(@"I should see the Education I have added\.")]
        public void ThenIShouldSeeTheEducationIHaveAdded_()
        {
            Thread.Sleep(2000);
            ep.validationEduDetails();
        }
    }
}
