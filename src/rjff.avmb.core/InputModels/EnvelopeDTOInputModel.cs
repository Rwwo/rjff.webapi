using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class EnvelopeDTOInputModel
    {
        public EnvelopeDTOInputModel(int id)
        {
            this.id = id;
        }

        [DefaultValue("64661")]
        public int id { get; private set; }
    }
}