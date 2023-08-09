using UnityEngine;



public class Timer
{
    private float _initialSeconds;
    private float _secondsRemaining;
    private bool _timerRunning;
    private bool _timerComplete;

    
    public Timer(float seconds)
    {
        _initialSeconds = _secondsRemaining = seconds;
        _timerRunning = false;
        _timerComplete = false;
    }

    public Timer()
    {
        _timerRunning = false;
        _timerComplete = false;
    }
    
    // Start is called before the first frame update
    public void Start()
    {
        _timerRunning = false;
        _timerComplete = false;
    }

    // Update is called once per frame
    public void Update(float unscaledDeltaTime)
    {
        if (_timerRunning && _secondsRemaining > 0f)
        {
            _secondsRemaining -= unscaledDeltaTime;
        } else if (_timerRunning)
        {
            _timerRunning = false;
            _timerComplete = true;
        }
    }

    public void SetTimer(float seconds)
    {
        _initialSeconds = _secondsRemaining = seconds;
    }
    
    public void StartTimer()
    {
        if (!_timerComplete)
        {
            _timerRunning = true;
        }
        else
        {
            Debug.Log("Can't start a completed timer! You must use ResetTimer() first.");
        }
    }

    
    public void StopTimer()
    {
        _timerRunning = false;
    }

    public void PauseTimer()
    {
        StopTimer();
    }

    public void ResetTimer()
    {
        _timerRunning = false;
        _timerComplete = false;
        _secondsRemaining = _initialSeconds;
    }

    public bool IsRunning()
    {
        return _timerRunning;
    }

    public bool IsComplete()
    {
        return _timerComplete;
    }

    public float GetSecondsRemaining()
    {
        return _secondsRemaining;
    }

    public float GetTotalTime()
    {
        return _initialSeconds;
    }
}
