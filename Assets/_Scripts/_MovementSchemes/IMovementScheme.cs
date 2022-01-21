
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public interface IMovementScheme
    {
        void ApplyInput(Rigidbody2D target);
    }
}