using UnityEngine;
using UnityEngine.UI;

// Emily's courage (her hearts). A tiger or snake touch makes her lose 1.
// Add to Emily, drag a UI Text into courageText.
// When courage hits 0, Emily gets scared and runs back to the hut to try again.
public class EmilyCourage : MonoBehaviour
{
    public int maxCourage = 3;
    public Text courageText;

    // Set this to your hut's position in the Inspector
    public Vector3 hutPosition = new Vector3(0f, 0.5f, 0f);

    private int courage;

    void Start()
    {
        courage = maxCourage;
        UpdateUI();
    }

    public void LoseCourage(int amount)
    {
        courage -= amount;
        UpdateUI();

        if (courage <= 0)
        {
            courage = maxCourage;
            UpdateUI();
            transform.position = hutPosition; // back to safety!
            if (StoryManager.Instance != null)
                StoryManager.Instance.ShowStory("Oh no! Emily got scared and ran back to the hut. Be brave and try again!");
        }
    }

    public void AddCourage(int amount)
    {
        courage = Mathf.Min(maxCourage, courage + amount);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (courageText != null)
        {
            string hearts = "";
            for (int i = 0; i < courage; i++) hearts += "♥";
            courageText.text = "Courage: " + hearts;
        }
    }
}
