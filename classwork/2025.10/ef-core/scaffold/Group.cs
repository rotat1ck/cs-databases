using System;
using System.Collections.Generic;

namespace scaffold;

public partial class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid OwnerUserId { get; set; }

    public DateTime СreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User OwnerUser { get; set; } = null!;

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();
}
