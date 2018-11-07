namespace FarmAPI.Models
{
    public class Temp
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Temp(string firstName)
        {
            name = firstName;
        }
    }
}