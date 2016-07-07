using UnityEngine;
using System.Collections;

public class RandomSound : MonoBehaviour
{
    //RandomSound by Chase Harris - MojoFilter Media
    //Version 0.0.1

    //Useage:
    //Fairly self-explanatory. Place this script on any gameobject, and fill in the fields in the inspector.
    //This scrip uses Resources, so make sure all of your audio files are located accordingly.
    [SerializeField]
    private float probability = 0.5f;
    [SerializeField]
    private float timeInSeconds = 1.0f;
    [SerializeField]
    private string resourcesPath;
    [SerializeField]
    private float volume = 1.0f;

    [SerializeField]
    private bool attachToParent; //somehow it needs to be indicated in the UI that this and fixedLocation are mutually exclusive - maybe a radio button is a better UI option
    [SerializeField]
    private bool constant;
    [SerializeField]
    private bool fixedLocation;
    [SerializeField]
    private float xmin = 0f;
    [SerializeField]
    private float xmax = 0f;
    [SerializeField]
    private float ymin = 0f;
    [SerializeField]
    private float ymax = 0f;
    [SerializeField]
    private float zmin = 0f;
    [SerializeField]
    private float zmax = 0f;

    private float n;
    private AudioClip[] audioClips;
    private AudioClip currentClip;

    private Transform location;

    void Start()
    {
        audioClips = Resources.LoadAll<AudioClip> (resourcesPath);
        StartCoroutine (RandomSoundCoroutine ());
    }

    private IEnumerator RandomSoundCoroutine()
    {
        while (true)
        {
            n = Random.Range (0.0f, 1.0f);
            if (attachToParent)
            {
                location = GetComponentInParent<Transform>();
            }
            else if (fixedLocation)
            {
                location = transform;
            }
            else
            {
                location.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), Random.Range(zmin, zmax));
            }

            if (n < probability && !constant)
            {
                PlayRandomClip();
            }
            if (constant)
            {
                PlayRandomClip();
                timeInSeconds = currentClip.length;
            }
            yield return new WaitForSeconds (timeInSeconds);
        }
    }

    private void PlayRandomClip()
    {
        currentClip = audioClips[(int)Random.Range(0, audioClips.Length - 1)];
//        AudioSource.PlayClipAtPoint(currentClip, location.position, volume);      //Native Unity Implementation
        var source = new ClipAtPointPlus();                                             //<- ClipAtPointPlus implementation
        source.Play(currentClip, location.position, volume: volume, maxDistance: 25);   //<-
    }
}