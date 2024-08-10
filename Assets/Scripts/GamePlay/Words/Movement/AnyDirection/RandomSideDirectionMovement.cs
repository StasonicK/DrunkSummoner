namespace GamePlay.Words.Movement.AnyDirection
{
    public class RandomSideDirectionMovement : AnyDirectionWordMovement
    {
        protected override void Initialize()
        {
            IsSideChanger = true;
        }
    }
}