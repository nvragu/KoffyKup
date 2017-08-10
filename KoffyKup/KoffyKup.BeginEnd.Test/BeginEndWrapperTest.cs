using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoffyKup.BeginEnd;
using System.Collections.Generic;
using System.Linq;

namespace KoffyKup.BeginEnd.Test
{
    [TestClass]
    public class BeginEndWrapperTest
    {
        [TestMethod]
        public void Test_BeginEndWrapper_Simple()
        {
            var logs = new List<string>();
            logs.Add("Zero");
            using (new Tracer(logs))
            {
                logs.Add("Begin");
                Assert.AreEqual("Begin", logs.Last());
            }
            Assert.AreEqual("End", logs.Last());
        }
        [TestMethod]
        public void Test_BeginEndWrapper_WhenException()
        {
            var logs = new List<string>();
            logs.Add("Zero");
            Assert.ThrowsException<Exception>(() =>
            {
                InvokeExceptionBlock(logs);
            });
            Assert.AreEqual("End", logs.Last());
        }

        private void InvokeExceptionBlock(List<string> logs)
        {
            using (new Tracer(logs))
            {
                logs.Add("Begin");
                Assert.AreEqual("Begin", logs.Last());
                throw new Exception();
            }
        }

        [TestMethod]
        public void Test_BeginEndWrapper_WhenReturnn()
        {
            var logs = new List<string>();
            logs.Add("Zero");
            InvokeReturnBlock(logs);
            Assert.AreEqual("End", logs.Last());
        }
        private void InvokeReturnBlock(List<string> logs)
        {
            using (new Tracer(logs))
            {
                logs.Add("Begin");
                Assert.AreEqual("Begin", logs.Last());
                return;
            }
        }
    }
}
