using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;

public class EncaminharEnvelopeParaAssinaturaRepository : Repository<EncaminharEnvelopeParaAssinatura>, IEncaminharEnvelopeParaAssinaturaRepository
{
    public EncaminharEnvelopeParaAssinaturaRepository(ApiContext context) : base(context) { }
}
