using System.Collections.Generic;
using Enums;
using Models;
using NSBLib.EventChannelSystem;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [Header("Order")]
    [SerializeField] private string orderText; 
    private List<Order> orders;
    
    [Header("Events")]
    [SerializeField] private EventChannel<string> UpdateOrderText;
    
    private void Start()
    {
        orderText = "";
        UpdateOrderText.Invoke(orderText);
        orders = new List<Order>();
        // GenerateOrder();
    }

    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            GenerateOrder();
        }
        
        if (Keyboard.current.zKey.wasPressedThisFrame)
            GenerateOrderV2();
    }

    private void GenerateOrder()
    {
        var cupSize = (ECupSize)Random.Range(1, 4);
        orderText = $"{cupSize} Coffee";
        UpdateOrderText.Invoke(orderText);
        NSBLogger.Log(orderText);
    }

    public void GenerateOrderV2()
    {
        var newOrder = new Order()
        {
            cupSize =  (ECupSize)Random.Range(1, 4),
            drinkType = (EDrinkType)Random.Range(0, 2),
            isIced =  Random.Range(0, 2) == 0,
        };

        var icedText = newOrder.isIced ? "Iced " : "";
        newOrder.orderText = $"{newOrder.cupSize} {icedText}{newOrder.drinkType}";
        orders.Add(newOrder);        
        UpdateOrderText.Invoke(newOrder.orderText);
        NSBLogger.Log(newOrder.orderText);
    }
}
