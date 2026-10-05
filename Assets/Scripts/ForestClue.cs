using UnityEngine;

// A story clue in the dark forest (Dad's hat, Mom's scarf, footprints)
// Add to small objects, check "Is Trigger". Only works after Ava is found.
public class ForestClue : MonoBehaviour
{
    [TextArea]
    public string clueMessage = "This is Daddy's hat! They went this way!";

    public float spinSpeed = 45f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!StoryManager.Instance.IsLookingForParents()) return;

        // Show the clue story
        if (StoryManager.Instance.storyText != null)
            StoryManager.Instance.storyText.text = clueMessage;

        Debug.Log("Clue found: " + clueMessage);
        gameObject.SetActive(false);

        // Check if all clues found
        var remaining = GameObject.FindObjectsOfType<ForestClue>();
        int activeLeft = 0;
        foreach (var c in remaining)
            if (c.gameObject.activeSelf) activeLeft++;

        if (activeLeft == 0)
        {
            // All clues found - parents appear!
            var parents = GameObject.Find("Parents");
            if (parents != null)
                parents.SetActive(true);
        }
    }
}
