using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Implementos
{
    public int IdImplemento { get; set; }

    public string CategoriaImplemento { get; set; } = null!;

    public string DescripcionImplemento { get; set; } = null!;

    public string NombreImplemento { get; set; } = null!;

    public string SerialImplemento { get; set; } = null!;
}
