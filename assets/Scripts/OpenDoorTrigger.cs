using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private DoorOpener _doorOpener;

    private bool _hasOpener;
    private bool _isOpened;

    private void Start()
    {
        _hasOpener = false;
        _isOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _doorOpener))
            _hasOpener = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _doorOpener))
            _hasOpener = false;
    }

    private void Update()
    {
        if (_isOpened)
        {
            if (_hasOpener && Input.GetKeyDown(KeyCode.E))
            {
                _door.Close();
                _isOpened = false;
            }
        }
        else
        {
            if (_hasOpener && Input.GetKeyDown(KeyCode.E))
            {
                _door.Open();
                _isOpened = true;
            }
        }
    }
}