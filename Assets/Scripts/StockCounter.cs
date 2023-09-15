using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StockCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;

    private void Update()
    {
        _counter.text = Supplies.Instance.Lemons.ToString();
    }
}
