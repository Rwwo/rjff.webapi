using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;

public class EnvelopeRepository : Repository<Envelope>, IEnvelopeRepository
{
    public EnvelopeRepository(ApiContext context) : base(context) { }
}
