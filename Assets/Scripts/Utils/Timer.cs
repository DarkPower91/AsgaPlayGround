using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    #region Private objects
    private float _startTime;
    private float _duration;
    private bool _started = false;
    #endregion

    public void Start(float duration = 0f)
    {
        _startTime = Time.time;
        _duration = duration;
        _started = true;
    }

    public float TimePassed() 
    {
        if (_started)
        {
            return Time.time - _startTime;
        } else 
        {
            return 0f;
        }
        
    }

    public bool IsStartedYet() {
        return _started;
    }

    public bool IsElapsed() 
    {
        return TimePassed() > _duration;
    }

    public void Stop()
    {
        _started = false;
        _startTime = 0f;
        _duration = 0f;
    }

    public float GetRemainingTime()
    {
        if (_started && _duration > 0f) 
        {
            return _duration - TimePassed();
        } else 
        {
            return 0f;
        }
    }

    public float GetProgressRatio()
    {
        return MathUtils.GetClampedPercentage(TimePassed(), 0, _duration);
    }
}
