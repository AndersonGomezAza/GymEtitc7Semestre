using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Maquinaria
{
    public int IdMaquinaria { get; set; }

    public string CategoriaMaquinaria { get; set; } = null!;

    public string DescripcionMaquinaria { get; set; } = null!;

    public string EstadoMaquinaria { get; set; } = null!;

    public string NombreMaquinaria { get; set; } = null!;

    public string SerialMaquinaria { get; set; } = null!;
}
