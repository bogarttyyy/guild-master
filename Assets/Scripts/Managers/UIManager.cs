using NSBLib.Helpers;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;
    [SerializeField] private TMP_Text beanValueText;
    [SerializeField] private TMP_Text grindValueText;
    [SerializeField] private TMP_Text heatValueText;
    [SerializeField] private TMP_Text pourValueText;

    public void UpdateCashText(int cash)
    {
        cashText.text = $"${cash}";
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
}
