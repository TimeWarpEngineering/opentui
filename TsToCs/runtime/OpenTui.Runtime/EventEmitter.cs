namespace OpenTui.Runtime;

public class EventEmitter
{
    private readonly Dictionary<string, List<Delegate>> _listeners = new();
    private readonly Dictionary<string, List<Delegate>> _onceListeners = new();

    public void On(string eventName, Delegate listener)
    {
        if (!_listeners.TryGetValue(eventName, out var list))
        {
            list = new List<Delegate>();
            _listeners[eventName] = list;
        }
        list.Add(listener);
    }

    public void Once(string eventName, Delegate listener)
    {
        if (!_onceListeners.TryGetValue(eventName, out var list))
        {
            list = new List<Delegate>();
            _onceListeners[eventName] = list;
        }
        list.Add(listener);
    }

    public void Off(string eventName, Delegate listener)
    {
        if (_listeners.TryGetValue(eventName, out var list))
            list.Remove(listener);
        if (_onceListeners.TryGetValue(eventName, out var onceList))
            onceList.Remove(listener);
    }

    public void RemoveAllListeners(string? eventName = null)
    {
        if (eventName is null)
        {
            _listeners.Clear();
            _onceListeners.Clear();
        }
        else
        {
            _listeners.Remove(eventName);
            _onceListeners.Remove(eventName);
        }
    }

    public void Emit(string eventName, params object[] args)
    {
        if (_listeners.TryGetValue(eventName, out var list))
        {
            foreach (var listener in list.ToArray())
            {
                listener.DynamicInvoke(args);
            }
        }

        if (_onceListeners.TryGetValue(eventName, out var onceList))
        {
            var snapshot = onceList.ToArray();
            onceList.Clear();
            foreach (var listener in snapshot)
            {
                listener.DynamicInvoke(args);
            }
        }
    }

    public int ListenerCount(string eventName)
    {
        int count = 0;
        if (_listeners.TryGetValue(eventName, out var list))
            count += list.Count;
        if (_onceListeners.TryGetValue(eventName, out var onceList))
            count += onceList.Count;
        return count;
    }
}
