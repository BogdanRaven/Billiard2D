using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject ball;
    [SerializeField] private LineRenderer _lineRenderer;

    private RaycastHit2D hit;
    
    private void FixedUpdate()
    {
        Ray2D rayDirection = new Ray2D(point.transform.position, point.transform.up);
        // Debug.DrawRay(point.transform.position, point.transform.up, Color.red);
        Ray2D b;
        RaycastHit2D anonymoust;

        _lineRenderer.SetPosition(0, point.transform.position);

        if (Deflect(rayDirection, out b, out anonymoust))
        {
            Debug.Log("deflect");
            _lineRenderer.SetPosition(1, b.origin);
            _lineRenderer.SetPosition(2, b.origin + 3 * b.direction);
        }
    }

    bool Deflect(Ray2D ray, out Ray2D deflected, out RaycastHit2D anonymoust)
    {
        anonymoust = Physics2D.Raycast(ray.origin, ray.direction);
        if (anonymoust.collider != null)
        {
            Debug.Log(anonymoust.collider.name);
            Vector2 normal = anonymoust.normal;
            Vector2 deflect = Vector3.Reflect(ray.direction, normal);

            deflected = new Ray2D(anonymoust.point, deflect);
            return true;
        }

        deflected = new Ray2D(Vector2.zero, Vector2.zero);
        return false;
    }
}