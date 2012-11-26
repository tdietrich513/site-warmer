namespace SiteWarmer
{
    using System;
    using System.Configuration;

    public class JobCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "job";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }

        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }
        
        protected override ConfigurationElement CreateNewElement()
        {
            return new Job();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Job)(element)).Name;
        }

        public Job this[int id]
        {
            get { return (Job)BaseGet(id); }
        }
    }
}