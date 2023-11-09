using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Login
{
    public int IdLogin { get; set; }

    public string CorreoUsuario { get; set; } = null!;

    public string PasswordUsuario { get; set; } = null!;

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }
}
