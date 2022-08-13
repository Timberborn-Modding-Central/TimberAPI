using Timberborn.FactionSystem;
using Timberborn.SingletonSystem;
using Timberborn.TimeSystem;
using Timberborn.ToolSystem;
using Timberborn.WeatherSystem;
using TimberbornAPI.EventSystem;
using static TimberAPIExample.TimberAPIExamplePlugin;

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
                Log.LogInfo("Tool Group: " + toolGroupEnteredEvent.ToolGroup.DisplayNameLocKey);
            }
        }

        [OnEvent]
        public void OnToolEntered(ToolEnteredEvent toolEnteredEvent)
        {
            Log.LogInfo("ToolEnteredEvent");
        }

        [OnEvent]
        public void OnNighttimeStartEvent(NighttimeStartEvent nighttimeStartEvent)
        {
            Log.LogInfo("NighttimeStartEvent");
        }

        [OnEvent]
        public void OnDaytimeStartEvent(DaytimeStartEvent daytimeStartEvent)
        {
            Log.LogInfo("DaytimeStartEvent");
        }

        [OnEvent]
        public void OnFactionUnlocked(FactionUnlockedEvent factionUnlockedEvent)
        {
            Log.LogInfo("FactionUnlockedEvent");
        }

        [OnEvent]
        public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent)
        {
            Log.LogInfo("DroughtStartedEvent");
        }

        [OnEvent]
        public void OnDroughtEnded(DroughtEndedEvent droughtEndedEvent)
        {
            Log.LogInfo("DroughtEndedEvent");
        }
    }
}

