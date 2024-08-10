namespace GamePlay.Words.Movement.AnyDirection
{
    public class FullRandomDirectionMovement : AnyDirectionWordMovement
    {
        protected override void Initialize()
        {
            IsFullRandom = true;
        }
    }
}