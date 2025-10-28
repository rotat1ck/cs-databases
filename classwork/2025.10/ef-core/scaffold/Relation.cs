using System;
using System.Collections.Generic;

namespace scaffold;

public partial class Relation
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }

    public int Status { get; set; }

    public DateTime СreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
