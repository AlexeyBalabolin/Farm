using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private CellData CellData;

    private bool _entryCellCreated = false;

    public void GenerateMap(int width, int height)
    {
        float xOffset = 0;
        float yOffset = 0;

        for (int i = 0; i < height; i++)
        {    
            for(int j = 0; j < width; j++)
            {
                GameObject currentCell = (i == 0 || j == 0  || i== height-1 || j == width-1) ? CellData.BorderPrefab : 
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
