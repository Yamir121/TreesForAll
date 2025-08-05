using Sirenix.OdinInspector;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundTypes", menuName = "BuildYourOwnForest/GroundTypes")]
//Type of ground for the player to reforest. Based on real world groundtypes.
public class GroundType : ScriptableObject
{
    public Attributes Attributes => new Attributes(carbonStorage, biodiversity, soilQuality);
    public GroundGrid GroundGrid => groundGrid;

    [SerializeField] private string groundTypeName;
    [TitleGroup("References")]
    [SerializeField] private GroundGrid groundGrid;

    [TitleGroup("Attributes")]
    [SerializeField] private int carbonStorage;
    [SerializeField] private int biodiversity;
    [SerializeField] private int soilQuality;
}
