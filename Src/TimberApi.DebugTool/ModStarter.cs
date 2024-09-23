using HarmonyLib;
using Timberborn.ModManagerScene;


namespace TimberApi.DebugTool;

public class ModStarter : IModStarter
{
    // private ScriptDomain domain = null;
    
    public void StartMod(IModEnvironment modEnvironment)
    {
        var harmony = new Harmony("TimberApi.Debug");
        
        harmony.PatchAll();

        // var code = File.ReadAllText(@"G:\Development\TimberApi\Kek\Class1.cs");
        //
        //
        // CompileAndRun(code);
    }
    
    // void CompileAndRun(string code)
    // {
    //     var syntaxTree = CSharpSyntaxTree.ParseText(code);
    //     
    //     // Get all current assemblies and filter out invalid ones
    //     var references = AppDomain.CurrentDomain.GetAssemblies()
    //         .Where(a => !a.IsDynamic && !string.IsNullOrEmpty(a.Location))
    //         .Select(a => MetadataReference.CreateFromFile(a.Location))
    //         .ToList();
    //     
    //     Debug.LogError(typeof(UnityEngine.Debug).Assembly.Location);
    //     references.Add(MetadataReference.CreateFromFile(Path.Combine(Application.dataPath, "Managed", "UnityEngine.CoreModule.dll")));
    //
    //     var compilation = CSharpCompilation.Create(
    //         "DynamicAssembly",
    //         new[] { syntaxTree },
    //         references,
    //         new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    //
    //     using (var ms = new MemoryStream())
    //     {
    //         var result = compilation.Emit(ms);
    //
    //         if (!result.Success)
    //         {
    //             StringBuilder sb = new StringBuilder();
    //             foreach (var diagnostic in result.Diagnostics)
    //             {
    //                 sb.AppendLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
    //             }
    //             Debug.LogError(sb.ToString());
    //         }
    //         else
    //         {
    //             ms.Seek(0, SeekOrigin.Begin);
    //             var assembly = Assembly.Load(ms.ToArray());
    //
    //             var type = assembly.GetType("Kek.Class1");
    //             var instance = Activator.CreateInstance(type);
    //             var method = type.GetMethod("Test");
    //             method.Invoke(instance, null);
    //         }
    //     }
    // }
    
    // public void WorkingSetup()
    // {
    //     // Create domain
    //     domain = ScriptDomain.CreateDomain("Example Domain");
    //     
    //     domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromNameOrFile("UnityEngine.dll"));
    //     domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromNameOrFile("mscorlib"));
    //     domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromNameOrFile("netstandard"));
    //
    //
    //     // Compile and load code
    //     ScriptAssembly assembly = domain.CompileAndLoadFile(@"G:\Development\TimberApi\Kek\Class1.cs", ScriptSecurityMode.UseSettings);
    //
    //     var test = assembly.FindType("Class1").CreateInstance();
    //     test.Call("Test");
    //     
    //     // Check for compiler errors
    //     if (domain.CompileResult.Success == false)
    //     {
    //         // Get all errors
    //         foreach (CompilationError error in domain.CompileResult.Errors)
    //         {
    //             if (error.IsError == true)
    //             {
    //                 UnityEngine.Debug.LogError(error.ToString());
    //             }
    //             else if (error.IsWarning == true)
    //             {
    //                 UnityEngine.Debug.LogWarning(error.ToString());
    //             }
    //         }
    //     }
    // }
}