using System.Linq;
using TimberApi.Tools.ToolSystem;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace Tester;

public class Test : ILoadableSingleton
{
    private readonly ToolService _toolService;

    public Test(ToolService toolService)
    {
        _toolService = toolService;
    }

    public void Load()
    {
        Debug.LogWarning($"Tool size is: {_toolService.Tools.Count()}");
    }
}