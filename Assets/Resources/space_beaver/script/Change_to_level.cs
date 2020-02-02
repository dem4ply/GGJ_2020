using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using space_beaver.controller;

namespace space_beaver.stuff
{
	public class Change_to_level : chibi.Chibi_behaviour
	{
		public float time_to_change = 10f;
		public bool is_going_to_change = false;
		public string scene_path = "";

		public void prepare_to_change()
		{
			StartCoroutine( change_level() );
		}

		IEnumerator change_level()
		{
			yield return new WaitForSeconds( time_to_change );
			SceneManager.LoadScene( "Scenes/Nivel 2" );
		 }
	}
}
