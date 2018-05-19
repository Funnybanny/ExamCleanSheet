using Converter;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Quartz
{
    public class IDGJob : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            var conv = new Converter.Converter();
            conv.Convert();
            return null;
        }
    }
}
