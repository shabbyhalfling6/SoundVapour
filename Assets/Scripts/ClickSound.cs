using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour

{
    public AudioClip sound;
	private AudioSource source;
	public string selectedMenuOption;
	public string prevSelectedMenuOption;

    // Use this for initialization

    void Start()
    {
		source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        source.clip = sound;
    }

	void Update()
	{
		if (PlayHoverSoundOnSelection ("Play")) 
		{
			PlayHoverSound ();
		}
		if (PlayHoverSoundOnSelection ("Options")) 
		{
			PlayHoverSound ();
		}
		if (PlayHoverSoundOnSelection ("Credits")) 
		{
			PlayHoverSound ();
		}
		if (PlayHoverSoundOnSelection ("Quit")) 
		{
			PlayHoverSound ();
		}

		prevSelectedMenuOption = selectedMenuOption;
	}

	bool PlayHoverSoundOnSelection (string ifSelectedOption)
	{
		selectedMenuOption = MenuDial.selectedOption;
		if (ifSelectedOption == prevSelectedMenuOption) 
		{
			return false;
		} 
		if (ifSelectedOption == selectedMenuOption) 
		{
			return true;
		} 
		return false;
	}

	public void PlayHoverSound()
	{
		source.PlayOneShot(sound);
	}
}