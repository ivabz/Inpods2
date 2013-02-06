using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.Super
{
    public class SuperNavigationMenu : HomeBase
    {
        /// <summary>
        /// Site Navigation menu
        /// </summary>
        public SiteNavigationMenu SuperMenu { get; private set; }
        
        /// <summary>
        /// SuperNavigationMenu Constructor 
        /// </summary>
        /// <param name="browser"></param>
        public SuperNavigationMenu(Browser browser)
            : base(browser)
        {
            try
            {

                SuperMenu = new SiteNavigationMenu(browser);
                SuperMenu.LocateSuperMenuControls();
            }
            catch (Exception exception)
            {

                throw new Exception("Error Locating - " + exception.Message); ;
            }
        }

        #region Public Methods
        /// <summary>
        /// Method to Navigate to Admin Page
        /// </summary>
        /// <returns></returns>
        public SuperAdminPage GotoAdminPage()
        {
            try
            {
                /// Click on Admin Tab and navigate to admin page
                bool isadminTabControl = this.WaitForElement("XPATH", (string)SuperMenu.objectRepository.ObjectRepositoryTable["SuperAdmin"]);

                if (!isadminTabControl)
                {
                    throw new Exception("Admin Tab");
                }

                SuperMenu.AdminTabControl.Click();
            }
            catch (Exception e)
            { 
                throw new Exception ("Error locating - " + e.Message);
            }

            /// return profiles page
            return new SuperAdminPage(this.Browser);
        }
        #endregion
    }
}
