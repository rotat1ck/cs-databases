using System;
using System.Collections.Generic;

namespace scaffold;

public partial class Friend
{
    public Guid Id { get; set; }

    public Guid UserIdRequester { get; set; }

    public Guid UserIdReceiver { get; set; }

    public int Status { get; set; }

    public DateTime СreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User UserIdReceiverNavigation { get; set; } = null!;

    public virtual User UserIdRequesterNavigation { get; set; } = null!;
}
