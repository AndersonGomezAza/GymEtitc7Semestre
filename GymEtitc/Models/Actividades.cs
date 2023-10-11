using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Actividades
{
    public int IdActividad { get; set; }

    public string DescripcionActividad { get; set; } = null!;

    public int DuracionMinActividad { get; set; }

    public string CategoriaActividad { get; set; } = null!;
}
