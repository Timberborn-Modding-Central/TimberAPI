using System;
using Bindito.Core;
using Timberborn.ConstructibleSystem;
using Timberborn.Goods;
using Timberborn.InventorySystem;
using Timberborn.Localization;
using Timberborn.Warehouses;
using TimberbornAPI.Internal;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class BinditoInjectComponentExample : MonoBehaviour
    {
        private ILoc _loc;
        
        [Inject]
        public void InjectDependencies(ILoc loc)
        {
            this._loc = loc;
        }

        private void Start()
        {
            Console.WriteLine(_loc.T("preview.bindito.start"));
        }
    }
}