namespace Mvc.Plugin.Vehicles.Models
{
    public class SampleViewModel
    {
        public string sampleFields { get; set; }

        public void Initialize(string str)
        {
            this.sampleFields = str;
        }
    }
}
