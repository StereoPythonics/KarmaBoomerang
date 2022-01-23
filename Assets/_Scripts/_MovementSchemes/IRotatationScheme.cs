using UnityEngine;
namespace KarmaBoomerang
{
    public interface IRotatationScheme
    {
        void ApplyInput(Rigidbody2D target);
    }
}