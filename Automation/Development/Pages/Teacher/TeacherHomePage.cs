using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Text;
using Automation.TestScripts;


namespace Automation.Development.Pages.Teacher
{
    public class TeacherHomePage : HomeBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private TeacherHomePage() { }

        /// <summary>
        /// Default Parameterized Constructor
        /// </summary>
        /// <param name="browser">browser value to store session</param>
        public TeacherHomePage(Browser browser)
            : base(browser)
        {

        }

    }
}
