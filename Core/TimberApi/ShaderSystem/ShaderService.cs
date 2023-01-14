using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Common.SingletonSystem;
using UnityEngine;

namespace TimberApi.ShaderSystem
{
    internal class ShaderService : ITimberApiPreLoadableSingleton
    {
        private readonly ImmutableArray<IShaderApplier> _shaderFixAppliers;

        private Shader _shader = null!;

        public ShaderService(IEnumerable<IShaderApplier> shaderFixAppliers)
        {
            _shaderFixAppliers = shaderFixAppliers.ToImmutableArray();
        }

        private Shader Shader
        {
            get
            {
                if (_shader == null)
                {
                    _shader = Resources.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails")
                        .GetComponent<MeshRenderer>().materials[0].shader;
                }

                return _shader;
            }
        }

        public void PreLoad()
        {
            foreach (IShaderApplier shaderFixApplier in _shaderFixAppliers)
            {
                shaderFixApplier.LoadShader();
            }
        }

        public void ApplyShaders(GameObject gameObject)
        {
            MeshRenderer[] meshRenderers = gameObject.GetComponents<MeshRenderer>();
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                foreach (Material material in meshRenderer.materials)
                {
                    int matRenderQueue = material.renderQueue;

                    ApplyShaders(material);

                    material.renderQueue = matRenderQueue;
                }
            }

            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject)
                {
                    ApplyShaders(child.gameObject);
                }
            }
        }

        public void ApplyShaders(Material material)
        {
            foreach (IShaderApplier shaderFixApplier in _shaderFixAppliers.Where(shaderFixApplier =>
                         shaderFixApplier.ShouldApplyShader(material)))
            {
                shaderFixApplier.Apply(material);
                return;
            }

            ApplyFallbackShaderFix(material);
        }

        private void ApplyFallbackShaderFix(Material material)
        {
            material.shader = Shader;
        }
    }
}