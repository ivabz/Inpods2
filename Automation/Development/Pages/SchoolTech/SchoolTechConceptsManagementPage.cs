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
    /// Concept management page class
    /// </summary>
    public class SchoolTechConceptsManagementPage : SchoolTechNavigationMenu
    {
        #region Concepts management page controls
        /// <summary>
        /// Gets SelectParentConceptLink
        /// </summary>
        public IWebElement SelectParentConceptField { get; private set; }

        /// <summary>
        /// Gets ParantConcept as Root
        /// </summary>
        public IWebElement ParantConceptRoot { get; private set; }

        /// <summary>
        /// Gets ConceptNameField
        /// </summary>
        public IWebElement ConceptNameField { get; private set; }

        /// <summary>
        /// Gets CreateConceptButton
        /// </summary>
        public IWebElement CreateConceptButton { get; private set; }

        /// <summary>
        /// Gets ChooseConceptFileButton
        /// </summary>
        public IWebElement ChooseConceptFileButton { get; private set; }

        /// <summary>
        /// Gets UploadConceptsFileButton
        /// </summary>
        public IWebElement UploadConceptsFileButton { get; private set; }
        
        /// <summary>
        /// Gets DownloadConceptsButton
        /// </summary>
        public IWebElement DownloadConceptsButton { get; private set; }

        #endregion

        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// school tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Concepts management page constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechConceptsManagementPage(Browser browser)
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

        #region Helper Methods
        /// <summary>
        /// Method to locate Concept management page controls
        /// </summary>
        private void LocateControls()
        {
            // Select Parent Concept
            bool isSelectParentConceptField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectParentConceptField"]);
            if (!isSelectParentConceptField)
            {
                throw new Exception("SelectParentConceptField");
            }
            SelectParentConceptField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectParentConceptField"]);

            /// Create Concept Name
            bool isConceptNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConceptNameField"]);
            if (!isConceptNameField)
            {
                throw new Exception("ConceptNameField");
            }
            ConceptNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ConceptNameField"]);

            bool isCreateConceptButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateConceptButton"]);
            if (!isCreateConceptButton)
            {
                throw new Exception("CreateConceptButton");
            }
            CreateConceptButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateConceptButton"]);

            bool isChooseConceptFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseConceptFileButton"]);
            if (!isChooseConceptFileButton)
            {
                throw new Exception("ChooseConceptFileButton");
            }
            ChooseConceptFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseConceptFileButton"]);

            bool isUploadConceptsFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UploadConceptsFileButton"]);
            if (!isUploadConceptsFileButton)
            {
                throw new Exception("UploadConceptsFileButton");
            }
            UploadConceptsFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UploadConceptsFileButton"]);

            bool isDownloadConceptsButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DownloadConceptsButton"]);
            if (!isDownloadConceptsButton)
            {
                throw new Exception("DownloadConceptsButton");
            }
            DownloadConceptsButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["DownloadConceptsButton"]);
        }

        /// <summary>
        /// Method to locate Parent Concepts tree.
        /// TODO: Add ability to select any parent concept
        /// </summary>
        private void LocateParentConcepts()
        {
            // Select Parent Concept
            bool isParantConceptRoot = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ParantConceptRoot"]);
            if (!isParantConceptRoot)
            {
                throw new Exception("ParantConceptRoot");
            }
            ParantConceptRoot = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ParantConceptRoot"]);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method to create new concept (Default under parent 'root')
        /// TODO: Add abiltiy create concept under any parent concept
        /// </summary>
        /// <param name="conceptName"></param>
        public void CreateConcept(string conceptName)
        {
            this.LocateControls();

            // Select root as Parent concept
            if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectParentConceptField"]))
            {
                // Click on select Parent concepts
                SelectParentConceptField.Click();

                // Locate Dynamic tree concepts
                this.LocateParentConcepts();

                // Select Root as parent concept
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ParantConceptRoot"]))
                {
                    ParantConceptRoot.Click();
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            else
            {
                throw new NotFoundException();
            }

            if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConceptNameField"]) && this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateConceptButton"]))
            {
                ConceptNameField.SendKeys(conceptName);
                CreateConceptButton.Click();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        /// <summary>
        /// Method to Upload Concepts file CSV
        /// </summary>
        /// <param name="filePath"></param>
        public void UploadConceptsAsCsv(string filePath)
        {
            this.LocateControls();

            if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseConceptFileButton"]) && this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UploadConceptsFileButton"]))
            {
                ChooseConceptFileButton.SendKeys(filePath);
                UploadConceptsFileButton.Click();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        /// <summary>
        /// Method to Download all concepts
        /// </summary>
        /// <param name="filePath"> File path</param>
        public void DownloadConcepts(string filePath)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
