using Sirenix.OdinInspector;
using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

public class GroundGrid : SerializedMonoBehaviour
{
    [TitleGroup("References")]
    [SerializeField] private InteractionZone zonePrefab;

    [TitleGroup("Variables")]
    [ReadOnly][SerializeField] private float gridHeight = 0f;
    [TitleGroup("Data")]
    [ReadOnly][SerializeField][TableMatrix(DrawElementMethod = "DrawElement")] private GridSpace[,] grid;

    [Serializable]
    private class GridSpace
    {
        public GridSpace(Vector3 position)
        {
            this.position = position;
        }
        public Vector3 position;
        public GridObject occupyingObject;
        public InteractionZone interactionZone;
    }

    [Button]
    /// <summary>
    /// sets the size of the grid according to parameter values.
    /// </summary>
    /// <param name="rows">The amount of gridspaces in the x-axis.</param>
    /// <param name="cols">The amount of gridspaces in the z-axis.</param>
    public void SetGridSize(int rows,int cols)
    {
        grid = new GridSpace[rows, cols];
        transform.position = new Vector3( -((float)rows / 2),gridHeight, -((float)cols / 2));
    }


    [Button]
    /// <summary>
    /// Populates the grid with Gridspaces and spawn interactionZones in the scene.
    /// </summary>
    public void PopulateGrid() 
    {
        Vector2 offset = new Vector2((grid.GetLength(0)/2), (grid.GetLength(1)/2));

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = new GridSpace(new Vector3(row - offset.x, gridHeight, col - offset.y));
                Instantiate(zonePrefab, grid[row, col].position, Quaternion.identity, gameObject.transform);
            }
        }
    }

    [Button]
    /// <summary>
    /// Spawn a plant on a specific position in the GroundGrid.
    /// </summary>
    /// <param name="plant">Plant to place in the grid</param>
    /// <param name="gridPlacement">Position in the GroundGrid</param>
    public void SpawnPlant(Plant plant, int x, int y)
    {
        GridSpace _gridSpace = grid[x - 1, y - 1];
        _gridSpace.occupyingObject = Instantiate(plant.GridObject, new Vector3(_gridSpace.position.x, gridHeight, _gridSpace.position.z), Quaternion.identity, this.transform);
    }

    public void RemoveGridObjectAtIndex(int x, int y)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveGridObjectByType(GridObject gridobject)
    {
        throw new System.NotImplementedException();
    }

#if UNITY_EDITOR
    /*public void OnDrawGizmos()
    {
        if (grid == null || grid.GetLength(0) != 5 || grid.GetLength(1) != 5)
        {
            //In meters
            SetGridSize(5, 5);
            PopulateGrid();
        }

        float size = 0.5f;
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Gizmos.color = UnityEngine.Color.white;

                Vector3 center = grid[row, col].position;
                Vector3 boxSize = new Vector3(size, 0.01f, size); // Flat on XZ plane

                Gizmos.DrawCube(center, boxSize);
            }
        }
        
    }*/
    static GroundGrid.GridSpace DrawElement(Rect rect, GroundGrid.GridSpace value)
    {
        string name = value != null && value.occupyingObject != null ? value.occupyingObject.name + (value.occupyingObject as PlantInGrid).CurrentGrowthStage : "<empty>";
        GUI.Label(rect, name);
        return value;
    }
#endif

}
