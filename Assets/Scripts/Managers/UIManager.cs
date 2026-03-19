using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;

    public void UpdateCashText(int cash)
    {
        cashText.text = $"${cash}";
    }
}
