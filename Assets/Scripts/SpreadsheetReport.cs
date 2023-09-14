using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Report : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cash;
    [SerializeField] private TextMeshProUGUI _stock;
    [SerializeField] private TextMeshProUGUI _salaryText;
    [SerializeField] private GameObject _salaryContainer;
    [SerializeField] private TextMeshProUGUI _rentText;
    [SerializeField] private GameObject _rentContainer;
    [SerializeField] private Supplies _supplies;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _cash.text = _supplies.Money.ToString();
        _stock.text = _supplies.Lemons.ToString();
        if (Salary() == 0)
        {
            _salaryContainer.SetActive(false);
        } else
        {
            _salaryContainer.SetActive(true);
            _salaryText.text = Salary().ToString();
        }

        if (Rent() == 0)
        {
            _rentContainer.SetActive(false);
        }
        else
        {
            _rentContainer.SetActive(true);
            _rentText.text = Rent().ToString();
        }
    }

    private int Salary()
    {
        if(_gameManager.CurrentDay % 3 == 0)
        {
            return _gameManager.DailySalary * 3;
        }
        return 0;
    }

    private int Rent()
    {
        if (_gameManager.CurrentDay % 6 == 0)
        {
            return _gameManager.DailyRent * 6;
        }
        return 0;
    }
}
