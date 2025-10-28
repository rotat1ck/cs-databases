using System;
using System.Collections.Generic;

namespace scaffold;

public partial class Pin
{
    public Guid Id { get; set; }

    public Guid OwnerUserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Lat { get; set; }

    public decimal Lon { get; set; }

    public DateTime СreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User OwnerUser { get; set; } = null!;

    public virtual ICollection<PinsShared> PinsShareds { get; set; } = new List<PinsShared>();
}
