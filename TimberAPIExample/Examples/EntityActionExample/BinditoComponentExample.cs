using System;
using Bindito.Core;
using Timberborn.Localization;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class BinditoComponentExample : MonoBehaviour
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
    }
}