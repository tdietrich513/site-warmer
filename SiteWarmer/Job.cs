namespace SiteWarmer
{
    using System.Configuration;

    public class Job : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("url", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Url
        {
            get { return (string)base["url"]; }
            set { base["url"] = value; }
        }

        [ConfigurationProperty("schedule", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Schedule
        {
            get { return (string)base["schedule"]; }
            set { base["schedule"] = value; }
        }
    }
}