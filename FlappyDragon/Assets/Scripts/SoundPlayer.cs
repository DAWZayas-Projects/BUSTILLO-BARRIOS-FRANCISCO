using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public TypeofSound typeofSound;
	public Sound sound;
	public enum TypeofSound{
		Music, EffectSound
	}
	public static GameObject backgroundMusicObject;
	
	private void Start () {
		if(typeofSound == TypeofSound.Music){
			BackgroundSoundManager.Instance.PlayMusic(sound);
		}
	}

	public void PlayFxSound(){
		FxSoundManager.Instance.PlayFxSound(sound);
	}

}
