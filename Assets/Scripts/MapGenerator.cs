using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private Cell CellData;

    void Start()
    {
        GenerateMap(1);
    }

    public void GenerateMap(int cellLayersCount)
    {
        GameObject startCell = Instantiate(CellData.CellPrefab);
        float angle = 0;
        for (int i = 0; i < 2; i++)
        {
            GameObject currentCell = Instantiate(CellData.CellPrefab, CalculateCellPosition(startCell.transform.position, angle), Quaternion.identity);
            angle += (360 / Cell.EDGE_COUNT);
        }
    }

    private Vector3 CalculateCellPosition(Vector3 startCellPosition, float angle)
    {
        float width = startCellPosition.x + Cell.RADIUS * Mathf.Sin(angle);
        float height = startCellPosition.y + Cell.RADIUS * Mathf.Cos(angle);
        return new Vector3(width, 0, height);
    }
}

[Serializable]
public class Cell
{

    public const float RADIUS = 1f;
    public const int EDGE_COUNT = 6;

    [SerializeField]
    private GameObject _cellPrefab;

    public GameObject CellPrefab { get => _cellPrefab; }
}
