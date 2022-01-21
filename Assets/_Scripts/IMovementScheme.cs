using UnityEngine;
namespace KarmaBoomerang
{
    public interface IMovementScheme
    {
        void ApplyInput(Rigidbody2D target);
    }
    
}

