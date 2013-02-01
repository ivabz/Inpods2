using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;

namespace Automation.Development.Pages.Common
{
    public class UserProfilePage : HomeBase
    {
        private IWebElement roleType;

        /// <summary>
        /// Gets User RoleType
        /// </summary>
        public IWebElement RoleType
        {
            get { return roleType; }
            private set { roleType = value; }
        }

        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// school tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// User profile constructor
        /// </summary>
        /// <param name="browser"></param>
        public UserProfilePage(Browser browser): base(browser)
        { 
            objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.ProfilePage),EnumHelper.OfType(Role.Common));
            objectRepository = new ObjectRepository(objectRepositoryFilePath);
            this.LocateControls();
        }

        #region Locate User Controls
        /// <summary>
        /// Locates controls on Profile page
        /// </summary>
        private void LocateControls()
        {
            try
            {
                /// Check Role Type
                bool isroleType = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["RoleType"]);

                if (!isroleType)
                {
                    throw new Exception("RoleType");
                }
                roleType = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["RoleType"]);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to locate control - " + e.Message);
            }
        }
        #endregion
    }
}
