using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FreeAgentReport : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cashIncrease;
    [SerializeField] private TextMeshProUGUI _cashDecrease;
    [SerializeField] private TextMeshProUGUI _cashTotal;
    [SerializeField] private TextMeshProUGUI _stockIncrease;
    [SerializeField] private TextMeshProUGUI _stockDecrease;
    [SerializeField] private TextMeshProUGUI _stockTotal;
    [SerializeField] private TextMeshProUGUI _salaryIncrease;
    [SerializeField] private TextMeshProUGUI _salaryDecrease;
    [SerializeField] private TextMeshProUGUI _salaryTotal;
    [SerializeField] private TextMeshProUGUI _rentIncrease;
    [SerializeField] private TextMeshProUGUI _rentDecrease;
    [SerializeField] private TextMeshProUGUI _rentTotal;
    [SerializeField] private TextMeshProUGUI _grandTotal;
    [SerializeField] private Supplies _supplies;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _cashIncrease.text = _supplies.MoneyIncrease.ToString();
        _cashDecrease.text = _supplies.MoneyDecrease.ToString();
        _cashTotal.text = _supplies.Money.ToString();


        _stockIncrease.text = (_gameManager.LemonCost * _supplies.LemonIncrease).ToString();
        _stockDecrease.text = (_gameManager.LemonCost * _supplies.LemonDecrease).ToString();
        _stockTotal.text = (_supplies.Lemons * _gameManager.LemonCost).ToString();

        _salaryIncrease.text = _gameManager.DailySalary.ToString();
        _salaryDecrease.text = _gameManager.Salary().ToString();
        _salaryTotal.text = ((_gameManager.CurrentDay % 3) * _gameManager.DailySalary).ToString();

        _rentIncrease.text = _gameManager.DailyRent.ToString();
        _rentDecrease.text = _gameManager.Rent().ToString();
        _rentTotal.text = ((_gameManager.CurrentDay % 6) * _gameManager.DailyRent).ToString();

        int grandTotal = _supplies.Money
            + (_supplies.Lemons * _gameManager.LemonCost)
            - (_gameManager.CurrentDay % 3) * _gameManager.DailySalary
            - (_gameManager.CurrentDay % 6) * _gameManager.DailyRent;
        _grandTotal.text = grandTotal.ToString();
    }
}
