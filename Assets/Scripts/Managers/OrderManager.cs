using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
        
    }
}
