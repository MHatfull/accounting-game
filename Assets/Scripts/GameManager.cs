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
    [SerializeField] private Supplies _supplies;

    public int DailySalary = 15;
    public int DailyRent = 20;
    public int LemonCost = 20;

    public int CurrentDay = 0;

    private void Start()
    {
        StartNextDay();
    }

    public void OpenBusiness()
    {
        CurrentPartOfDay = DayPhase.BusinessTime;
        _inventoryInterface.SetActive(false);
        _businessDayManager.StartBusinessDay();
    }

    public void CloseBusiness()
    {
        CurrentPartOfDay = DayPhase.Summary;
        _supplies.Money -= Rent() + Salary();
        _supplies.MoneyDecrease += Rent() + Salary();
        _summaryInterface.SetActive(true);
    }

    public void StartNextDay()
    {
        CurrentPartOfDay = DayPhase.Summary;
        _supplies.MoneyIncrease = 0;
        _supplies.MoneyDecrease = 0;
        _supplies.LemonIncrease = 0;
        _supplies.LemonDecrease = 0;

        _summaryInterface.SetActive(false);
        _inventoryInterface.SetActive(true);
        CurrentDay++;
    }

    public int Salary()
    {
        if (CurrentDay % 3 == 0)
        {
            return DailySalary * 3;
        }
        return 0;
    }

    public int Rent()
    {
        if (CurrentDay % 6 == 0)
        {
            return DailyRent * 6;
        }
        return 0;
    }
}
