using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Timberborn.BlueprintSystem;
using Timberborn.ModManagerScene;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.TesterMod;

public class ModStarter : IModStarter
{
    public void StartMod(IModEnvironment modEnvironment)
    {
        Debug.Log("Test");
    }
}

[HarmonyPatch(typeof(SpecService))]
public static class TestPatch
{
    
}