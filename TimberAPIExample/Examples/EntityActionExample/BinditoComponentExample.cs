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
    public class BinditoComponentExample : MonoBehaviour, IUnfinishedStateListener
    {
        private ILoc _loc;
        
        [Inject]
        public void InjectDependencies(ILoc loc)
        {
            this._loc = loc;
        }

        private void Start()
        {
            Console.WriteLine(_loc.T("menu.continue"));
        }

        public void OnEnterUnfinishedState()
        {
            
        }

        public void OnExitUnfinishedState()
        {
            if (gameObject.TryGetComponent(out Stockpile stockpile) && gameObject.TryGetComponent(out ToggleableGoodDisallower disallower))
            {
                foreach (StorableGoodAmount good in stockpile.Inventory.AllowedGoods)
                {
                    disallower.Disallow(good.StorableGood.GoodSpecification);
                    TimberAPIPlugin.Log.LogFatal(good.StorableGood.GoodSpecification.name);
                }
            }
        }
    }
}