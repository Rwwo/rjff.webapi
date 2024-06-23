namespace rjff.avmb.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICriarEnvelopeRepository CriarEnvelopeRepository { get; }
        IConfigurarSignatarioRepository ConfigurarSignatarioRepository { get; }
        IEncaminharEnvelopeParaAssinaturaRepository EncaminharEnvelopeParaAssinaturaRepository { get; }
        Task Commit();
    }

}
