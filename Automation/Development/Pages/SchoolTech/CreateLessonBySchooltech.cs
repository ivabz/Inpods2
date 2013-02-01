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
    public class CreateLessonBySchooltech : HomeBase
    {        
        private ObjectRepository objectRepository;
        private IWebElement ClickOnLessonLink;
        private IWebElement lessonNameControl;
        private IWebElement startDateControl;
        private IWebElement endDateControl;
        private IWebElement saveButtonControl;
        private IWebElement ClickOnChapterLink;
        private SelectElement selectLessonType;


        /// <summary>
        /// Default constructor
        /// </summary>
        private CreateLessonBySchooltech()
        {

        }

        /// <summary>
        /// Default parameterised constructor
        /// </summary>
        /// <param name="browser"></param>
        public CreateLessonBySchooltech(Browser browser)
            : base(browser)
        {

        }

        public void LocateControls()
        {
            string objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Page.LessonPage), EnumHelper.OfType(Role.SchoolTech));
            objectRepository = new ObjectRepository(objectRepositoryFilePath);

            bool isLessonNamePresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ClickOnLessonName"]);
            if (!isLessonNamePresent)
            {
                throw new Exception("Lesson Name not found");
            }
            ClickOnChapterLink = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ClickOnLessonName"]);
            ClickOnChapterLink.Click();
        }

        public CreateLessonBySchooltech CreateLessonSchooltech(string lessonName, string moduleStartdate, string moduleEnddate)
        {
            bool isLessonLinkClicked = false;
            isLessonLinkClicked = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["ClickOnLessonLink"]);
            if (!isLessonLinkClicked)
            {
                throw new Exception("Create New lesson link not found");
            }
            IWebElement ChapterLinkControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["ClickOnLessonLink"]);
            ChapterLinkControl.Click();

            bool isModuleNameTextPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LessonName"]);
            if (!isModuleNameTextPresent)
            {
                throw new Exception("Module Name Text not found");
            }
                        
            this.lessonNameControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["LessonName"]);
            lessonNameControl.FindElement(By.Id("Name")).Clear();
            lessonNameControl.SendKeys(lessonName);            

            return new CreateLessonBySchooltech(this.Browser);
        }

        public CreateLessonBySchooltech SelectLessonToCreate(string lessonValue)
        {
            bool isLessontypeDropDownPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["TypeOfLesson"]);
            if (!isLessontypeDropDownPresent)
            {
                throw new Exception("Lesson type DropDown not found");
            }
            selectLessonType = this.FindSelectControlByXpath((string)objectRepository.ObjectRepositoryTable["TypeOfLesson"]);
            selectLessonType.SelectByText(lessonValue);
            ImplicitlyWait(3000);
            //bool isLessomTextPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["VirtualMachineText"]);
            //if (!isVirtualMachineTextPresent)
            //{
            //    throw new Exception("Virtual Machine Text not found");
            //}
            return new CreateLessonBySchooltech(this.Browser);
        }

        public CreateLessonBySchooltech ClickOnSaveButton()
        {
            try
            {
                this.saveButtonControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SaveButton"]);
                saveButtonControl.Click();
            }
            catch (Exception)
            {         }
            return new CreateLessonBySchooltech(this.Browser);
        }

    }
}
