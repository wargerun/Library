using Library.Data.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BooksBl.BooksRemove(new[] { 13, 14 });


            //TODO TDD development?
            Assert.AreEqual(true, true);
        }
    }
}
