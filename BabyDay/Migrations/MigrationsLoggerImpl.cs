using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;

namespace BabyDay.Migrations
{
    public class MigrationsLoggerImpl : MigrationsLogger
    {
        public override void Info(string message)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("Info: {0}", message));
        }

        public override void Verbose(string message)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("Verbose: {0}", message));
        }

        public override void Warning(string message)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("Warning: {0}", message));
        }
    }
}