/*
    Copyright ® 2019 March devMobile Software, All Rights Reserved
 
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
namespace devMobile.Azure.ApplicationInsightsLog4NetClientPoC
{
	using System;
	using Microsoft.ApplicationInsights.Extensibility;

	class Program
   {
      private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      static void Main(string[] args)
      {
         if (( args.Length != 0) && (args.Length != 1 ))
         {
            Console.WriteLine("Usage AzureApplicationInsightsClientConsole");
            Console.WriteLine("      AzureApplicationInsightsClientConsole <instrumentationKey>");
            return;
         }

         if (args.Length == 1)
         {
            TelemetryConfiguration.Active.InstrumentationKey = args[0];
         }

			log.Debug("This is a Log4Net Debug message");
         log.Info("This is a Log4Net Info message");
         log.Warn("This is a Log4Net Warning message");
         log.Error("This is an Log4Net Error message");
         log.Fatal("This is a Log4Net Fatal message");

			TelemetryConfiguration.Active.TelemetryChannel.Flush();

			Console.WriteLine("Press <enter> to exit>");
         Console.ReadLine();
      }
   }
}