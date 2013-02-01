using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{
    public class SchoolTechHomePage : HomeBase
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
        /// Site Navigation menu
        /// </summary>
        SiteNavigationMenu menu = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        private SchoolTechHomePage()
        { }

        /// <summary>
        /// Default parameterised constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechHomePage(Browser browser)
            : base(browser)
        {
            /// Initialize School tech Site navigation menu
            menu = new SiteNavigationMenu(browser);
            menu.LocateSchoolTechMenuControls();            

           /// Initiate Schooltech Homepage repository
           objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.HomePage), EnumHelper.OfType(Role.SchoolTech));
           objectRepository = new ObjectRepository(objectRepositoryFilePath);
           this.LocateControls();
        }

        /// <summary>
        /// To locate elements on SchoolTech home page using xpaths      
        /// </summary>
        private void LocateControls()
        {
            /// TODO: Any other user specific controls can be initialize here.
            /// Eg:  Announcement , section Schedule
        }
        
        /// <summary>
        /// Method to go to user profile tab
        /// </summary>
        public bool ValidateSchoolTechUserProfile()
        {
            UserProfilePage profile = menu.GoToUserProfile();
            return ((profile.RoleType.Text.Equals("SchoolTech")) ? true : false);
        }
    }
}
