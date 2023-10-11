using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Rutina
{
    public int IdRutina { get; set; }

    public int CaloriasRutina { get; set; }

    public string DescripcionRutina { get; set; } = null!;

    public string NombreRutina { get; set; } = null!;

    public string CategoriaRutina { get; set; } = null!;

    public int TiempoRutinaMin { get; set; }
}
