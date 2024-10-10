using System;
using System.Collections.Generic;

namespace portifolio_rafa.Models;

public partial class Projeto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }
}
