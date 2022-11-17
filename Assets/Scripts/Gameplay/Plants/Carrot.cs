namespace Gameplay
{
    public class Carrot : Plant
    {
        protected override void ActivatePlant()
        {
            Cell cell = GetComponentInParent<Cell>();
            cell.IsFree = true;
            Destroy(gameObject);
        }
    }
}

