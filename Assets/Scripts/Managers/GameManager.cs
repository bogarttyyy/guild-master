using NSBLib.EventChannelSystem;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int cash = 0;

    [SerializeField] private EventChannel<int> updateCashText;
    
    private void Start()
    {
        updateCashText.Invoke(cash);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            NSBLogger.Log("R was pressed");
        }
    }

    public void AddCash(int amount)
    {
        cash += amount;
        updateCashText.Invoke(cash);
    }
}
