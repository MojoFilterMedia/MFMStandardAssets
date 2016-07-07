using UnityEngine;
using System.Collections;

public class Native : MonoBehaviour
{

    [SerializeField]
    private AudioClip clip;

    void OnTriggerEnter()
    {
        StartCoroutine(Play());
    }

    void OnTriggerExit()
    {
        StopCoroutine(Play());
    }

    private IEnumerator Play()
    {
        AudioSource.PlayClipAtPoint(clip, GetComponent<Transform>().position);
        yield return new WaitForSeconds(clip.length + 1);
    }

}
