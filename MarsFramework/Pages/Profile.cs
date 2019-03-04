using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Click on Name
        [FindsBy(How = How.XPath, Using = "//*[@class='title']/i")]
        private IWebElement clickUserName { get; set; }

        //Edit First Name
        [FindsBy(How = How.XPath, Using = "//*[@class='field']/input[1]")]
        private IWebElement firstName { get; set; }

        //Edit Last Name
        [FindsBy(How = How.XPath, Using = "//*[@class='field']/input[2]")]
        private IWebElement lastName { get; set; }

        //Click Save button for Name
        [FindsBy(How = How.XPath, Using = "//*[@class='ui fluid accordion']/div[2]/div/div[2]/button")]
        private IWebElement clickSave { get; set; }

        //Click on Availability Edit button
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[2]/div/span/i")]
        private IWebElement availabilityTimeEditIcon { get; set; }

        //Click on Hours Edit button
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[3]/div/span/i")]
        private IWebElement hoursEditIcon { get; set; }

        //Click on Earn target Edit button
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[4]/div/span/i")]
        private IWebElement earnTargetEditIcon { get; set; }

       
        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(5000);

            //Click on user name 
            clickUserName.Click();

            //Edit First Name
            Thread.Sleep(10000);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Edit Last Name
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Click Availiable  Edit Icon
            Thread.Sleep(5000);
            availabilityTimeEditIcon.Click();

            //Availability Time option

            //Thread.Sleep(1500);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(dropDown1).Build().Perform();
            Thread.Sleep(1000);

            IWebElement dropDown1 = GlobalDefinitions.driver.FindElement(By.Name("availabiltyType"));
            IList<IWebElement> AvailableTime = dropDown1.FindElements(By.TagName("option"));
            int count = AvailableTime.Count;
            for(int i = 0; i < count; i++)
            {
                if(AvailableTime[i].Text==GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"))
                {
                    AvailableTime[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the available time");

                }
            }

            // Hours Edit Icon
            Thread.Sleep(5000);
            hoursEditIcon.Click();

            //Availability Hours option
            IWebElement dropDown2 = GlobalDefinitions.driver.FindElement(By.Name("availabiltyHour"));
            IList<IWebElement> AvailableHours = dropDown2.FindElements(By.TagName("option"));
            int count2 = AvailableHours.Count;
            for (int i = 0; i < count; i++)
            {
                if (AvailableHours[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Hours"))
                {
                    AvailableHours[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the available time");

                }
            }


            //Click edit for earn Target
            Thread.Sleep(5000);
            earnTargetEditIcon.Click();

            //Earn Target option
            IWebElement dropDown3 = GlobalDefinitions.driver.FindElement(By.Name("availabiltyTarget"));
            IList<IWebElement> earnTarget = dropDown3.FindElements(By.TagName("option"));
            int count3 = earnTarget.Count;
            for (int i = 0; i < count; i++)
            {
                if (earnTarget[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"))
                {
                    earnTarget[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the available time");

                }
            }

            ////---------------------------------------------------------
            ////Click on Add New Language button
            //AddNewLangBtn.Click();
            //Thread.Sleep(1000);
            ////Enter the Language
            //AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Language"));

            ////Choose Lang
            //ChooseLang.Click();
            //Thread.Sleep(1000);
            //ChooseLangOpt.Click();
            //Thread.Sleep(500);
            //AddLang.Click();
            //Base.test.Log(LogStatus.Info, "Added Language successfully");

            ////-----------------------------------------------------------
            ////Click on Add New Skill Button
            //AddNewSkillBtn.Click();
            ////Enter the skill 
            //AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Skill"));

            ////Click the skill dropdown
            //ChooseSkill.Click();
            //Thread.Sleep(500);
            //ChooseSkilllevel.Click();
            //AddSkill.Click();
            //Thread.Sleep(500);
            //Base.test.Log(LogStatus.Info, "Added Skills successfully");

            ////---------------------------------------------------------
            ////Add Education
            //AddNewEducation.Click();
            ////Enter the University
            //EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"University"));

            ////Choose Country
            //ChooseCountry.Click();
            //Thread.Sleep(500);
            ////Choose Country Level
            //ChooseCountryOpt.Click();

            ////Choose Title
            //ChooseTitle.Click();
            //Thread.Sleep(500);
            //ChooseTitleOpt.Click();

            ////Enter Degree
            //Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Degree"));

            ////Year of Graduation
            //DegreeYear.Click();
            //Thread.Sleep(500);
            //DegreeYearOpt.Click();
            //AddEdu.Click();
            //Thread.Sleep(500);
            //Base.test.Log(LogStatus.Info, "Added Education successfully");

            ////-------------------------------------------------
            ////Add new Certificate
            //AddNewCerti.Click();

            ////Enter Certificate Name
            //EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certificate"));

            ////Enter Certified from
            //CertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"CertifiedFrom"));

            ////Enter the Year
            //CertiYear.Click();
            //Thread.Sleep(500);
            //CertiYearOpt.Click();
            //AddCerti.Click();
            //Thread.Sleep(500);
            //Base.test.Log(LogStatus.Info, "Added Certificate successfully");

            ////-----------------------------------------------------
            ////Add Description
            //Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));
            //Thread.Sleep(500);
            //Save.Click();
            //Base.test.Log(LogStatus.Info, "Added Description successfully");

        }
    }
}