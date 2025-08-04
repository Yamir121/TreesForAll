using System.Collections.Generic;
using UnityEngine;

public class SelectionTable : MonoBehaviour
{
    [SerializeField] private List<Transform> selectionSlots;

    public void SpawnAndFillSelectionSlots(List<Selectable> selectable)
    {
        for (int i = 0; i < selectable.Count; i++)
        {
            Instantiate(selectable[i], selectionSlots[i].position, selectionSlots[i].rotation, selectionSlots[i]);
        }
    }

    public void DespawnAndEmptySelectionSlots()
    {
        for (int i = 0; i < selectionSlots.Count; i++) 
        {
            Destroy(selectionSlots[i].transform.GetChild(0));
        }
    }
}
