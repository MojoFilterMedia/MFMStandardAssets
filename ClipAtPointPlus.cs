using UnityEngine;
using System.Collections;

public class ClipAtPointPlus
{
    //ClipAtPointPlus by Chase Harris - MojoFilter Media
    //Version 0.1.0

    //Useage:
    //This was made to solve some of the issues encountered with PlayClipAtPoint, namely that it couldn't be used with the built-in Unity audio mixers.
    //
    //For example useage, see comments at end
    //
    //All the parameters from AudioSource that would realistically be needed are present.
    //Notice that things like "loop" are missing - this is a safety measure. You don't want to loop an AudioSource you don't have further access to. 
    //If you want it to loop, put it in a coroutine that will .Play() every (AudioClip.length)

    //Call this to play the clip at the point!
    public void Play(AudioClip clip, Vector3 playPosition,  //<- these are required parameters
        bool bypassEffects = false,                         //all the rest are optional
        bool bypassListenerEffects = false,
        bool bypassReverbZones = false,
        float dopplerLevel = 1.0f,
        bool ignoreListenerPause = false,
        bool ignoreListenerVolume = false,
        float maxDistance = 100f,
        float minDistance = 1.0f,
        UnityEngine.Audio.AudioMixerGroup outputAudioMixerGroup = null,
        float panStereo = 0.0f,
        float pitch = 1.0f,
        int priority = 128,
        float reverbZoneMix = 1.0f,
        AudioRolloffMode rolloffmode = AudioRolloffMode.Logarithmic,
        float spatialBlend = 1f,
        float spread = 0f,
        float volume = 1f)
    {
        GameObject soundObject = new GameObject ("tempSound");
        soundObject.transform.position = playPosition;
        AudioSource audioSource = soundObject.AddComponent<AudioSource> ();

        audioSource.bypassEffects = bypassEffects;
        audioSource.bypassListenerEffects = bypassListenerEffects;
        audioSource.bypassReverbZones = bypassReverbZones;
        audioSource.clip = clip;
        audioSource.dopplerLevel = dopplerLevel;
        audioSource.ignoreListenerPause = ignoreListenerPause;
        audioSource.ignoreListenerVolume = ignoreListenerVolume;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = minDistance;
        audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
        audioSource.panStereo = panStereo;
        audioSource.pitch = pitch;
        audioSource.priority = priority;
        audioSource.reverbZoneMix = reverbZoneMix;
        audioSource.rolloffMode = rolloffmode;
        audioSource.spatialBlend = spatialBlend;
        audioSource.spread = spread;
        audioSource.volume = volume;

        audioSource.Play ();
        MonoBehaviour.Destroy (soundObject, clip.length + 0.01f);
    }
    //
    //Example (same as PlayClipAtPoint, but assigns to a mixer group called "ExampleGroup":
    //
    //void SomeFunction ()
    //{
    //    var source = new ClipAtPointPlus();
    //    source.Play (exampleClip, exampleTransform.position, exampleOptionalParameter: value);
    //{
}
