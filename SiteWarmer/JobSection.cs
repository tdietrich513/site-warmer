namespace SiteWarmer
{
    using System.Configuration;

    public class JobSection : ConfigurationSection
    {
        [ConfigurationProperty("jobs")]
        public JobCollection JobElement
        {
            get { return ((JobCollection)(base["jobs"])); }
            set { base["jobs"] = value; }
        }
    }
}