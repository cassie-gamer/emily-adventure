using UnityEngine;
using UnityEngine.UI;

// Manages Emily's quest: Find Ava first, then find Mom and Dad
// Add to an empty GameObject called "StoryManager"
// Drag the story Text UI into storyText
public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    public Text storyText;

    private int stage = 0; // 0 = find Ava, 1 = find parents, 2 = won!

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShowStory("Hi! I'm Emily! Follow the twinkly fireflies to find my big sister Ava in the cave behind the waterfall!");
    }

    public void FoundAva()
    {
        if (stage != 0) return;
        stage = 1;
        ShowStory("Yay! You found Ava! She hugs you tight. Now together, follow the clues to find Mommy and Daddy in the dark forest!");
    }

    public void FoundParents()
    {
        if (stage != 1) return;
        stage = 2;
        ShowStory("You did it! Emily and Ava found Mommy and Daddy! The whole family is together again. The end!");
    }

    public bool IsLookingForAva()
    {
        return stage == 0;
    }

    public bool IsLookingForParents()
    {
        return stage == 1;
    }

    void ShowStory(string message)
    {
        if (storyText != null)
            storyText.text = message;
        Debug.Log(message);
    }
}
