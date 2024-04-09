using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _alarmCoroutine;

    public void On()
    {
        _alarmCoroutine = StartCoroutine(ChangeAlarmVolume(true));
    }

    public void Off()
    {
        _alarmCoroutine = StartCoroutine(ChangeAlarmVolume(false));
    }

    private IEnumerator ChangeAlarmVolume(bool isVolumeUp)
    {
        float minVolume = 0f;
        float maxVolume = 1f;
        float timer = 0f;
        float duration = 3f;

        if (_alarmCoroutine != null)
            StopCoroutine(_alarmCoroutine);

        _audioSource.volume = isVolumeUp ? minVolume : maxVolume;

        if (isVolumeUp)
            _audioSource.Play();

        while (timer < duration)
        {
            _audioSource.volume = Mathf.MoveTowards(isVolumeUp ? minVolume : maxVolume, isVolumeUp ? maxVolume : minVolume, timer / duration);
            timer += Time.deltaTime;

            yield return null;
        }

        if (!isVolumeUp)
            _audioSource.Stop();
    }
}

