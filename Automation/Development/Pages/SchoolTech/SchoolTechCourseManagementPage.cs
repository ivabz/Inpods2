using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Automation.Development.Browsers;
using Automation.Development.Pages.Common;
using Automation.TestScripts;

namespace Automation.Development.Pages.SchoolTech
{
    /// <summary>
    /// Course management page class
    /// </summary>
    public class SchoolTechCourseManagementPage : SchoolTechNavigationMenu
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
        public SchoolTechCourseManagementPage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.CourseManagementPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                //this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
        }

        #region Locate control methods

        /// <summary>
        /// Methods to LocateSemesterLinkControls
        /// </summary>
        private void LocateSemesterLinkControls()
        {
            /// Course management Page controls goes here.
            
            /// CreateSemesterModule
            bool isCreateSemesterButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateSemesterButton"]);
            if (!isCreateSemesterButton)
            {
                throw new Exception("CreateSemesterButton");
            }
            CreateSemesterButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateSemesterButton"]);
        }

        /// <summary>
        /// Method to LocateDeptControls
        /// </summary>
        private void LocateDeptControls()
        {
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
        }

        /// <summary>
        /// Method to LocateSubjectControls
        /// </summary>
        private void LocateSubjectControls()
        {
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
        }

        /// <summary>
        /// Method to LocateCourseControls
        /// </summary>
        private void LocateCourseControls()
        {
            /// CreateCourseModule
            bool isCreateCourseButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateCourseButton"]);
            if (!isCreateCourseButton)
            {
                throw new Exception("CreateCourseButton");
            }
            CreateCourseButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateCourseButton"]);
        }

        /// <summary>
        /// Method to LocateSectionControls
        /// </summary>
        private void LocateSectionControls()
        {
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
        }

        /// <summary>
        /// Method to LocateDownloadSectionDataControls
        /// </summary>
        private void LocateDownloadSectionDataControls()
        {
           
            /// DownloadSectionDataModule
            bool isSectionDownloadButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SectionDownloadButton"]);
            if (!isSectionDownloadButton)
            {
                throw new Exception("SectionDownloadButton");
            }
            SectionDownloadButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SectionDownloadButton"]);           
        }

        /// <summary>
        /// Method to LocateCreateSectionUsingCsvControls
        /// </summary>
        private void LocateCreateSectionUsingCsvControls()
        {
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
        }

        /// <summary>
        /// Method to LocateQuestionBankControls
        /// </summary>
        private void LocateQuestionBankControls()
        {
            /// QuestionBankModule
            bool isManageQuestionBankLinkField = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ManageQuestionBankLinkField"]);
            if (!isManageQuestionBankLinkField)
            {
                throw new Exception("ManageQuestionBankLinkField");
            }
            ManageQuestionBankLinkField = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ManageQuestionBankLinkField"]);
        }

        #endregion

        #region Navigation Methods
        /// <summary>
        /// Method to navigate to create semester page
        /// </summary>
        public CreateSemesterPage GoToCreateSemesterPage()
        {
            this.LocateSemesterLinkControls();

            try
            {
                // New Institute link
                if (this.WaitForElement("XPATH", (string)this.objectRepository.ObjectRepositoryTable["CreateSemesterButton"]))
                {
                    // Click manage Course link
                    this.CreateSemesterButton.Click();
                }
            }
            catch (Exception)
            { }

            return new CreateSemesterPage(this.Browser);

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Method to create new department
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="departmentDescription"></param>
        /// <returns></returns>
        public bool CreateNewDepartment(string departmentName, string departmentDescription)
        {
              try
            {
                string currentPageTitle = Browser.PageTitle;

                this.LocateDeptControls();

                // Enter departmentName
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DepartmentNameField"]))
                {
                    DepartmentNameField.SendKeys(departmentName);
                    
                }

                // Enter departmentDescription 
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["DepartmentDescriptionField"]))
                {
                    DepartmentDescriptionField.SendKeys(departmentDescription);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateDepartmentButton"]))
                {
                    CreateDepartmentButton.Click();
                }

                // Validate creation 
                // TODO: Need confiormation on this
                if (Browser.PageTitle.ToLower().Equals(currentPageTitle.ToLower()))
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

        /// <summary>
        /// Method to create new subject
        /// </summary>
        /// <param name="departmentName">departmentName</param>
        /// <param name="subjectName">subjectName</param>
        /// <param name="description">subjectDescription</param>
        /// <returns>Is Subject created</returns>
        public bool CreateNewSubject(string departmentName, string subjectName, string subjectDescription)
        {
            try
            {
                string currentPageTitle = Browser.PageTitle;

                this.LocateSubjectControls();

                // Enter departmentName
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SelectDepartmentField"]))
                {
                    var department = new SelectElement(SelectDepartmentField);
                    department.SelectByText(departmentName);
                }

                // Enter subjectName 
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubjectNameField"]))
                {
                    SubjectNameField.SendKeys(subjectName);
                }

                // Enter subjectDescription
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubjectDescriptionField"]))
                {
                    SubjectDescriptionField.SendKeys(subjectDescription);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateSubjectField"]))
                {
                    CreateSubjectField.Click();
                }

                // Validate creation 
                // TODO: Need confiormation on this
                if (Browser.PageTitle.ToLower().Equals(currentPageTitle.ToLower()))
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
