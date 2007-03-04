/* 
* Copyright 2007 OpenSymphony 
* 
* Licensed under the Apache License, Version 2.0 (the "License"); you may not 
* use this file except in compliance with the License. You may obtain a copy 
* of the License at 
* 
*   http://www.apache.org/licenses/LICENSE-2.0 
*   
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
* WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
* License for the specific language governing permissions and limitations 
* under the License.
* 
*/
using System;
using Common.Logging;
using Quartz.Impl;

namespace Quartz.Examples.Example10
{
	
	/// <summary> 
	/// This example will spawn a large number of jobs to run.
	/// </summary>
	/// <author>James House, Bill Kratzer</author>
	public class PlugInExample : IExample
	{
		public string Name
		{
			get { throw new NotImplementedException(); }
		}
		
		public virtual void Run()
		{
			ILog log = LogManager.GetLogger(typeof(PlugInExample));
			
			// First we must get a reference to a scheduler
			ISchedulerFactory sf = new StdSchedulerFactory();
			IScheduler sched = sf.GetScheduler();
			
			log.Info("------- Initialization Complete -----------");
			
			log.Info("------- (Not Scheduling any Jobs - relying on XML definitions --");
			
			log.Info("------- Starting Scheduler ----------------");
			
			// start the schedule 
			sched.Start();
			
			log.Info("------- Started Scheduler -----------------");
			
			log.Info("------- Waiting five minutes... -----------");
			
			// wait five minutes to give our jobs a chance to run
			try
			{
				System.Threading.Thread.Sleep(new TimeSpan(10000 * 300L * 1000L));
			}
			catch 
			{
			}
			
			// shut down the scheduler
			log.Info("------- Shutting Down ---------------------");
			sched.Shutdown(true);
			log.Info("------- Shutdown Complete -----------------");
			
			SchedulerMetaData metaData = sched.GetMetaData();
			log.Info("Executed " + metaData.NumJobsExecuted + " jobs.");
		}
	}
}