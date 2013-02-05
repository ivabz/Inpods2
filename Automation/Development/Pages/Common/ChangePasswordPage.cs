using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.TestScripts;

namespace Automation.Development.Pages.Common
{
    public class ChangePasswordPage : HomeBase
    {
        private IWebElement currentPassField;

        /// <summary>
        /// Gets Current Password field control
        /// </summary>
        public IWebElement CurrentPassField
        {
            get { return currentPassField; }
            private set { currentPassField = value; }
        }

        private IWebElement newPasswordField;

        /// <summary>
        /// Gets New Password field control
        /// </summary>
        public IWebElement NewPasswordField
        {
            get { return newPasswordField; }
            private set { newPasswordField = value; }
        }

        private IWebElement confirmPasswordField;

        /// <summary>
        /// Gets Confirm Password field control
        /// </summary>
        public IWebElement ConfirmPasswordField
        {
            get { return confirmPasswordField; }
            private set { confirmPasswordField = value; }
        }

        /// <summary>
        /// Change Password Button
        /// </summary>
        public IWebElement ChangePasswordButton { get; private set; }

        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// School tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Change Password Page constructor
        /// </summary>
        /// <param name="browser"></param>
        public ChangePasswordPage(Browser browser) :
            base(browser)
        {
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Common),EnumHelper.OfType(Page.ChangePasswordPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControl();
             }
            catch (Exception e)
            {
                throw new Exception("Unable to find control - " + e.Message);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Methods to control Change Password page controls 
        /// </summary>
        private void LocateControl()
        {
            bool isCurrentPassField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CurrentPasswordField"]);
            if (!isCurrentPassField)
            {
                throw new Exception("CurrentPasswordField");
            }
            CurrentPassField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CurrentPasswordField"]);

            bool isNewPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["NewPasswordField"]);
            if (!isNewPasswordField)
            {
                throw new Exception("NewPasswordField");
            }
            NewPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["NewPasswordField"]);

            bool isConfirmPasswordField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]);
            if (!isConfirmPasswordField)
            {
                throw new Exception("ConfirmPasswordField");
            }
            ConfirmPasswordField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ConfirmPasswordField"]);

            bool isChangePasswordButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChangePaswordButton"]);
            if (!isChangePasswordButton)
            {
                throw new Exception("ChangePaswordButton");
            }
            ChangePasswordButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChangePaswordButton"]);
        }
        #endregion
    }
}
