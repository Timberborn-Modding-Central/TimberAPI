using Timberborn.AssetSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberbornAPI.AssetLoaderSystem.ResourceAssetPatch
{
    public class TimberApiResourceAssetLoader : IResourceAssetLoader
    {
        private readonly IAssetLoader _assetLoader;

        private Shader _shader;

        private Shader Shader
        {
            get
            {
                if (_shader == null)
                    _shader = Resources.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails").GetComponent<MeshRenderer>().materials[0].shader;
                return _shader;
            }
        }

        public TimberApiResourceAssetLoader(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public T Load<T>(string path) where T : Object
        {
            T item = Resources.Load<T>(path);

            if (item != null)
                return item;

            item = _assetLoader.Load<T>(path);
            if (item is GameObject gameObject)
                FixMaterialShader(gameObject, Shader);

            return item;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        private static void FixMaterialShader(GameObject obj, Shader shader)
        {
            var meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                foreach (Material mat in meshRenderer.materials)
                {
                    mat.shader = shader;
                }
            }

            foreach (Transform child in obj.transform)
            {
                if (child.gameObject)
                {
                    FixMaterialShader(child.gameObject, shader);
                }
            }
        }
    }
}