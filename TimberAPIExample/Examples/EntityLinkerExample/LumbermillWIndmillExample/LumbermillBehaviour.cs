using Timberborn.Buildings;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample
{
    public class LumbermillBehaviour : BaseEntityLinker<LumbermillWindmillLink, WindmillBehaviour, LumbermillBehaviour>
    {

        /// <summary>
        /// Helper method which pauses the building if it isn't already paused
        /// </summary>
        public void Pause()
        {
            var pausableComponent = GetComponent<PausableBuilding>();
            if (!pausableComponent.Paused)
            {
                pausableComponent.Pause();
            }
        }

        /// <summary>
        /// Helper method which resumes the building if not already resumed
        /// </summary>
        public void Resume()
        {
            var pausableComponent = GetComponent<PausableBuilding>();
            if (pausableComponent.Paused)
            {
                pausableComponent.Resume();
            }
        }
    }
}
