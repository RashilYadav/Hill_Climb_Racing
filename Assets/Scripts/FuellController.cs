using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuellController : MonoBehaviour
{
    public static FuellController instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;

    private float _currenFuelAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currenFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        _currenFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();

        if(_currenFuelAmount <= 0f)
        {
            GameManager.instance.GameOver();
        }
    }

    private void UpdateUI()
    {
        _fuelImage.fillAmount = (_currenFuelAmount / _maxFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }

    public void FillFuel()
    {
        _currenFuelAmount = _maxFuelAmount;
        UpdateUI();
    }
}
