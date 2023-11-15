using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext? TestContext { get; set; }
        public string OutputMssg { get; set; } = string.Empty;
        //public string fileName { get; set; } = string.Empty;
        #region GetTestSettings
        protected T GetTestSetting<T>(string name, T defaultValue)
        {
            T ret = defaultValue;
            try
            {
                var tmp = TestContext?.Properties[name];
                if (tmp != null)
                {
                    ret = (T)Convert.ChangeType(tmp, typeof(T));
                }
            }
            catch
            {

            }
            return ret;
        }
        #endregion
        #region GetTestName Method
        protected string GetTestName()
        {
            var ret = TestContext?.TestName;
            if (ret == null)
            {
                return string.Empty;
            }
            else
            {
                return ret.ToString();
            }
        }
        #endregion
        #region GetFileName Method
        protected string GetFileName(string name, string
        defaultValue)
        {
            string fileName = GetTestSetting<string>(name,
           defaultValue);
            fileName = fileName.Replace("[AppDataPath]",
            Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData));
            return fileName;
        }
        #endregion

        #region GetAttribute Method
        protected T? GetAttribute<T>(Type typ)
        {
            // Get the currently executing test name
            string testName = GetTestName();
            // Retrieve the <TAttr> attribute if it exists
            Attribute? attr = typ.GetMethod(testName)?
            .GetCustomAttribute(typeof(T));
            if (attr != null)
            {
                // Cast the attribute to a <TAttr> type
                return (T)Convert.ChangeType(attr, typeof(T));
            }
            else
            {
                return default;
            }
        }
        #endregion

        #region WriteDescription Method
        protected void WriteDescription(Type typ)
        {
            // Retrieve the [Description] attribute if it exists
            DescriptionAttribute? attr =
           GetAttribute<DescriptionAttribute>(typ);
            if (attr != null)
            {
                // Output the test description
                TestContext?.WriteLine("Test Purpose: " +
               attr.Description);
            }
        }
        #endregion

        #region WriteOwner Method
        protected void WriteOwner(Type typ)
        {
            // Retrieve the [Owner] attribute if it exists
            OwnerAttribute? attr = GetAttribute<OwnerAttribute>(typ);
            if (attr != null)
            {
                // Output the test owner
                TestContext?.WriteLine("Test Owner: " + attr.Owner);
            }
        }
        #endregion
    }
}
