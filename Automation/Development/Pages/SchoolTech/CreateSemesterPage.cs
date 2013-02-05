using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{

    /// <summary>
    /// Semeter page class 
    /// </summary>
    public class CreateSemesterPage : SchoolTechNavigationMenu
    {
        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// school tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Semester page constructor
        /// </summary>
        /// <param name="browser"></param>
        public CreateSemesterPage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.CreateSemesterPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
 
        }

        #region Helper Methods
        /// <summary>
        /// Locate controls on Create semester page
        /// </summary>
        private void LocateControls()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
