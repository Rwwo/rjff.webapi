using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;

public class CriarEnvelopeRepository : Repository<CriarEnvelope>, ICriarEnvelopeRepository
{
    public CriarEnvelopeRepository(ApiContext context) : base(context) { }
}
