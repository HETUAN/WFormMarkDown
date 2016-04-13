using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    public static class RunInLocal
    {
        //private static string serverUrl = "http://localhost:8181/";

        public static Thread t = new Thread(new ThreadStart(Run));

        public static bool RunServer()
        {
            try
            {
                t.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool StopServer()
        {
            //if (t.ThreadState == ThreadState.Running)
            //{
            t.Abort();
            t.DisableComObjectEagerCleanup();
           
            return true;
            //}
            //return false;
        }

        public static void Run()
        {
            try
            {
                string serverUrl = "http://localhost:"+Program.GetConfig().Site.localport;
                var startOpts = new StartOptions(serverUrl.ToString())
                {
                };
                WebApp.Start<Startup>(startOpts);

                Console.WriteLine("Server run at " + serverUrl + " , press Enter to exit.");
                // Console.ReadLine();
                System.Diagnostics.Process.Start("explorer.exe", serverUrl.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Run(string serverUrl)
        {
            try
            {
                var startOpts = new StartOptions()
                {
                };
                startOpts.Urls.Add(serverUrl);
                startOpts.Urls.Add(serverUrl.Replace("localhost","127.0.0.1"));
                using (WebApp.Start<Startup>(startOpts))
                {
                    Console.WriteLine("Server run at " + serverUrl + " , press Enter to exit.");
                    // Console.ReadLine();
                    System.Diagnostics.Process.Start("explorer.exe", serverUrl);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //public static bool Run()
        //{
        //    try
        //    {
        //        var startOpts = new StartOptions(serverUrl)
        //        {
        //        };
        //        using (WebApp.Start<Startup>(startOpts))
        //        {
        //            Console.WriteLine("Server run at " + serverUrl + " , press Enter to exit.");
        //            // Console.ReadLine();
        //            System.Diagnostics.Process.Start("explorer.exe", serverUrl);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
