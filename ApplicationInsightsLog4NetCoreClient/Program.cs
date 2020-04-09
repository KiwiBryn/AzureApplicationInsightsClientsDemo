/*
    Copyright ® 2020 April devMobile Software, All Rights Reserved
 
    MIT License

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE

*/
namespace devMobile.Azure.ApplicationInsightsLog4NetCoreClient
{
   using System;
   using System.IO;
   using System.Reflection;

   using log4net;
   using log4net.Config;

   using Microsoft.ApplicationInsights;
   using Microsoft.ApplicationInsights.Extensibility;

   class Program
   {
      private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      static void Main(string[] args)
      {
         using (TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.CreateDefault())
         {
            TelemetryClient telemetryClient = new TelemetryClient(telemetryConfiguration);

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(Environment.CurrentDirectory, "log4net.config")));

            log.Debug("This is a Log4Net Core Debug message");
            log.Info("This is a Log4Net Core Info message");
            log.Warn("This is a Log4Net Core Warning message");
            log.Error("This is a Log4Net Core Error message");
            log.Fatal("This is a Log4Net Core Fatal message");

            telemetryClient.Flush();
         }

         Console.WriteLine("Press <enter> to exit");
         Console.ReadLine();
      }
   }
}
