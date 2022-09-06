using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using Timberborn.MainMenuScene;
using Timberborn.Persistence;

namespace TimberApi.New.SpecificationSystem
{
    public class SpecificationPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            Harmony harmony = new Harmony("TimberApi.specification");

            harmony.Patch(
                original: AccessTools.Method(typeof(PersistenceConfigurator), nameof(PersistenceConfigurator.Configure)),
                transpiler: new HarmonyMethod(AccessTools.Method(typeof(SpecificationPatcher), nameof(RemoveSpecificationBind)))
                );

            harmony.Patch(
                original: AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"),
                transpiler: new HarmonyMethod(AccessTools.Method(typeof(SpecificationPatcher), nameof(RemoveSpecificationBind)))
            );
        }

        public static IEnumerable<CodeInstruction> RemoveSpecificationBind(IEnumerable<CodeInstruction> instructions)
        {
            // IL instructions
            List<CodeInstruction> code = new List<CodeInstruction>(instructions);

            int startIndex = -1;
            int endIndex = -1;

            for (int i = 0; i < code.Count - 1; i++)
            {
                // Search for the ISpecification bind call
                if (code[i].opcode != OpCodes.Ldarg_1 || code[i + 1].opcode != OpCodes.Callvirt ||
                    code[i + 1].operand.ToString() != "Bindito.Core.IBindingBuilder`1[Timberborn.Persistence.ISpecificationService] Bind[ISpecificationService]()")
                    continue;

                // Loop to end of call to find last index
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

            // If method was not found skip
            if (startIndex == -1 && endIndex == -1)
                return code;

            // Removes the method out the IL code
            code.RemoveRange(startIndex, endIndex - startIndex + 1);
            return code;
        }
    }
}