using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels;

public class InsertPostViewModel
{

    [NotNull]
    public string Name { get; set; } = default!;
    public string Text { get; set; } = default!;
}

