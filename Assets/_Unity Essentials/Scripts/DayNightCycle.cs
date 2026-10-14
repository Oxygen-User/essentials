
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Cycle")]
    [Min(1f)]
    public float secondsPerDay = 120f;

    void Update()
    {
        float rotationSpeed = 360f / secondsPerDay;

        transform.Rotate(
            Vector3.right,
            rotationSpeed * Time.deltaTime,
            Space.World
        );
    }
}
