using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on Edit button
        [FindsBy(How = How.XPath, Using = "//*[@name='title']")]
        private IWebElement titleBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='description']")]
        private IWebElement descriptionBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='form-wrapper field  ']/div/div/div/input")]
        private IWebElement tagsBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement radioST { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement radioST2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement radioST3 { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[8]/div[2]/div/div[2]/div/input")]
        //private IWebElement radioST4 { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[6]/div[2]/div/div[1]/div/input")]
        //private IWebElement radioLT { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[6]/div[2]/div/div[2]/div/input")]
        //private IWebElement radioLT2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='charge']")]
        private IWebElement creditEnter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='huge plus circle icon padding-25']")]
        private IWebElement imageUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement radioA { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement radioH { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='field error ']/div/div/div/div/input")]
        private IWebElement skillExch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='nav-secondary']//a[text()[normalize-space(.)='Share Skill']]")]
        private IWebElement shareSkillButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Save']")]
        private IWebElement saveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Cancel']")]
        private IWebElement cancelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='nav-secondary']//a[text()[normalize-space(.)='Manage Listings']]")]
        private IWebElement manageListingLink { get; set; }

        



        #endregion


        public void enterDetails()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShareAdd");


            //Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click ShareSkill button
            //IWebElement shareSkillButton = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='nav-secondary']//a[text()[normalize-space(.)='Share Skill']]"));
            shareSkillButton.Click();


            //Enter title
            titleBox.Click();
            titleBox.Clear();
            titleBox.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description
            descriptionBox.Click();
            descriptionBox.Clear();
            descriptionBox.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            GlobalDefinitions.wait(5);

            //Select Category
            IWebElement categoryList = GlobalDefinitions.driver.FindElement(By.XPath("//*[@name='categoryId']"));
            IList<IWebElement> optionsCategory = categoryList.FindElements(By.TagName("option"));
            int optionCount = optionsCategory.Count();
            for (int i = 0; i < optionCount; i++)
            {
                if (optionsCategory[i].Text == Global.GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    optionsCategory[i].Click();
                }
            }
            //Select Subcategory
            IWebElement subCategoryList = GlobalDefinitions.driver.FindElement(By.XPath("//*[@name='subcategoryId']"));
            IList<IWebElement> optionsSubCategory = subCategoryList.FindElements(By.TagName("option"));
            int optionsSubCategoryCount = optionsSubCategory.Count();
            for (int i = 0; i < optionsSubCategoryCount; i++)
            {
                if (optionsSubCategory[i].Text == Global.GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"))
                {
                    optionsSubCategory[i].Click();
                }
            }

            //Enter tag
            tagsBox.Click();
            tagsBox.Clear();
            tagsBox.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='form-wrapper field  ']/div/div/div/input")).SendKeys(Keys.Enter);



            //Select Servicetype

            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"))
            {
                case "Hourly basis service":

                    //var radioST = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[5]/div[2]/div[1]/div[1]/div/input"));
                    radioST.Click();
                    break;
                case "One-off service":
                    //var radioST2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[5]/div[2]/div[1]/div[2]/div/input"));
                    radioST2.Click();
                    break;
            }


            //Select Location type
            string test = Global.GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"))
            {
                case "On-Site":
                    var radioLT = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[6]/div[2]/div/div[1]/div/input"));
                    radioLT.Click();
                    break;
                case "Online":
                    var radioLT2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[6]/div[2]/div/div[2]/div/input"));
                    radioLT2.Click();
                    break;
            }


            //Enter Start Date for Available Days
            string start = Global.GlobalDefinitions.ExcelLib.ReadData(2, "StartDate");
            //splitting date and time for start date
            string[] sDate = start.Split(' ');
            string startdate = sDate[0].ToString();
            string startDateTime = sDate[1].ToString();


            //splitting date and time for end date
            string end = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EndDate");
            string[] eDate = start.Split(' ');
            string enddate = sDate[0].ToString();
            string endDateTime = sDate[1].ToString();

            //Enter start date
            var startDateEnter = GlobalDefinitions.driver.FindElement(By.Name("startDate"));
            startDateEnter.SendKeys(startdate);
            //Enter end Date        
            var endDateEnter = GlobalDefinitions.driver.FindElement(By.Name("endDate"));            
            endDateEnter.SendKeys(enddate);

            //Availiable Days
            string selectSunMon = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayOneSel");
            string selectTuWed = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayTwoSel");
            string selectThuFri = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayThreeSel");

            //select Sunday or Monday
            if (selectSunMon.Contains("Sun") || selectSunMon.Contains("Mon"))
            {
                if (selectSunMon.Contains("Sun"))
                {
                    var checkSun = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[1]/div/input"));
                    checkSun.Click();
                    string[] arrDate = selectSunMon.Split(',');
                    string day = arrDate[0].ToString();
                    string startTimeSun = arrDate[1].ToString();
                    string endTimeSun = arrDate[2].ToString();
                    var enterStartTimeSun = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[2]/input"));
                    enterStartTimeSun.Click();
                    enterStartTimeSun.SendKeys(startTimeSun);
                    var enterEndTimeSun = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[3]/input"));
                    enterEndTimeSun.Click();
                    enterEndTimeSun.SendKeys(endTimeSun);
                }
                else
                {
                    var checkMon = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[1]/div/input"));
                    checkMon.Click();
                    string[] arrDate2 = selectSunMon.Split(',');
                    string day = arrDate2[0].ToString();
                    string startTimeMon = arrDate2[1].ToString();
                    string endTimeMon = arrDate2[2].ToString();
                    var enterStartTimeMon = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[2]/input"));
                    enterStartTimeMon.Click();
                    enterStartTimeMon.SendKeys(startTimeMon);
                    var enterEndTimeMon = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[3]/input"));
                    enterEndTimeMon.Click();
                    enterEndTimeMon.SendKeys(endTimeMon);
                }
            }

            if (selectTuWed.Contains("Tue") || selectTuWed.Contains("Wed"))
            {
                if (selectTuWed.Contains("Tue"))
                {
                    var checkTue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[1]/div/input"));
                    checkTue.Click();
                    string[] arrDate3 = selectTuWed.Split(',');
                    string day = arrDate3[0].ToString();
                    string startTimeTue = arrDate3[1].ToString();
                    string endTimeTue = arrDate3[2].ToString();
                    var enterStartTimeTue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[2]/input"));
                    enterStartTimeTue.Click();
                    enterStartTimeTue.SendKeys(startTimeTue);
                    var enterEndTimeTue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[3]/input"));
                    enterEndTimeTue.Click();
                    enterEndTimeTue.SendKeys(endTimeTue);

                }
                else
                {
                    var checkWed = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[1]/div/input"));
                    checkWed.Click();
                    string[] arrDate4 = selectTuWed.Split(',');
                    string day = arrDate4[0].ToString();
                    string startTimeWed = arrDate4[1].ToString();
                    string endTimeWed = arrDate4[2].ToString();
                    var enterStartTimeWed = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[2]/input"));
                    enterStartTimeWed.Click();
                    enterStartTimeWed.SendKeys(startTimeWed);
                    var enterEndTimeWed = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[3]/input"));
                    enterEndTimeWed.Click();
                    enterEndTimeWed.SendKeys(endTimeWed);
                }

            }

            if (selectThuFri.Contains("Thu") || selectThuFri.Contains("Fri") || selectThuFri.Contains("Sat"))
            {
                if (selectThuFri.Contains("Thu"))
                {
                    var checkThu = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[1]/div/input"));
                    checkThu.Click();
                    string[] arrDate5 = selectTuWed.Split(',');
                    string day = arrDate5[0].ToString();
                    string startTimeThu = arrDate5[1].ToString();
                    string endTimeThu = arrDate5[2].ToString();
                    var enterStartTimeThu = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[2]/input"));
                    enterStartTimeThu.Click();
                    enterStartTimeThu.SendKeys(startTimeThu);
                    var enterEndTimeThu = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[3]/input"));
                    enterEndTimeThu.Click();
                    enterEndTimeThu.SendKeys(endTimeThu);
                }
                else if (selectThuFri.Contains("Fri"))
                {
                    var checkFri = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[1]/div/input"));
                    checkFri.Click();
                    string[] arrDate6 = selectTuWed.Split(',');
                    string day = arrDate6[0].ToString();
                    string startTimeFri = arrDate6[1].ToString();
                    string endTimeFri = arrDate6[2].ToString();
                    var enterStartTimeFri = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[2]/input"));
                    enterStartTimeFri.Click();
                    enterStartTimeFri.SendKeys(startTimeFri);
                    var enterEndTimeFri = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[3]/input"));
                    enterEndTimeFri.Click();
                    enterEndTimeFri.SendKeys(endTimeFri);
                }
                else if (selectThuFri.Contains("Sat"))
                {
                    var checkSat = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[8]/div[1]/div/input"));
                    checkSat.Click();
                    string[] arrDate7 = selectTuWed.Split(',');
                    string day = arrDate7[0].ToString();
                    string startTimeSat = arrDate7[1].ToString();
                    string endTimeSat = arrDate7[2].ToString();
                    var enterStartTimeSat = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[8]/div[2]/input"));
                    enterStartTimeSat.Click();
                    enterStartTimeSat.SendKeys(startTimeSat);
                    var enterEndTimeSat = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[3]/input"));
                    enterEndTimeSat.Click();
                    enterEndTimeSat.SendKeys(endTimeSat);
                }

            }





            //Select Skill Trade
            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"))
            {
                case "Skill-exchange":
                    //var radioST3 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[8]/div[2]/div/div[1]/div/input"));
                    radioST3.Click();
                    //Enter Skill Exchange
                    //IWebElement skillExch = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field error ']/div/div/div/div/input"));
                    skillExch.Click();
                    skillExch.Clear();
                    skillExch.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field error ']/div/div/div/div/input")).SendKeys(Keys.Enter);
                    break;
                case "Credit":
                    GlobalDefinitions.wait(5);

                    var radioST4 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[8]/div[2]/div/div[2]/div/input"));
                    radioST4.Click();
                    //IWebElement creditEnter = GlobalDefinitions.driver.FindElement(By.XPath("//*[@name='charge']"));
                    creditEnter.Click();
                    creditEnter.Clear();
                    creditEnter.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));

                    break;
            }


            //SkillExchange

            //Upload Work Samples

            //IWebElement imageUpload = Driver.webDriver.FindElement(By.XPath("//*[@class='huge plus circle icon padding-25']"));
            //imageUpload.Click();
            //string a = "C:\\Users\\Dell\\Desktop\\";
            //string b = workSamples;
            //Process.Start(a + "" + b);

            //IWebElement imageUpload = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='huge plus circle icon padding-25']"));
            imageUpload.Click();
            string filePath = @"C:\\Users\\Dell\\Desktop\\" + Global.GlobalDefinitions.ExcelLib.ReadData(2, "Work Samples") + "";
            Process.Start(filePath);

            //Select Active


            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Active"))
            {
                case "Active":
                    // var radioA = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[10]/div[2]/div/div[1]/div/input"));
                    radioA.Click();
                    break;
                case "Hidden":
                    //var radioH = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[10]/div[2]/div/div[2]/div/input"));
                    radioH.Click();
                    break;
            }

            //Click Save Button
            saveButton.Click();


        }

        public void verifyListing()
        {
            manageListingLink.Click();

            GlobalDefinitions.wait(10);
            bool shareSkillPresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui striped table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title")) && row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description")))
                {
                    shareSkillPresent = true;
                    //SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillShareAdded");
                    //CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    break;
                }
            }
            shareSkillPresent = false;
        }
    }
}

        
