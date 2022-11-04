using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitTest.Test
{
    public class NUnitTests
    {
        List<EmployeeDetails> li;
        #region CheckDetails Test Start...
        [Test]
        [TearDown]
        public void Checkdetails()
        {
            Program pobj = new Program();
            li = pobj.AllUsers();
            foreach (var x in li)
            {
                //check if any class property is null
                Assert.IsNotNull(x.id);
                Assert.IsNotNull(x.Name);
                Assert.IsNotNull(x.salary);
                Assert.IsNotNull(x.Gender);
            }
        }
        #endregion

        #region TestLogin Test Start...
        [Test]
        [TestOf(typeof (EmployeeDetails))]
        public void TestLogin()
        {
            Program pobj = new Program();
            string x = pobj.Login("Lucas", "1234");
            string y = pobj.Login("", "");
            string z = pobj.Login("Admin", "Admin");
            Assert.AreEqual("Incorrect UserId or Password.", x);
            Assert.AreEqual("Userid or password could not be Empty.", y);
            Assert.AreEqual("Welcome Admin.", z);
            Assert.Pass(x);

        }
        #endregion

        #region Standard Tests...
        [Test]
        [SetUp]
        public void ArrayTest()
        {
        int[] array = new int[] { 1, 2, 3 };
        Assert.That(array, Has.Exactly(1).EqualTo(3));
        Assert.That(array, Has.Exactly(2).GreaterThan(1));
        Assert.That(array, Has.Exactly(3).LessThan(100));
        }

        [Test]
        public void Add()
        {
            int s;
            int x = 2;
            int y = 2;
            s = x + y;

            Assert.AreEqual(4, s, "x + y is Not Equal to 4");

            Assert.Pass("x + y is Equal to 4. Test OK!");
        }
        [Test]
        public void Sub()
        {
            int s;
            int x = 2;
            int y = 2;
            s = x - y;

            Assert.AreEqual(0, s, "x - y is Not Equal to 0");

            Assert.Pass("x - y is Equal to 0. Test OK!");
        }
        #endregion

    }
}
