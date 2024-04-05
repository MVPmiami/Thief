using UnityEngine;

public class ThiefController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AudioSource _audioSource;

    private string Horizontal;
    private string Vertical;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Horizontal = nameof(Horizontal);
        Vertical = nameof(Vertical);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * Time.deltaTime * _moveSpeed;

        if (direction != 0 && !_audioSource.isPlaying)
            _audioSource.Play();
        else if (direction == 0 && _audioSource.isPlaying)
            _audioSource.Stop();

        transform.Translate(distance * Vector3.forward);
        _animator.SetFloat("speed", Mathf.Abs(direction));
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * Time.deltaTime * _rotateSpeed * Vector3.up);
    }
}
