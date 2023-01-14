using UnityEngine;

namespace TimberApi.ShaderSystem
{
    public interface IShaderApplier
    {
        public void LoadShader();

        public bool ShouldApplyShader(Material material);

        public void Apply(Material material);
    }
}