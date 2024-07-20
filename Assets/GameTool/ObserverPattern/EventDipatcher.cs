using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class EventDispatcher : MonoBehaviour
{
    private static EventDispatcher instance;

    public static EventDispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<EventDispatcher>();
                singletonObject.name = "EventDispatcher (Singleton)";
            }

            return instance;
        }
    }
    private void Awake()
    {
        // Nếu trên Scene có 1 GameObject khác cũng tên là EventDispatcher (Singleton) mà khác InstanceID thì huỷ
        // cái đó đi chỉ giữ lại 1 thể hiện thôi, còn trùng ID thì gán thành instance
        if (instance != null && instance.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private Dictionary<EventID, Action<Object>> eventManager = new Dictionary<EventID, Action<object>>();

    public void AddListener(EventID eventID, Action<Object> callback)
    {
        if (eventManager.ContainsKey(eventID))
            eventManager[eventID] += callback;
        else
        {
            eventManager.Add(eventID, null);
            eventManager[eventID] += callback;
        }
    }

    public void RemoveListener(EventID eventID, Action<Object> callback)
    {
        if (eventManager.ContainsKey(eventID))
            eventManager[eventID] -= callback;
        else
        {
            Debug.Log("Do not contain eventID");
        }
    }

    public void PostEvent(EventID eventID, Object param = null)
    {
        if (eventManager.ContainsKey(eventID))
        {
            var callback = eventManager[eventID];
            if (callback == null)
                Debug.Log("Have event but do not have action");
            else callback(param);
        }
        else
        {
            Debug.Log("Do not have evenID");
        }
    }
}

public static class EventDispatcherExtention
{
    public static void AddListener(this MonoBehaviour listener, EventID eventID, Action<Object> callback)
    {
        EventDispatcher.Instance.AddListener(eventID, callback);
    }

    public static void RemoveListener(this MonoBehaviour listener, EventID eventID, Action<Object> callback)
    {
        EventDispatcher.Instance.RemoveListener(eventID, callback);
    }

    public static void PostEvent(this MonoBehaviour sender, EventID eventID, Object param)
    {
        EventDispatcher.Instance.PostEvent(eventID, param);
    }
}
