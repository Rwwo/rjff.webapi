using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ConfigAuxiliarInputModel
    {
        public ConfigAuxiliarInputModel(string documentosComXMLs, string? urlCarimboTempo)
        {
            this.documentosComXMLs = documentosComXMLs;
            this.urlCarimboTempo = urlCarimboTempo;
        }

        [DefaultValue("N")]
        public string documentosComXMLs { get; set; }
        [DefaultValue(null)]
        public string? urlCarimboTempo { get; set; }

    }

}
