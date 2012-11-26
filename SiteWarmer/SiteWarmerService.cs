namespace SiteWarmer
{
    using System;
    using System.ServiceProcess;

    using Common.Logging;

    using Quartz;
    using Quartz.Impl;

    public partial class SiteWarmerService : ServiceBase
    {
        ILog _log;
        IScheduler _sched;

        public SiteWarmerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var js = new JobSettings();
            
            _log = LogManager.GetLogger("SiteWarmer");
            _log.Info("Starting Up...");

            var schedFact = new StdSchedulerFactory();
            
            _sched = schedFact.GetScheduler();
            _sched.Start();

            _log.Info("Initializing Jobs...");            
            foreach (var j in js.Jobs)
            {
                _log.Info(String.Format("Initialized Job: {0} URL: {1} Schedule: {2}", j.Name, j.Url, j.Schedule));
                var jobDetail = new JobDetailImpl(j.Name, null, typeof(GetUrlJob));
                jobDetail.JobDataMap["url"] = j.Url;

                var trigger = TriggerBuilder.Create().WithCronSchedule(j.Schedule).Build();

                _sched.ScheduleJob(jobDetail, trigger);
            }            
        }

        protected override void OnStop()
        {
            _log.Info("Shutting Down...");
            _sched.Shutdown();            
        }
    }
}
