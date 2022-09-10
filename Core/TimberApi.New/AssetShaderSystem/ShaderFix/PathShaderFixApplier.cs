using UnityEngine;

namespace TimberApi.New.AssetShaderSystem.ShaderFix
{
    internal class PathShaderFixApplier : IShaderFixApplier
    {
        private Shader _pathShader = null!;

        public void LoadShader()
        {
            _pathShader = Resources.Load<GameObject>("Buildings/Paths/Path/DirtDrivewayStraightPath").GetComponent<MeshRenderer>().materials[0].shader;
        }

        public bool ShouldApplyShader(Material material)
        {
            return material.renderQueue == 2998;
        }

        public void Apply(Material material)
        {
            material.shader = _pathShader;
        }
    }
}