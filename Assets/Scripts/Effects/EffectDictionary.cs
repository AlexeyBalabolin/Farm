using UnityEngine;

namespace FX
{
    public class EffectDictionary
    {
        public EffectType EffectType;
        public GameObject EffectObject;

        public EffectDictionary(EffectType effectType, GameObject effectObject)
        {
            EffectType = effectType;
            EffectObject = effectObject;
        }
    }
}

