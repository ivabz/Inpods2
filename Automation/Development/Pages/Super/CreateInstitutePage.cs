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
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }

        }

        #region Locate controls methods
        /// <summary>
        /// Locates control on create institute page
        /// </summary>
        private void LocateControls()
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

                /// FirstNameField
                bool isFirstNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["FirstNameField"]);

                if (!isFirstNameField)
                {
                    throw new Exception("FirstNameField");
                }

                this.FirstNameField.SendKeys(firstName);

                /// LastNameField
                bool isLastNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LastNameField"]);

                if (!isLastNameField)
                {
                    throw new Exception("LastNameField");
                }

                this.LastNameField.SendKeys(lastName);

                /// EmailField
                bool isEmailField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EmailField"]);

                if (!isEmailField)
                {
                    throw new Exception("EmailField");
                }

                this.EmailField.SendKeys(email);

                /// PasswordField
                bool isPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["PasswordField"]);

                if (!isPasswordField)
                {
                    throw new Exception("PasswordField");
                }

                this.PasswordField.SendKeys(password);

                /// ConfirmPasswordField
                bool isConfirmPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]);

                if (!isConfirmPasswordField)
                {
                    throw new Exception("ConfirmPasswordField");
                }

                this.ConfirmPasswordField.SendKeys(password);

                /// Create Techadmin button
                bool isCreateTechAdminButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateTechAdminButton"]);

                if (!isCreateTechAdminButton)
                {
                    throw new Exception("CreateTechAdminButton");
                }

                this.CreateTechAdminButton.Click();

                /// Checks if creation succesfull
                if (Browser.PageTitle.Equals(currentPagetitle))
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

                /// InstituteNameField
                bool isInstituteNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteNameField"]);

                if (!isInstituteNameField)
                {
                    throw new Exception("InstituteNameField");
                }

                this.InstituteNameField.SendKeys(instituteName);

                /// InstituteDescriptionField
                bool isInstituteDescriptionField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteDescriptionField"]);

                if (!isInstituteDescriptionField)
                {
                    throw new Exception("InstituteDescriptionField");
                }

                this.InstituteDescriptionField.SendKeys(description);

                /// InstituteShortNameField
                bool isInstituteShortNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["InstituteShortNameField"]);

                if (!isInstituteShortNameField)
                {
                    throw new Exception("InstituteShortNameField");
                }

                this.InstituteShortNameField.SendKeys(shortname);

                /// LogoChooseFileButton
                bool isLogoChooseFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LogoChooseFileButton"]);

                if (!isLogoChooseFileButton)
                {
                    throw new Exception("LogoChooseFileButton");
                }

                /// TODO : Test this.
                this.LogoChooseFileButton.SendKeys(logoFileLocation);


                /// SchoolTechSelectField
                bool isSchoolTechSelectField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SchoolTechSelectField"]);

                if (!isSchoolTechSelectField)
                {
                    throw new Exception("SchoolTechSelectField");
                }

                /// Select Desired schooltech element
                /// TODO: test this
                var schoolTech = new SelectElement(this.SchoolTechSelectField);
                schoolTech.SelectByValue(schoolTechType);


                /// SelectTimeZoneField
                bool isSelectTimeZoneField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectTimeZoneField"]);

                if (!isSelectTimeZoneField)
                {
                    throw new Exception("SelectTimeZoneField");
                }

                var timeZone = new SelectElement(this.SelectTimeZoneField);
                timeZone.SelectByValue(timeZoneType);

                /// SelectPasswordResetField
                bool isSelectPasswordResetField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectPasswordResetField"]);

                if (!isSelectPasswordResetField)
                {
                    throw new Exception("SelectPasswordResetField");
                }

                /// Select Password reset type
                var passReset = new SelectElement(this.SelectPasswordResetField);
                passReset.SelectByValue(passResetType);

                /// CreateInstituteButton
                bool isCreateInstituteButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateInstituteButton"]);

                if (!isCreateInstituteButton)
                {
                    throw new Exception("CreateInstituteButton");
                }
                                
                this.CreateInstituteButton.Click();

                /// Checks if creation succesfull
                if (Browser.PageTitle.Equals(currentPagetitle))
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
        #endregion
    }
}
