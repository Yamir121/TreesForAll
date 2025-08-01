using UnityEngine;

public class GroundGridManager : Manager
{
    [SerializeField] private GroundGrid grid;

    public void SetupGroundGrid(int x, int y)
    {
        grid.SetGridSize(x,y);
        grid.PopulateGrid();
    }
}
