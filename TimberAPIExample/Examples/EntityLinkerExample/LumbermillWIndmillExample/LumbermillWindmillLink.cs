using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample
{
    public class LumbermillWindmillLink : BaseEntityLink<LumbermillBehaviour, WindmillBehaviour>
    {
        public LumbermillWindmillLink(LumbermillBehaviour linker, WindmillBehaviour linkee) 
            : base(linker, linkee)
        {
        }
    }
}
