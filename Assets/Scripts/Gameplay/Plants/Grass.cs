namespace Gameplay
{
    public class Grass : Plant
    {
        protected override void ActivatePlant()
        {
            Cell cell = GetComponentInParent<Cell>();
            cell.IsFree = true;
            Destroy(gameObject);
        }
    }
}

