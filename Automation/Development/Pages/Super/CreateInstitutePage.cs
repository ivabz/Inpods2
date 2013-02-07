using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;
using Automation.TestScripts;
using OpenQA.Selenium.Support.UI;

namespace Automation.Development.Pages.Super
{
    /// <summary>
    /// Create Institute page class
    /// </summary>
    public class CreateInstitutePage : SuperNavigationMenu
    {
        #region
        /// <summary>
        /// Gets FirstNameField
        /// </summary>
        public IWebElement FirstNameField { get; private set; }
        /// <summary>
        /// Gets LastNameField
        /// </summary>
        public IWebElement LastNameField { get; private set; }
        /// <summary>
        /// Gets EmailField
        /// </summary>
        public IWebElement EmailField { get; private set; }
        /// <summary>
        /// Gets PasswordField
        /// </summary>
        public IWebElement PasswordField { get; private set; }
        /// <summary>
        /// Gets ConfirmPasswordField
        /// </summary>
        public IWebElement ConfirmPasswordField { get; private set; }
        /// <summary>
        /// Gets CreateTechAdminButton
        /// </summary>
        public IWebElement CreateTechAdminButton { get; private set; }
        /// <summary>
        /// Gets InstituteCleanupNameField
        /// </summary>
        public IWebElement InstituteCleanupNameField { get; private set; }
        /// <summary>
        /// Gets DeleteInstituteButton
        /// </summary>
        public IWebElement DeleteInstituteButton { get; private set; }
        /// <summary>
        /// Gets InstituteNameField
        /// </summary>
        public IWebElement InstituteNameField { get; private set; }
        /// <summary>
        /// Gets InstituteDescriptionField
        /// </summary>
        public IWebElement InstituteDescriptionField { get; private set; }
        /// <summary>
        /// Gets InstituteShortNameField
        /// </summary>
        public IWebElement InstituteShortNameField { get; private set; }
        /// <summary>
        /// Gets LogoChooseFileButton
        /// </summary>
        public IWebElement LogoChooseFileButton { get; private set; }
        /// <summary>
        /// Gets SchoolTechSelectField
        /// </summary>
        public IWebElement SchoolTechSelectField { get; private set; }
        /// <summary>
        /// Gets SelectTimeZoneField
        /// </summary>
        public IWebElement SelectTimeZoneField { get; private set; }
        /// <summary>
        /// Gets SelectPasswordResetField
        /// </summary>
        public IWebElement SelectPasswordResetField { get; private set; }
        /// <summary>
        /// Gets CreateInstituteButton
        /// </summary>
        public IWebElement CreateInstituteButton { get; private set; }
        /// <summary>
        /// Gets ChooseCSVButton
        /// </summary>
        public IWebElement ChooseCSVButton { get; private set; }
        /// <summary>
        /// Gets ChooseLogoFileButton
        /// </summary>
        public IWebElement ChooseLogoFileButton { get; private set; }

        /// <summary>
        /// Gets Create institute by CSV button
        /// </summary>
        public IWebElement CreateInstituteCsvButton { get; private set; }
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
        /// Create institute page constructor
        /// </summary>
        /// <param name="browser">browser</param>
        public CreateInstitutePage(Browser browser)
            : base(browser)
        {
            /// Initiate Super Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Super), EnumHelper.OfType(Page.CreateInstitutePage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                //this.LocateControls();
                this.LocateTechAdminControls();
                this.LocateAddInstituteControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }

        }

        #region Locate controls methods
        /// <summary>
        /// Locates Tech Admin control on create institute page
        /// </summary>
        private void LocateTechAdminControls()
        {
            /// FirstNameField
            bool isFirstNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["FirstNameField"]);

            if (!isFirstNameField)
            {
                throw new Exception("FirstNameField");
            }

            FirstNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["FirstNameField"]);
            /// LastNameField
            bool isLastNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LastNameField"]);

            if (!isLastNameField)
            {
                throw new Exception("LastNameField");
            }

            LastNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["LastNameField"]);
            /// EmailField
            bool isEmailField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EmailField"]);

            if (!isEmailField)
            {
                throw new Exception("EmailField");
            }

            EmailField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["EmailField"]);
            /// PasswordField
            bool isPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["PasswordField"]);

            if (!isPasswordField)
            {
                throw new Exception("PasswordField");
            }

            PasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["PasswordField"]);
            /// ConfirmPasswordField
            bool isConfirmPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]);

            if (!isConfirmPasswordField)
            {
                throw new Exception("ConfirmPasswordField");
            }

            ConfirmPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]);

            /// Create Techadmin button
            bool isCreateTechAdminButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateTechAdminButton"]);

            if (!isCreateTechAdminButton)
            {
                throw new Exception("CreateTechAdminButton");
            }

            CreateTechAdminButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateTechAdminButton"]);

        }
        /// <summary>
        /// Locates Delete Institute Conrols on Create Institute Page
        /// </summary>
        private void LocateDeleteInstituteControls()
        {
            /// InstituteCleanupNameField
            bool isInstituteCleanupNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteCleanupNameField"]);

            if (!isInstituteCleanupNameField)
            {
                throw new Exception("InstituteCleanupNameField");
            }

            InstituteCleanupNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["InstituteCleanupNameField"]);
            /// DeleteInstituteButton
            bool isDeleteInstituteButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DeleteInstituteButton"]);

            if (!isDeleteInstituteButton)
            {
                throw new Exception("DeleteInstituteButton");
            }

            DeleteInstituteButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["DeleteInstituteButton"]);
        }
        /// <summary>
        /// Locates Add new institute controls on create institute page
        /// </summary>
        private void LocateAddInstituteControls()
        {
            /// InstituteNameField
            bool isInstituteNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteNameField"]);

            if (!isInstituteNameField)
            {
                throw new Exception("InstituteNameField");
            }

            InstituteNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["InstituteNameField"]);
            /// InstituteDescriptionField
            bool isInstituteDescriptionField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteDescriptionField"]);

            if (!isInstituteDescriptionField)
            {
                throw new Exception("InstituteDescriptionField");
            }

            InstituteDescriptionField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["InstituteDescriptionField"]);
            /// InstituteShortNameField
            bool isInstituteShortNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteShortNameField"]);

            if (!isInstituteShortNameField)
            {
                throw new Exception("InstituteShortNameField");
            }

            InstituteShortNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["InstituteShortNameField"]);
            /// LogoChooseFileButton
            bool isLogoChooseFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LogoChooseFileButton"]);

            if (!isLogoChooseFileButton)
            {
                throw new Exception("LogoChooseFileButton");
            }

            LogoChooseFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["LogoChooseFileButton"]);
            /// SchoolTechSelectField
            bool isSchoolTechSelectField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SchoolTechSelectField"]);

            if (!isSchoolTechSelectField)
            {
                throw new Exception("SchoolTechSelectField");
            }

            SchoolTechSelectField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SchoolTechSelectField"]);
            /// SelectTimeZoneField
            bool isSelectTimeZoneField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectTimeZoneField"]);

            if (!isSelectTimeZoneField)
            {
                throw new Exception("SelectTimeZoneField");
            }

            SelectTimeZoneField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectTimeZoneField"]);
            /// SelectPasswordResetField
            bool isSelectPasswordResetField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectPasswordResetField"]);

            if (!isSelectPasswordResetField)
            {
                throw new Exception("SelectPasswordResetField");
            }

            SelectPasswordResetField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectPasswordResetField"]);
            /// CreateInstituteButton
            bool isCreateInstituteButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]);

            if (!isCreateInstituteButton)
            {
                throw new Exception("CreateInstituteButton");
            }
            CreateInstituteButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]);
        }
        /// <summary>
        /// Locates Add new institute Using CSV controls on Create Institute Mage
        /// </summary>
        private void LocateAddInstituteUsingCsvControls()
        {
            
            /// ChooseCSVButton
            bool isChooseCSVButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseCSVButton"]);

            if (!isChooseCSVButton)
            {
                throw new Exception("ChooseCSVButton");
            }

            ChooseCSVButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseCSVButton"]);
            /// ChooseLogoFileButton
            bool isChooseLogoFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseLogoFileButton"]);

            if (!isChooseLogoFileButton)
            {
                throw new Exception("ChooseLogoFileButton");
            }

            ChooseLogoFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseLogoFileButton"]);

            /// CreateInstituteCsvButton
            bool isCreateInstituteCsvButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteCsvButton"]);

            if (!isCreateInstituteCsvButton)
            {
                throw new Exception("CreateInstituteCsvButton");
            }

            CreateInstituteCsvButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateInstituteCsvButton"]);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Method to Create Tech admin
        /// </summary>
        /// <param name="firstName">First name </param>
        /// <param name="lastName">Last Name</param>
        /// <param name="email">Email Id/ User Name</param>
        /// <param name="password">Password</param>
        public bool CreateTechadmin(string firstName, string lastName, string email, string password)
        {
            try
            {
                string currentPagetitle = this.Browser.PageTitle;
                // Locate Corresponding Tech Admin Module controls 
                LocateTechAdminControls();

                // FirstNameField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["FirstNameField"]))
                {
                    this.FirstNameField.SendKeys(firstName); 
                }

                // LastNameField
                if(this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LastNameField"]))
                {
                    this.LastNameField.SendKeys(lastName);
                }

                //EmailField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EmailField"]))
                {
                    this.EmailField.SendKeys(email); 
                }

                // PasswordField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["PasswordField"]))
                {
                    this.PasswordField.SendKeys(password); 
                }
                
                // ConfirmPasswordField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]))
                {
                    this.ConfirmPasswordField.SendKeys(password); 
                }

                // Create Techadmin button
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateTechAdminButton"]))
                {
                    this.CreateTechAdminButton.Click(); 
                }

                // Checks if creation succesfull
                if (Browser.PageTitle.ToLower().Equals(currentPagetitle.ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error location - " + e.Message);
            }

        }

        /// <summary>
        /// Method to Create new institute Manually
        /// </summary>
        /// <param name="instituteName">Institute name</param>
        /// <param name="description">Description</param>
        /// <param name="shortname">Short name </param>
        /// <param name="logoFileLocation">Logog file location</param>
        /// <param name="schoolTechType">Schooltech(TechAdmin) Name</param>
        /// <param name="timeZoneType">Time zone</param>
        /// <param name="passResetType"> Password reset type</param>
        public bool AddNewInstitute(string instituteName,string description, string shortname,string logoFileLocation, string schoolTechType,string timeZoneType, string passResetType)
        {
            try
            {
                string currentPagetitle = this.Browser.PageTitle;
                // Locate corresponding Add Institute module control
                LocateAddInstituteControls();

                // InstituteNameField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteNameField"]))
                {
                    InstituteNameField.SendKeys(instituteName); 
                }                

                // InstituteDescriptionField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteDescriptionField"]))
                {
                    InstituteDescriptionField.SendKeys(description);
                }

                // InstituteShortNameField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteShortNameField"]))
                { 
                    InstituteShortNameField.SendKeys(shortname); 
                }

                // LogoChooseFileButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LogoChooseFileButton"]))
                {
                    LogoChooseFileButton.SendKeys(logoFileLocation);
                }

                // SchoolTechSelectField                
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SchoolTechSelectField"]))
                {
                    // Select Desired schooltech element
                    var schoolTech = new SelectElement(this.SchoolTechSelectField);
                    schoolTech.SelectByValue(schoolTechType);
                }


                /// SelectTimeZoneField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectTimeZoneField"]))
                {
                    var timeZone = new SelectElement(this.SelectTimeZoneField);
                    timeZone.SelectByText(timeZoneType);
                }


                /// SelectPasswordResetField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectPasswordResetField"]))
                {
                    /// Select Password reset type
                    var passReset = new SelectElement(this.SelectPasswordResetField);
                    passReset.SelectByText(passResetType);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]))
                {
                    // Click create institute button
                    CreateInstituteButton.Click();
                }

                // Checks if creation succesfull
                if (Browser.PageTitle.ToLower().Equals(currentPagetitle.ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete institute
        /// </summary>
        /// <param name="instituteName"></param>
        /// <returns>Is Deleted</returns>
        public bool DeleteInstitute(string instituteName)
        {
            try
            {
                string currentPageTitle = this.Browser.PageTitle;
                LocateDeleteInstituteControls();
                /// InstituteCleanupNameField
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteCleanupNameField"]))
                {
                    InstituteCleanupNameField.SendKeys(instituteName);
                }

                /// DeleteInstituteButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DeleteInstituteButton"]))
                {
                    DeleteInstituteButton.Click();
                }
                if (Browser.PageTitle.ToLower().Equals(currentPageTitle.ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to add Institute using CSV file
        /// TODO : Testing this function is pending since, No way for validating if the institute has been created succesfully
        /// </summary>
        /// <param name="csvFilePath">CSV file path</param>
        /// <param name="logoFilePath">Logo file path</param>
        /// <returns>Is Added</returns>
        public bool AddNewInstituteUsingCsv(string csvFilePath, string logoFilePath)
        {
            try
            {
                string currentPageTitle = Browser.PageTitle;

                LocateAddInstituteUsingCsvControls();
                /// ChooseCSVButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseCSVButton"]))
                {
                    ChooseCSVButton.SendKeys(csvFilePath);
                }

                /// ChooseLogoFileButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseLogoFileButton"]))
                {
                    ChooseLogoFileButton.SendKeys(logoFilePath);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteCsvButton"]))
                {
                    CreateInstituteCsvButton.Click();
                }
                
                // Validate creation 
                // TODO: Need confiormation on this
                if(Browser.PageTitle.ToLower().Equals(currentPageTitle.ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Error locating - " + e.Message);
            }
        }
        #endregion
    }
}
