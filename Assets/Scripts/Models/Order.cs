using Enums;

namespace Models
{
    public class Order
    {
        public ECupSize cupSize;
        public EDrinkType drinkType;
        public bool isIced;
        
        public string orderText;
    }
}