using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {
            public ExtentReports extent;
            public ExtentTest test;

            [Test]
            public void userAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                MarsFramework.Global.Base.test.Log(LogStatus.Pass, "Edited the Account");
                obj.EditProfile();

               

            }

            [Test]
            public void addShareSkill()
            {
                ShareSkill obje = new ShareSkill();
                MarsFramework.Global.Base.test.Log(LogStatus.Pass, "Added the SkillShare");
                obje.enterDetails();

            }

            [Test]
            public void editShareSkill()
            {
                test = extent.StartTest("Edit the share skill");

                ShareSkill edit = new ShareSkill();
                edit.editShareSkillML();

            }

            [Test]
            public void deleteShareSkill()
            {
               

                ShareSkill delete = new ShareSkill();
                MarsFramework.Global.Base.test.Log(LogStatus.Pass, "Deleted the skillshare");
                delete.deleteShareSkill();

                
            }
        }
    }
}