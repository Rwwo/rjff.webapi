namespace rjff.avmb.core.InputModels
{
    public class ListaxmlauxiliarInputModel
    {
        public ListaxmlauxiliarInputModel(List<XmlauxiliarInputModel> xMLAuxiliar)
        {
            XMLAuxiliar = xMLAuxiliar;
        }

        public List<XmlauxiliarInputModel> XMLAuxiliar { get; private set; }
    }
}
