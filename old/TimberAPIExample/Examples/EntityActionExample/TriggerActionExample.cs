using Timberborn.EnterableSystem;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class TriggerActionExample : IEntityAction
    {
        // We can use this to modify any existing entity, including changing behavior of MonoBehaviours
        public void ApplyToEntity(GameObject entity)
        {
            // Receives the RangeEnterableHighlighter component
            RangeEnterableHighlighter highlighter = entity.GetComponent<RangeEnterableHighlighter>();
            if (highlighter == null)
                return;
            // Changes the color of the Monument building heighlight to yellow
            highlighter._colors._buildingInRange = Color.yellow;
        }
    }
}