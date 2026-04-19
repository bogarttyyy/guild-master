using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private string orderListText;
    
    private List<Order> orders;
    
    [Header("Events")]
    [SerializeField] private EventChannel<string> UpdateOrderText;
    [SerializeField] private EventChannel<string> UpdateOrderListText;
    
    private void Start()
    {
        orderText = "";
        UpdateOrderText.Invoke(orderText);
        UpdateOrderListText.Invoke("");
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
            PrintOrders();
    }

    private void PrintOrders()
    {
        // NSBLogger.Log("Printing orders");
        // foreach (var order in orders)
        //     NSBLogger.Log(order.orderText);
        orderListText = "";
        foreach (var order in orders)
        {
            orderListText += $"{order.orderText}\n";
        }
        UpdateOrderListText.Invoke(orderListText);
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
        AddOrder(newOrder);
        UpdateOrderText.Invoke(newOrder.orderText);
        NSBLogger.Log(newOrder.orderText);
    }

    public void AddOrder(Order newOrder)
    {
        orders.Add(newOrder);
        PrintOrders();
    }

    public void FulfillOrder(Order newOrder)
    {
        var foundOrder = orders.FirstOrDefault(x => x.drinkType == newOrder.drinkType &&
                          x.isIced == newOrder.isIced &&
                          x.cupSize == newOrder.cupSize);

        if (foundOrder != null)
        {
            orders.Remove(foundOrder);
            PrintOrders();
        }
    }
}
