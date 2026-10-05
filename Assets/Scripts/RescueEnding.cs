using UnityEngine;
using System.Collections;

// The happy ending! After Emily finds Ava and Mom & Dad, a rescue ship arrives.
// Add to an empty GameObject called "EndingDirector".
// Set up: "ForestScene" (active during play), "HouseScene" (starts INACTIVE),
// a "RescueShip" object (starts INACTIVE, placed off to one side),
// and a UI Text "VictoryText" that says VICTORY! (starts INACTIVE).
public class RescueEnding : MonoBehaviour
{
    [Header("Scene groups")]
    public GameObject forestScene;
    public GameObject houseScene;
    public GameObject rescueShip;
    public GameObject victoryText;

    [Header("Narration (optional)")]
    public StoryNarrator narrator;
    public int victoryLine = 5; // "A ship found us! ... VICTORY!"

    public void PlayEnding()
    {
        StartCoroutine(EndingRoutine());
    }

    IEnumerator EndingRoutine()
    {
        // Freeze Emily - the adventure is over
        var emily = FindObjectOfType<EmilyMover>();
        if (emily != null) emily.enabled = false;

        // The rescue ship sails in!
        if (rescueShip != null) rescueShip.SetActive(true);
        if (narrator != null) narrator.PlayLine(victoryLine);

        Vector3 start = rescueShip.transform.position;
        float t = 0f;
        while (t < 4f)
        {
            t += Time.deltaTime;
            rescueShip.transform.position = start + Vector3.left * t * 2f;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        // Everyone boards... and now they're home!
        if (forestScene != null) forestScene.SetActive(false);
        if (rescueShip != null) rescueShip.SetActive(false);
        if (houseScene != null) houseScene.SetActive(true);
        if (victoryText != null) victoryText.SetActive(true);

        if (StoryManager.Instance != null)
            StoryManager.Instance.ShowVictory();
    }
}
