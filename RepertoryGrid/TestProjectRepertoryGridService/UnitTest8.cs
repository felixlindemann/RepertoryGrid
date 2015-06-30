using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 using LimeTree.Extensions;

namespace TestProjectRepertoryGridService
{
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> l = new List<int>();
            for (int i = 0; i <= 5; i++)
            {
                l.Add(i);

            }
            l.Move(2, 3);
            Assert.IsTrue(l[2] == 3);
            Assert.IsTrue(l[3] == 2);

            l.Move(2, 3);
            Assert.IsTrue(l[2] == 2);
            Assert.IsTrue(l[3] == 3);


            l.Move(3, 2);
            Assert.IsTrue(l[2] == 3);
            Assert.IsTrue(l[3] == 2);

            l.Move(3, 2);
            Assert.IsTrue(l[2] == 2);
            Assert.IsTrue(l[3] == 3);


            l.Swap(4, 2);
            Assert.IsTrue(l[2] == 4);
            Assert.IsTrue(l[4] == 2);

            l.Swap(4, 2);
            Assert.IsTrue(l[2] == 2);
            Assert.IsTrue(l[4] == 4);
        }
    }
}
