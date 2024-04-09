using UnityEngine;

public class AlarmTrriger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Thief _thief;

    private bool _hasThief;
    private bool _isActive;

    private void Start()
    {
        _hasThief = false;
        _isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _thief))
            _hasThief = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _thief))
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
