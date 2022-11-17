using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private CellData CellData;

    private bool _entryCellCreated = false;

    public void GenerateMap(Vector2 mapSize)
    {
        float xOffset = 0;
        float yOffset = 0;

        for (int i = 0; i < mapSize.y; i++)
        {    
            for(int j = 0; j < mapSize.x; j++)
            {
                GameObject currentCell = (i == 0 || j == 0  || i== mapSize.y-1 || j == mapSize.x-1) ? CellData.BorderPrefab : 
                    _entryCellCreated ? CellData.CellPrefab : CellData.EntryPrefab;

                if (currentCell == CellData.EntryPrefab)
                    _entryCellCreated = true;

                Instantiate(currentCell, new Vector3(xOffset, 0, yOffset), Quaternion.identity);

                xOffset += CellData.X_OFFSET;
            }
            xOffset = i % 2 == 0 ? CellData.X_OFFSET/2 : 0;
            yOffset -= CellData.Y_OFFSET;
        }
    }
}
