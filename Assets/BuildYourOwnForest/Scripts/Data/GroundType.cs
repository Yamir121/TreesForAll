using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundTypes", menuName = "BuildYourOwnForest/GroundTypes")]
//Type of ground for the player to reforest. Based on real world locations.
public class GroundType : ScriptableObject
{

    public string WorldLocation => worldLocation;

    [SerializeField] private string worldLocation;
    [SerializeField] private Vector2 groundSize;
    

}
