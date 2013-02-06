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
    /// Super Home page class
    /// </summary>
    public class SuperAdminPage : SuperNavigationMenu
    {
        #region Supe Home page UI elements 
        /// <summary>
        /// Gets Create new institute button
        /// </summary>
        public IWebElement NewInstituteLink { get; private set; }
        /// <summary>
        /// Gets Manage User button
        /// </summary>
        public IWebElement ManageUserLink { get; private set; }
        /// <summary>
        /// Gets Choose file button
        /// </summary>
        public IWebElement ChooseFileButton { get; private set; }
        /// <summary>
        /// Gets Create institute buttin
        /// </summary>
        public IWebElement CreateInstituteButton { get; private set; }
        #endregion
        /// <summary>
        /// Super Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// Super Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// SuperAdminPage constructor
        /// </summary>
        /// <param name="browser"></param>
        public SuperAdminPage(Browser browser)
            : base(browser)
        {
            /// Initiate Super AdminPage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Super), EnumHelper.OfType(Page.AdminPage));
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
        /// Method to locate Super Admin page UI controls 
        /// </summary>
        private void LocateControls()
        {
            /// New Institute link
            bool isNewInstituteLink = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["NewInstituteLink"]);

            if (!isNewInstituteLink)
            {
                throw new Exception("NewInstituteLink");
            }

            NewInstituteLink = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["NewInstituteLink"]);

            /// Manage User link
            bool isManageUserLink = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageUserLink"]);

            if (!isManageUserLink)
            {
                throw new Exception("ManageUserLink");
            }

            ManageUserLink = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageUserLink"]);
            
            /// Choose file
            bool isChooseFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseFileButton"]);

            if (!isChooseFileButton)
            {
                throw new Exception("ChooseFileButton");
            }

            ChooseFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseFileButton"]);

            /// Create institute
            bool isCreateInstituteButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]);

            if (!isCreateInstituteButton)
            {
                throw new Exception("CreateInstituteButton");
            }

            CreateInstituteButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method to navigate to CreateNewInstitutePage
        /// </summary>
        /// <returns></returns>
        public CreateInstitutePage GoToCreateInstitutePage()
        {
            try
            {
                /// New Institute link
                bool isNewInstituteLink = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["NewInstituteLink"]);

                if (!isNewInstituteLink)
                {
                    throw new Exception("NewInstituteLink");
                }

                /// Click on Create new institute link
                this.NewInstituteLink.Click();
            }
            catch (Exception e)
            {
                throw new Exception ("Error locating - " + e.Message);
            }

            return new CreateInstitutePage(this.Browser);
        }
        
        #endregion
    }
}
