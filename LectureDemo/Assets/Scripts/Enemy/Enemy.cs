using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHeight;
    public bool CheckPlayer(float rayDistance, float rayAngle)
    {
        Vector3 origin = transform.position + Vector3.up * enemyHeight;

        Vector3 forwardDir = transform.forward;
        Vector3 rightDir = Quaternion.Euler(0, rayAngle, 0) * transform.forward;
        Vector3 leftDir = Quaternion.Euler(0, -rayAngle, 0) * transform.forward;

        Debug.DrawRay(origin, forwardDir * rayDistance, Color.red);
        Debug.DrawRay(origin, rightDir * rayDistance, Color.red);
        Debug.DrawRay(origin, leftDir * rayDistance, Color.red);

        if (ShootRay(origin, forwardDir, rayDistance)) return true;
        if (ShootRay(origin, rightDir, rayDistance)) return true;
        if (ShootRay(origin, leftDir, rayDistance)) return true;

        return false;
    }

    private bool ShootRay(Vector3 origin, Vector3 direction, float distance)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, distance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
}