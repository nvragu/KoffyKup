using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoffyKup.Code;

namespace KoffyKup.CodeExtensions.Test
{
    [TestClass]
    public class CodeExtensionTest
    {
        [TestMethod]
        public void Test_WhenPrePostActionsProvidedShouldSucceed()
        {
            var flag = "";
            Code.CodeExtensions.Code(() =>
           {
               Assert.AreEqual("PreExecuted", flag);
           })
             .PreAndPost(() => flag = "PreExecuted", () => flag = "PostExecuted")
             ();
            Assert.AreEqual("PostExecuted", flag);
        }

        [TestMethod]
        public void Test_WhenPrePostActionsProvidedAndWithExceptionShouldExecuteActions()
        {
            var preFlag = ""; var postFlag = "";
            try
            {
                Code.CodeExtensions.Code(() =>
                {
                    throw new System.Exception("error");
                })
                 .PreAndPost(() => preFlag = "PreExecuted", () => postFlag = "PostExecuted")
                 ();
            }
            catch {; }
            Assert.AreEqual("PreExecuted", preFlag);
            Assert.AreEqual("PostExecuted", postFlag);
        }
        [TestMethod]
        public void Test_WhenTimeMetricRequestedShould()
        {
            Code.CodeExtensions.Code(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    var j = i + i;
                }
                System.Threading.Thread.Sleep(1000);
                throw new System.Exception("break this flow");
                for (int i = 0; i < 10000000; i++)
                {
                    var j = i + i;
                }
            }).MeasureTime(metric =>
            {
                Assert.IsTrue(metric.CpuTime > 0);
                Assert.IsTrue(metric.WallClockTime > 0);
                Assert.IsTrue(metric.StartAt > 0);
                Assert.IsTrue(metric.EndAtt > 0);
            })
             ();
        }
    }
}
