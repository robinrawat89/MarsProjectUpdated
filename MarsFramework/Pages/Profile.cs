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

        //Click on fulltime option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[2]/div/span/select/option[3]")]
        private IWebElement fullTime { get; set; }

        //Click on parttime option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[2]/div/span/select/option[2]")]
        private IWebElement partTime { get; set; }

        //Click on lessHours option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[3]/div/span/select/option[2]")]
        private IWebElement lessHours { get; set; }

        //Click on moreHours option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[3]/div/span/select/option[3]")]
        private IWebElement moreHours { get; set; }

        //Click on AsneddedHours option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[3]/div/span/select/option[4]")]
        private IWebElement asNeeded { get; set; }

        //Click on earnoption1 option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[4]/div/span/select/option[2]")]
        private IWebElement lessEarn { get; set; }

        //Click on earnoption2 option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[4]/div/span/select/option[3]")]
        private IWebElement moreEarn { get; set; }

        //Click on earnoption3 option
        [FindsBy(How = How.XPath, Using = "//*[@class='extra content']/div/div[4]/div/span/select/option[4]")]
        private IWebElement doubleEarn { get; set; }
                                       

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            GlobalDefinitions.wait(5);

            //Click on user name 
            clickUserName.Click();

            //Edit First Name
            GlobalDefinitions.wait(5);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Edit Last Name
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //click Save button
            clickSave.Click();
            Thread.Sleep(5000);

            //Click Availiable  Edit Icon

            availabilityTimeEditIcon.Click();
            GlobalDefinitions.wait(5);

            //Availability Time option

            switch (GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"))
            {

                case "Full Time":
                   // IWebElement fullTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[3]"));
                    fullTime.Click();
                    break;
                case "Part Time":
                    //IWebElement partTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[2]"));
                    partTime.Click();
                    break;
            }
            // Hours Edit Icon
                    
            hoursEditIcon.Click();
            GlobalDefinitions.wait(5);

            //Availability Hours option
            
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "Hours"))
            {

                case "Less than 30hours a week":
                    //IWebElement lessHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[2]"));
                    lessHours.Click();
                    break;
                case "More than 30hours a week":
                    //IWebElement moreHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[3]"));
                    moreHours.Click();
                    break;
                case "As needed":
                    //IWebElement asNeeded = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[4]"));
                    asNeeded.Click();
                    break;
            }

            //Click edit for earn Target
           
            earnTargetEditIcon.Click();
            GlobalDefinitions.wait(5);

            //Earn Target option
            
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"))
            {

                case "Less than $500 per month":
                    //IWebElement lessEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[2]"));
                    lessEarn.Click();
                    break;
                case "Between $500 and $1000 per month":
                    //IWebElement moreEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[3]"));
                    moreEarn.Click();
                    break;
                case "More than $1000 per month":
                    //IWebElement doubleEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[4]"));
                    doubleEarn.Click();
                    break;
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