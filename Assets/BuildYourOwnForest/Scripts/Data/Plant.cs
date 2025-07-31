using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "BuildYourOwnForest/Plant")]
public class Plant : ScriptableObject
{
    //Central data container for easy access to all information in one place, reducing chance for mistakes and allowing for easy extendability in content for the future.
    public Selectable SelectionPrefab => selectionPrefab;
    [PreviewField(100)][SerializeField] private Selectable selectionPrefab;
    [PreviewField(100)][SerializeField] private SeedPrefab SeedPrefab;
    [PreviewField(100)][SerializeField] private GridObject gridObject;
    [Range(1, 5)][SerializeField] private int growthStages;
    [SerializeField] private GroundType indigiousLocation;

    [TitleGroup("Attributes")]
    [SerializeField] private int carbonStorage;
    [SerializeField] private int biodiversity;
    [SerializeField] private int soilQuality;
    
}
