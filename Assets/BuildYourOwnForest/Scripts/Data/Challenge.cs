using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "BuildYourOwnForest/Challenge")]
//Modifier on location attributes based on real world ecological challenges.
public class Challenge : ScriptableObject
{
    public string Explanation => explanation;
    public GroundType GroundType => groundType;

    [SerializeField] private string explanation;
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private GroundType groundType;
}
