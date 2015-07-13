using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task1.Tests
{
    [TestClass]
    public class NewtonRootTest
    {
        private const string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..;Extended Properties=\"text;HDR=Yes;FMT=Delimited\"";
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource(connectionString, "NewtonRootTestData#csv")]
        [TestMethod()]
        public void NewtonRoot_FromDataSourceTest()
        {
            Double value = Convert.ToDouble(TestContext.DataRow["Value"]);
            int degree = Convert.ToInt32(TestContext.DataRow["Degree"]); 
            Double precision = Convert.ToDouble(TestContext.DataRow["Precision"]);
            bool exception = Convert.ToBoolean(TestContext.DataRow["Exception"]);
            bool catched = false;
            try
            {
                Double actual = Calculator.NewtonRoot(value, degree, precision);
                Assert.AreEqual(Math.Pow(value, 1d / degree), actual, precision);

            }
            catch(ArgumentException e){
                catched = true;
            }
            if (catched != exception)
            {
                Assert.Fail();
            }
        }
    }
}
