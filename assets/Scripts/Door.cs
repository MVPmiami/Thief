using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int OpenTrigger = Animator.StringToHash("Open");
    private readonly int CloseTrigger = Animator.StringToHash("Close");

    public void Open()
    {
        _animator.SetTrigger(OpenTrigger);
    }

    public void Close()
    {
        _animator.SetTrigger(CloseTrigger);
    }
}