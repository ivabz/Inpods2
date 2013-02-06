using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;
using Automation.TestScripts;

namespace Automation.Development.Pages.Super
{
    /// <summary>
    /// SuperHomePage Class
    /// </summary>
    public class SuperHomePage : SuperNavigationMenu
    {
        /// <summary>
        /// Super Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// Super Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// SuperHomePage Constructor
        /// </summary>
        /// <param name="browser"></param>
        public SuperHomePage(Browser browser)
            : base(browser)
        {
            /// Initiate Super Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Super), EnumHelper.OfType(Page.HomePage));
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
        /// Method to locate Super Homepage Controls
        /// </summary>
        private void LocateControls()
        {
            ////TODO: addtional Home page UI control initialization goes here

        }
        #endregion

        public void CreateTechAdminAndInstituteManually(string firstName, string lastName, string email, string password)
        {
            

        }


    }
}
