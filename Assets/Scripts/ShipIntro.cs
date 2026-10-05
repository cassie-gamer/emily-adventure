using UnityEngine;
using System.Collections;

// Plays the opening story: ship sailing -> storm -> sinking -> forest hut
// Add to an empty GameObject called "IntroDirector".
// Set up two groups in your scene: "ShipScene" (ship + sea + clouds) and
// "ForestScene" (everything for the forest, starts INACTIVE).
public class ShipIntro : MonoBehaviour
{
    [Header("Scene groups")]
    public GameObject shipScene;    // active at start
    public GameObject forestScene;  // inactive at start

    [Header("Ship animation")]
    public GameObject ship;
    public GameObject stormClouds;  // inactive at start
    public float sailTime = 4f;
    public float stormTime = 3f;
    public float sinkTime = 3f;
    public float sinkDepth = -6f;

    [Header("Narration (optional)")]
    public StoryNarrator narrator;
    // lines: 0 = ship, 1 = storm, 2 = sinking, 3 = forest hut

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        // Emily can't move during the movie
        var emily = FindObjectOfType<EmilyMover>();
        if (emily != null) emily.enabled = false;

        // Scene 1: the giant ship sails - "One day Emily went on a ship with her family..."
        if (narrator != null) narrator.PlayLine(0);
        Vector3 startPos = ship.transform.position;
        float t = 0f;
        while (t < sailTime)
        {
            t += Time.deltaTime;
            ship.transform.position = startPos + Vector3.right * t * 1.5f;
            yield return null;
        }

        // Scene 2: the storm comes
        if (narrator != null) narrator.PlayLine(1);
        if (stormClouds != null) stormClouds.SetActive(true);
        yield return new WaitForSeconds(stormTime);

        // Scene 3: the ship sinks!
        if (narrator != null) narrator.PlayLine(2);
        Vector3 sinkStart = ship.transform.position;
        Vector3 sinkEnd = sinkStart + new Vector3(0f, sinkDepth, 0f);
        t = 0f;
        while (t < sinkTime)
        {
            t += Time.deltaTime;
            float k = t / sinkTime;
            ship.transform.position = Vector3.Lerp(sinkStart, sinkEnd, k);
            ship.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, -25f, k));
            yield return null;
        }

        // Scene 4: wake up in the forest hut - the game begins!
        if (narrator != null) narrator.PlayLine(3);
        if (shipScene != null) shipScene.SetActive(false);
        if (forestScene != null) forestScene.SetActive(true);
        if (emily != null) emily.enabled = true;

        if (StoryManager.Instance != null)
            StoryManager.Instance.BeginSearch();
    }
}
