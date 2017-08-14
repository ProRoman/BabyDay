using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;

namespace BabyDay.Migrations
{
    /// <summary>
    /// MigrationsRunner uses the DbMigrator class. It uses reflection to read out all classes from the assembly, 
    /// and find the ones which are subclasses of DbMigration. Each DB migration has a name, which is a combination of a timestamp and the name you gave it in the Add-Migration command.
    /// In the database, there’s a table (or will be, after you run your first migration) called dbo.__MigrationHistory (it may be under the “System Tables” folder).
    /// That table holds information about migrations you have already ran.
    /// When we call DbMigrator.Update(), it searches for all migrations, removes the ones which already have entries in the table, and orders them according to timestamp.
    /// </summary>    
    public class MigrationsRunner
    {
        public static void DoDbUpdate()
        {
            DbMigrator migrator = new DbMigrator(new Configuration());
            MigratorLoggingDecorator logger = new MigratorLoggingDecorator(migrator, new MigrationsLoggerImpl());
            logger.Update();
        }
    }
}