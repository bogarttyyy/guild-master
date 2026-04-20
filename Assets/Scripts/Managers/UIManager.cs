using Enums;
using NSBLib.Helpers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;
    [SerializeField] private TMP_Text orderText;
    [SerializeField] private TMP_Text orderListText;
    [SerializeField] private TMP_Text beanValueText;
    [SerializeField] private TMP_Text grindValueText;
    [SerializeField] private TMP_Text heatValueText;
    [SerializeField] private TMP_Text pourValueText;
    [SerializeField] private TMP_Text waterValueText;
    [SerializeField] private TMP_Text funnelValueText;
    [SerializeField] private TMP_Text cupSizeText;
    [SerializeField] private TMP_Text icedText;
    [SerializeField] private TMP_Text drinkText;
    [SerializeField] private TMP_Text customerCountText;

    [SerializeField] private Button sCupBtn;
    [SerializeField] private Button mCupBtn;
    [SerializeField] private Button lCupBtn;

    [SerializeField] private Button coffeeBtn;
    [SerializeField] private Button teaBtn;
    [SerializeField] private Button beanBtn;
    [SerializeField] private Button grindBtn;

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

    public void UpdateWaterValueText(float value)
    {
        waterValueText.text = $"{value:F1} oz";
    }

    public void UpdateFunnelValueText(float value)
    {
        funnelValueText.text = $"{value:F1}";
    }

    public void UpdateOrderListText(string orderList)
    {
        orderListText.text = $"{orderList}";
    }

    public void UpdateCupSizeText(string cupSize)
    {
        cupSizeText.text = $"Cup: {cupSize}";
    }

    public void UpdateIcedText(string iced)
    {
        icedText.text = $"Iced?: {iced}";
    }

    public void UpdateDrinkText(string value)
    {
        drinkText.text = $"Drink: {value}";
    }

    public void UpdateCustomerCountText(int customerCount)
    {
        customerCountText.text = $"Customers: {customerCount}";
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

    public void DrinkSelected(int size)
    {
        switch ((EDrinkType)size)
        {
            case EDrinkType.Coffee:
                teaBtn.interactable = false;
                break;
            case EDrinkType.Tea:
                coffeeBtn.interactable = false;
                break;
            default:
                coffeeBtn.interactable = true;
                teaBtn.interactable = true;
                break;
        }
    }

    public void DisableButton(string btnId)
    {
        switch (btnId)
        {
            case "beanBtn":
                beanBtn.interactable = false;
                break;
            case "grindBtn":
                grindBtn.interactable = false;
                break;
        }
    }
    
    public void ResetUI()
    {
        UpdateOrderText("");
        beanBtn.interactable = true;
        sCupBtn.interactable = true;
        mCupBtn.interactable = true;
        lCupBtn.interactable = true;
        coffeeBtn.interactable = true;
        teaBtn.interactable = true;
    }
}
