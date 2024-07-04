namespace BluePrint;

public class Blueprint
{
    public BlueprintItem[] BlueprintItems { get; }

    public Blueprint(BlueprintItem[] blueprintItems)
    {
        BlueprintItems = blueprintItems;
    }
}