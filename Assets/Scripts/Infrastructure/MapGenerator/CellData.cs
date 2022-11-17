using System;
using UnityEngine;

[Serializable]
public class CellData
{

    public const float X_OFFSET = 1f;
    public const float Y_OFFSET = 0.8f;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private GameObject _borderPrefab;

    [SerializeField]
    private GameObject _entryPrefab;

    public GameObject CellPrefab { get => _cellPrefab; }
    public GameObject BorderPrefab { get => _borderPrefab; }
    public GameObject EntryPrefab { get => _entryPrefab; }
}
