using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "BuildYourOwnForest/Location")]
//Location in the world for the player to reforest. Based on real world locations with reforestation needs.
public class Location : ScriptableObject
{
    public string WorldLocation => worldLocation;
    public List<Plant> AvailablePlants => availablePlants;

    [SerializeField] private string worldLocation;
    [SerializeField] private List<Plant> availablePlants;
}
