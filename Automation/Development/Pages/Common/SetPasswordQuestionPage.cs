using System;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.TestScripts;

namespace Automation.Development.Pages.Common
{
    public class SetPasswordQuestionPage : HomeBase
    {
        private IWebElement currentPassField;

        /// <summary>
        /// Gets current password field
        /// </summary>
        public IWebElement CurrentPassField
        {
            get { return currentPassField; }
            private set { currentPassField = value; }
        }

        private IWebElement selectQestionField;

        /// <summary>
        /// Gets select password question field
        /// </summary>
        public IWebElement SelectQestionField
        {
            get { return selectQestionField; }
            private set { selectQestionField = value; }
        }

        private IWebElement passAnswerField;

        /// <summary>
        /// Gets Password answer field
        /// </summary>
        public IWebElement PassAnswerField
        {
            get { return passAnswerField; }
            private set { passAnswerField = value; }
        }

        /// <summary>
        /// Set button field
        /// </summary>
        public IWebElement SetButton { get; private set; }
        
        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// School tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Set Password Question page Constructor
        /// </summary>
        /// <param name="browser"></param>
        public SetPasswordQuestionPage(Browser browser)
            : base(browser)
        {
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath( EnumHelper.OfType(Role.Common),EnumHelper.OfType(Page.SetPaswordQuestionPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating - " + e.Message);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Method to locate controls on Set Password question page 
        /// </summary>
        private void LocateControls()
        {
            bool isCurrentPassField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CurrentPasswordField"]);
            if (!isCurrentPassField)
            {
                throw new Exception("CurrentPasswordField");
            }
            CurrentPassField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CurrentPasswordField"]);

            bool isSelectQestionField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["selectQuestionField"]);
            if (!isSelectQestionField)
            {
                throw new Exception("selectQuestionField");
            }
            SelectQestionField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["selectQuestionField"]);

            bool isPassAnswerField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["PasswordAnswerField"]);
            if (!isPassAnswerField)
            {
                throw new Exception("PasswordAnswerField");
            }
            PassAnswerField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["PasswordAnswerField"]);

            bool isSetButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SetQuestionButton"]);
            if (!isSetButton)
            {
                throw new Exception("CurrentPasswordField");
            }
            SetButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SetQuestionButton"]);
        }
        #endregion
    }
}
