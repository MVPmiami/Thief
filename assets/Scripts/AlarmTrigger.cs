using UnityEngine;

public class AlarmTrriger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Thief _thief;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _thief))
            _alarm.On();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _thief))
            _alarm.Off();
    }
}
