using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;

public class PlantInGrid : GridObject
{
    public int CurrentGrowthStage => currentGrowthStage;

    [TitleGroup("References")]
    private GameObject mesh;

    [TitleGroup("Variables")]
    [SerializeField] private List<float> growthStageObjectScales;
    [Button] public void ResetSizeToGrowthStages() => growthStageObjectScales.SetLength(plantData.GrowthStages);

    [TitleGroup("Data")]
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    [ReadOnly][Range(1, 5)][SerializeField] private int currentGrowthStage = 1;

    public void Start()
    {
        mesh.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 270f), 0f);
    }

    public void Water()
    {
        TimeManager.Instance.StartTimer(5, true, () => GrowOneStage());
    }

    public void Grow(int growthAmount)
    {
        currentGrowthStage += growthAmount;
        UpdateGrowthStage();
    }

    public void SetGrowthstage(int stage)
    {
        currentGrowthStage = stage;
        UpdateGrowthStage();
    }

    public void GrowOneStage()
    {
        currentGrowthStage += 1;
        UpdateGrowthStage();
    }

    public void Wither()
    {

    }

    private void UpdateGrowthStage()
    {
        mesh.transform.localScale = new Vector3(growthStageObjectScales[currentGrowthStage], growthStageObjectScales[currentGrowthStage], growthStageObjectScales[currentGrowthStage]);
    }
}
