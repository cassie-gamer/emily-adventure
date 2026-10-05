using UnityEngine;
using System.Collections;

// A tiger or snake that chases Emily through the forest.
// Add to the tiger/snake object. It needs a Collider with "Is Trigger" checked.
// Tag Emily's GameObject as "Player".
public class ForestDanger : MonoBehaviour
{
    [Header("Chase settings")]
    public float chaseSpeed = 3.5f;   // tigers are faster, snakes slower - tune per animal!
    public float chaseRange = 8f;     // starts chasing when Emily is this close
    public float giveUpRange = 12f;   // stops chasing when Emily gets this far

    [Header("Attack")]
    public int courageDamage = 1;     // courage lost when it touches Emily

    private Transform emily;
    private bool chasing = false;
    private bool stunned = false;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) emily = player.transform;
    }

    void Update()
    {
        if (emily == null || stunned) return;

        float dist = Vector3.Distance(transform.position, emily.position);

        if (!chasing && dist < chaseRange) chasing = true;
        if (chasing && dist > giveUpRange) chasing = false; // Emily outran it!

        if (chasing)
        {
            Vector3 dir = (emily.position - transform.position).normalized;
            dir.y = 0f; // stay on the ground
            transform.position += dir * chaseSpeed * Time.deltaTime;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        }
    }

    // Called by Emily's fire stick - freezes the animal for a few seconds
    public void Stun(float seconds)
    {
        if (stunned) return;
        StartCoroutine(StunRoutine(seconds));
    }

    IEnumerator StunRoutine(float seconds)
    {
        stunned = true;
        chasing = false;
        yield return new WaitForSeconds(seconds);
        stunned = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (stunned) return;
        if (other.CompareTag("Player"))
        {
            var courage = other.GetComponent<EmilyCourage>();
            if (courage != null) courage.LoseCourage(courageDamage);
        }
    }
}
