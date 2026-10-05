using UnityEngine;

// Emily's movement - add this to Emily (a small capsule or character)
// Move with WASD / arrow keys
public class EmilyMover : MonoBehaviour
{
    public float speed = 4f; // Emily is little, so she walks gently

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // Make Emily face where she's going (cute!)
        if (move.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(move.normalized, Vector3.up);
        }
    }
}
