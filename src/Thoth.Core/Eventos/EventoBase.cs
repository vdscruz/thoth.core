namespace Thoth.Core.Eventos;

public abstract class EventoBase
{
    public string Tipo { get; set; }
    protected EventoBase(string tipo)
    {
        Tipo = tipo;
    }
}