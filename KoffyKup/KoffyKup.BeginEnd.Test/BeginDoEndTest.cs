using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace KoffyKup.BeginEnd.Test
{
    [TestClass]
    public class BeginDoEndTest
    {
        [TestMethod]
        public void Test_BeginDoEnd_Simple()
        {
            var message = "Zero";
            Assert.AreEqual("Zero", message);

            BeginDoEnd.Begin(() =>
                message = "Begin"
            ).Do(() =>
            {
                Assert.AreEqual("Begin", message);
            }
            ).End(() =>
                message = "End"
            );

            Assert.AreEqual("End", message);
        }
        [TestMethod]
        public void Test_BeginDoEnd_WhenException()
        {
            var message = "Zero";
            Assert.AreEqual("Zero", message);
            Assert.ThrowsException<Exception>(() =>
            {
                BeginDoEnd.Begin(() =>
                message = "Begin"
            ).Do(() =>
              {
                  Assert.AreEqual("Begin", message);
                  throw new Exception();
              }
            ).End(() =>
                message = "End"
                );
            }
            );
            Assert.AreEqual("End", message);
        }


        [TestMethod]
        public void Test_BeginDoEnd_WhenReturnn()
        {
            var message = "Zero";
            Assert.AreEqual("Zero", message);

            BeginDoEnd.Begin(() =>
                message = "Begin"
            ).Do(() =>
              {
                  Assert.AreEqual("Begin", message);
                  return;
              }
            ).End(() =>
                message = "End"
                );

            Assert.AreEqual("End", message);
        }
    }
}
