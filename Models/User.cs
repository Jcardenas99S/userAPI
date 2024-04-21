using System;
using System.Collections.Generic;

namespace usersAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public string? Username { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
