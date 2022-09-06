using System;
using UnityEngine;

namespace TimberApi.Common.Helpers
{
    public class PrefabBuilder
    {
        private readonly GameObject _root;

        public PrefabBuilder(string name)
        {
            _root = new GameObject(name);
        }

        /// <summary>
        /// Creates a prefabBuilder with a empty gameObject
        /// </summary>
        public static PrefabBuilder Create(string name)
        {
            return new PrefabBuilder(name);
        }

        /// <summary>
        /// Creates a builder with a starting component added
        /// </summary>
        public static PrefabBuilder Create<TComponent>(string name) where TComponent : Component
        {
            PrefabBuilder prefabBuilder = Create(name);
            prefabBuilder.AddComponent<TComponent>();
            return prefabBuilder;
        }

        /// <summary>
        /// Adding component to gameObject
        /// </summary>
        public PrefabBuilder AddComponent<TComponent>() where TComponent : Component
        {
            _root.AddComponent<TComponent>();
            return this;
        }

        /// <summary>
        /// Creates a builder that will added to the main prefab
        /// </summary>
        public PrefabBuilder AddGameObject(string name, Action<PrefabBuilder> gameObjectBuilder)
        {
            var prefabBuilder = new PrefabBuilder(name);
            gameObjectBuilder(prefabBuilder);
            GameObject gameObject = prefabBuilder.Build();
            gameObject.transform.parent = _root.transform;
            return this;
        }

        /// <summary>
        /// Creates a builder with a starting component that will added to the main prefab
        /// </summary>
        public PrefabBuilder AddGameObject<TComponent>(string name, Action<PrefabBuilder> gameObjectBuilder) where TComponent : Component
        {
            PrefabBuilder prefabBuilder = AddGameObject(name, gameObjectBuilder);
            prefabBuilder.AddComponent<TComponent>();
            return this;
        }

        /// <summary>
        /// Adds a gameObject with a single component added to the main prefab
        /// </summary>
        public PrefabBuilder AddGameObject<TComponent>(string name) where TComponent : Component
        {
            Create<TComponent>(name).FinishAndSetParent(_root);
            return this;
        }

        /// <summary>
        /// Adds a gameObject with a single component added to the main prefab
        /// </summary>
        public GameObject Build()
        {
            return _root;
        }

        /// <summary>
        /// Adds gameObject to parent
        /// </summary>
        public void FinishAndSetParent(GameObject parent)
        {
            _root.transform.parent = parent.transform;
        }
    }
}