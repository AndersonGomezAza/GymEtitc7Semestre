using System;
using System.Collections.Generic;

namespace GymEtitc.Models;

public partial class Planes
{
    public int IdPlan { get; set; }

    public decimal ValorPlan { get; set; }

    public int DuracionMesesPlan { get; set; }

    public string DescripcionPlan { get; set; } = null!;
}
