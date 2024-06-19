namespace rjff.avmb.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEnvelopeRepository EnvelopeRepository { get; }

        Task Commit();
    }

}
