using System.Collections.Generic;
using UnityEngine;
namespace KarmaBoomerang
{
    public static class KeyMappingFactory
    {
        public static Dictionary<InputAction,KeyCode>  GetInputMappings(int playerNumber = 0){
            return playerNumber switch
            {
                0 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.W},
                    {InputAction.MoveRight,KeyCode.D},
                    {InputAction.MoveDown,KeyCode.S},
                    {InputAction.MoveLeft,KeyCode.A}
                },
                1 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.UpArrow},
                    {InputAction.MoveRight,KeyCode.RightArrow},
                    {InputAction.MoveDown,KeyCode.DownArrow},
                    {InputAction.MoveLeft,KeyCode.LeftArrow}
                },
            };
        }
    }
    
}

