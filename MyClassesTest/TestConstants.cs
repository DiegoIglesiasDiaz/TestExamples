using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    internal class TestConstants
    {
        public const string GOOD_FILE_NAME = @"[AppDataPath]\TestFile.txt";
        public const string BAD_FILE_NAME = @"C:\NotExists.txt";
        public const string EMPTY_FILE_FAIL_MSG = "The Call to the FileExists() method did not thorw an ArgumentNullException and it should have";
        public const string EMPTY_FILE_MSG = "Checking for empty files";
    }
}
