using UnityEngine;

namespace GameMechanics
{
    public class BilliardLineRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineMain;
        [SerializeField] private LineRenderer _lineTarget;
        [SerializeField] private GameObject _ghostBall;

        private RaycastHit2D hit;

        public void Draw(Vector2 origin, Vector2 direction, float radius)
        {
            hit = Physics2D.CircleCast(origin, radius, direction, Mathf.Infinity);

            if (hit)
            {
                _lineMain.SetPosition(0, origin);
                _lineMain.SetPosition(1, hit.point);

                if (hit.rigidbody == null)
                {
                    Ray2D deflected;
                    RaycastHit2D hit;

                    Deflect(new Ray2D(origin, direction), out deflected, out hit);

                    _lineTarget.SetPosition(0, deflected.origin);
                    _lineTarget.SetPosition(1, deflected.origin + deflected.direction);

                    var ghostBallPosition = hit.point - (direction * radius);
                    _ghostBall.transform.position = new Vector3(ghostBallPosition.x, ghostBallPosition.y);
                }
                else
                {
                    _lineTarget.SetPosition(0, hit.point);
                    _lineTarget.SetPosition(1, hit.point - hit.normal);
                    var ghostBallPosition = hit.point - (direction * radius);
                    _ghostBall.transform.position = new Vector3(ghostBallPosition.x, ghostBallPosition.y);
                }
            }
        }

        public void SetEnableLines(bool enable)
        {
            _lineMain.gameObject.SetActive(enable);
            _lineTarget.gameObject.SetActive(enable);
            _ghostBall.gameObject.SetActive(enable);
        }

        private bool Deflect(Ray2D ray, out Ray2D deflected, out RaycastHit2D hit)
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                Vector2 normal = hit.normal;
                Vector2 deflect = Vector3.Reflect(ray.direction, normal);

                deflected = new Ray2D(hit.point, deflect);
                return true;
            }

            deflected = new Ray2D(Vector2.zero, Vector2.zero);
            return false;
        }
    }
}