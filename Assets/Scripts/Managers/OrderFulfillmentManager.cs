using Enums;
using Models;
using UnityEngine;

public class OrderFulfillmentManager : MonoBehaviour
{
    private Order currentOrder;
    
    private void Start()
    {
        ResetOrder();
    }

    public void ResetOrder()
    {
        currentOrder = new Order();
    }

    public void SelectCupSize(ECupSize cupSize)
    {
        currentOrder.cupSize = cupSize;
    }

    public void AddIce()
    {
        currentOrder.isIced = true;
    }

    public void SelectDrink(EDrinkType drinkType)
    {
        currentOrder.drinkType = drinkType;
    }

    public void Serve()
    {
        
    }
}
