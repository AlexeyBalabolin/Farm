using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantsList", menuName = "Data/PlantsList")]
public class AllPlants : ScriptableObject
{
    public List<PlantData> Plants = new List<PlantData>();

    [ContextMenu("Clear plants")]
    public void ClearPlants() => Plants.Clear();

#if UNITY_EDITOR
    [ContextMenu("Find plants")]
    public void FindPlants()
    {
        ClearPlants();
        var guids = AssetDatabase.FindAssets("t:PlantData");
        foreach (var guid in guids)
            Plants.Add(AssetDatabase.LoadAssetAtPath<PlantData>(AssetDatabase.GUIDToAssetPath(guid)));
    }
#endif
    public IEnumerator GetEnumerator() => Plants.GetEnumerator();
}
