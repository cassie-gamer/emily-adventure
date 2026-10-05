using UnityEngine;

// Reads the story aloud, one line per scene.
// Add to the "IntroDirector" object. In the Inspector, drag your recorded
// voice AudioClips into the Lines array in this order:
// 0: "One day Emily went on a ship with her family..."
// 1: storm, 2: sinking, 3: forest hut, 4: Ava's cave, 5: victory!
public class StoryNarrator : MonoBehaviour
{
    public AudioClip[] lines;

    private AudioSource source;

    void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void PlayLine(int index)
    {
        if (lines == null || index < 0 || index >= lines.Length) return;
        if (lines[index] == null) return;
        source.Stop();
        source.clip = lines[index];
        source.Play();
    }

    public void Stop()
    {
        if (source != null) source.Stop();
    }
}
