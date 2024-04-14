using System;
using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Domain.Entities;

public class Atendimento : Entity
{
    public long Cliente { get; set; }
    
    public long Atendente { get; set; }

    public DateTime DataChegada { get; set; }
    
    public DateTime DataInicioAtendimento { get; set; }
    
    public DateTime DataFimAtendimento { get; set; }
}