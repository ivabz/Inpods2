using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{
    /// <summary>
    /// Create course page class
    /// </summary>
    public class CreateCoursePage : SchoolTechNavigationMenu
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
        /// Create course page constructor 
        /// </summary>
        /// <param name="browser"></param>
        public CreateCoursePage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.CreateCoursePage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                //this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Locate UI Controls in create course page
        /// </summary>
        private void LocateControls()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
