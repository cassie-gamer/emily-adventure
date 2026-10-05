using UnityEngine;

// Ava waiting in the cave behind the waterfall
// Add to Ava (a slightly bigger capsule), check "Is Trigger" on her collider
// Emily must touch Ava to rescue her
public class AvaRescue : MonoBehaviour
{
    public GameObject avaFollower; // Optional: a little heart or sparkle that follows Emily after rescue

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!StoryManager.Instance.IsLookingForAva()) return;

        // Ava is found!
        StoryManager.Instance.FoundAva();

        // Make Ava follow Emily now (simple follow)
        var follow = gameObject.AddComponent<AvaFollow>();
        follow.target = other.transform;

        Debug.Log("Ava found! She will follow Emily now.");
    }
}

// Simple follow script added at runtime
public class AvaFollow : MonoBehaviour
{
    public Transform target;
    public float followDistance = 2f;
    public float followSpeed = 5f;

    void Update()
    {
        if (target == null) return;
        Vector3 toTarget = target.position - transform.position;
        if (toTarget.magnitude > followDistance)
        {
            transform.position += toTarget.normalized * followSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(toTarget.normalized, Vector3.up);
        }
    }
}
