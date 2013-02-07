using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{

    /// <summary>
    /// Schooltech Navigation menu class
    /// </summary>
    public class SchoolTechNavigationMenu : HomeBase
    {
        /// <summary>
        /// Site Navigation menu
        /// </summary>
        public SiteNavigationMenu SchooltechMenu { get; private set; }

        /// <summary>
        /// Schooltech Navigation menu constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechNavigationMenu(Browser browser)
            : base(browser)
        {
            SchooltechMenu = new SiteNavigationMenu(browser);
        }

        #region Navigation Methods
        /// <summary>
        /// Method to go to User Profile page
        /// </summary>
        /// <returns></returns>
        public UserProfilePage GoToUserProfile()
        {
            try
            {
                SchooltechMenu.LocateSchoolTechMenuControls();

                /// Click User Options tab
                if (this.WaitForElement("XPATH", (string)SchooltechMenu.objectRepository.ObjectRepositoryTable["SchooltechUserOption"]))
                {
                    SchooltechMenu.UserOptionControl.Click();
                }

                SchooltechMenu.LocateUserOptionControls();

                /// Click on Profile link
                SchooltechMenu.ProfileLinkControl.Click();

                /// return profiles page
                return new UserProfilePage(this.Browser);
            }
            catch (Exception e)
            {
                throw new Exception("Error Locating -" + e.Message);
            }
        }

        public SchoolTechAdminPage GoToSchooltechAdmin()
        {
              try
            {
                SchooltechMenu.LocateSchoolTechMenuControls();
                /// Click Profile tab
                if (this.WaitForElement("XPATH", (string)SchooltechMenu.objectRepository.ObjectRepositoryTable["SchooltechAdmin"]))
                {
                    SchooltechMenu.AdminTabControl.Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error Locating -" + e.Message);
            }
              return new SchoolTechAdminPage(this.Browser);
        }

        /// <summary>
        /// Function to log out from current page
        /// </summary>
        /// <returns></returns>
        public bool LogOut()
        {
            try
            {
                SchooltechMenu.LocateSuperMenuControls();
                /// Click User Options tab
                if (this.WaitForElement("XPATH", (string)SchooltechMenu.objectRepository.ObjectRepositoryTable["SuperUserOption"]))
                {
                    SchooltechMenu.UserOptionControl.Click();
                }

                SchooltechMenu.LocateUserOptionControls();

                /// Click on Profile link
                this.SchooltechMenu.LogOffLinkControl.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }
}
