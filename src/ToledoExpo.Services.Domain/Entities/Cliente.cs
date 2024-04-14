using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Domain.Entities;

public class Cliente : Entity
{
    public string Nome { get; set; }
    
    public double VelocidadeMovimento { get; set; }
    
    public double CapacidadeCognitiva { get; set; }

}