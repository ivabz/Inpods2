using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.Common;

namespace Automation.Development.Pages.SchoolTech
{

    /// <summary>
    /// Semeter page class 
    /// </summary>
    public class CreateSemesterPage : SchoolTechNavigationMenu
    {
        /// <summary>
        /// Gets SemesterTitle
        /// </summary>
        public IWebElement SemesterTitle { get; private set; }
        /// <summary>
        /// Gets SemesterYear
        /// </summary>
        public IWebElement SemesterYear { get; private set; }
        /// <summary>
        /// Gets SemesterDescription
        /// </summary>
        public IWebElement SemesterDescription { get; private set; }
        /// <summary>
        /// Gets SchoolYear
        /// </summary>
        public IWebElement SchoolYear { get; private set; }
        /// <summary>
        /// Gets StartDate
        /// </summary>
        public IWebElement StartDate { get; private set; }
        /// <summary>
        /// Gets EndDate
        /// </summary>
        public IWebElement EndDate { get; private set; }
        /// <summary>
        /// Gets SubmitButton
        /// </summary>
        public IWebElement SubmitButton { get; private set; }
        /// <summary>
        /// Gets BackLink
        /// </summary>
        public IWebElement BackLink { get; private set; }

        /// <summary>
        /// SchoolTech Object Repository
        /// </summary>
        ObjectRepository objectRepository = null;

        /// <summary>
        /// school tech Object repository path
        /// </summary>
        string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Semester page constructor
        /// </summary>
        /// <param name="browser"></param>
        public CreateSemesterPage(Browser browser)
            : base(browser)
        {
            /// Initiate Schooltech Homepage repository
            try
            {
                objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.SchoolTech), EnumHelper.OfType(Page.CreateSemesterPage));
                objectRepository = new ObjectRepository(objectRepositoryFilePath);
                //this.LocateControls();
            }
            catch (Exception e)
            {
                throw new Exception("Error locating" + e.Message);
            }
 
        }

        #region Locate controls methods
        /// <summary>
        /// Method to Locate controls on Create semester page
        /// </summary>
        private void LocateSemesterControls()
        {
            /// Create Semester Group
            bool isSemesterTitle = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterTitle"]);
            if (!isSemesterTitle)
            {
                throw new Exception("SemesterTitle");
            }
            SemesterTitle = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SemesterTitle"]);

            bool isSemesterYear = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterYear"]);
            if (!isSemesterYear)
            {
                throw new Exception("SemesterYear");
            }
            SemesterYear = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SemesterYear"]);

            bool isSemesterDescription = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterDescription"]);
            if (!isSemesterDescription)
            {
                throw new Exception("SemesterDescription");
            }
            SemesterDescription = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SemesterDescription"]);

            bool isSchoolYear = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SchoolYear"]);
            if (!isSchoolYear)
            {
                throw new Exception("SchoolYear");
            }
            SchoolYear = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SchoolYear"]);

            bool isStartDate = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StartDate"]);
            if (!isStartDate)
            {
                throw new Exception("StartDate");
            }
            StartDate = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["StartDate"]);

            bool isEndDate = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EndDate"]);
            if (!isEndDate)
            {
                throw new Exception("EndDate");
            }
            EndDate = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["EndDate"]);

            bool isSubmitButton = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubmitButton"]);
            if (!isSubmitButton)
            {
                throw new Exception("SubmitButton");
            }
            SubmitButton = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SubmitButton"]);
        }
        /// <summary>
        /// Method to locate 
        /// </summary>
        private void LocateBackLinkControl()
        {
            bool isBackLink = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["BackLink"]);
            if (!isBackLink)
            {
                throw new Exception("BackLink");
            }
            BackLink = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["BackLink"]);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Method to CreateNewSemester 
        /// </summary>
        /// <param name="semesterTitle">Semester Title</param>
        /// <param name="year">Year </param>
        /// <param name="description">Description</param>
        /// <param name="schoolYear">School Year</param>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns>IsSemesterCreated</returns>
        public bool CreateNewSemester(string semesterTitle, string year, string description, string schoolYear, string startDate, string endDate)
        {
            try
            {
                string currentPageTitle = Browser.PageTitle;

                // TODO: Instead of Locating controls on entire page, Call LocateCotrol specific to that module.
                this.LocateSemesterControls();

                /// ChooseCSVButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterTitle"]))
                {
                    SemesterTitle.SendKeys(semesterTitle);
                    
                }

                /// ChooseLogoFileButton
                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterYear"]))
                {
                    SemesterYear.Clear();
                    SemesterYear.SendKeys(year);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SemesterDescription"]))
                {
                    SemesterDescription.SendKeys(description);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SchoolYear"]))
                {
                    SchoolYear.Clear();
                    SchoolYear.SendKeys(schoolYear);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["StartDate"]))
                {
                    StartDate.Clear();
                    StartDate.SendKeys(startDate);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["EndDate"]))
                {
                    EndDate.Clear();
                    EndDate.SendKeys(endDate);
                }

                if (this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SubmitButton"]))
                {
                    SubmitButton.Click();
                }

                // Validate creation 
                // TODO: Need confiormation on this
                if (Browser.PageTitle.ToLower().Equals(currentPageTitle.ToLower()))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error locating - " + e.Message);
            }
        }

        /// <summary>
        /// Method to navigate back to SchoolTechCourseManagementPage
        /// </summary>
        /// <returns></returns>
        public SchoolTechCourseManagementPage GoBackToCourseManagementPage()
        {
            this.LocateBackLinkControl();

            try
            {
                // New Institute link
                if (this.WaitForElement("XPATH", (string)this.objectRepository.ObjectRepositoryTable["BackLink"]))
                {
                    // Click manage Course link
                    this.BackLink.Click();
                }
            }
            catch (Exception)
            { }

            return new SchoolTechCourseManagementPage(this.Browser);
        }
        #endregion
    }
}
