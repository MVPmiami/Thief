using UnityEngine;

public class AlarmTrriger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _hasThief;
    private bool _isActive;

    private void Start()
    {
        _hasThief = false;
        _isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
            _hasThief = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
            _hasThief = false;
    }

    private void Update()
    {
        if (_isActive && _hasThief)
            return;

        if (!_isActive && !_hasThief)
            return;

        if (!_isActive && _hasThief)
        {
            _alarm.On();
            _isActive = true;
        }

        if (_isActive && !_hasThief)
        {
            _alarm.Off();
            _isActive = false;
        }
    }
}
