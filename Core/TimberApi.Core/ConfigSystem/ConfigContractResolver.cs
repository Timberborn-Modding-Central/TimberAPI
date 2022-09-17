using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TimberApi.Core.ConfigSystem
{
    internal class ConfigContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);
            contract.ItemRequired = Required.Always;
            return contract;
        }
    }
}