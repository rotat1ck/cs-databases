using System;
using System.Collections.Generic;

namespace scaffold;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsVerified { get; set; }

    public bool IsRestricted { get; set; }

    public int Role { get; set; }

    public DateTime СreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Friend> FriendUserIdReceiverNavigations { get; set; } = new List<Friend>();

    public virtual ICollection<Friend> FriendUserIdRequesterNavigations { get; set; } = new List<Friend>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Pin> Pins { get; set; } = new List<Pin>();

    public virtual ICollection<PinsShared> PinsShareds { get; set; } = new List<PinsShared>();

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();
}
