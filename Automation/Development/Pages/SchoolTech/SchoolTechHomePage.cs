using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{
    public class SchoolTechHomePage : SchoolTechNavigationMenu
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
        /// Default parameterised constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechHomePage(Browser browser)
            : base(browser)
        {
            
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech),EnumHelper.OfType(Page.HomePage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Locate control methods for SchoolTech home page
        /// <summary>
        /// Method to locate elements on SchoolTech home page using xpaths      
        /// </summary>
        private void LocateControls()
        {
            /// TODO: Any other user specific controls can be initialize here.
            /// Eg:  Announcement , section Schedule
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Method to go to user profile tab
        /// </summary>
        public bool ValidateSchoolTechUserProfile()
        {
            UserProfilePage profile = SchooltechMenu.GoToUserProfile();
            return ((profile.RoleType.Text.Equals("SchoolTech")) ? true : false);
        } 
        #endregion
    }
}
