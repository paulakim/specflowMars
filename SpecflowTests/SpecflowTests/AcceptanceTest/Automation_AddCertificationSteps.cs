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
    public class AddCertificationSteps
    {
        CertificationPage cp = new CertificationPage();

        [Given(@"I am on Profile page\.")]
        public void GivenIAmOnProfilePage_()
        {
            //Wait
            Thread.Sleep(1500);
            cp.ttabProfile();
        }
        
        [When(@"I click on Certificaton tab button\.")]
        public void WhenIClickOnCertificatonTabButton_()
        {
            cp.ttabCertification();
        }
        
        [When(@"I click on Add New button\.")]
        public void WhenIClickOnAddNewButton_()
        {
            cp.bbtnAddNewCerti();
        }
        
        [When(@"I complete the form with (.*) and (.*) and (.*)\.")]
        public void WhenICompleteTheFormWithExcelAndMSAnd_(string certificate, string certifiForm, int year)
        {
            cp.txtNameCerti(certificate);
            cp.ttxtCertifiedForm(certifiForm);
            cp.chooseYear(year.ToString());
        }
        
        [When(@"I click Add button\.")]
        public void WhenIClickAddButton_()
        {
            cp.bbtnAddCerti();
        }
        
        [Then(@"(.*) and (.*) and (.*) should be displayed on the list\.")]
        public void ThenExcelAndMSAndShouldBeDisplyedOnTheList_(string certificate, string certifiForm, int year)
        {
            Thread.Sleep(3000);
            cp.validationCertiDetails(certificate, certifiForm,year.ToString());
        }
    }
}
