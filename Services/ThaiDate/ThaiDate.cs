using System.Globalization;

namespace DotnetAPIApp.Services.ThaiDate
{
    public class ThaiDate : IThaiDate
    {
        public void DisplayThaiDate()
        {
            throw new NotImplementedException();
        }

        public string ShowThaiDate()
        {
            return DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("th-TH"));
        }
    }
}
