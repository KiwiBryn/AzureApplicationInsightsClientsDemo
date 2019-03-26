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
namespace AzureApplicationInsightsClientConsole
{
	using System;
	using System.Net.Http;

	using Microsoft.ApplicationInsights;
	using Microsoft.ApplicationInsights.DataContracts;
	using Microsoft.ApplicationInsights.DependencyCollector;
	using Microsoft.ApplicationInsights.Extensibility;

	class Program
   {
      static DependencyTrackingTelemetryModule module = new DependencyTrackingTelemetryModule();

      static void Main(string[] args)
      {
         TelemetryConfiguration configuration = TelemetryConfiguration.Active;

			if (args.Length != 1)
			{
				Console.WriteLine("Command line argument InstrumentationKey missing");
				return;
			}
			TelemetryConfiguration.Active.InstrumentationKey = args[0];

			var telemetryClient = new TelemetryClient();

			telemetryClient.TrackTrace("This is an AI API Verbose message", SeverityLevel.Verbose);
			telemetryClient.TrackTrace("This is an AI API Information message", SeverityLevel.Information);
			telemetryClient.TrackTrace("This is an AI API Warning message", SeverityLevel.Warning);
			telemetryClient.TrackTrace("This is an AI API Error message", SeverityLevel.Error);
			telemetryClient.TrackTrace("This is an AI API Critical message", SeverityLevel.Critical);

			telemetryClient.Flush();

			Console.WriteLine("Press <enter> to exit>");
			Console.ReadLine();
      }
   }
}
