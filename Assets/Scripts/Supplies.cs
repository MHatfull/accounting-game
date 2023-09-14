using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour
{
    public int Money = 250;
    public int MoneyIncrease = 0;
    public int MoneyDecrease = 0;
    public int Lemons = 0;
    public int LemonIncrease = 0;
    public int LemonDecrease = 0;

    public static Supplies Instance;

    private void Awake()
    {
        Instance = this;
    }
}
