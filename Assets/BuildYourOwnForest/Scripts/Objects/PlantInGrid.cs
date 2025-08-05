using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;

public class PlantInGrid : GridObject
{
    public int CurrentGrowthStage => currentGrowthStage;
    public float ProgressToNextStage => progressToNextStage;


    [TitleGroup("References")]
    [SerializeField] private GameObject mesh;

    [TitleGroup("Variables")]
    [SerializeField] private List<float> growthStageObjectScales;
    [Button] public void ResetSizeToGrowthStages() => growthStageObjectScales.SetLength(plantData.MaxGrowthStage);

    [TitleGroup("Data")]
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    [ReadOnly][SerializeField] private float progressToNextStage = 0f;
    [ReadOnly][Range(1, 5)][SerializeField] private int currentGrowthStage = 1;

    public void Start()
    {
        mesh.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 270f), 0f);
    }

    public void Water()
    {
        TimeManager.Instance.StartTimer(5, true, () => GrowOneStage());
    }

    public void AddProgressToNextStage(float amount)
    {
        if (currentGrowthStage != plantData.MaxGrowthStage)
        {
            progressToNextStage += amount;
        }
    }

    public void Grow(int growthAmount)
    {
        if (currentGrowthStage != plantData.MaxGrowthStage) 
        { 
            currentGrowthStage += growthAmount;
            UpdateGrowthStage();
        }
    }

    public void SetGrowthstage(int stage)
    {
        if (currentGrowthStage != plantData.MaxGrowthStage)
        {
            currentGrowthStage = stage;
            UpdateGrowthStage();
        }
            
    }

    public void GrowOneStage()
    {
        if (currentGrowthStage != plantData.MaxGrowthStage)
        {
            currentGrowthStage += 1;
            progressToNextStage = 0;
            UpdateGrowthStage();
        }
    }

    public void Wither()
    {

    }

    private void UpdateGrowthStage()
    {
        mesh.transform.localScale = new Vector3(growthStageObjectScales[currentGrowthStage-1], growthStageObjectScales[currentGrowthStage-1], growthStageObjectScales[currentGrowthStage-1]);
    }
}
