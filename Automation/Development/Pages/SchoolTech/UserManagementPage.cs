using System;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;
using Automation.TestScripts;

namespace Automation.Development.Pages.SchoolTech
{
    /// <summary>
    /// User management page Class
    /// </summary>
    public class UserManagementPage : SchoolTechNavigationMenu
    {
        #region User Management Page fields
        /// <summary>
        /// Gets User Type Dropdown
        /// </summary>
        public IWebElement ChooseUserField { get; private set; }
        /// <summary>
        /// Gets New password field 
        /// </summary>
        public IWebElement NewPasswordField { get; private set; }
        /// <summary>
        /// Gets Change password field
        /// </summary>
        public IWebElement ChangePasswordButton { get; private set; }

        /// <summary>
        /// Gets User role drop down field 
        /// </summary>
        public IWebElement SelectRoleField { get; private set; }
        /// <summary>
        /// Gets user first name field
        /// </summary>
        public IWebElement UserFirstNameField { get; private set; }
        /// <summary>
        /// Gets user last name field 
        /// </summary>
        public IWebElement UserLastNameField { get; private set; }
        /// <summary>
        /// Gets user email field 
        /// </summary>
        public IWebElement UserEmailField { get; private set; }
        /// <summary>
        /// Gets user password field
        /// </summary>
        public IWebElement UserPasswordField { get; private set; }
        /// <summary>
        /// Gets user Confirm password field 
        /// </summary>
        public IWebElement UserConfirmPasswordField { get; private set; }
        /// <summary>
        /// Gets Create User button 
        /// </summary>
        public IWebElement CreateUserButton { get; private set; }

        /// <summary>
        /// Gets StudentFirstNameField
        /// </summary>
        public IWebElement StudentFirstNameField { get; private set; }
        /// <summary>
        /// Gets StudentLastNameField
        /// </summary>
        public IWebElement StudentLastNameField { get; private set; }
        /// <summary>
        /// Gets StudentEmailField
        /// </summary>
        public IWebElement StudentEmailField { get; private set; }

        /// <summary>
        /// Gets StudentPasswordField
        /// </summary>
        public IWebElement StudentPasswordField { get; private set; }
        /// <summary>
        /// Gets StudentConfirmPasswordField
        /// </summary>
        public IWebElement StudentConfirmPasswordField { get; private set; }
        /// <summary>
        /// Gets CreateStudentButton
        /// </summary>
        public IWebElement CreateStudentButton { get; private set; }

        /// <summary>
        /// Gets EnrollButton
        /// </summary>
        public IWebElement EnrollButton { get; private set; }
        /// <summary>
        /// Gets ChooseParentField
        /// </summary>
        public IWebElement ChooseParentField { get; private set; }
        /// <summary>
        /// Gets ChooseStudentField
        /// </summary>
        public IWebElement ChooseStudentField { get; private set; }
        /// <summary>
        /// Gets AssociateButton
        /// </summary>
        public IWebElement AssociateButton { get; private set; }

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
        /// User management page constructor
        /// </summary>
        /// <param name="browser"></param>
        public UserManagementPage(Browser browser)
            : base(browser)
        {
            /// Initiate User management page object repository
            try
            {
                /// TODO: see if this work
                /// objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), Enum.GetName(typeof(Page), Page.LoginPage));
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.UserManagementPage));
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
        /// Method to locate UserManagement page controls
        /// </summary>
        private void LocateControls()
        {
            /// Manage User Group
            bool isChooseUserField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseUserField"]);
            if (!isChooseUserField)
            {
                throw new Exception("ChooseUserField");
            }
            ChooseUserField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseUserField"]);

            bool isNewPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["NewPasswordField"]);
            if (!isNewPasswordField)
            {
                throw new Exception("NewPasswordField");
            }
            NewPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["NewPasswordField"]);

            bool isChangePasswordButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChangePasswordButton"]);
            if (!isChangePasswordButton)
            {
                throw new Exception("ChangePasswordButton");
            }
            ChangePasswordButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChangePasswordButton"]);

            /// Create User Group
            bool isSelectRoleField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectRoleField"]);
            if (!isSelectRoleField)
            {
                throw new Exception("SelectRoleField");
            }
            SelectRoleField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectRoleField"]);

            bool isUserFirstNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserFirstNameField"]);
            if (!isUserFirstNameField)
            {
                throw new Exception("UserFirstNameField");
            }
            UserFirstNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserFirstNameField"]);

            bool isUserLastNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserLastNameField"]);
            if (!isUserLastNameField)
            {
                throw new Exception("UserLastNameField");
            }
            UserLastNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserLastNameField"]);

            bool isUserEmailField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserEmailField"]);
            if (!isUserEmailField)
            {
                throw new Exception("UserEmailField");
            }
            UserEmailField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserEmailField"]);

            bool isUserPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserPasswordField"]);
            if (!isUserPasswordField)
            {
                throw new Exception("UserPasswordField");
            }
            UserPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserPasswordField"]);

            bool isUserConfirmPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserConfirmPasswordField"]);
            if (!isUserConfirmPasswordField)
            {
                throw new Exception("UserConfirmPasswordField");
            }
            UserConfirmPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserConfirmPasswordField"]);

            bool isCreateUserButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateUserButton"]);
            if (!isCreateUserButton)
            {
                throw new Exception("CreateUserButton");
            }
            CreateUserButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateUserButton"]);

            /// EnrollStudentGroup
            bool isStudentFirstNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StudentFirstNameField"]);
            if (!isStudentFirstNameField)
            {
                throw new Exception("StudentFirstNameField");
            }
            StudentFirstNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StudentFirstNameField"]);

            bool isStudentLastNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StudentLastNameField"]);
            if (!isStudentLastNameField)
            {
                throw new Exception("StudentLastNameField");
            }
            StudentLastNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StudentLastNameField"]);

            bool isStudentEmailField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StudentEmailField"]);
            if (!isStudentEmailField)
            {
                throw new Exception("StudentEmailField");
            }
            StudentEmailField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StudentEmailField"]);

            bool isStudentPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StudentPasswordField"]);
            if (!isStudentPasswordField)
            {
                throw new Exception("StudentPasswordField");
            }
            StudentPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StudentPasswordField"]);

            bool isStudentConfirmPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StudentConfirmPasswordField"]);
            if (!isStudentConfirmPasswordField)
            {
                throw new Exception("StudentConfirmPasswordField");
            }
            StudentConfirmPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StudentConfirmPasswordField"]);

            bool isCreateStudentButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateStudentButton"]);
            if (!isCreateStudentButton)
            {
                throw new Exception("CreateStudentButton");
            }
            CreateStudentButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateStudentButton"]);

            /// TODO: Add additional control locators 
            bool isEnrollButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EnrollButton"]);
            if (!isEnrollButton)
            {
                throw new Exception("EnrollButton");
            }
            EnrollButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["EnrollButton"]);

            /// Relationship 
            bool isChooseParentField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseParentField"]);
            if (!isChooseParentField)
            {
                throw new Exception("ChooseParentField");
            }
            ChooseParentField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseParentField"]);
            bool isChooseStudentField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseStudentField"]);
            if (!isChooseStudentField)
            {
                throw new Exception("ChooseStudentField");
            }
            ChooseStudentField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseStudentField"]);
            bool isAssociateButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["AssociateButton"]);
            if (!isAssociateButton)
            {
                throw new Exception("AssociateButton");
            }
            AssociateButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["AssociateButton"]);
        }
        #endregion

    }
}
