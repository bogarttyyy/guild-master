using System;
using Enums;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
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
        NSBLogger.Log($"{cupSize} Coffee");
    }
}
