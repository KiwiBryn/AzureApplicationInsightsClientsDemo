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
namespace ApplicationInsightsEnterpriseLibraryClient
{
	using System;
	using Microsoft.ApplicationInsights.Extensibility;
	using Microsoft.Practices.EnterpriseLibrary.Logging;
	using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

	class Program
   {
      static void Main(string[] args)
      {
         if ((args.Length != 0) && (args.Length != 1))
         {
            Console.WriteLine("Usage ApplicationInsightsEnterpriseLibraryClient");
            Console.WriteLine("      ApplicationInsightsEnterpriseLibraryClient <instrumentationKey>");
            return;
         }

         if (args.Length == 1)
         {
            TelemetryConfiguration.Active.InstrumentationKey = args[0];
         }

         LogWriterFactory logWriterFactory = new LogWriterFactory();
         LogWriter logWriter = logWriterFactory.Create();
         Logger.SetLogWriter(logWriter);

         ExceptionManager exceptionManager = new ExceptionPolicyFactory().CreateManager();
         ExceptionPolicy.SetExceptionManager(exceptionManager);

         logWriter.Write("This is Entlib", "General");

         logWriter.Write("Application startup", "Startup");

         logWriter.Write("General category", "General");
         logWriter.Write(new LogEntry() { Severity = System.Diagnostics.TraceEventType.Error, Categories = { "General" }, Message = "General category more complex overload", Title = "Dumpster fire" });

         try
         {
            throw new ApplicationException("Something bad has happened");
         }
         catch (Exception ex)
         {
            bool rethrow = ExceptionPolicy.HandleException(ex, "ProgramMain");
            if (rethrow)
               throw;
         }

			logWriter.Write("Application shutdown", "Shutdown");

			TelemetryConfiguration.Active.TelemetryChannel.Flush();

			Console.WriteLine("Press <enter> to exit>");
			Console.ReadLine();
		}
	}
}
