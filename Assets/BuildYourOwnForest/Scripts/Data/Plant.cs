using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "BuildYourOwnForest/Plant")]
public class Plant : ScriptableObject
{
    public enum PlantType
    {
        SHRUB,
        GROUND_COVER,
        TREE
    }

    //Central data container for easy access to all information in one place, reducing chance for mistakes and allowing for easy extendability in content for the future.
    public Selectable SelectionObject => selectionObject;
    public Seed SeedObject => seedObject;
    public GridObject GridObject => gridObject;
    public string PlantName => plantName;
    public PlantType Type => plantType;
    public int MaxGrowthStage => growthStages;
    public Location IndigiousLocation => indigiousLocation;

    public Vector3 Attributes => new Vector3(carbonStorage, biodiversity, soilQuality);

    [SerializeField] private string plantName;
    [SerializeField] private PlantType plantType;
    [TitleGroup("References")]
    [SerializeField] private Selectable selectionObject;
    [SerializeField] private Seed seedObject;
    [SerializeField] private GridObject gridObject;
    [TitleGroup("Variables")]
    [Range(1, 5)][SerializeField] private int growthStages;
    [SerializeField] private Location indigiousLocation;

    [TitleGroup("Attributes")]
    [SerializeField] private int carbonStorage;
    [SerializeField] private int biodiversity;
    [SerializeField] private int soilQuality;
    
}
