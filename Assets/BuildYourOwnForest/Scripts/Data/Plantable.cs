using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Plantable", menuName = "BuildYourOwnForest/Plantable")]
public class Plantable : ScriptableObject
{
    [PreviewField(100)][SerializeField] private GameObject prefab;
    [Range(1, 5)][SerializeField] private int growthStages;
    [SerializeField] private GroundType indigiousLocation;

    [TitleGroup("Attributes")]
    [SerializeField] private int carbonStorage;
    [SerializeField] private int biodiversity;
    [SerializeField] private int soilQuality;
    
}
