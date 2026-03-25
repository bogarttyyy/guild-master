using System;
using Enums;
using NSBLib.EventChannelSystem;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrewingManager : MonoBehaviour
{
    [Header("Coffee")]
    [SerializeField] private ECupSize selectedCupSize;
    [SerializeField] private float beanAmount;
    [SerializeField] private float grindAmount;
    [SerializeField] private float heatAmount;
    [SerializeField] private float pourAmount;
    
    [Header("Values")]
    [SerializeField] private float beanMax = 10f;
    [SerializeField] private float grindMax = 100f;
    [SerializeField] private float heatMax = 100f;
    [SerializeField] private float pourMax = 12f;
    
    [Header("Rate")]
    [SerializeField] private float beanAmountPerSecond;
    [SerializeField] private float grindAmountPerSecond;
    [SerializeField] private float heatAmountPerSecond;
    [SerializeField] private float coolingAmountPerSecond;
    [SerializeField] private float pourAmountPerSecond;

    [Header("Active")]
    [SerializeField] private bool isGettingBeans;
    [SerializeField] private bool isGrindingBeans;
    [SerializeField] private bool isHeatingWater;
    [SerializeField] private bool isPouringWater;
    
    [Header("Events")]
    [SerializeField] private EventChannel<float> updateBeanValueText;
    [SerializeField] private EventChannel<float> updateGrindValueText;
    [SerializeField] private EventChannel<float> updateHeatValueText;
    [SerializeField] private EventChannel<float> updatePourValueText;
    
    [SerializeField] private EventChannel resetCupSelection;
    [SerializeField] private EventChannel resetUI;
    [SerializeField] private EventChannel<string> disableBtn;

    private void Start()
    {
        beanAmount = 0;
        grindAmount = 0;
        heatAmount = 0;
        pourAmount = 0;
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            ResetCup();
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SetBean(0);
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SetGrind(0);
            // SetHeat(0);
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            SetPour(0);
    }

    private void ResetCup()
    {
        selectedCupSize = ECupSize.None;
        resetCupSelection.Invoke(new Empty());
    }

    public void SelectCupSize(int size)
    {
        selectedCupSize = (ECupSize)size;
    }

    public void ResetAll()
    {
        SetBean(0);
        SetGrind(0);
        SetHeat(0);
        SetPour(0);
        ResetCup();
        resetUI.Invoke(new Empty());
    }

    /// <summary>
    /// Set the amount of beans in the cup. S = 8g, M = 12g, L = 16g
    /// </summary>
    /// <param name="value"></param>
    public void SetBean(float value)
    {
        beanAmount = value;
        updateBeanValueText.Invoke(value);
    }
    
    /// <summary>
    /// Grind beans from coarse to extra fine.
    /// </summary>
    /// <param name="value"></param>
    public void SetGrind(float value)
    {
        grindAmount = value;
        updateGrindValueText.Invoke(value);
    }
    
    /// <summary>
    /// Heat water to boil.
    /// </summary>
    /// <param name="value"></param>
    public void SetHeat(float value)
    {
        heatAmount = value;
        updateHeatValueText.Invoke(value);
    }
    
    /// <summary>
    /// Pour water depending on the cup size.
    /// </summary>
    /// <param name="value"></param>
    public void SetPour(float value)
    {
        pourAmount = value;
        updatePourValueText.Invoke(value);
    }

    public void IsBeansBtnPressed(bool isPressed)
    {
        isGettingBeans = isPressed;
    }

    public void IsGrindBtnPressed(bool isPressed)
    {
        if (beanAmount > 0)
        {
            // SetBean(0);
            isGrindingBeans = isPressed;
            disableBtn.Invoke("beanBtn");
        }
        else
        {
            NSBLogger.Log("Must have beans to grind!");
        }
    }

    public void IsHeadBtnPressed(bool isPressed)
    {
        isHeatingWater = isPressed;
    }

    public void IsPourBtnPressed(bool isPressed)
    {
        if (grindAmount > 0)
        {
            disableBtn.Invoke("grindBtn");
            isPouringWater = isPressed;
        }
        else
        {
            NSBLogger.Log("Must have ground beans to pour!");
        }
    }

    private void FixedUpdate()
    {
        AddBeans();
        GrindBeans();
        HeatWater();
        PourWater();
    }

    private void PourWater()
    {
        if (isPouringWater && pourAmount < pourMax)
        {
            pourAmount += pourAmountPerSecond * Time.deltaTime;
        }
        updatePourValueText?.Invoke(pourAmount);
    }

    private void HeatWater()
    {
        if (isHeatingWater && heatAmount < heatMax)
        {
            heatAmount += heatAmountPerSecond * Time.deltaTime;
        }
        else if (heatAmount > 37f)
        {
            heatAmount -= coolingAmountPerSecond * Time.deltaTime;
        }
        updateHeatValueText?.Invoke(heatAmount);
    }

    private void AddBeans()
    {
        if (isGettingBeans && beanAmount < beanMax)
        {
            beanAmount += beanAmountPerSecond * Time.deltaTime;
        }
        updateBeanValueText?.Invoke(beanAmount);
    }

    private void GrindBeans()
    {
        if (isGrindingBeans && grindAmount < grindMax)
        {
            grindAmount += grindAmountPerSecond * Time.deltaTime;
        }
        updateGrindValueText?.Invoke(grindAmount);
    }
}
