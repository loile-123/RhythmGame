using UnityEngine;

public class ChartPlaybackClock : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("State")]
    [SerializeField] private bool playOnStart = true;

    private float _startTime;
    private float _pausedSongTime;
    private bool _isPlaying;

    public float SongTime
    {
        get
        {
            if (audioSource != null)
            {
                return audioSource.time;
            }

            if (!_isPlaying)
            {
                return _pausedSongTime;
            }

            return Time.time - _startTime;
        }
    }

    public bool IsPlaying => _isPlaying;

    private void Start()
    {
        if (playOnStart)
        {
            Play();
        }
    }

    public void Play()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        _startTime = Time.time - _pausedSongTime;
        _isPlaying = true;
    }

    public void Pause()
    {
        _pausedSongTime = SongTime;
        _isPlaying = false;

        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void Stop()
    {
        _pausedSongTime = 0f;
        _isPlaying = false;

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}