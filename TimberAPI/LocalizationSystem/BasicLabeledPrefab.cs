using System;
using Timberborn.EntitySystem;

namespace TimberbornAPI.LocalizationSystem
{
    public class BasicLabeledPrefab : LabeledPrefab
    {
        private string GetPrefabName()
        {
            return GetComponent<Prefab>().PrefabName;
        }

        public string displayNameText;
        public string descriptionText;
        public string flavorText;

        void OnValidate()
        {
            DisplayNameLocKey = $"{GetPrefabName()}.DisplayName";
            DescriptionLocKey = $"{GetPrefabName()}.Description";
            FlavorDescriptionLocKey = $"{GetPrefabName()}.Flavor";
        }
    }
}

