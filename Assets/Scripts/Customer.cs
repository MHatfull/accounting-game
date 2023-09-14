using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    [SerializeField] private float _animationDuration = 1f;

    private float _startTime;
    private bool _hasPurchased = false;
    private bool _angry = false;

    public void Start()
    {
        Destroy(gameObject, 30);
    }

    public void WalkTo(Vector3 end)
    {
        _startPoint = transform.position;
        _endPoint = end;
        _startTime = Time.time;
    }

    private void Update()
    {
        float t = (Time.time - _startTime) / _animationDuration;
        transform.position = Vector3.Lerp(_startPoint, _endPoint, (Time.time - _startTime) / _animationDuration);
        if (t > 1)
        {
            if (_hasPurchased)
            {
                int multiplier = _angry ? -5 : 5;
                WalkTo(transform.position + multiplier * Vector3.right);
            } else
            {
                if (Supplies.Instance.Lemons > 0)
                {
                    Supplies.Instance.Money += 25;
                    Supplies.Instance.MoneyIncrease += 25;
                    Supplies.Instance.Lemons -= 1;
                    Supplies.Instance.LemonDecrease += 1;
                } else
                {
                    _angry = true;
                }

                WalkTo(transform.position);
                _hasPurchased = true;
            }
        }
    }
    }
