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
namespace ApplicationInsightsAzureFunctionLog4NetClient
{
	using System;
	using System.IO;
	using System.Reflection;
	using log4net;
	using log4net.Config;
	using Microsoft.ApplicationInsights.Extensibility;
	using Microsoft.Azure.WebJobs;

	public static class ApplicationInsightsTimer
	{
		[FunctionName("ApplicationInsightsTimerLog4Net")]
		public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ExecutionContext executionContext)
		{
			ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

			TelemetryConfiguration.Active.InstrumentationKey = Environment.GetEnvironmentVariable("InstrumentationKey", EnvironmentVariableTarget.Process);

			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(executionContext.FunctionAppDirectory, "log4net.config")));

			log.Debug("This is a Log4Net Debug message");
			log.Info("This is a Log4Net Info message");
			log.Warn("This is a Log4Net Warning message");
			log.Error("This is a Log4Net Error message");
			log.Fatal("This is a Log4Net Fatal message");

			TelemetryConfiguration.Active.TelemetryChannel.Flush();
		}
	}
}
