using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;
using Automation.TestScripts;

namespace Automation.Development.Pages.SchoolTech
{
    /// <summary>
    /// Course management page class
    /// </summary>
    public class CourseManagementPage : SchoolTechNavigationMenu
    {
        #region Course Management Page Fields
        /// <summary>
        /// Gets CreateSemesterButton
        /// </summary>
        public IWebElement CreateSemesterButton { get; private set; }
        /// <summary>
        /// Gets DepartmentNameField
        /// </summary>
        public IWebElement DepartmentNameField { get; private set; }
        /// <summary>
        /// Gets DepartmentDescriptionField
        /// </summary>
        public IWebElement DepartmentDescriptionField { get; private set; }
        /// <summary>
        /// Gets CreateDepartmentButton
        /// </summary>
        public IWebElement CreateDepartmentButton { get; private set; }
        /// <summary>
        /// Gets SelectDepartmentField
        /// </summary>
        public IWebElement SelectDepartmentField { get; private set; }
        /// <summary>
        /// Gets SubjectNameField
        /// </summary>
        public IWebElement SubjectNameField { get; private set; }
        /// <summary>
        /// Gets SubjectDescriptionField
        /// </summary>
        public IWebElement SubjectDescriptionField { get; private set; }
        /// <summary>
        /// Gets CreateSubjectField
        /// </summary>
        public IWebElement CreateSubjectField { get; private set; }
        /// <summary>
        /// Gets CreateCourseButton
        /// </summary>
        public IWebElement CreateCourseButton { get; private set; }
        /// <summary>
        /// Gets SelectCourseField
        /// </summary>
        public IWebElement SelectCourseField { get; private set; }
        /// <summary>
        /// Gets SelectTeacherField
        /// </summary>
        public IWebElement SelectTeacherField { get; private set; }
        /// <summary>
        /// Gets SectionNameField
        /// </summary>
        public IWebElement SectionNameField { get; private set; }
        
        //TODO: Manage it as a collection of Days 
        /// <summary>
        /// Gets Collection of MeetingDays
        /// </summary>
        public ReadOnlyCollection<IWebElement> MeetingDaysList { get; private set; }
        /// <summary>
        /// Gets SectionDownloadButton
        /// </summary>
        public IWebElement SectionDownloadButton { get; private set; }

        /// <summary>
        /// Gets ChooseFileButton
        /// </summary>
        public IWebElement ChooseFileButton { get; private set; }
        /// <summary>
        /// Gets CreateSectionButton
        /// </summary>
        public IWebElement CreateSectionButton { get; private set; }
        /// <summary>
        /// Gets ManageQuestionBankLinkField
        /// </summary>
        public IWebElement ManageQuestionBankLinkField { get; private set; }
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
        /// Course management page constructor
        /// </summary>
        /// <param name="browser"></param>
        public CourseManagementPage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.CourseManagementPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Helper methods
        private void LocateControls()
        {
            /// Course management Page controls goes here.
            
            /// CreateSemesterModule
            bool isCreateSemesterButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateSemesterButton"]);
            if (!isCreateSemesterButton)
            {
                throw new Exception("CreateSemesterButton");
            }
            CreateSemesterButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateSemesterButton"]);

            /// CreateDepartmentModule
            bool isDepartmentNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DepartmentNameField"]);
            if (!isDepartmentNameField)
            {
                throw new Exception("DepartmentNameField");
            }
            DepartmentNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["DepartmentNameField"]);

            bool isDepartmentDescriptionField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DepartmentDescriptionField"]);
            if (!isDepartmentDescriptionField)
            {
                throw new Exception("DepartmentDescriptionField");
            }
            DepartmentDescriptionField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["DepartmentDescriptionField"]);

            bool isCreateDepartmentButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateDepartmentButton"]);
            if (!isCreateDepartmentButton)
            {
                throw new Exception("CreateDepartmentButton");
            }
            CreateDepartmentButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateDepartmentButton"]);

            /// CreateSubjectModule
            bool isSelectDepartmentField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectDepartmentField"]);
            if (!isSelectDepartmentField)
            {
                throw new Exception("SelectDepartmentField");
            }
            SelectDepartmentField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectDepartmentField"]);

            bool isSubjectNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubjectNameField"]);
            if (!isSubjectNameField)
            {
                throw new Exception("SubjectNameField");
            }
            SubjectNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SubjectNameField"]);

            bool isSubjectDescriptionField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubjectDescriptionField"]);
            if (!isSubjectDescriptionField)
            {
                throw new Exception("SubjectDescriptionField");
            }
            SubjectDescriptionField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SubjectDescriptionField"]);

            bool isCreateSubjectField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateSubjectField"]);
            if (!isCreateSubjectField)
            {
                throw new Exception("CreateSubjectField");
            }
            CreateSubjectField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateSubjectField"]);

            /// CreateCourseModule
            bool isCreateCourseButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateCourseButton"]);
            if (!isCreateCourseButton)
            {
                throw new Exception("CreateCourseButton");
            }
            CreateCourseButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateCourseButton"]);


            /// CreateSectionModule
            bool isSelectCourseField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectCourseField"]);
            if (!isSelectCourseField)
            {
                throw new Exception("SelectCourseField");
            }
            SelectCourseField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectCourseField"]);

            bool isSelectTeacherField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectTeacherField"]);
            if (!isSelectTeacherField)
            {
                throw new Exception("SelectTeacherField");
            }
            SelectTeacherField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SelectTeacherField"]);

            bool isSectionNameField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SectionNameField"]);
            if (!isSectionNameField)
            {
                throw new Exception("SectionNameField");
            }
            SectionNameField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SectionNameField"]);


            /// Collection of Meeting days checkboxes
            bool isMeetingDaysList = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["MeetingDaysList"]);
            if (!isMeetingDaysList)
            {
                throw new Exception("MeetingDaysList");
            }
            MeetingDaysList = this.FindControlsByXPath((string)objectRepository.ObjectRepositoryTable["MeetingDaysList"]);

            /// DownloadSectionDataModule
            bool isSectionDownloadButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SectionDownloadButton"]);
            if (!isSectionDownloadButton)
            {
                throw new Exception("SectionDownloadButton");
            }
            SectionDownloadButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SectionDownloadButton"]);

            /// UsingCSVModule
            bool isChooseFileButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ChooseFileButton"]);
            if (!isChooseFileButton)
            {
                throw new Exception("ChooseFileButton");
            }
            ChooseFileButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ChooseFileButton"]);

            bool isCreateSectionButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateSectionButton"]);
            if (!isCreateSectionButton)
            {
                throw new Exception("CreateSectionButton");
            }
            CreateSectionButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateSectionButton"]);

            /// QuestionBankModule
            bool isManageQuestionBankLinkField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageQuestionBankLinkField"]);
            if (!isManageQuestionBankLinkField)
            {
                throw new Exception("ManageQuestionBankLinkField");
            }
            ManageQuestionBankLinkField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageQuestionBankLinkField"]);
        }
        #endregion

    }
}
