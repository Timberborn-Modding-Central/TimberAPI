using UnityEngine;

namespace TimberApi.New.AssetShaderSystem
{
    public interface IShaderFixApplier
    {
        public void LoadShader();

        public bool ShouldApplyShader(Material material);

        public void Apply(Material material);
    }
}