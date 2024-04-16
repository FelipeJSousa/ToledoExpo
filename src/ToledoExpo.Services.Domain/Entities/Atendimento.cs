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

    #region Navigation Properties

    public Cliente ClienteObj { get; set; }

    public Atendente AtendenteObj { get; set; }
    
    #endregion

    #region Regras de Negócio

    public AtendimentoSituacao ObterSituacao()
    {
        if (DataFimAtendimento < DateTime.Now)
        {
            return AtendimentoSituacao.Finalizado;
        }
        
        if(DataInicioAtendimento < DateTime.Now && DataFimAtendimento > DateTime.Now)
        {
            return AtendimentoSituacao.Atendimento;
        }
        
        return AtendimentoSituacao.Pendente;
    }

    #endregion
}