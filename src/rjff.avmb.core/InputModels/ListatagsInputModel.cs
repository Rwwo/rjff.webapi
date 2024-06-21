using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListatagsInputModel
    {
        [DefaultValue(typeof(List<object>), "[]")]
        public List<object> Tag { get; set; } = Enumerable.Empty<object>().ToList();
    }
}
