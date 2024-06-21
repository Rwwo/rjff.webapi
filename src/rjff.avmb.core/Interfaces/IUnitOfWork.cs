namespace rjff.avmb.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICriarEnvelopeRepository CriarEnvelopeRepository { get; }
        Task Commit();
    }

}
