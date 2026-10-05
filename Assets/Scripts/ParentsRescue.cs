using UnityEngine;

// Mom and Dad waiting in the dark forest
// Put them in a GameObject called "Parents", set it to Inactive at start
// Add this script, check "Is Trigger" on their collider
public class ParentsRescue : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!StoryManager.Instance.IsLookingForParents()) return;

        StoryManager.Instance.FoundParents();
        Debug.Log("Parents found! Family together!");
    }
}
