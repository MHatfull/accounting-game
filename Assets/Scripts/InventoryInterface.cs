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
    [SerializeField] TextMeshProUGUI _validationMessage;

    private void OnEnable()
    {
        DisplayCurrentSupplies();
        _validationMessage.text = "";
    }

    private void DisplayCurrentSupplies()
    {
        _money.text = _supplies.Money.ToString();
        _lemons.text = _supplies.Lemons.ToString();
    }

    public void PurchaseStock()
    {
        int quantity = int.Parse(_purchaseAmount.text);
        if (quantity < 0)
        {
            _validationMessage.text = "You can't buy negative lemons!";
            return;
        }
        int cost = quantity * _gameManager.LemonCost;
        if (cost > _supplies.Money)
        {
            _validationMessage.text = "You can't afford that!";
            return;
        }
        _validationMessage.text = "";
        _supplies.Lemons += quantity;
        _supplies.Money -= cost;
        _supplies.MoneyDecrease += cost;
        _supplies.LemonIncrease += quantity;
        DisplayCurrentSupplies();
    }
}
