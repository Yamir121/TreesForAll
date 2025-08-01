using Sirenix.OdinInspector;
using UnityEngine;

public class PlantInGrid : GridObject
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    [TitleGroup("Data")]
    [ReadOnly][Range(1, 5)][SerializeField] private int currentGrowthStage = 1;

    public void Water()
    {

    }

    public void Grow()
    {

    }

    public void GrowOneStage()
    {

    }

    public void Wither()
    {

    }
}
