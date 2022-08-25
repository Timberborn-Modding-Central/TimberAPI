using Timberborn.AssetSystem;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Internal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberbornAPI.AssetLoaderSystem.ResourceAssetPatch
{
    public class TimberApiResourceAssetLoader : IResourceAssetLoader
    {
        private readonly IAssetLoader _assetLoader;

        private static Shader _buidlingShader;
        private static Shader _dirtShader;
        private static Shader _pathShader;

        private enum RenderQueueType
        {
            Dirt = 2999,
            Path = 2998
        }
        
        private static Shader GetShader(Material mat)
        {
           
            if (_buidlingShader == null)
                _buidlingShader = Resources.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails").GetComponent<MeshRenderer>().materials[0].shader;
            if (_dirtShader == null)
                _dirtShader = Resources.Load<GameObject>("Buildings/Wellbeing/Carousel/CarouselConstructionSite5x5+3x1Dirt").GetComponentsInChildren<MeshRenderer>()[1].materials[0].shader;
            if (_pathShader == null)
                _pathShader = Resources.Load<GameObject>("Buildings/Paths/Path/DirtDrivewayStraightPath").GetComponent<MeshRenderer>().materials[0].shader;
            
            switch (mat.renderQueue)
            {
                case (int)RenderQueueType.Dirt:
                    return _dirtShader;
                
                case (int)RenderQueueType.Path:
                    return _pathShader;
                
                default:
                    return _buidlingShader;
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
                FixMaterialShader(gameObject);

            return item;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        private static void FixMaterialShader(GameObject obj)
        {
            var meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                foreach (Material mat in meshRenderer.materials)
                {
                    var matRenderQueue = mat.renderQueue; 
                    mat.shader = GetShader(mat);
                    mat.renderQueue = matRenderQueue;
                }
            }

            foreach (Transform child in obj.transform)
            {
                if (child.gameObject)
                {
                    FixMaterialShader(child.gameObject);
                }
            }
        }
    }
}