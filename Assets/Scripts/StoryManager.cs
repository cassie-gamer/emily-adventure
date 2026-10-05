using UnityEngine;
using UnityEngine.UI;

// Emily's quest stages:
// Intro (ship movie) -> FindAva -> FindParents -> Rescue (ship + house) -> Victory!
// Add to an empty GameObject called "StoryManager".
// Drag the story Text UI into storyText, and the EndingDirector into ending.
public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    public Text storyText;
    public RescueEnding ending;

    // -1 = intro movie playing, 0 = find Ava, 1 = find parents, 2 = ending, 3 = victory!
    private int stage = -1;

    void Awake()
    {
        Instance = this;
    }

    // Called by ShipIntro when the opening movie finishes
    public void BeginSearch()
    {
        stage = 0;
        ShowStory("Follow the twinkly fireflies to find Ava in the cave behind the waterfall! Watch out for tigers and snakes - wave your fire stick with F!");
    }

    public void FoundAva()
    {
        if (stage != 0) return;
        stage = 1;
        ShowStory("Yay! You found Ava! She hugs you tight. Now find the 3 clues to find Mommy and Daddy!");
    }

    public void FoundParents()
    {
        if (stage != 1) return;
        stage = 2;
        ShowStory("The family is together again! Look... a ship!");
        if (ending != null) ending.PlayEnding();
    }

    public void ShowVictory()
    {
        stage = 3;
        ShowStory("VICTORY! The ship brought Emily's family home safe!");
    }

    public bool IsLookingForAva() => stage == 0;
    public bool IsLookingForParents() => stage == 1;

    public void ShowStory(string message)
    {
        if (storyText != null) storyText.text = message;
        Debug.Log(message);
    }
}
