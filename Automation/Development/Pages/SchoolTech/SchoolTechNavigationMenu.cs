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
            SchooltechMenu.LocateSchoolTechMenuControls(); 
        }
    }
}
