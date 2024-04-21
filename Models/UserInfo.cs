using System;
using System.Collections.Generic;

namespace usersAPI.Models;

public partial class UserInfo
{
    public int UserInfoId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UserId { get; set; }

    public byte? UserRoleId { get; set; }

    public bool? IsActive { get; set; }

    public virtual User? User { get; set; }

    public virtual UserRole? UserRole { get; set; }
}
