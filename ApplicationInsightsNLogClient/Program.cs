//---------------------------------------------------------------------------------
// Copyright (c) 2018, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//---------------------------------------------------------------------------------
using System;
using Microsoft.ApplicationInsights.Extensibility;
using NLog;

namespace devMobile.Azure.ApplicationInsightsNLogClient
{
   class Program
   {
      private static Logger log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());

      static void Main(string[] args)
      {
         if (args.Length != 1)
         {
            Console.WriteLine("Command line argument InstrumentationKey missing");
            return;
         }
         TelemetryConfiguration.Active.InstrumentationKey = args[0];

         log.Trace("This is an nLog Trace message");
         log.Debug("This is an nLog Debug message");
         log.Info("This is an nLog Info message");
         log.Warn("This is an nLog Warning message");
         log.Error("This is an nLog Error message");
         log.Fatal("This is an nLog Fatal message");

         new Microsoft.ApplicationInsights.TelemetryClient().Flush();

			Console.WriteLine("Press <enter> to exit>");
			Console.ReadLine();
		}
	}
}
