using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Valoracione
{
    public int IdValoracion { get; set; }

    public DateTime FechaValoracion { get; set; }

    public string CategoriaValoracion { get; set; } = null!;

    public string DescripcionValoracion { get; set; } = null!;

    public int RecomendacionValoracion { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
