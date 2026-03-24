using System;
using Enums;
using NSBLib.EventChannelSystem;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [Header("Order")]
    [SerializeField] private string orderText;
    
    [Header("Events")]
    [SerializeField] private EventChannel<string> UpdateOrderText;
    
    private void Start()
    {
        orderText = "";
        UpdateOrderText.Invoke(orderText);
    }
    
    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            GenerateOrder();
        }
    }

    private void GenerateOrder()
    {
        var cupSize = (ECupSize)Random.Range(1, 4);
        orderText = $"{cupSize} Coffee";
        UpdateOrderText.Invoke(orderText);
        NSBLogger.Log(orderText);
    }
}
