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
    class EducatinPage
    {
        public EducatinPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Paula's Onboarding Task
        //Define profile tab button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[2]")]
        IWebElement tabProfile { get; set; }

        //Define Education tab button
        [FindsBy(How = How.XPath, Using = "//a[contains(@data-tab,'third')]")]
        IWebElement tabEducation { get; set; }

        //Define Add New button
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        IWebElement btnAddNewEdu { get; set; }

        //Define College/University text field
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='College/University Name']")]
        IWebElement txtNmaeCollUni { get; set; }

        //Define Country of College/University drop down box
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")]
        IWebElement ddbCountry { get; set; }

        //Define Title drop down box
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")]
        IWebElement ddbTitle { get; set; }

        //Define Degree text field
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        IWebElement txtDegree { get; set; }

        //Define Year of Graduation drop down box
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")]
        IWebElement ddbYearGradu { get; set; }

        //Define Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        IWebElement btnAddEdu { get; set; }

        //Define the name of College/University from the table
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")]
        IWebElement actualNameCollUni { get; set; }

        //Define Countrry of College/University from the table
        [FindsBy(How = How.XPath, Using = "//html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")]
        IWebElement actualCountry { get; set; }

        //Define Title from the table
        [FindsBy(How = How.XPath, Using = "//html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]")]
        IWebElement actualTitle { get; set; }

        //Define Degree from the table
        [FindsBy(How = How.XPath, Using = "//html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")]
        IWebElement actualDegree { get; set; }

        //Define the Year of Graduation from the table
        [FindsBy(How = How.XPath, Using = "//html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[5]")]
        IWebElement actualYearGraduation { get; set; }

        public void ttabProfile()
        {
            tabProfile.Click();
        }
        public void ttabEducation()
        {
            tabEducation.Click();
        }
        public void bbtnAddNewEdu()
        {
            btnAddNewEdu.Click();
        }
        public void txtNameUni(string name)
        {
            txtNmaeCollUni.SendKeys(name);
        }
        public void chooseCountry(string country)
        {
            //listCountry contains the list of coutries
            var listCountry = ddbCountry.FindElements(By.TagName("option"));
            foreach (var pickedCountry in listCountry)
            {
                //When the country from the list is matched with the country I want, it will be clicked.
                if (pickedCountry.Text.Contains(""+country))
                {
                    pickedCountry.Click();
                    break;
                }
            }
        }
        public void chooseTitle(string title)
        {

            //listTitle contains the list of Title
            List<IWebElement> listTitle = new List<IWebElement>(ddbTitle.FindElements(By.TagName("option")));
           
                for (int i = 1;i<=listTitle.Count;i++)
                {

                //When the Title is matched with what I want it will be clicked
                    if (listTitle.ElementAt(i).Text.Equals(title))
                    {
                        listTitle.ElementAt(i).Click();
                        break;
                    }
                }
        }
        public void txtbDegree(string degree)
        {
            txtDegree.SendKeys(degree);
        }
        public void chooseYear(string year)
        {
            //listYear contains the list of the year
            List<IWebElement> listYear = new List<IWebElement>(ddbYearGradu.FindElements(By.TagName("option")));
            foreach (var pickedYear in listYear)
            {
                //When the year is matched with what I want it will be clicked
                if (pickedYear.Text.Equals(year))
                {
                    pickedYear.Click();
                    break;
                }
            }
        }
        public void bbtnAddEdu()
        {
            btnAddEdu.Click();
        }
        public void validationEduDetails()
        {
            //Starting ExtentReports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            //Create a toggle for the given test, add all log events under it
            CommonMethods.test = CommonMethods.extent.StartTest("Add Education");
            
            //Data for Expected values
            string expectNameCollUni = "AIS";
            string expectCountry = "New Zealand";
            string expectTitle = "B.A";
            string expectDegree = "Software";
            string expectYearGraduation = "2016";
            
            //Data for acutal values
            string aName = actualNameCollUni.Text;
            string aCountry = actualCountry.Text;
            string aTitle = actualTitle.Text;
            string aDegree = actualDegree.Text;
            string aYear = actualYearGraduation.Text;


            try
            {
                //When the expected values match with actual values the test is passed.
                if (expectNameCollUni.Equals(aName) && expectCountry.Equals(aCountry) && expectTitle.Equals(aTitle) 
                    && expectDegree.Equals(aDegree) && expectYearGraduation.Equals(aYear))
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, Education is added successfully");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test failed, Add Education is Unsuccessful");
            }

        }
    }
}
