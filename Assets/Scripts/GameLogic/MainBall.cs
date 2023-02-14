using UnityEngine;

namespace GameLogic
{
    public class MainBall : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody2D;
        [SerializeField] private Collider2D _collider2D;

        public Collider2D GetCollider2D()
        {
            return _collider2D;
        }

        public Rigidbody2D GetRigidBody2D()
        {
            return _rigidBody2D;
        }

        public void StopMovement()
        {
            _rigidBody2D.velocity = new Vector2();
            _rigidBody2D.angularVelocity = 0f;
        }

        public bool IsMoving()
        {
            return _rigidBody2D.velocity.magnitude > 0;
        }
    }
}