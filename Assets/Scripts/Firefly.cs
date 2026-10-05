using UnityEngine;

// A glowing firefly that bobs up and down and leads to Ava's cave
// Add to small glowing spheres, make a trail of them from the hut to the waterfall
public class Firefly : MonoBehaviour
{
    public float bobSpeed = 2f;
    public float bobAmount = 0.3f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Cute bobbing
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Gentle glow pulse (needs a Light or emissive material to look best)
        transform.Rotate(Vector3.up, 90f * Time.deltaTime, Space.World);
    }
}
