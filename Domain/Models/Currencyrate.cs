using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Currencyrate
{
    public int Currencyrateid { get; set; }

    public string? Code { get; set; }

    public string? Date { get; set; }

    public decimal? Purchaserate { get; set; }

    public decimal? Sellingrate { get; set; }

    public string? Sideid { get; set; }

    public string? Toboid { get; set; }

    public string? Tobosname { get; set; }
}
