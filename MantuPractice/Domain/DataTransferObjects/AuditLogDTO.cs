using System;
using System.Collections.Generic;

namespace MantuPractice.Domain.Models;

public partial class AuditLogDTO
{
    public int AuditLogId { get; set; }

    public string? TableName { get; set; }

    public int? RecordId { get; set; }

    public string? Action { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public DateTime? ActionDate { get; set; }

    public int? UserId { get; set; }

}
