using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

//Object in the ground grid such as trees and shrubbery.
public class GridObject : Selectable
{
    [SerializeField] float removalDelay = 4f;

    public void StartRemovalVisual(float countdownLength)
    {
        throw new System.NotImplementedException();
    }
    public virtual void RemoveFromGrid()
    {
        throw new System.NotImplementedException();
    }
}
