using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _money;
    [SerializeField] TextMeshProUGUI _lemons;
    [SerializeField] Supplies _supplies;
    [SerializeField] TMP_InputField _purchaseAmount;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        DisplayCurrentSupplies();
    }

    private void DisplayCurrentSupplies()
    {
        _money.text = _supplies.Money.ToString();
        _lemons.text = _supplies.Lemons.ToString();
    }

    public void PurchaseStock()
    {
        int quantity = int.Parse(_purchaseAmount.text);
        _supplies.Lemons += quantity;
        _supplies.Money -= quantity * _gameManager.LemonCost;
        _supplies.MoneyDecrease += quantity * _gameManager.LemonCost;
        _supplies.LemonIncrease += quantity;
        DisplayCurrentSupplies();
    }
}
