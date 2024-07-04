using System.Collections.Generic;
using Timberborn.Coordinates;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace BluePrint;

public class BlueprintRepository : ILoadableSingleton
{
    private Blueprint _blueprint = null!;

    public void Load()
    {
_blueprint = new Blueprint(new BlueprintItem[]
{
    new("BeaverStatue.Folktails", new Vector3Int(1, 0, 0), Orientation.Cw0, FlipMode.Unflipped),
    new("BeaverStatue.Folktails", new Vector3Int(2, 0, 0), Orientation.Cw90, FlipMode.Unflipped),
    new("BeaverStatue.Folktails", new Vector3Int(3, 0, 0), Orientation.Cw180, FlipMode.Unflipped),
    new("BeaverStatue.Folktails", new Vector3Int(4, 0, 0), Orientation.Cw270, FlipMode.Unflipped),
    
    new("Bench.Folktails", new Vector3Int(1, 2, 0), Orientation.Cw0, FlipMode.Unflipped),
    new("Bench.Folktails", new Vector3Int(2, 2, 0), Orientation.Cw90, FlipMode.Unflipped),
    new("Bench.Folktails", new Vector3Int(3, 2, 0), Orientation.Cw180, FlipMode.Unflipped),
    new("Bench.Folktails", new Vector3Int(4, 2, 0), Orientation.Cw270, FlipMode.Unflipped)
});
    }

    public Blueprint Get()
    {
        return _blueprint;
    }

    public void Add(Blueprint blueprint)
    {
        _blueprint = blueprint;
    }
}