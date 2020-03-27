/*
    Copyright ® 2020 March devMobile Software, All Rights Reserved
 
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
namespace AzureApplicationInsightsCoreClientConsole
{
   using System;

   using Microsoft.ApplicationInsights;
   using Microsoft.ApplicationInsights.DataContracts;
   using Microsoft.ApplicationInsights.Extensibility;

   class Program
   {

      static void Main(string[] args)
      {
#if INSTRUMENTATION_KEY_TELEMETRY_CONFIGURATION
         if (args.Length != 1)
         {
            Console.WriteLine("Usage AzureApplicationInsightsClientConsole <instrumentationKey>");
            return;
         }

         using( TelemetryConfiguration telemetryConfiguration = new TelemetryConfiguration(args[0]))
         {
            TelemetryClient telemetryClient = new TelemetryClient(telemetryConfiguration);
            telemetryClient.TrackTrace("INSTRUMENTATION_KEY_TELEMETRY_CONFIGURATION", SeverityLevel.Information);
#endif
#if INSTRUMENTATION_KEY_APPLICATION_INSIGHTS_CONFIG
         using (TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.CreateDefault())
         {
            TelemetryClient telemetryClient = new TelemetryClient(telemetryConfiguration);
            telemetryClient.TrackTrace("INSTRUMENTATION_KEY_APPLICATION_INSIGHTS_CONFIG", SeverityLevel.Information);
#endif

            telemetryClient.Context.User.Id = Environment.UserName;
            telemetryClient.Context.Device.Id =Environment.MachineName;
            telemetryClient.Context.Operation.Name = "Test harness";

            telemetryClient.TrackTrace("This is a .Net Core AI API Verbose message", SeverityLevel.Verbose);
            telemetryClient.TrackTrace("This is a .Net Core AI API Information message", SeverityLevel.Information);
            telemetryClient.TrackTrace("This is a .Net Core AI API Warning message", SeverityLevel.Warning);
            telemetryClient.TrackTrace("This is a .Net Core AI API Error message", SeverityLevel.Error);
            telemetryClient.TrackTrace("This is a .Net Core AI API Critical message", SeverityLevel.Critical);

            telemetryClient.Flush();
         }
         Console.WriteLine("Press <enter> to exit");
         Console.ReadLine();
      }
   }
}


