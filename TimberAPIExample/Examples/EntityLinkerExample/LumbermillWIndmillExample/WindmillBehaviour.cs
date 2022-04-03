using Timberborn.PowerGenerating;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample
{
    public class WindmillBehaviour : BaseEntityLinkee<LumbermillWindmillLink, LumbermillBehaviour, WindmillBehaviour>
    {
        private WindPoweredGenerator _windmill;

        public override void OnEnterFinishedState()
        {
            base.OnEnterFinishedState();

            _windmill = GetComponent<WindPoweredGenerator>();
        }

        public override void OnExitFinishedState()
        {
            base.OnExitFinishedState();

            _windmill = null;
        }

        public override void Tick()
        {
            var windmillPower = _windmill.GeneratorStrength;

            foreach (var link in EntityLinks)
            {
                if (windmillPower == 0f)
                {
                    link.Linker.Pause();
                    continue;
                }
                link.Linker.Resume();
            }
        }
    }
}
