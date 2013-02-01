using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using Automation.TestScripts;
using System.Threading;

namespace Automation.Development.Pages
{
    public class CreateModuleBySchooltech : HomeBase
    {
        private IWebElement lessonTabControl;
        private ObjectRepository objectRepository;
        private IWebElement ClickOnModuleLink;
        private IWebElement moduleNameControl;
        private IWebElement startDateControl;
        private IWebElement endDateControl;
        private IWebElement saveButtonControl;

        /// <summary>
        /// Default constructor
        /// </summary>
        private CreateModuleBySchooltech()
        {

        }

        /// <summary>
        /// Default parameterised constructor
        /// </summary>
        /// <param name="browser"></param>
        public CreateModuleBySchooltech(Browser browser)
            : base(browser)
        {

        }

        /// <summary>
        /// To locate elements on Home page using xpaths
        /// </summary>
        public void LocateControls()
        {
            string objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.LessonPage), EnumHelper.OfType(Role.SchoolTech));
            objectRepository = new ObjectRepository(objectRepositoryFilePath);

            bool isLessonTabControl = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ClickOnLessontab"]);
            if (!isLessonTabControl)
            {
                throw new Exception("Lesson Tab not found");
            }
            lessonTabControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ClickOnLessontab"]);
            lessonTabControl.Click();
        }

        public CreateModuleBySchooltech CreateModuleSchooltech(string moduleName, string moduleStartdate, string moduleEnddate)
        {
            bool isModuleLinkClicked = false;
            isModuleLinkClicked = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["CreateNewChapterlink"]);
            if (!isModuleLinkClicked)
            {
                throw new Exception("Create New Chapter link not found");
            }

            IWebElement ChapterLinkControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["CreateNewChapterlink"]);
            ChapterLinkControl.Click();

            bool isModuleNameTextPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ModuleName"]);
            if (!isModuleNameTextPresent)
            {
                throw new Exception("Module Name Text not found");
            }

            this.moduleNameControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ModuleName"]);
            moduleNameControl.SendKeys(moduleName);                  

            this.saveButtonControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ClickOnSaveButton"]);
            saveButtonControl.Click();
           
            return new CreateModuleBySchooltech(this.Browser);
        }
    
    }
}