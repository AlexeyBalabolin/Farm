using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Infrastructure.Services
{
    public class EventBus : IService
    {
        private Dictionary<string, UnityEvent> m_EventDictionary;

        public UnityAction<string> OnTriggerEvent;

        public EventBus()
        {
            m_EventDictionary = new Dictionary<string, UnityEvent>();
            OnTriggerEvent += TriggerEvent;
        }

        public void StartListening(string eventName, UnityEvent listener)
        {
            m_EventDictionary.Add(eventName, listener);
        }

        public void StopListening(string eventName)
        {
            m_EventDictionary.Remove(eventName);
        }

        public void TriggerEvent(string eventName)
        {
            UnityEvent thisEvent = null;
            if (m_EventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent?.Invoke();
            }
        }

    }
}

