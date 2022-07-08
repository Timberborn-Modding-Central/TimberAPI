using System.Collections.Generic;
using System.Reflection.Emit;
using Bindito.Core;
using HarmonyLib;
using Timberborn.MainMenuScene;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem
{
    public class SpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ISpecificationService>().To<TimberApiSpecificationService>().AsSingleton();
        }
    }

    [HarmonyPatch(typeof(PersistenceConfigurator), nameof(PersistenceConfigurator.Configure))]
    public static class SpecificationPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return SpecificationServiceTranspiler.RemoveSpecificationBind(instructions);
        }
    }

    [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
    public static class MainMenuSceneConfiguratorPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return SpecificationServiceTranspiler.RemoveSpecificationBind(instructions);
        }
    }

    public static class SpecificationServiceTranspiler
    {
        public static IEnumerable<CodeInstruction> RemoveSpecificationBind(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> code = new(instructions);

            int startIndex = -1;
            int endIndex = -1;
            for (int i = 0; i < code.Count - 1; i++)
            {
                if (code[i].opcode != OpCodes.Ldarg_1 || code[i + 1].opcode != OpCodes.Callvirt ||
                    code[i + 1].operand.ToString() != "Bindito.Core.IBindingBuilder`1[Timberborn.Persistence.ISpecificationService] Bind[ISpecificationService]()")
                    continue;

                for (int j = i; j < code.Count; j++)
                {
                    if (code[j].opcode != OpCodes.Callvirt || code[j].operand.ToString() != "Void AsSingleton()")
                        continue;

                    endIndex = j;
                    break;
                }

                startIndex = i;
                break;
            }

            if (startIndex == -1 && endIndex == -1)
                return code;

            code.RemoveRange(startIndex, endIndex - startIndex + 1);
            return code;
        }
    }
}