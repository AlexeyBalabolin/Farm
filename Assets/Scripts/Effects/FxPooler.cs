using Infrastructure.Factory;
using Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace FX
{
    public class FxPooler : MonoBehaviour
    {
        [SerializeField]
        private List<Effect> _effects;

        private IGameFactory _gameFactory;
        private List<EffectDictionary> _createdEffects = new List<EffectDictionary>();

        public void InitalizeEffects()
        {
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            foreach (var effect in _effects)
            {
                for (int i = 0; i < effect.Buffer; i++)
                {
                    GameObject currentEffect = _gameFactory.CreateGameobject(effect.EffectObject);
                    _createdEffects.Add(new EffectDictionary(effect.EffectType, currentEffect));
                    currentEffect.SetActive(false);
                }
            }
        }

        public void PlayEffectByType(EffectType effectType, Vector3 position)
        {
            foreach (var effect in _createdEffects)
            {
                if (effect.EffectType == effectType && !effect.EffectObject.activeSelf)
                {
                    effect.EffectObject.SetActive(true);
                    effect.EffectObject.transform.position = position;
                    effect.EffectObject.GetComponent<ParticleSystem>().Play();
                    break;
                }
            }
        }
    }
}

