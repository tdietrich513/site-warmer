namespace SiteWarmer
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class JobSettings
    {
        public JobSection JobConfiguration
        {
            get { return (JobSection)ConfigurationManager.GetSection("jobSection"); }
        }

        public JobCollection JobCollection
        {
            get { return JobConfiguration.JobElement; }
        }

        public IEnumerable<Job> Jobs
        {
            get
            {
                return JobCollection.Cast<Job>().Where(job => job != null);
            }
        }
    }
}