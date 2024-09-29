using Timberborn.ModManagerScene;
using UnityEngine;

namespace TimberApi.TesterMod;

public class ModStarter : IModStarter
{
    public void StartMod(IModEnvironment modEnvironment)
    {
        Debug.Log("Test");
    }
}