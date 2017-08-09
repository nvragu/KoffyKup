using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoffyKup.BeginEnd;
namespace KoffyKup.BeginEnd.Test
{
    [TestClass]
    public class BeginEndAgentTest
    {
        [TestMethod]
        public void Test_BeginEndAgent_Simple()
        {
            var message = "Zero";
            Assert.AreEqual("Zero", message);
            using (new BeginEndAgent(() => message = "Begin", () => message = "End"))
            {
                Assert.AreEqual("Begin", message);
            }
            Assert.AreEqual("End", message);
        }
        [TestMethod]
        public void Test_BeginEndAgent_WhenException()
        {
            var message = "Zero";
            Assert.AreEqual("Zero", message);
            Assert.ThrowsException<Exception>(() =>
            {
                using (new BeginEndAgent(() => message = "Begin", () => message = "End"))
                {
                    Assert.AreEqual("Begin", message);
                    throw new Exception();
                }
            }
            );
            Assert.AreEqual("End", message);
        }

        string _message;
        [TestMethod]
        public void Test_BeginEndAgent_WhenReturnn()
        {
            InvokeReturn();
            Assert.AreEqual("End", _message);
        }
        private void InvokeReturn()
        {
            _message = "Zero";
            Assert.AreEqual("Zero", _message);

            using (new BeginEndAgent(() => _message = "Begin", () => _message = "End"))
            {
                Assert.AreEqual("Begin", _message);
                return;
            }
        }
    }
}
