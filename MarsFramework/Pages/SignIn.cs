using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()

        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//*[@class='ui secondary menu inverted']/div/a")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@class='fluid ui teal button']")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {

            //extent Reports
            Base.test = Base.extent.StartTest("Login Test");

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");

            //Navigate to the Url
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2,"Url"));

            //Click on Sign In tab
            
            SignIntab.Click();
            Thread.Sleep(500);

            //Enter the data in Username textbox
            GlobalDefinitions.driver.SwitchTo().Window(GlobalDefinitions.driver.WindowHandles.Last());
            Email.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2,"Username"));
            Thread.Sleep(500);

            //Enter the password 
            Password.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            LoginBtn.Click();
            GlobalDefinitions.wait(20);

            string text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='item']/button")).Text;

            if (text == "Sign Out")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

        }
    }
}