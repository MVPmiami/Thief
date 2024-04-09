using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class ThiefMover : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AudioSource _audioSource;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private Animator _animator;
    private readonly int Speed = Animator.StringToHash(nameof(Speed));

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        _animator.SetFloat(Speed, Mathf.Abs(direction));
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * Time.deltaTime * _rotateSpeed * Vector3.up);
    }
}
