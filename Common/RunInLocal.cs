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

        public static bool RunServer(string serverUrl)
        {
            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(Run));
                t.Start(serverUrl);
                //while(true)
                //{
                //    Thread.Sleep(1000);
                //    if (!Program.GetIsRunInLocal())
                //    {
                //        t.Abort();
                //    }
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         

        public static void Run(object serverUrl)
        {
            try
            {
                var startOpts = new StartOptions(serverUrl.ToString())
                {
                };
                using (WebApp.Start<Startup>(startOpts))
                {
                    Console.WriteLine("Server run at " + serverUrl + " , press Enter to exit.");
                    // Console.ReadLine();
                    System.Diagnostics.Process.Start("explorer.exe", serverUrl.ToString());
                }
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
                var startOpts = new StartOptions(serverUrl)
                {
                };
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
