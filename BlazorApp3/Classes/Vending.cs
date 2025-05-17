namespace BlazorApp3.Data
{
    public partial class Vending
    {
        public string AdressAndPlace { get
            {
                return Address + "," + "\n" + Place;
            }
        }
    }
}
