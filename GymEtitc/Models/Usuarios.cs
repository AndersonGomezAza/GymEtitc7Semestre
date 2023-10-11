using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public int NumDocumento { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string TipoDoc { get; set; } = null!;

    public int IdPlan { get; set; }

    public virtual Planes IdPlanNavigation { get; set; } = null!;

    public virtual ICollection<Valoraciones> Valoraciones { get; set; } = new List<Valoraciones>();
}
