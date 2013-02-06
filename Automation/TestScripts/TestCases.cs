using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.Development.Browsers;
using Automation.Development.Pages;
using Automation.Development.Pages.Common;
using Automation.Development.Pages.SchoolTech;
using Automation.Development.Pages.Super;
using Automation.TestScripts;
using System.IO;


namespace Automation.TestScripts
{
    [TestClass]
    public class TestCases : TestCaseUtil
    {
        /// Initializing all Test Parametrs        
        Browser browser;
        int stepNo;
        static DateTime startTimeOfExecution = new DateTime();
        static DateTime endTimeOfExecution = new DateTime();
        private static string ExecutionStartDateTime = String.Empty;
        private static string logFilesDirectory = String.Empty;

        private static string reportFilesDirectory = String.Empty;
        private static string serverName = String.Empty;
        private static string configFilesLocation = String.Empty;
        private static string embeddedMailContents = String.Empty;

        /// Application log instance
        ApplicationLog applicationLog;
        
        /// <summary>
        /// Defines test context
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// TestCases Class Constructor
        /// </summary>
        public TestCases() 
        {
            try
            {
                // Loads config data and creates a Singleton object of Configuration and loads data into generic test case variables
                GetConfigData();

                /// Get debug viewer exe file path
                configFilesLocation = PrepareConfigureDataFilePath();

                /// Prepare log directory details from xml file
                PrepareLogDirectoryPath(configFilesLocation);

                // Initializing Automation report related parameters
                ExecutionStartDateTime = GetValuesFromXML("TestDataConfig", "ExecutionStartDateTime", configFilesLocation + "\\RunTime.xml");
                startTimeOfExecution = Convert.ToDateTime(ExecutionStartDateTime.ToString());
                logFilesDirectory = base.logFileDirectory;
                reportFilesDirectory = base.reportFileDirectory;
                serverName = base.server;

                /// Initialize browser instance
                browser = null;
                applicationLog = null;
                stepNo = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Test Setup Failed - " + e.Message);
            }
        }
        
