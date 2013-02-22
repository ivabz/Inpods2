using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Text;
using Automation.Development.Browsers;
using Automation.TestScripts;

namespace Automation.Development.Pages.SchoolTech
{
    /// <summary>
    /// Schooltech Question bank management class.
    /// </summary>
    public class SchoolTechManageQuestionBankPage : SchoolTechNavigationMenu
    {
        /// <summary>
        /// SchoolTechManageQuestionBankPage Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// SchoolTechManageQuestionBankPage repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Concepts management page constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechManageQuestionBankPage(Browser browser)
            : base(browser)
        {
            /// Initiate User management page object repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.ConceptManagementPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

    }
}
