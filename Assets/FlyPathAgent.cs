using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;
    private int nextIndex = 1;

    void Start() => transform.position = flyPath[0];

    void Update()
    {
        if (flyPath == null) return;
        if (nextIndex >= flyPath.waypoints.Length) return;
        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
        }
        else
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint()
        => transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], flySpeed * Time.deltaTime);
}