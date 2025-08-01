using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "BuildYourOwnForest/Plant")]
public class Plant : ScriptableObject
{
    //Central data container for easy access to all information in one place, reducing chance for mistakes and allowing for easy extendability in content for the future.
    public Selectable SelectionObject => selectionObject;
    public GridObject GridObject => gridObject;
    public string PlantName => plantName;
    public GroundType IndigiousLocation => indigiousLocation;

    public Vector3 Attributes => new Vector3(carbonStorage, biodiversity, soilQuality);

    [TitleGroup("References")]
    [SerializeField] private Selectable selectionObject;
    [SerializeField] private Seed SeedObject;
    [SerializeField] private GridObject gridObject;
    [TitleGroup("Variables")]
    [SerializeField] private string plantName;
    [Range(1, 5)][SerializeField] private int growthStages;
    [SerializeField] private GroundType indigiousLocation;

    [TitleGroup("Attributes")]
    [SerializeField] private int carbonStorage;
    [SerializeField] private int biodiversity;
    [SerializeField] private int soilQuality;
    
}
