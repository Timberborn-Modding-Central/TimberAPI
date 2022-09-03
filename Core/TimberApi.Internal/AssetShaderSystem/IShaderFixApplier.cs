using UnityEngine;

namespace TimberApi.Internal.AssetShaderSystem
{
    public interface IShaderFixApplier
    {
        public void LoadShader();

        public bool ShouldApplyShader(Material material);

        public void Apply(Material material);
    }
}