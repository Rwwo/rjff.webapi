namespace rjff.avmb.core.InputModels
{
    public class ConfigAuxiliarInputModel
    {
        public ConfigAuxiliarInputModel(string urlCarimboTempo = "",string documentosComXMLs = "N")
        {
            this.documentosComXMLs = documentosComXMLs;
            this.urlCarimboTempo = urlCarimboTempo;
        }

        public string documentosComXMLs { get; set; }
        public string urlCarimboTempo { get; set; }

    }

}
