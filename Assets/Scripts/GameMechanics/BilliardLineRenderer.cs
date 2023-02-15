using UnityEngine;

namespace GameMechanics
{
    public class BilliardLineRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineMain;
        [SerializeField] private LineRenderer _lineTarget;
        [SerializeField] private GameObject _ghostBall;

        private BilliardRayCast _billiardRayCast;

        private void Start()
        {
            _billiardRayCast = new BilliardRayCast();
        }

        public void DrawBilliardRays(Vector3 origin, Vector3 direction, float radius)
        {
            var hit2D = new RaycastHit2D();
            var cueBallHitPosition = Vector2.zero;
            var normal = new Ray2D();
            var ballDirection = new Ray2D();
            var mainBallDirection = new Ray2D();

            if (_billiardRayCast.BallCast(origin, radius, direction, out hit2D, out cueBallHitPosition, out normal,
                out ballDirection, out mainBallDirection))
            {
                _lineMain.SetPosition(0, origin);
                _lineMain.SetPosition(1, cueBallHitPosition);

                if (hit2D.rigidbody == null)
                {
                    _lineTarget.SetPosition(0, cueBallHitPosition);
                    Vector2 deflected = (Vector2) Vector3.Reflect((hit2D.point - (Vector2)origin).normalized, hit2D.normal);
                    _lineTarget.SetPosition(1, hit2D.point + deflected);

                    var ghostBallPosition = cueBallHitPosition;
                    _ghostBall.transform.position = new Vector3(ghostBallPosition.x, ghostBallPosition.y);
                }
                else
                {
                    _lineTarget.SetPosition(0, ballDirection.origin);
                    _lineTarget.SetPosition(1, ballDirection.origin + ballDirection.direction);
                    _ghostBall.transform.position = cueBallHitPosition;
                }
            }
        }

        public void SetEnableLines(bool enable)
        {
            _lineMain.gameObject.SetActive(enable);
            _lineTarget.gameObject.SetActive(enable);
            _ghostBall.gameObject.SetActive(enable);
        }
    }
}