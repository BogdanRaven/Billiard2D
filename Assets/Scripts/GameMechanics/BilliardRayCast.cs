using UnityEngine;

namespace GameMechanics
{
    public class BilliardRayCast
    {
        Quaternion rotate90 = Quaternion.AngleAxis(-90, Vector3.up);

        public bool BallCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit2D hit,
            out Vector2 cueBallHitPosition, out Ray2D normal, out Ray2D ballDirection, out Ray2D mainBallDirection)
        {
            hit = Physics2D.CircleCast(origin, radius, direction);
            if (hit)
            {
                cueBallHitPosition = hit.point + (radius * hit.normal);
                float scale = ((Vector2) origin - hit.point).magnitude;
                float ballAngle = Vector3.Angle(-1 * direction, rotate90 * hit.normal);

                // Main Ball Direction
                Debug.DrawLine(origin, cueBallHitPosition, Color.red);

                //normalDirection
                normal = new Ray2D(cueBallHitPosition, hit.normal);
                Debug.DrawRay(cueBallHitPosition, hit.normal, Color.black);

                // Ball direction
                Vector2 ballDirectionVector2 = -1 * hit.normal * scale;
                Vector2 ballDirectionOrigin = hit.point + (-radius * hit.normal);
                ballDirection = new Ray2D(ballDirectionOrigin, ballDirectionVector2);
                Debug.DrawRay(ballDirectionOrigin, ballDirectionVector2, Color.blue);

                // Main Ball Direction
                Vector2 mainBallDirectionVector2 = rotate90 * hit.normal * scale;
                mainBallDirection = new Ray2D(cueBallHitPosition, mainBallDirectionVector2);
                Debug.DrawRay(cueBallHitPosition, mainBallDirectionVector2, Color.green);

                return true;
            }

            cueBallHitPosition = Vector2.zero;
            normal = new Ray2D();
            ballDirection = new Ray2D();
            mainBallDirection = new Ray2D();
            return false;
        }

        public bool Deflect(Ray2D ray, out Ray2D deflected, out RaycastHit2D hit)
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