using Enums;
using NSBLib.Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;
    [SerializeField] private TMP_Text orderText;
    [SerializeField] private TMP_Text beanValueText;
    [SerializeField] private TMP_Text grindValueText;
    [SerializeField] private TMP_Text heatValueText;
    [SerializeField] private TMP_Text pourValueText;

    [SerializeField] private Button sCupBtn;
    [SerializeField] private Button mCupBtn;
    [SerializeField] private Button lCupBtn;

    public void UpdateCashText(int cash)
    {
        cashText.text = $"${cash}";
    }

    public void UpdateOrderText(string order)
    {
        orderText.text = $"{order}";
    }

    public void UpdateBeanValueText(float value)
    {
        beanValueText.text = $"{value:F1} g";
    }

    public void UpdateGrindValueText(float value)
    {
        grindValueText.text = $"{value:F0}";
    }

    public void UpdateHeatValueText(float value)
    {
        heatValueText.text = $"{value:F0} c";
    }

    public void UpdatePourValueText(float value)
    {
        pourValueText.text = $"{value:F1} oz";
    }
    
    public void CupSizeSelected(int size)
    {
        switch ((ECupSize)size)
        {
            case ECupSize.Small:
                mCupBtn.interactable = false;
                lCupBtn.interactable = false;
                break;
            case ECupSize.Medium:
                sCupBtn.interactable = false;
                lCupBtn.interactable = false;
                break;
            case ECupSize.Large:
                mCupBtn.interactable = false;
                sCupBtn.interactable = false;
                break;
            default:
                sCupBtn.interactable = true;
                mCupBtn.interactable = true;
                lCupBtn.interactable = true;
                break;
        }
        NSBLogger.Log($"Cup Size Selected: {(ECupSize)size}");
    }
}
