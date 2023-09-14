using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayPhase { Inventory, BusinessTime, Summary}

public class GameManager : MonoBehaviour
{
    public DayPhase CurrentPartOfDay = DayPhase.Inventory;

    [SerializeField] private GameObject _inventoryInterface;
    [SerializeField] private GameObject _summaryInterface;
    [SerializeField] private BusinessDayManager _businessDayManager;

    public void OpenBusiness()
    {
        CurrentPartOfDay = DayPhase.BusinessTime;
        _inventoryInterface.SetActive(false);
        _businessDayManager.StartBusinessDay();
    }

    public void CloseBusiness()
    {
        CurrentPartOfDay = DayPhase.Summary;
        _summaryInterface.SetActive(true);
    }

    public void StartNextDay()
    {
        CurrentPartOfDay = DayPhase.Summary;
        _summaryInterface.SetActive(false);
        _inventoryInterface.SetActive(true);
    }
}
