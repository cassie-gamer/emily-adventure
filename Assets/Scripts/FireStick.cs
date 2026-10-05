using UnityEngine;

// Emily's fire stick! Wave it to scare away tigers and snakes for a few seconds.
// Add to Emily. Press F on keyboard, or call UseFireStick() from a UI button on mobile.
// Tip: show the cooldown on a UI bar with CooldownLeft / CooldownTotal.
public class FireStick : MonoBehaviour
{
    [Header("Fire stick")]
    public float stunRadius = 4f;  // how close a danger must be to get stunned
    public float stunTime = 3f;     // how long dangers stay stunned
    public float cooldown = 5f;     // wait this long between uses

    private float cooldownLeft = 0f;

    public float CooldownLeft => cooldownLeft;
    public float CooldownTotal => cooldown;

    void Update()
    {
        if (cooldownLeft > 0f) cooldownLeft -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
            UseFireStick();
    }

    public void UseFireStick()
    {
        if (cooldownLeft > 0f) return; // still cooling down!
        cooldownLeft = cooldown;

        var dangers = FindObjectsOfType<ForestDanger>();
        foreach (var d in dangers)
        {
            if (Vector3.Distance(transform.position, d.transform.position) <= stunRadius)
                d.Stun(stunTime);
        }

        Debug.Log("Fire stick whoosh! Nearby dangers are stunned!");
    }
}
