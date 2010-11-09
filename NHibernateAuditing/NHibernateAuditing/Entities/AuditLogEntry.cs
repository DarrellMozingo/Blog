using System;

namespace NHibernateAuditing.Entities
{
	public class AuditLogEntry
	{
		public virtual int Id { get; set; }
		public virtual string Username { get; set; }
		public virtual string AuditEntryType { get; set; }
		public virtual string EntityFullName { get; set; }
		public virtual string EntityShortName { get; set; }
		public virtual int EntityId { get; set; }
		public virtual string FieldName { get; set; }
		public virtual string OldValue { get; set; }
		public virtual string NewValue { get; set; }
		public virtual DateTime Timestamp { get; set; }
	}
}