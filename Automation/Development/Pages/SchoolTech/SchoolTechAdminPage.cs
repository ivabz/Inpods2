using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Development.Browsers;
using Automation.TestScripts;
using OpenQA.Selenium;

namespace Automation.Development.Pages.SchoolTech
{
    public class SchoolTechAdminPage : SchoolTechNavigationMenu
    {
        #region User Controls

        /// <summary>
        /// User Management : 
        /// Manage user control
        /// </summary>
        public IWebElement ManageUser { get; private set; }

        /// <summary>
        /// Course Management: 
        /// Manage Course control
        /// </summary>
        public IWebElement ManageCourse { get; private set; }

        /// <summary>
        /// Concepts Management:
        /// manage concepts control
        /// </summary>
        public IWebElement ManageConcepts { get; private set; }

        /// <summary>
        /// Gets PurposeType Field
        /// Upload Homework file:
        /// </summary>
        public IWebElement PurposeType { get; private set; }

        /// <summary>
        /// Gets ChooseHomeworkFileButton
        /// Upload Homework file:
        /// </summary>
        public IWebElement ChooseHomeworkFileButton { get; private set; }

        /// <summary>
        /// Gets UploadHomeworkFileButton
        /// Upload Homework file:
        /// </summary>
        public IWebElement UploadHomeworkFileButton { get; private set; }

        /// <summary>
        /// Gets AssignFileName
        /// Assign Bunch of Homeworks
        /// </summary>
        public IWebElement AssignFileName { get; private set; }

        /// <summary>
        /// Gets AssignHomeworkType
        /// Assign Bunch of Homeworks
        /// </summary>
        public IWebElement AssignHomeworkType { get; private set; }

        /// <summary>
        /// Gets AssignLessonName
        /// Assign Bunch of Homeworks
        /// </summary>
        public IWebElement AssignLessonName { get; private set; }

        /// <summary>
        /// Gets AssignHomeworkButton
        /// Assign Bunch of Homeworks
        /// </summary>
        public IWebElement AssignHomeworkButton { get; private set; }

        /// <summary>
        /// Gets UploadHomeworkType
        /// Upload Homework Excel:
        /// </summary>
        public IWebElement UploadHomeworkType { get; private set; }

        /// <summary>
        /// Gets UploadLessonName
        /// Upload Homework Excel:
        /// </summary>
        public IWebElement UploadLessonName { get; private set; }

        /// <summary>
        /// Gets UploadExcelButton
        /// Upload Homework Excel:
        /// </summary>
        public IWebElement UploadExcelButton { get; private set; }

        /// <summary>
        /// Gets AssignExcelButton
        /// Upload Homework Excel:
        /// </summary>
        public IWebElement AssignExcelButton { get; private set; }

        /// <summary>
        /// Gets ExamIdField
        /// Exam details:
        /// </summary>
        public IWebElement ExamIdField { get; private set; }

        /// <summary>
        /// Gets ChooseExamFileField
        /// Exam details:
        /// </summary>
        public IWebElement ChooseExamFileField { get; private set; }

        /// <summary>
        /// Gets ImportExamDetailsButton
        /// Exam details:
        /// </summary>
        public IWebElement ImportExamDetailsButton { get; private set; } 
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
        /// Admin page constructor
        /// </summary>
        /// <param name="browser"></param>
        public SchoolTechAdminPage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech),EnumHelper.OfType(Page.AdminPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Helper method
        /// <summary>
        /// Method to locate Admin page controls
        /// </summary>
        private void LocateControls()
        {
            bool isManageUser = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageUserControl"]);
            if (!isManageUser)
            {
                throw new Exception("ManageUserControl");
            }
            ManageUser = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageUserControl"]);

            bool isManageCourse = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageCourseControl"]);
            if (!isManageCourse)
            {
                throw new Exception("ManageCourseControl");
            }
            ManageCourse = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageCourseControl"]);

            bool isManageConcepts = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageConceptsControl"]);
            if (!isManageConcepts)
            {
                throw new Exception("ManageConceptsControl");
            }
            ManageConcepts = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageConceptsControl"]);
        }
        #endregion

        #region Page Navigatoin methods 
        /// <summary>
        /// Method to navigate to User management page
        /// </summary>
        /// <returns></returns>
        public SchoolTechUserManagementPage GotoUserManagementPage()
        {
            try
            {
                // New Institute link
                if (this.WaitForElement("XPATH", (string)this.objectRepository.ObjectRepositoryTable["ManageUserControl"]))
                {
                    // Click manage user link
                    this.ManageUser.Click();
                }                
            }
            catch (Exception)
            { }

            return new SchoolTechUserManagementPage(this.Browser);
 
        }
        
        public SchoolTechCourseManagementPage GotoCourseManagementPage()
        {
            try
            {
                // New Institute link
                if (this.WaitForElement("XPATH", (string)this.objectRepository.ObjectRepositoryTable["ManageCourseControl"]))
                {
                    // Click manage Course link
                    this.ManageCourse.Click();
                }                
            }
            catch (Exception)
            { }

            return new SchoolTechCourseManagementPage(this.Browser);
 
        }
        #endregion

    }
}
