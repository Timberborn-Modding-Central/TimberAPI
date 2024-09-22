using System.Collections.Generic;
using Timberborn.DropdownSystem;
using UnityEngine;

namespace Tester;

public class TestDropdownProvider : IDropdownProvider
{
    public string GetValue()
    {
        Debug.LogError("IDK");
        return "Test";
    }

    public void SetValue(string value)
    {
        Debug.LogError("New item selected:" + value);
    }

    public IReadOnlyList<string> Items => new[] { "Hello", "World", "Owo" };
}