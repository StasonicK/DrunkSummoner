namespace GamePlay.Words.Movement.AnyDirection
{
    public class LeftSideRandomAngleDirectionMovement : AnyDirectionWordMovement
    {
        protected override void Initialize()
        {
            IsRandomAngle = true;
            IsLeft = true;
        }
    }
}