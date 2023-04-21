using UnityEngine;

namespace TimberApi.ShaderSystem.ShaderAppliers
{
    internal class PathShaderApplier : IShaderApplier
    {
        private Shader _pathShader = null!;

        public void LoadShader()
        {
            _pathShader = Resources.Load<Material>("buildings/paths/path/Path.Folktails").shader;
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