
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
                InputAction.MoveRight => Vector2.right,
                _ => Vector2.zero
            };
        }
        public static float ToRotation(this InputAction inputAction)
        {
            return inputAction switch
            {
                InputAction.RotateAntiClockwise => 1,
                InputAction.RotateClockwise => -1,
                _ => 0
            };
        }

    }
}