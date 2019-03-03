using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@class='ui secondary menu inverted']/div/button")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.Name, Using = "terms")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.Id, Using = "submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void register()
        {
            

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");


            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click on Join button
            Join.Click();

            //Enter FirstName
            GlobalDefinitions.driver.SwitchTo().Window(GlobalDefinitions.driver.WindowHandles.Last());
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.Clear();
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.Clear();
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();

            
        }
    }
}
