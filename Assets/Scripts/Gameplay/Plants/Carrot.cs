using FX;

namespace Gameplay
{
    public class Carrot : Plant
    {
        private bool _isTaken = false;
        protected override void ActivatePlant()
        {
            if(!_isTaken)
            {
                Cell cell = GetComponentInParent<Cell>();
                cell.IsFree = true;
                _scoreService.AddCarrot();
                _isTaken = false;
                _gameFactory.FxPooler.GetComponent<FxPooler>().PlayEffectByType(EffectType.DestroyPlant, transform.position);
                _gameFactory.DestroyObject(gameObject);
            }
        }
    }
}

