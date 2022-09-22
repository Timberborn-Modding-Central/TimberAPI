using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Common.SingletonSystem;
using UnityEngine;

namespace TimberApi.AssetShaderSystem
{
    internal class AssetShaderFixer : ITimberApiPreLoadableSingleton
    {
        private readonly ImmutableArray<IShaderFixApplier> _shaderFixAppliers;

        private Shader _shader = null!;

        public AssetShaderFixer(IEnumerable<IShaderFixApplier> shaderFixAppliers)
        {
            _shaderFixAppliers = shaderFixAppliers.ToImmutableArray();
        }


        private Shader Shader
        {
            get
            {
                if (_shader == null)
                {
                    _shader = Resources.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails").GetComponent<MeshRenderer>().materials[0].shader;
                }

                return _shader;
            }
        }

        public void PreLoad()
        {
            foreach (IShaderFixApplier shaderFixApplier in _shaderFixAppliers)
            {
                shaderFixApplier.LoadShader();
            }
        }

        public void FixShaders(GameObject gameObject)
        {
            var meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                foreach (Material material in meshRenderer.materials)
                {
                    int matRenderQueue = material.renderQueue;
                    if (!ApplyShaderFix(material))
                    {
                        ApplyFallbackShaderFix(material);
                    }

                    material.renderQueue = matRenderQueue;
                }
            }

            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject)
                {
                    FixShaders(child.gameObject);
                }
            }
        }

        private bool ApplyShaderFix(Material material)
        {
            foreach (IShaderFixApplier shaderFixApplier in _shaderFixAppliers.Where(shaderFixApplier => shaderFixApplier.ShouldApplyShader(material)))
            {
                shaderFixApplier.Apply(material);
                return true;
            }

            return false;
        }

        public void ApplyFallbackShaderFix(Material material)
        {
            material.shader = Shader;
        }
    }
}