using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Development.Browsers;
using Automation.TestScripts;

namespace Automation.Development.Pages.Common
{
    public class ContactSupportPage : HomeBase
    {

        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// School tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Contact support page constructor
        /// </summary>
        public ContactSupportPage(Browser browser) : base (browser)
        {
            objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.ContactSupportPage), EnumHelper.OfType(Role.Common));
            objectRepository = new ObjectRepository(objectRepositoryFilePath);
        }
    }
}
