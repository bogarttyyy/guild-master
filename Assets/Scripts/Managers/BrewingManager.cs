using System;
using NSBLib.EventChannelSystem;
using NSBLib.Helpers;
using UnityEngine;

public class BrewingManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float beanAmount;
    [SerializeField] private float beanMax = 10f;
    [SerializeField] private float grindAmount;
    [SerializeField] private float grindMax = 100f;
    [SerializeField] private float heatAmount;
    [SerializeField] private float heatMax = 100f;
    [SerializeField] private float pourAmount;
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

    private void Start()
    {
        beanAmount = 0;
        grindAmount = 0;
        heatAmount = 0;
        pourAmount = 0;
    }

    public void ResetAll()
    {
        SetBean(0);
        SetGrind(0);
        SetHeat(0);
        SetPour(0);
    }

    public void SetBean(float value)
    {
        beanAmount = value;
        updateBeanValueText.Invoke(value);
    }
    
    public void SetGrind(float value)
    {
        grindAmount = value;
        updateGrindValueText.Invoke(value);
    }
    
    public void SetHeat(float value)
    {
        heatAmount = value;
        updateHeatValueText.Invoke(value);
    }
    
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
        isGrindingBeans = isPressed;
    }

    public void IsHeadBtnPressed(bool isPressed)
    {
        isHeatingWater = isPressed;
    }

    public void IsPourBtnPressed(bool isPressed)
    {
        isPouringWater = isPressed;
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
