using System;
using System.Collections.Generic;

namespace usersAPI.Models;

public partial class UserRole
{
    public byte UserRoleId { get; set; }

    public string RoleCoddeType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
