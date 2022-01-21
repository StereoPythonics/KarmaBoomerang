using UnityEngine;
namespace KarmaBoomerang
{
    public static class DirectionTranslationExtensions
    {
        public static Vector2 ToVectorDirection(this InputAction inputAction)
        {
            return inputAction switch
            {
                InputAction.MoveUp => Vector2.up,
                InputAction.MoveLeft => Vector2.left,
                InputAction.MoveDown => Vector2.down,
                InputAction.MoveRight => Vector2.right
            };
        }

    }
    
}

