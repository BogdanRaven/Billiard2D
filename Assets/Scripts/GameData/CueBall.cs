using UnityEngine;

namespace GameData
{
    public class CueBall : MonoBehaviour
    {
        [SerializeField] private CueBallData CueBallData;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;

        public void Initialize(CueBallData cueBallData)
        {
            CueBallData = cueBallData;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void StopMovement()
        {
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.angularVelocity = 0f;
        }

        public bool IsMoving()
        {
            return _rigidbody2D.velocity.magnitude > 0;
        }

        public CueBallData GetData()
        {
            return CueBallData;
        }

        public Collider2D GetCollider2D()
        {
            return _collider2D;
        }

        public Rigidbody2D GetRigidBody2D()
        {
            return _rigidbody2D;
        }
    }
}