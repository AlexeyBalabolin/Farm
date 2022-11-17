namespace Gameplay
{
    public class Carrot : ActivatedPlant
    {
        protected override void ActivatePlant()
        {
            base.ActivatePlant();
            _scoreService.AddCarrot();
        }
    }
}

