namespace GamePlay.Words.Movement.AnyDirection
{
    public class RightSideRandomRotationDirectionMovement : AnyDirectionWordMovement
    {
        protected override void Initialize()
        {
            IsRandomAngle = true;
        }
    }
}