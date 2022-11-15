using UnityEngine;

[CreateAssetMenu(fileName ="Plant", menuName ="Data/Plant")]
public class Plant : ScriptableObject
{
    public PlantType PlantType;
    public string Name;
    public string Description;
    public Sprite PlantSprite;
    public float GrowthTime;
    public int Score;
    public GameObject Prefab;
}
