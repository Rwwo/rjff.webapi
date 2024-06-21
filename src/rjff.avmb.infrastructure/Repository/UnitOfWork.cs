using rjff.avmb.core.Interfaces;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;
public class UnitOfWork : IUnitOfWork
{
    public readonly ApiContext _dbContext;
    public UnitOfWork(ApiContext dbContext)
    {
        _dbContext = dbContext;
    }


    private ICriarEnvelopeRepository _CriarEnvelopeRepository = null;
    public ICriarEnvelopeRepository CriarEnvelopeRepository
    {
        get => _CriarEnvelopeRepository ?? (_CriarEnvelopeRepository = new CriarEnvelopeRepository(_dbContext));
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }

}
