using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowPages;

namespace SpecflowTests.Pages
{
    class CertificationPage
    {
        public CertificationPage()
        {
            PageFactory.InitElements(Driver.driver,this);
        }

        //Paula's Onboarding Task
        //Define Profile tab button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[2]")]
        IWebElement tabProfile { get; set; }

        //Define Certification tab button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Certifications')]")]
        IWebElement tabCertification { get; set; }

        //Define Add New button for Certification
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        IWebElement btnAddNewCerti { get; set; }

        //Define Certificate and Award
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        IWebElement txtNmaeCertification { get; set; }

        //Define Certified Form text field
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        IWebElement txtCertifiedForm { get; set; }

        //Define Year drop down box
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")]
        IWebElement ddbYearCerti { get; set; }

        //Define Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        IWebElement btnAddCerti { get; set; }

        //Define Certificate on the list of the table
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")]
        IWebElement actualNameCertificate { get; set; }

        //Define the body of the table for reading the data on the table
        [FindsBy(How =How.XPath,Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table")]
        IWebElement certificateBody { get; set; }
        
        public void ttabProfile()
        {
            tabProfile.Click();
        }
        
        public void ttabCertification()
        {
            tabCertification.Click();
        }

        
        public void bbtnAddNewCerti()
        {
            btnAddNewCerti.Click();
        }

        public void txtNameCerti(string certificate)
        {
            txtNmaeCertification.SendKeys(certificate);
        }

        public void ttxtCertifiedForm(string certifiForm)
        {
            txtCertifiedForm.SendKeys(certifiForm);
        }

        //choose the year from drop down box
        public void chooseYear(string year)
        {
            //listYear contains the list of all year in the drop down box
            List<IWebElement> listYear = new List<IWebElement>(ddbYearCerti.FindElements(By.TagName("option")));
            for (int i=1;i<=listYear.Count;i++)
            {
                //when listYear matches with year I provoide it will click and leave the for loop statement
                if (listYear.ElementAt(i).Text.Equals(year))
                {
                    listYear.ElementAt(i).Click();
                    break;
                }
                
            }
        }
        public void bbtnAddCerti()
        {
            btnAddCerti.Click();
        }

        public void validationCertiDetails(string certificate, string certifiForm, string year)
        {
            try
            { 
            //Starting ExtentReports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            //Create a toggle for the given test, add all log events under it
            CommonMethods.test = CommonMethods.extent.StartTest("Add Certification");

            //listCerti contains the all data of the list on the table
            List<IWebElement> listCerti = new List<IWebElement>(certificateBody.FindElements(By.TagName("tbody")));
            Thread.Sleep(1000);

            //The reason using listCerti.Count is for when there are one more list on the table. At the moment I didn't make for else statement it's not important for this task.
            if (listCerti.Count == 1)
            {
                //actualList contains the data of the list on the table
                List<IWebElement> actualList = new List<IWebElement>(certificateBody.FindElements(By.TagName("td")));

                //Name of Certificate from the table
                string actualCertificate = actualList.ElementAt(0).Text;

                //Name of Certified Form from the table
                string actualCertiForm = actualList.ElementAt(1).Text;

                //Year of Certificate from the table
                string actualYear = actualList.ElementAt(2).Text;

                //When the actual values and expected values match the test is passed. If they don't match it is failed. 
                if (actualCertificate.Equals(certificate) && actualCertiForm.Equals(certifiForm)
                        && actualYear.Equals(year))
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, Certification is added successfully");
                }

            }
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, Add Certification is Unsuccessful");
            }
        }
    }
}
