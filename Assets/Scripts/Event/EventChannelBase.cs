using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChannelBase : DescriptionBase
{
}

public abstract class EventChannel : EventChannelBase
{
    private UnityAction _onEventRaised;
    public void RegisterListener(UnityAction action)
    {
        _onEventRaised += action;
    }
    public void UnregisterListener(UnityAction action)
    {
        _onEventRaised -= action;
    }
    public void RaiseEvent()
    {
        _onEventRaised?.Invoke();
    }
}
public abstract class EventChannelBase<T> : EventChannelBase
{
    private UnityAction<T> _onEventRaised;
    public void RegisterListener(UnityAction<T> action)
    {
        _onEventRaised += action;
    }
    public void UnregisterListener(UnityAction<T> action)
    {
        _onEventRaised -= action;
    }
    public void RaiseEvent(T arg1)
    {
        _onEventRaised?.Invoke(arg1);
    }
}
public abstract class EventChannelBase<T1,T2> : EventChannelBase
{
}