using GameMechanics;
using UnityEngine;

namespace GameLogic
{
    public class BilliardLineController : MonoBehaviour
    {
        [SerializeField] private BilliardLineRenderer _billiardLineRenderer;
        [SerializeField] private MainBall _mainBall;
        [SerializeField] private GameObject _startPoint;

        private Ray2D _rayDirection;

        [SerializeField] private float radius;

        private void Start()
        {
            radius = _mainBall.GetCollider2D().bounds.extents.x;
        }

        private void FixedUpdate()
        {
            _rayDirection = new Ray2D(_mainBall.transform.position, _startPoint.transform.up);

            _billiardLineRenderer.Draw(_mainBall.transform.position, _rayDirection.direction,
                radius);
        }
    }
}