        /// <summary>
        /// Test case to verify the user log in Functionlity Eg: For role - SchoolTech
        /// </summary>
        [TestMethod,Description("BVT -Test to validate user LogIn functionality - Role - SchoolTech")]
        [Priority(0)]
        public void LoginTestCase()
        {            
            /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                /// Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                /// Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);

                /// Test Data
                TestData testData = new TestData(testDataFilePath);
                string schooltechUName = (string)testData.TestDataTable["SchooltechUName"];
                string schooltechPassword = (string)testData.TestDataTable["SchooltechPassword"];

                /// Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);
                
                /// Log in as Schooltech
                SchoolTechHomePage st_Homepage = loginPage.LoginAsSchoolTech(schooltechUName, schooltechPassword, base.applicationURL);
                Assert.IsNotNull(st_Homepage, "Failed to login to InPods application as Schooltech");
                WriteLogs(testScriptName, stepNo, "Login to InPods Application as Schooltech", "Pass", browser);
                stepNo++;

                /// Validate if the login is of type SchoolTech
                Assert.IsTrue(st_Homepage.ValidateSchoolTechUserProfile(), "Failed to validate current login as Schooltech");
                WriteLogs(testScriptName, stepNo, "Validate current Login as Schooltech", "Pass", browser);
            }
           catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in " + testScriptName, "FAIL", browser);
                Assert.Fail();
            }
            finally
            {
                /// Close Debug viewer and verify log file
                applicationLog.StopDebugViewer();
                bool isExceptionFound = applicationLog.VerifyDebugLogFiles(reportFileDirectory, testScriptName);
                if (!isExceptionFound)
                {
                    WriteLogs(testScriptName, stepNo, "Exception/error found in log file", "INFO", browser);
                }
            }
        }

        /// <summary>
        /// Test case to verify if create module and corresponding event works fine.
        /// </summary>
        [Ignore]
        [TestMethod, Description("Test case to verify if create module and corresponding event works fine.")]
        public void CreateAndVerifyEvent()
        {
            /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                /// Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                /// Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);

                /// Test Data
                TestData testData = new TestData(testDataFilePath);
                string schooltechUName = (string)testData.TestDataTable["SchooltechUName"];
                string schooltechPassword = (string)testData.TestDataTable["SchooltechPassword"];

                /// Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);

                /// Log in as Schooltech
                SchoolTechHomePage st_Homepage = loginPage.LoginAsSchoolTech(schooltechUName, schooltechPassword, base.applicationURL);

            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in " + testScriptName, "FAIL", browser);
                Assert.Fail();
            }
            finally
            {
                /// Close Debug viewer and verify log file
                applicationLog.StopDebugViewer();
                bool isExceptionFound = applicationLog.VerifyDebugLogFiles(reportFileDirectory, testScriptName);
                if (!isExceptionFound)
                {
                    WriteLogs(testScriptName, stepNo, "Exception/error found in log file", "INFO", browser);
                }
            }

        }

        /// <summary>
        /// Test case to create and verify Techadmin and Institute creation manually (i.e Not through CSV)
        /// </summary>
        [TestMethod, Description("BVT - Test case to create and verify Techadmin and Institute creation manually")]
        [Priority(0)]
        public void CreateTechadminAndInstituteManually()
        {
            /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                /// Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                /// Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);

                /// Test Data
                TestData testData = new TestData(testDataFilePath);
                string superUName = (string)testData.TestDataTable["SuperUName"];
                string superPassword = (string)testData.TestDataTable["SuperPassword"];
                string firstName = (string)testData.TestDataTable["FirstName"];
                string lastName = (string)testData.TestDataTable["LastName"];
                string email  = (string)testData.TestDataTable["Email"];
                string password = (string)testData.TestDataTable["Password"];
                string instituteName = (string)testData.TestDataTable["InstituteName"];
                string instituteDescription = (string)testData.TestDataTable["InstituteDescription"];
                string instituteShortName= (string)testData.TestDataTable["InstituteShortName"];
                string logoFilePath= testDataFilePath + (string)testData.TestDataTable["LogoFileName"];
                string schoolTechName= (string)testData.TestDataTable["SchoolTechName"];
                string timeZone= (string)testData.TestDataTable["TimeZone"];
                string passwordReset= (string)testData.TestDataTable["PasswordReset"];

                /// Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);

                /// Log in as Super
                SuperHomePage s_Homepage = loginPage.LoginAsSuper(superUName, superPassword, base.applicationURL);
                Assert.IsNotNull(s_Homepage, "Failed to login to InPods application as Super");
                WriteLogs(testScriptName, stepNo, "Login to InPods Application as Super", "Pass", browser);
                stepNo++;

                /// Go to Admin Page
                SuperAdminPage admin = s_Homepage.GotoAdminPage();
                Assert.IsNotNull(admin, "Failed to navigate to super admin page");
                WriteLogs(testScriptName, stepNo, "Navigate to Admin page", "Pass", browser);
                stepNo++;

                /// Click on CreateInstitute Link
                CreateInstitutePage newInstitute = admin.GoToCreateInstitutePage();
                Assert.IsNotNull(admin, "Failed to navigate to Create Institute Page");
                WriteLogs(testScriptName, stepNo, "Navigate to CreateNewInstitutePage", "Pass", browser);
                stepNo++;

                /// Create TechAdmin as schooltech
                Assert.IsNotNull(newInstitute.CreateTechadmin(firstName, lastName, email, password), "Failed to create tech admin");
                WriteLogs(testScriptName, stepNo, "Create TechAdmin", "Pass", browser);
                stepNo++;

                /// Add new institute
                Assert.IsNotNull(newInstitute.AddNewInstitute(instituteName, instituteDescription, instituteShortName, logoFilePath, schoolTechName, timeZone, passwordReset), "Failed to create new institute");
                WriteLogs(testScriptName, stepNo, "Create New institute", "Pass", browser);
                stepNo++;

                /// LogOff
                Assert.IsNotNull(newInstitute.SuperMenu.LogOut(), "Failed to Log out");
                WriteLogs(testScriptName, stepNo, "LogOff", "Pass", browser);
            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in " + testScriptName, "FAIL", browser);
                Assert.Fail();
            }
            finally
            {
                /// Close Debug viewer and verify log file
                applicationLog.StopDebugViewer();
                bool isExceptionFound = applicationLog.VerifyDebugLogFiles(reportFileDirectory, testScriptName);
                if (!isExceptionFound)
                {
                    WriteLogs(testScriptName, stepNo, "Exception/error found in log file", "INFO", browser);
                }
            }
        }

        /// <summary>
        /// Test clean up activities
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                if (browser != null)
                {
                    /// Delete browser cookies and close it
                    browser.Driver.Manage().Cookies.DeleteAllCookies();
                    browser.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Browser Closing operation not succeeded" + e.Message);
            }
        }

        /// <summary>
        ///  Test Class cleanup
        /// </summary>
        [ClassCleanup]
        public static void TestClassCleanupClass()
        {
            try
            {
                /// Delete all temporary config files.
                DeleteConfigDetails();

                endTimeOfExecution = DateTime.Now;

                // Generate custome html report form csv logs
                AutomationReport automationReport = new AutomationReport(logFilesDirectory, reportFilesDirectory, serverName, Convert.ToDateTime(ExecutionStartDateTime.ToString()), DateTime.Now);
                embeddedMailContents = automationReport.CompileReportFromCSV();

                // Prepare path for zip file
                string zippedFolderPath = reportFilesDirectory + ".zip";

                // Zip the custome html report folder
                FileZipOperations fileZipOperations = new FileZipOperations(reportFilesDirectory, zippedFolderPath, null);
                fileZipOperations.ZipFiles();

                // Send Mail/Notification to given mail ids in config file
                Notifications notifications = new Notifications(reportFilesDirectory, embeddedMailContents);
                notifications.SendNotification();
            }
            catch (Exception e)
            {
                Console.WriteLine("Test Clean not succeed and report not sent" + e.Message);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Helper method to delete intermidiate config files 
        /// </summary>
        private static void DeleteConfigDetails()
        {
            try
            {
                string fileName = configFilesLocation  + "\\" + "RunTime.xml";

                // check if intermidiate file exist
                if (File.Exists(fileName))
                {
                    try
                    {
                        System.IO.File.SetAttributes(fileName, System.IO.FileAttributes.Normal);
                        // delete log file
                        File.Delete(fileName);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Failed to delete intermidiate config file => " + exception.Message);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to delete intermidiate config file => " + exception.Message);
            }
            finally
            {
            }
        }
        #endregion
    }
}
