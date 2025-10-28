using System;
using System.Collections.Generic;

namespace scaffold;

public partial class PinsShared
{
    public Guid Id { get; set; }

    public Guid PinId { get; set; }

    public Guid UserId { get; set; }

    public DateTime СreatedAt { get; set; }

    public virtual Pin Pin { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
