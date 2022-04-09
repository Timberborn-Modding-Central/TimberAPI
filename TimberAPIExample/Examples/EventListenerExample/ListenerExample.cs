using System;
using Timberborn.FactionSystem;
using Timberborn.SingletonSystem;
using Timberborn.TimeSystem;
using Timberborn.ToolSystem;
using Timberborn.WeatherSystem;
using TimberbornAPI.EventSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EventListenerExample
{
    /**
    * Example listener class. Can listen to any event with [OnEvent]
    * It automatically registers, but must be bound with an IConfigurator
    * This is not comprehensive of all events, but you can use it with any.
    */
    public class ExampleListener : EventListener
    {
        [OnEvent]
        public void OnToolGroupEntered(ToolGroupEnteredEvent toolGroupEnteredEvent)
        {
            if (toolGroupEnteredEvent.ToolGroup != null)
            {
                Debug.Log("Tool Group: " + toolGroupEnteredEvent.ToolGroup.DisplayNameLocKey);
            }
        }

        [OnEvent]
        public void OnToolEntered(ToolEnteredEvent toolEnteredEvent)
        {
            Debug.Log("ToolEnteredEvent");
        }

        [OnEvent]
        public void OnNighttimeStartEvent(NighttimeStartEvent nighttimeStartEvent)
        {
            Debug.Log("NighttimeStartEvent");
        }

        [OnEvent]
        public void OnDaytimeStartEvent(DaytimeStartEvent daytimeStartEvent)
        {
            Debug.Log("DaytimeStartEvent");
        }

        [OnEvent]
        public void OnFactionUnlocked(FactionUnlockedEvent factionUnlockedEvent)
        {
            Debug.Log("FactionUnlockedEvent");
        }

        [OnEvent]
        public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent)
        {
            Debug.Log("DroughtStartedEvent");
        }

        [OnEvent]
        public void OnDroughtEnded(DroughtEndedEvent droughtEndedEvent)
        {
            Debug.Log("DroughtEndedEvent");
        }
    }
}

