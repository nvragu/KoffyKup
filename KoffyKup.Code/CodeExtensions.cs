using System;

namespace KoffyKup.Code
{
    public static class CodeExtensions
    {
        public static Action Code(Action act)
        {
            return act;
        }
        public static Action PreAndPost(this Action code, Action PreAction, Action postAction)
        {
            return () =>
            {
                try
                {
                    PreAction();
                    code();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    postAction();
                }
            };
        }

        public static Action HandleException(this Action code, Action<Exception> handler)
        {
            return () =>
            {
                try
                {
                    code();
                }
                catch (Exception ex)
                {
                    handler(ex);
                }

            };
        }
        public static Action MeasureTime(this Action code, Action<TimeMetric> metricProcessor)
        {
            return () =>
            {
                var metric = new TimeMetric();
                metric.StartAt = DateTime.Now.Ticks;
                metric.CpuTime = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.Ticks;
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                try
                {
                    code();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (metric != null)
                    {
                        metric.EndAtt = System.DateTime.Now.Ticks;
                        metric.CpuTime = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.Ticks - metric.CpuTime;
                        watch.Stop();
                        metric.WallClockTime = watch.ElapsedTicks;
                        metricProcessor(metric);
                    }
                }
            };
        }
    }

    public class TimeMetric
    {
        public long CpuTime { get; set; }
        public long WallClockTime { get; set; }
        public long StartAt { get; set; }
        public long EndAtt { get; set; }
    }
}
