namespace rjff.avmb.core.InputModels
{
    public class ConfigurarSignatarioInputModel
    {
        public string token { get; private set; }
        public ParamsConfigurarSignatarioInputModel @params { get; private set; }

        public ConfigurarSignatarioInputModel(string token, ParamsConfigurarSignatarioInputModel @params)
        {
            this.token = token;
            this.@params = @params;
        }
    }
}
