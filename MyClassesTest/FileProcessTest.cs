using MyClasses;
namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        #region Class Initialize and Cleanup Methods
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            //code runs before all test run in this class
            tc.WriteLine("In FileProcessTest.ClassInitialize() method");
        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //code runs after all test run in this class
            //TestContext not available
        }
        #endregion

        #region Test Initialize and Cleanup Methods
        [TestInitialize()]
        public void TestInitialize()
        {
            //TestContext?.WriteLine("In FileProcessTest.TestInitialize() method");
            WriteDescription(this.GetType());
            WriteOwner(this.GetType());

            // Check to see which test we are running
            if (GetTestName() == "FileNameDoesExist")
            {
                // Get Good File Name
                string fileName = GetFileName("GoodFileName",
               TestConstants.GOOD_FILE_NAME);
                // Create the Good File
                File.AppendAllText(fileName, "Some Text");
            }
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            // Check to see which test we are running
            if (GetTestName() == "FileNameDoesExist")
            {
                // Get Good File Name
                string fileName = GetFileName("GoodFileName",
               TestConstants.GOOD_FILE_NAME);
                // Delete the Good File if it Exists
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }
        #endregion

        #region Tests
        [TestMethod]
        [TestCategory("NoException")]
        [Description("Check to see if a file exists.")]
        [Owner("PaulS")]
        [Priority(3)]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);
            TestContext?.WriteLine($"Checking for file '{fileName}'");

            //Act

            bool fromCall = fp.FileExists(fileName);

            //Assert
            Assert.IsTrue(fromCall, "File '{0}' does NOT exist", fileName);
        }
        [TestMethod]
        [TestCategory("NoException")]
        [Owner("JohnK")]
        [Description("Check to see if file does not exist.")]
        [Priority(3)]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            string fileName = GetFileName("BadFileName", TestConstants.BAD_FILE_NAME);
            TestContext?.WriteLine($"Checking for file '{fileName}'");
            //Act
            bool fromCall = fp.FileExists(fileName);

            //Assert

            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [TestCategory("Exception")]
        [Owner("SteveN")]
        [Priority(2)]
        [Description("Check for a thrown ArgumentNullException using try...catch.")]
        public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            string fileName = string.Empty;
            bool fromCall = false;
            OutputMssg = GetFileName("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
            TestContext?.WriteLine(OutputMssg);
            try
            {
                fromCall = fp.FileExists(fileName);
                OutputMssg = GetFileName("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
                Assert.Fail(OutputMssg);
            }
            catch (ArgumentNullException)
            {
                Assert.IsFalse(fromCall);
            }
        }
        [TestMethod]
        [Priority(1)]
        [Owner("SteveN")]
        [TestCategory("Exception")]
        [Description("Check for a thrown ArgumentNullException using ExpectedException.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            string fileName = string.Empty;
            bool fromCall;
            OutputMssg = GetFileName("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
            TestContext?.WriteLine(OutputMssg);
            //Act
            fromCall = fp.FileExists(fileName);


            //Assert: Fail as we should bot get here
            OutputMssg = GetFileName("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
            Assert.Fail(OutputMssg);
        }

        [TestMethod]
        [Ignore]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }
        #endregion
    }
}