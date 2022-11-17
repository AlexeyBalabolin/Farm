using FX;

namespace Gameplay
{
    public class Grass : Plant
    {
        protected override void ActivatePlant()
        {
            Cell cell = GetComponentInParent<Cell>();
            cell.IsFree = true;
            _gameFactory.FxPooler.GetComponent<FxPooler>().PlayEffectByType(EffectType.DestroyPlant, transform.position);
            Destroy(gameObject);
        }
    }
}

