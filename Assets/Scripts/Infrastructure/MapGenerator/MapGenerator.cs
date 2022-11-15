using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private CellData CellData;

    void Start()
    {
        GenerateMap(3,3);
    }

    public void GenerateMap(int width, int height)
    {
        float xOffset = 0;
        float yOffset = 0;

        for (int i = 0; i < height; i++)
        {    
            for(int j = 0; j < width; j++)
            {
                GameObject currentCell = Instantiate(CellData.CellPrefab, new Vector3(xOffset, 0, yOffset), Quaternion.identity);
                xOffset += CellData.X_OFFSET;
            }
            xOffset = i % 2 == 0 ? CellData.X_OFFSET/2 : 0;
            yOffset -= CellData.Y_OFFSET;
        }
    }
}
