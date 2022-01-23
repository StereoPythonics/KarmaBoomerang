
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public static class KeyMappingFactory
    {
        public static int playerCounter = 0;
        public static Dictionary<InputAction,KeyCode>  GetNextPlayerInputMappings()
        {
            Debug.Log($"PlayerCounter = {playerCounter}");
            return GetInputMappings(playerCounter++);
        }
        public static Dictionary<InputAction,KeyCode>  GetInputMappings(int playerNumber = 0){
            return playerNumber switch
            {
                0 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.W},
                    {InputAction.MoveRight,KeyCode.D},
                    {InputAction.MoveDown,KeyCode.S},
                    {InputAction.MoveLeft,KeyCode.A},
                    {InputAction.Shoot, KeyCode.F},
                    {InputAction.RotateClockwise, KeyCode.E},
                    {InputAction.RotateAntiClockwise, KeyCode.Q}
                },
                1 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.I},
                    {InputAction.MoveRight,KeyCode.L},
                    {InputAction.MoveDown,KeyCode.K},
                    {InputAction.MoveLeft,KeyCode.J},
                    {InputAction.Shoot, KeyCode.Semicolon},
                    {InputAction.RotateAntiClockwise, KeyCode.U},
                    {InputAction.RotateClockwise, KeyCode.O}
                },
                _ => null
            };
        }
    }
}