using UnityEngine;

namespace TimberApi.New.AssetShaderSystem.ShaderFix
{
    public class DirtShaderFixApplier : IShaderFixApplier
    {
        private Shader _dirtShader = null!;

        public void LoadShader()
        {
            _dirtShader = Resources.Load<GameObject>("Buildings/Wellbeing/Carousel/CarouselConstructionSite5x5+3x1Dirt").GetComponentsInChildren<MeshRenderer>()[1].materials[0].shader;
        }

        public bool ShouldApplyShader(Material material)
        {
            return material.renderQueue == 2999;
        }

        public void Apply(Material material)
        {
            material.shader = _dirtShader;
        }
    }
}