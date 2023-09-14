using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessDayManager : MonoBehaviour
{
    [SerializeField] private float _dayDuration = 20f;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Customer _customerPrefab;
    [SerializeField] private Transform _customerSpawn;
    [SerializeField] private Transform _checkout;

    public void StartBusinessDay()
    {
        StartCoroutine(StartTimer());
        for(int i = 0; i < 5; i++)
        {
            StartCoroutine(SpawnCustomerDelayed(Random.Range(0f, _dayDuration - 1.5f)));
        }
    }

    private void SpawnCustomer()
    {
        Customer newCustomer = Instantiate(_customerPrefab, _customerSpawn.position, Quaternion.identity);
        newCustomer.WalkTo(_checkout.position);
    }

    public IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(_dayDuration);
        _gameManager.CloseBusiness();
    }

    public IEnumerator SpawnCustomerDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnCustomer();
    }
}
