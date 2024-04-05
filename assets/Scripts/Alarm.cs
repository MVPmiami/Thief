using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _fadeCoroutine;

    public void On()
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeInAlarm(3f));
    }

    public void Off()
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeOutAlarm(3f));
    }

    private IEnumerator FadeInAlarm(float duration)
    {
        float startVolume = 0f;
        float timer = 0f;

        _audioSource.volume = startVolume;
        _audioSource.Play();

        while (timer < duration)
        {
            _audioSource.volume = Mathf.MoveTowards(startVolume, 1f, timer / duration);
            timer += Time.deltaTime;

            yield return null;
        }

        _audioSource.volume = 1f;
    }

    private IEnumerator FadeOutAlarm(float duration)
    {
        float startVolume = 1f;
        float timer = 0f;

        _audioSource.volume = startVolume;

        while (timer < duration)
        {
            _audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / duration);
            timer += Time.deltaTime;

            yield return null;
        }

        _audioSource.volume = 0f;
        _audioSource.Stop();
    }
}

