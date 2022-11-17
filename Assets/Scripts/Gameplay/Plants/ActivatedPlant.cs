using Audio;
using FX;

namespace Gameplay
{
    public class ActivatedPlant : Plant
    {
        protected override void ActivatePlant()
        {
            Cell cell = GetComponentInParent<Cell>();
            cell.IsFree = true;
            _gameFactory.FxPooler.GetComponent<FxPooler>().PlayEffectByType(EffectType.DestroyPlant, transform.position);
            _gameFactory.Audio.GetComponent<AudioPlayer>().PlayAudioType(AudioType.DestroyPlant);
            Destroy(gameObject);
        }
    }
}

