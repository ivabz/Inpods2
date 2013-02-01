using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Text;
using Automation.TestScripts;

namespace Automation.Development.Pages.Student
{
    public class StudentHomePage : HomeBase
    {
        private IWebElement homeTabControl;

        private ObjectRepository objectRepository = null;
        private string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        private StudentHomePage() { }

        /// <summary>
        /// Default Parameterized Constructor
        /// </summary>
        /// <param name="browser">browser value to store session</param>
        public StudentHomePage(Browser browser)
            : base(browser)
        {
            /// Initiate object repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.HomePage), EnumHelper.OfType(Role.SchoolTech));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception(" Error locating " + e.Message);
            }
        }

         /// <summary>
        /// To locate elements on login page using xpaths
        /// </summary>
        private void LocateControls()
        {
            #region All Home Page Controls 
            
            /// Home Tab Controls
            bool isHomeTabPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SectionDropDown"]);
            if (!isHomeTabPresent)
            {
                throw new Exception("Home Tab not found");
            }
            homeTabControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SectionDropDown"]);
            #endregion
        }
    }
}
