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
                WalkTo(transform.position + 5 * Vector3.right);
            } else
            {
                WalkTo(transform.position);
                _hasPurchased = true;
            }
        }
    }
    }
