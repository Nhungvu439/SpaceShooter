using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;
    public Vector3 this[int index] => waypoints[index].transform.position;
    private void Reset() => waypoints = GetComponentsInChildren<Waypoint>();

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }
        }
    }
}