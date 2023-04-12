using System;
using System.Linq;
using UnityEngine;

namespace TimberApi.ShaderSystem.ShaderAppliers
{
    internal class DirtUrpApplier : IShaderApplier
    {
        private Shader _dirtUrpShader = null!;

        public void LoadShader()
        {
            _dirtUrpShader = Resources.Load<GameObject>("constructionsites/constructionsite5x5+3x1dirt/ConstructionSite5x5+3x1Dirt").GetComponentsInChildren<MeshRenderer>()[0].materials[0].shader;
        }

        public bool ShouldApplyShader(Material material)
        {
            return material.renderQueue == 2999;
        }

        public void Apply(Material material)
        { 
            material.shader = _dirtUrpShader;
        }
    }
}