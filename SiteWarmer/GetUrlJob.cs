namespace SiteWarmer
{
    using System;
    using System.Net;
    using System.Diagnostics;

    using Common.Logging;

    using Quartz;

    public class GetUrlJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var log = LogManager.GetLogger("SiteWarmer");
            var jdm = context.JobDetail.JobDataMap;
            var uri = new Uri(jdm.GetString("url"));
            var sw = new Stopwatch();
            
            sw.Start();
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadString(uri);
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    log.Error(string.Format("Job {1} Failed: Error Fetching {0}!", uri.AbsoluteUri, context.JobDetail.Key.Name), ex);
                    return;
                }                
            }
            sw.Stop();            
            log.Info(string.Format("Executed Job {2} - Fetched: {0}. Duration: {1} ms",uri.AbsoluteUri, sw.ElapsedMilliseconds, context.JobDetail.Key.Name));
        }
    }
}