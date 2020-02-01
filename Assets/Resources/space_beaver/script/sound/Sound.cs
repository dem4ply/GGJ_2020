using UnityEngine;

namespace space_beaver.sound
{
	[CreateAssetMenu( menuName = "space_beaver/sound" )]
	public class Sound : chibi.Chibi_object
	{
		public AudioSource audio;

		public void play()
		{
			if ( audio )
				audio.Play();
		}
	}

}
