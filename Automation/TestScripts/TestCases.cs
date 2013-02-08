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
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in  \"" + testScriptName + "\" Test case", "FAIL", browser);
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
                string testDataDirectoryPath = PrepareTestDataDirectory(testScriptName);

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
                string logoFilePath= testDataDirectoryPath + (string)testData.TestDataTable["LogoFileName"];
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
                SuperAdminPage admin = s_Homepage.GotoSuperAdminPage();
                Assert.IsNotNull(admin, "Failed to navigate to super admin page");
                WriteLogs(testScriptName, stepNo, "Navigate to Admin page", "Pass", browser);
                stepNo++;


                /// Click on CreateInstitute Link
                CreateInstitutePage newInstitute = admin.GoToCreateInstitutePage();
                Assert.IsNotNull(newInstitute, "Failed to navigate to Create Institute Page");
                WriteLogs(testScriptName, stepNo, "Navigate to CreateNewInstitutePage", "Pass", browser);
                stepNo++;

                /// Create TechAdmin as schooltech
                Assert.IsTrue(newInstitute.CreateTechadmin(firstName, lastName, email, password), "Failed to create tech admin");
                WriteLogs(testScriptName, stepNo, "Create TechAdmin", "Pass", browser);
                stepNo++;

                /// Add new institute
                Assert.IsTrue(newInstitute.AddNewInstitute(instituteName, instituteDescription, instituteShortName, logoFilePath, schoolTechName, timeZone, passwordReset), "Failed to create new institute");
                WriteLogs(testScriptName, stepNo, "Create New institute", "Pass", browser);
                stepNo++;

                /// LogOff
                Assert.IsTrue(newInstitute.LogOut(), "Failed to Log out");
                WriteLogs(testScriptName, stepNo, "LogOff", "Pass", browser);
            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in \"" + testScriptName + "\" Test case", "FAIL", browser);
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
        /// Test case to verify if user of each type can be created
        /// </summary>
        [TestMethod,Description("BVT - Test case to create and verify if the Teacher is created successfully")]
        public void CreateUsersOfEachRoleType()
        {
            /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                // Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                // Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);
                string testDataDirectoryPath = PrepareTestDataDirectory(testScriptName);

                // Test Data
                TestData testData = new TestData(testDataFilePath);
                string schooltechUName = (string)testData.TestDataTable["schooltechUName"];
                string schooltechPassword = (string)testData.TestDataTable["schooltechPassword"];

                string teacherRole = (string)testData.TestDataTable["teacherRole"];
                string firstNameTeacher = (string)testData.TestDataTable["firstNameTeacher"];
                string lastNameTeacher = (string)testData.TestDataTable["lastNameTeacher"];
                string emailTeacher = (string)testData.TestDataTable["emailTeacher"];
                string passwordTeacher = (string)testData.TestDataTable["passwordTeacher"];

                string parentRole = (string)testData.TestDataTable["parentRole"];
                string firstNameParent = (string)testData.TestDataTable["firstNameParent"];
                string lastNameParent = (string)testData.TestDataTable["lastNameParent"];
                string emailParent = (string)testData.TestDataTable["emailParent"];
                string passwordParent = (string)testData.TestDataTable["passwordParent"];

                string authorRole = (string)testData.TestDataTable["authorRole"];
                string firstNameAuthor = (string)testData.TestDataTable["firstNameAuthor"];
                string lastNameAuthor = (string)testData.TestDataTable["lastNameAuthor"];
                string emailAuthor = (string)testData.TestDataTable["emailAuthor"];
                string passwordAuthor = (string)testData.TestDataTable["passwordAuthor"];

                string administratorRole = (string)testData.TestDataTable["administratorRole"];
                string firstNameAdministrator = (string)testData.TestDataTable["firstNameAdministrator"];
                string lastNameAdministrator = (string)testData.TestDataTable["lastNameAdministrator"];
                string emailAdministrator = (string)testData.TestDataTable["emailAdministrator"];
                string passwordAdministrator = (string)testData.TestDataTable["passwordAdministrator"];

                string schooltechRole = (string)testData.TestDataTable["schooltechRole"];
                string firstNameSchooltech = (string)testData.TestDataTable["firstNameSchooltech"];
                string lastNameSchooltech = (string)testData.TestDataTable["lastNameSchooltech"];
                string emailSchooltech = (string)testData.TestDataTable["emailSchooltech"];
                string passwordSchooltech = (string)testData.TestDataTable["passwordSchooltech"];

                string studentRole = (string)testData.TestDataTable["studentRole"];
                string firstNameStudent = (string)testData.TestDataTable["firstNameStudent"];
                string lastNameStudent = (string)testData.TestDataTable["lastNameStudent"];
                string emailStudent = (string)testData.TestDataTable["emailStudent"];
                string passwordStudent = (string)testData.TestDataTable["passwordStudent"];
                
                // Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);

                // Log in as Schooltech
                SchoolTechHomePage s_Homepage = loginPage.LoginAsSchoolTech(schooltechUName, schooltechPassword, base.applicationURL);
                Assert.IsNotNull(s_Homepage, "Failed to login to InPods application as Schooltech");
                WriteLogs(testScriptName, stepNo, "Login to InPods Application as Schooltech", "Pass", browser);
                stepNo++;

                // Navigate to schooltech admin
                SchoolTechAdminPage admin = s_Homepage.GoToSchooltechAdmin();
                Assert.IsNotNull(admin, "Failed to navigate to Schooltech Admin Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Schooltech Admin Page", "Pass", browser);
                stepNo++;

                // Navigate to User Management page
                SchoolTechUserManagementPage manage = admin.GotoUserManagementPage();
                Assert.IsNotNull(manage, "Failed to navigate to User management Page");
                WriteLogs(testScriptName, stepNo, "Navigate to User management Page", "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Teacher'
                Assert.IsTrue(manage.CreateUser(teacherRole, firstNameTeacher, lastNameTeacher, emailTeacher, passwordTeacher), "Unable to Create User of type " + teacherRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + teacherRole, "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Parent'
                Assert.IsTrue(manage.CreateUser(parentRole, firstNameParent, lastNameParent, emailParent, passwordParent), "Unable to Create User of type " + parentRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + parentRole, "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Author'
                Assert.IsTrue(manage.CreateUser(authorRole, firstNameAuthor, lastNameAuthor, emailAuthor, passwordAuthor), "Unable to Create User of type " + authorRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + authorRole, "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Administrator'
                Assert.IsTrue(manage.CreateUser(administratorRole, firstNameAdministrator, lastNameAdministrator, emailAdministrator, passwordAdministrator), "Unable to Create User of type " + administratorRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + administratorRole, "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Schooltech'
                Assert.IsTrue(manage.CreateUser(schooltechRole, firstNameSchooltech, lastNameSchooltech, emailSchooltech, passwordSchooltech), "Unable to Create User of type " + schooltechRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + schooltechRole, "Pass", browser);
                stepNo++;

                // Create new user of Role - 'Student'
                Assert.IsTrue(manage.CreateUser(studentRole, firstNameStudent, lastNameStudent, emailStudent, emailStudent), "Unable to Create User of type " + studentRole);
                WriteLogs(testScriptName, stepNo, "Create new user of role " + studentRole, "Pass", browser);
                stepNo++;

                /// LogOff
                Assert.IsTrue(manage.LogOut(), "Failed to Log out");
                WriteLogs(testScriptName, stepNo, "LogOff", "Pass", browser);                
            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + " Exception Occured in \"" + testScriptName + "\" Test case", "FAIL", browser);
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
        /// Test case to verify if new semester can be created.
        /// </summary>
        [TestMethod,Description("BVT - Test case to create and verify if semester is created successfully")]
        public void CreateSemester()
        {
             /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                // Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                // Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);
                string testDataDirectoryPath = PrepareTestDataDirectory(testScriptName);

                // Test Data
                TestData testData = new TestData(testDataFilePath);
                string schooltechUName = (string)testData.TestDataTable["schooltechUName"];
                string schooltechPassword = (string)testData.TestDataTable["schooltechPassword"];

                string semesterTitle = (string)testData.TestDataTable["semesterTitle"];
                string semesterYear = (string)testData.TestDataTable["semesterYear"];
                string semesterDescription = (string)testData.TestDataTable["semesterDescription"];
                string schoolYear = (string)testData.TestDataTable["schoolYear"];
                string startDate = (string)testData.TestDataTable["startDate"];
                string endDate = (string)testData.TestDataTable["endDate"];
                

                // Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);

                // Log in as Schooltech
                SchoolTechHomePage s_Homepage = loginPage.LoginAsSchoolTech(schooltechUName, schooltechPassword, base.applicationURL);
                Assert.IsNotNull(s_Homepage, "Failed to login to InPods application as Schooltech");
                WriteLogs(testScriptName, stepNo, "Login to InPods Application as Schooltech", "Pass", browser);
                stepNo++;

                // Navigate to schooltech admin
                SchoolTechAdminPage admin = s_Homepage.GoToSchooltechAdmin();
                Assert.IsNotNull(admin, "Failed to navigate to Schooltech Admin Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Schooltech Admin Page", "Pass", browser);
                stepNo++;

                // Navigate to Course Management page
                SchoolTechCourseManagementPage manage = admin.GotoCourseManagementPage();
                Assert.IsNotNull(manage, "Failed to navigate to Manage Course Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Manage Course Page", "Pass", browser);
                stepNo++;

                // Navigate to create Semester page
                CreateSemesterPage semester = manage.GoToCreateSemesterPage();
                Assert.IsNotNull(manage, "Failed to navigate to Create Semester Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Create Semester Page", "Pass", browser);
                stepNo++;

                // Create new semester
                Assert.IsTrue(semester.CreateNewSemester(semesterTitle, semesterYear, semesterDescription, schoolYear, startDate, endDate), "Unable to create new semester");
                WriteLogs(testScriptName, stepNo, "Create new semester " + semesterTitle, "Pass", browser);
                stepNo++;

                // Log out
                Assert.IsTrue(manage.LogOut(), "Failed to Log out");
                WriteLogs(testScriptName, stepNo, "LogOff", "Pass", browser); 
            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + "And Exception Occured in \"" + testScriptName + "\" Test case", "FAIL", browser);
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
        /// Test case to verify if New department and subject is created.
        /// </summary>
        [TestMethod, Description("BVT - Test method to create and verify if new department and subject under that department is created successfully")]
        public void CreateDepartmentAndSubject()
        {
             /// Gets test name
            string testScriptName = TestContext.TestName;

            try
            {
                // Start debug viewer for writting application logs
                applicationLog = new ApplicationLog(configFilesLocation, reportFileDirectory, testScriptName);
                applicationLog.StartDebugViewer();

                // Prepare test data file path
                string testDataFilePath = PrepareTestDataFilePath(testScriptName);
                string testDataDirectoryPath = PrepareTestDataDirectory(testScriptName);

                // Test Data
                TestData testData = new TestData(testDataFilePath);
                string schooltechUName = (string)testData.TestDataTable["schooltechUName"];
                string schooltechPassword = (string)testData.TestDataTable["schooltechPassword"];

                string departmentName = (string)testData.TestDataTable["departmentName"];
                string departmentDescription = (string)testData.TestDataTable["departmentDescription"];
                string subjectName = (string)testData.TestDataTable["subjectName"];
                string subjectDescription = (string)testData.TestDataTable["subjectDescription"];

                // Create browser instace
                browser = BrowserFactory.Instance.GetBrowser(browserId, testScriptName, configFilesLocation, driverPath);
                LoginPage loginPage = new LoginPage(browser);

                // Log in as Schooltech
                SchoolTechHomePage s_Homepage = loginPage.LoginAsSchoolTech(schooltechUName, schooltechPassword, base.applicationURL);
                Assert.IsNotNull(s_Homepage, "Failed to login to InPods application as Schooltech");
                WriteLogs(testScriptName, stepNo, "Login to InPods Application as Schooltech", "Pass", browser);
                stepNo++;

                // Navigate to schooltech admin
                SchoolTechAdminPage admin = s_Homepage.GoToSchooltechAdmin();
                Assert.IsNotNull(admin, "Failed to navigate to Schooltech Admin Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Schooltech Admin Page", "Pass", browser);
                stepNo++;

                // Navigate to Course Management page
                SchoolTechCourseManagementPage manage = admin.GotoCourseManagementPage();
                Assert.IsNotNull(manage, "Failed to navigate to Manage Course Page");
                WriteLogs(testScriptName, stepNo, "Navigate to Manage Course Page", "Pass", browser);
                stepNo++;

                // Create Department
                Assert.IsTrue(manage.CreateNewDepartment(departmentName, departmentDescription),"Unable to create new department");
                WriteLogs(testScriptName, stepNo, "Create new Department " + departmentName, "Pass", browser);
                stepNo++;

                Assert.IsTrue(manage.CreateNewSubject(departmentName, subjectName, subjectDescription), "Unable to create new Subject");
                WriteLogs(testScriptName, stepNo, "Create new Subject " + subjectName + "Under "+ departmentName, "Pass", browser);
                stepNo++;

                // Log out
                Assert.IsTrue(manage.LogOut(), "Failed to Log out");
                WriteLogs(testScriptName, stepNo, "LogOff", "Pass", browser);
            }
            catch (Exception exception)
            {
                WriteLogs(testScriptName, stepNo, exception.Message.ToString() + "And Exception Occured in \"" + testScriptName + "\" Test case", "FAIL", browser);
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
        /// Test case to verify if new section is created or not.
        /// </summary>
        [Ignore]
        [TestMethod, Description("BVT - Test method to create and verify new section ")]
        public void CreateNewSection()
        {
            new NotImplementedException();
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
        /// Class cleanup activities
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

        /// <summary>
        /// TODO: Abstract out logic for debug loggging from test case here.
        /// </summary>
        /// <param name="testScriptName"></param>
        private static void StopAndVerifyDebugLog(string testScriptName)
        {
             new NotImplementedException();
        }
        #endregion
    }
}
