using UnityEngine;

[CreateAssetMenu(fileName ="Plant", menuName ="Data/Plant")]
public class PlantData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite PlantSprite;
    public float GrowthTime;
    public int Score;
    public GameObject PlantPrefab;
    public GameObject SproutPrefab;
    public InstrumentType InstrumentType;
}
