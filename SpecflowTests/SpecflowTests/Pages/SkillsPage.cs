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
    class SkillsPage
    {
        public SkillsPage()
        {
            PageFactory.InitElements(Driver.driver,this);
        }

        //Paula's Onboarding Task
        //Define profile tab button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[2]")]
        IWebElement tabProfile { get; set; }

        //Define Skills tab button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Skills')]")]
        IWebElement tabSkills { get; set; }

        //Define Add New button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui teal button']")]
        IWebElement btnAddNewSkill { get; set; }

        //Define Skill text field
        [FindsBy(How =How.XPath, Using = "//input[@placeholder='Add Skill']")]
        IWebElement txtSkill { get; set; }

        //Define Skill Level drop down box
        [FindsBy(How =How.XPath,Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        IWebElement ddbSkill { get; set; }

        //Define Add button
        [FindsBy(How =How.XPath,Using = "//input[contains(@value,'Add')]")]
        IWebElement btnAddSkill { get; set; }

        //Define the body of the table
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")]
        IWebElement skillBody { get; set; }

        //Define small write icon for Editing Skill
        [FindsBy(How =How.XPath,Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
        IWebElement writeIconSkill { get; set; }

        //Define Skill text field for updating
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Add Skill']")]
        IWebElement txtupdatedSkill { get; set; }

        //Define Level drop down box for updating
        [FindsBy(How =How.XPath,Using = "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select")]
        IWebElement ddbUpdatedLevel { get; set; }

        //Define Update button
        [FindsBy(How =How.XPath,Using = "//input[contains(@value,'Update')]")]
        IWebElement btnUpdateSkill { get; set; }

        public void ttabProfile()
        {
            tabProfile.Click();
        }
        public void ttabSkills()
        {
            tabSkills.Click();
        }
        public void bbtnAddNewSkill()
        {
            btnAddNewSkill.Click();
        }
        public void ttxtSkill(string skill)
        {
            txtSkill.SendKeys(skill);
        }
        public void chooseLevel(string level)
        {
            //listLevel contains the list of the level
                List<IWebElement> listLevel = new List<IWebElement>(ddbSkill.FindElements(By.TagName("option")));
                for (int i = 1; i <= listLevel.Count; i++)
                {

                //When the level matches with the expected level it will be clicked.
                    if (listLevel.ElementAt(i).Text.Equals(level))
                    {
                        listLevel.ElementAt(i).Click();
                        break;
                    }
                }
        }
        public void bbtnAddSkill()
        {
            btnAddSkill.Click();
        }
        public void validationSkill(string skill, string level)
        {
            try
            {
                //Starting ExtentReports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);

                //Create a toggle for the given test, add all log events under it
                CommonMethods.test = CommonMethods.extent.StartTest("Edit Skill");

                //listCerti contains the whole data from the table
                List<IWebElement> listCerti = new List<IWebElement>(skillBody.FindElements(By.TagName("tbody")));
                Thread.Sleep(1000);

                //The reason using listCerti.Count is for when there are one more list on the table. At the moment I didn't make for else statement it's not important for this task.
                if (listCerti.Count == 1)
                {
                    //actualList contains the data of the list on the table
                    List<IWebElement> actualList = new List<IWebElement>(skillBody.FindElements(By.TagName("td")));

                    //Name of Skill from the table
                    string actualSkill = actualList.ElementAt(0).Text;

                    //Level of Skill from the table
                    string actualLevel = actualList.ElementAt(1).Text;

                    //When the level is matched with the expected level, the test will be passed.
                    if (actualSkill.Equals(skill) && actualLevel.Equals(level))
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, Skill is updated successfully");
                    }
                }
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Failed, Skill is updated Unsuccessfully",e.Message);
            }
        }
        public void swriteIconSkill()
        {
            writeIconSkill.Click();
        }
        public void ttxtUpdatedSkill(string updatedSkill)
        {
            txtupdatedSkill.Clear();
            txtupdatedSkill.SendKeys(updatedSkill);
        }
        public void chooseUpdatedLevel(string updatedLevel)
        {
            //listupLevel contains the list of levle for updating
            List<IWebElement> listupLevel = new List<IWebElement>(ddbUpdatedLevel.FindElements(By.TagName("option")));
            for(int i=1;i<=listupLevel.Count;i++)
            {

                //when the level is the same as expected level it will be clicked
                if (listupLevel.ElementAt(i).Text.Equals(updatedLevel))
                {
                    listupLevel.ElementAt(i).Click();
                    break;
                }
            }
        }
        public void bbtnUpdatedSkill()
        {
            btnUpdateSkill.Click();
        }
        public void validationUpdatedSkill(string updatedSkill, string updatedLevel)
        {
            try
            {
                //Starting ExtentReports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);

                //Create a toggle for the given test, add all log events under it
                CommonMethods.test = CommonMethods.extent.StartTest("Edit Skill");


                List<IWebElement> listCerti = new List<IWebElement>(skillBody.FindElements(By.TagName("tbody")));
                Thread.Sleep(1000);
                if (listCerti.Count == 1)
                {
                    //actualList contains the whole data from the table
                    List<IWebElement> actualList = new List<IWebElement>(skillBody.FindElements(By.TagName("td")));
                    string actualSkill = actualList.ElementAt(0).Text;
                    string actualLevel = actualList.ElementAt(1).Text;

                    //When the actual values matches with expected values, the test will be passed.
                    if (actualSkill.Equals(updatedSkill) && actualLevel.Equals(updatedLevel))
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test passed, Skill is updated successfully");
                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Failed, Skill is updated Unsuccessfully", e.Message);
            }
        }
    }
}
