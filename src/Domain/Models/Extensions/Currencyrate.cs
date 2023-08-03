using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public partial class Currencyrate
{
    public string Key
    {
        get => $"{Code}-{Date}-{Tobosname}";
    }
}

