using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSoundManager : MonoBehaviour {

	public static FxSoundManager Instance;
	public AudioSource fxSoundAudioSource;

	private void Awake() {
		Instance = this;

		if(fxSoundAudioSource == null){
			fxSoundAudioSource = gameObject.AddComponent<AudioSource>();
			fxSoundAudioSource.playOnAwake = false;
			fxSoundAudioSource.loop = false;
		}
	}
	public void PlayFxSound(Sound sound){
		fxSoundAudioSource.clip = sound.clip;
		fxSoundAudioSource.volume = sound.volume;
		fxSoundAudioSource.Play();
	} 
}
