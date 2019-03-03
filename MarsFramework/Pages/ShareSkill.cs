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

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement radioST4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement radioLT { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='ui form']/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement radioLT2 { get; set; }

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

            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Service Type"))
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
            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Location Type"))
            {
                case "On-site":
                   // var radioLT = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[6]/div[2]/div/div[1]/div/input"));
                    radioLT.Click();
                    break;
                case "Online":
                    //var radioLT2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[6]/div[2]/div/div[2]/div/input"));
                    radioLT2.Click();
                    break;
            }

            //Enter Start Date for Available Days
            GlobalDefinitions.driver.FindElement(By.Name("startDate")).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Start Date"));
            GlobalDefinitions.driver.FindElement(By.Name("endDate")).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "End Date"));

            //Select the Days 


            //Select Skill Trade
            switch (Global.GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade"))
            {
                case "Skill-exchange":
                    //var radioST3 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[8]/div[2]/div/div[1]/div/input"));
                    radioST3.Click();
                    //Enter Skill Exchange
                    //IWebElement skillExch = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field error ']/div/div/div/div/input"));
                    skillExch.Click();
                    skillExch.Clear();
                    skillExch.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Skill Exchange"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field error ']/div/div/div/div/input")).SendKeys(Keys.Enter);
                    break;
                case "Credit":
                    //var radioST4 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui form']/div[8]/div[2]/div/div[2]/div/input"));
                    radioST4.Click();
                    //IWebElement creditEnter = GlobalDefinitions.driver.FindElement(By.XPath("//*[@name='charge']"));
                    creditEnter.Click();
                    creditEnter.Clear();
                    creditEnter.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));

                    break;
            }

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
        }

        

    }
}
