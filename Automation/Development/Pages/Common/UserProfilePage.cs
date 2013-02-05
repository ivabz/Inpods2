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
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Common),EnumHelper.OfType(Page.ProfilePage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Locate User Controls
        /// <summary>
        /// Locates controls on Profile page
        /// </summary>
        private void LocateControls()
        {
            /// Check Role Type
            bool isroleType = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["RoleType"]);

            if (!isroleType)
            {
                throw new Exception("RoleType");
            }
            roleType = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["RoleType"]);
        }
        #endregion
    }
}
