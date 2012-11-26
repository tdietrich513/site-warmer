namespace SiteWarmer
{
    using System.ServiceProcess;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
                                    { 
                                        new SiteWarmerService() 
                                    };
            ServiceBase.Run(servicesToRun);
        }
    }
}
