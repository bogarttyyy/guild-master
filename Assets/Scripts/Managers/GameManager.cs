using NSBLib.EventChannelSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int cash = 0;
    [SerializeField] private int customerCount = 0;

    [SerializeField] private EventChannel reset;
    [SerializeField] private EventChannel<int> updateCashText;
    [SerializeField] private EventChannel<int> UpdateCustomerCount;
    [SerializeField] private EventChannel takeOrder;
    
    private void Start()
    {
        updateCashText.Invoke(cash);
        UpdateCustomerCount.Invoke(customerCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            reset.Invoke(new Empty());
        }
    }

    public void AddCash(int amount)
    {
        cash += amount;
        updateCashText.Invoke(cash);
    }

    public void AddCustomer()
    {
        customerCount++;
        UpdateCustomerCount.Invoke(customerCount);
    }
    
    public void TakeOrder()
    {
        if (customerCount > 0)
        {
            customerCount--;
            UpdateCustomerCount.Invoke(customerCount);
            takeOrder.Invoke(new Empty());
        }
    }
}
