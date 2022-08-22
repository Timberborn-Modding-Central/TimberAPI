using System.IO;
using HarmonyLib;
using TimberApi.Core.Common;
using TimberApi.Core2.Common;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.TimberApiVisualizer
{
    public class Visualizer
    {
        public Visualizer()
        {
            Harmony harmony = new Harmony("lololol");

            harmony.Patch(
                original: AccessTools.TypeByName("Timberborn.MainMenuScene.MainMenuPanel").GetMethod("GetPanel"),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(Visualizer), nameof(PatchMainMenuPanel)))
            );
        }

        public static AssetBundle assetbundle = null;

        public static void PatchMainMenuPanel(VisualElement __result, VisualElementLoader ____visualElementLoader)
        {
            if(assetbundle == null)
                assetbundle = AssetBundle.LoadFromFile(Path.Combine(Paths.Mods, "timberapi"));

            VisualElement topbar = __result.Q<VisualElement>("TopBarTop").Q<VisualElement>("Center").Q<VisualElement>("Logo");

            topbar.Add(new VisualElement() { style =
            {
                position = Position.Absolute,
                backgroundImage = new StyleBackground(assetbundle.LoadAsset<Sprite>("TimberApi_board_2")),
                width = new StyleLength(new Length(228, LengthUnit.Pixel)),
                height = new StyleLength(new Length(83, LengthUnit.Pixel)),
                left = 305,
                bottom = 22,
                rotate = new StyleRotate(new Rotate(5))
            }});
        }
    }
}