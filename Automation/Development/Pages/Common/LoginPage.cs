using System;
using Automation.Development.Browsers;
using OpenQA.Selenium;
using System.Diagnostics;
using Automation.TestScripts;
using Automation.Development.Pages.SchoolTech;
using Automation.Development.Pages.Student;
using Automation.Development.Pages.Teacher;

namespace Automation.Development.Pages.Common
{
    /// <summary>
    /// To use access functionalities of login page
    /// </summary>
    public class LoginPage : HomeBase
    {
        //Declaring variables to access web elements        
        private IWebElement signInButtonControl;
        private IWebElement userNameControl;
        private IWebElement passwordControl;
        private IWebElement loginButtonControl;
        private ObjectRepository objectRepository = null;
        private string objectRepositoryFilePath = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        private LoginPage() { }

        /// <summary>
        /// Default Parameterized Constructor
        /// </summary>
        /// <param name="browser">browser value to store session</param>
        public LoginPage(Browser browser)
            : base(browser)
        {
            /// Initiate object repository
            objectRepositoryFilePath = PrepareObjectRepositoryFilePath(EnumHelper.OfType(Role.Common),EnumHelper.OfType(Page.LoginPage));
            objectRepository = new ObjectRepository(objectRepositoryFilePath);
        }

        #region Functions for login to Application
        /// <summary>
        /// Function to log in as schoolTech
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="loginPageUrl">Login Page Url</param>
        /// <returns>SchoolTech HomePage</returns>
        public SchoolTechHomePage LoginAsSchoolTech(string userName, string password, string loginPageUrl)
        {
            try
            {
                // Perform Sign in
                SignIn(userName, password, loginPageUrl);
                return new SchoolTechHomePage(this.Browser);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in login " + ex.Message);
            }
        }

        /// <summary>
        /// Function to log in as Student
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="loginPageUrl">Login Page Url</param>
        /// <returns>Student HomePage</returns>
        public StudentHomePage LoginAsStudent(string userName, string password, string loginPageUrl)
        {
            try
            {
                // Perform Signin
                SignIn(userName, password, loginPageUrl);
                return new StudentHomePage(this.Browser);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in login " + ex.Message);
            }
        }

        /// <summary>
        /// Function to log in as Student
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="loginPageUrl">Login Page Url</param>
        /// <returns>Student HomePage</returns>
        public TeacherHomePage LoginAsTeacher(string userName, string password, string loginPageUrl)
        {
            try
            {
                // Perform Signin
                SignIn(userName, password, loginPageUrl);
                return new TeacherHomePage(this.Browser);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in login " + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// To locate elements on login page using xpaths
        /// </summary>
        private void LocateControls()
        {
            try
            {
                bool isUserNameTextBoxPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["UserNameTextbox"]);
                if (!isUserNameTextBoxPresent)
                {
                    throw new Exception("User name  Textbox not found");
                }
                userNameControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserNameTextbox"]);
                bool isPasswordTextboxPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["PasswordTextbox"]);
                if (!isPasswordTextboxPresent)
                {
                    throw new Exception("Password Textbox not found");
                }
                passwordControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["PasswordTextbox"]);
                bool isLoginButtonPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["LoginButton"]);
                if (!isLoginButtonPresent)
                {
                    throw new Exception("Login Button not found");
                }
                loginButtonControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["LoginButton"]);
            }
            catch (Exception e)
            {
                throw new Exception(" Error locating control "+ e.Message);
            }
        }

        /// <summary>
        /// To locate sign in button controls using xpath
        /// </summary>
        private void LocateSignInButtonControl()
        {
            bool isSignInPresent = this.WaitForElement("XPATH", (string)objectRepository.ObjectRepositoryTable["SignInButton"]);
            if (!isSignInPresent)
            {
                throw new Exception("Sign in Button not found");
            }
            signInButtonControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["SignInButton"]);
        }

        /// <summary>
        /// Method which performs actual sign in operation
        /// </summary>
        private void SignIn(string userName, string password, string loginPageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    throw new ArgumentNullException("userName");
                }

                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("password");
                }

                // Launch InPods LP
                try
                {
                    this.Browser.Driver.Navigate().GoToUrl(loginPageUrl);
                    MaximizeWindowWithAltD();
                }
                catch (Exception)
                { }
                // Locate and click 'SignIn' drop down
                try
                {
                    LocateSignInButtonControl();
                    signInButtonControl.Click();

                }
                catch (Exception)
                { }

                // Enter Credentials and try Signin
                try
                {
                    LocateControls();

                    this.userNameControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["UserNameTextbox"]);
                    userNameControl.SendKeys(userName);
                    this.passwordControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["PasswordTextbox"]);
                    passwordControl.SendKeys(password);
                    this.loginButtonControl = this.FindControlByXPath((string)objectRepository.ObjectRepositoryTable["LoginButton"]);
                    loginButtonControl.Click();
                }
                catch (Exception)
                { }
            }
            catch (Exception)
            { }

        }
      
    }
}
