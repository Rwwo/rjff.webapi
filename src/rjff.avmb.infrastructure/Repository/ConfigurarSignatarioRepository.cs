using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;

namespace rjff.avmb.infrastructure.Repository;

public class ConfigurarSignatarioRepository : Repository<ConfigurarSignatario>, IConfigurarSignatarioRepository
{
    public ConfigurarSignatarioRepository(ApiContext context) : base(context) { }
}
