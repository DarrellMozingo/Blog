using System;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using NHibernateAuditing.Entities;

namespace NHibernateAuditing
{
	public class Program
	{
		private const string _dbFilename = "nhib_auditing.db";

		private static ISessionFactory CreateSessionFactory()
		{
			return Fluently.Configure()
				.Database(SQLiteConfiguration.Standard
				          	.UsingFile(_dbFilename))
				.Mappings(m => m.AutoMappings.Add(
				               	AutoMap.AssemblyOf<Employee>(type => type.Namespace.EndsWith("Entities"))))
				.ExposeConfiguration(BuildSchema)
				.ExposeConfiguration(AddAuditor)
				.BuildSessionFactory();
		}

		private static void BuildSchema(Configuration config)
		{
			if (File.Exists(_dbFilename))
			{
				File.Delete(_dbFilename);
			}

			new SchemaExport(config).Create(false, true);
		}

		private static void AddAuditor(Configuration config)
		{
			config.SetListener(ListenerType.PostUpdate, new AuditUpdateListener());
		}

		private static void Main(string[] args)
		{
			var sessionFactory = CreateSessionFactory();

			int employeeId;

			// Create employee
			using (var session = sessionFactory.OpenSession())
			{
				using (var transaction = session.BeginTransaction())
				{
					var employee = new Employee { Age = 25, Name = "Darrell" };

					session.SaveOrUpdate(employee);

					transaction.Commit();

					employeeId = employee.Id;
				}
			}

			// Edit employee
			using (var session = sessionFactory.OpenSession())
			{
				using (var transaction = session.BeginTransaction())
				{
					var employee = session.Load<Employee>(employeeId);

					employee.Name = "John";
					employee.Age = 26;

					session.SaveOrUpdate(employee);

					transaction.Commit();
				}
			}

			using (var session = sessionFactory.OpenSession())
			{
				using (session.BeginTransaction())
				{
					var auditLogEntries = session.CreateCriteria(typeof(AuditLogEntry))
						.List<AuditLogEntry>();

					foreach (var auditLogEntry in auditLogEntries)
					{
						Console.WriteLine("Entity = {0}, Property = {1}, Old Value = '{2}', New Value = '{3}'",
						                  auditLogEntry.EntityShortName,
						                  auditLogEntry.FieldName,
						                  auditLogEntry.OldValue,
						                  auditLogEntry.NewValue);
					}
				}
			}

			Console.ReadKey();

			File.Delete(_dbFilename);
		}
	}
}