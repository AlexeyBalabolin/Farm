using UnityEngine;

[CreateAssetMenu(fileName = "Instrument", menuName = "Data/Instrument")]
public class InstrumentData : ScriptableObject
{
    public Sprite InstrumentSprite;
    public InstrumentType InstrumentType;
}
