using Enums;
using Models;
using NSBLib.EventChannelSystem;
using UnityEngine;

public class OrderFulfillmentManager : MonoBehaviour
{
    private Order currentOrder;
    [SerializeField] private ECupSize cupSize;
    [SerializeField] private bool iced;
    [SerializeField] private EDrinkType drinkType;

    [Header("Events")] 
    [SerializeField] private EventChannel<string> UpdateCupSizeText;
    [SerializeField] private EventChannel<string> UpdateIcedText;
    [SerializeField] private EventChannel<string> UpdateDrinkType;
    [SerializeField] private EventChannel<Order> ServeOrder;
    
    private void Start()
    {
        ResetOrder();
    }

    public void ResetOrder()
    {
        currentOrder = new Order();
        UpdateCupSizeText.Invoke("");
        UpdateIcedText.Invoke("False");
        UpdateDrinkType.Invoke("");
    }
    
    public void SelectCupSize(int cupSize)
    {
        currentOrder.cupSize = (ECupSize)cupSize;
        UpdateCupSizeText.Invoke($"{currentOrder.cupSize}");
    }

    public void AddIce()
    {
        currentOrder.isIced = true;
        UpdateIcedText.Invoke($"{currentOrder.isIced}");
    }

    public void SelectDrink(int drinkType)
    {
        currentOrder.drinkType = (EDrinkType)drinkType;
        UpdateDrinkType.Invoke($"{currentOrder.drinkType}");
    }

    public void Serve()
    {
        ServeOrder.Invoke(currentOrder);
        ResetOrder();
    }
    
    public void Trash()
    {
        ResetOrder();
    }
}
