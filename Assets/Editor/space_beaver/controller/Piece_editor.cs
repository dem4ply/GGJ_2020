using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using space_beaver.controller;

namespace space_beaver.editor.controller.wagon
{
	[CustomEditor( typeof( Piece_controller ), true )]
	public class Piece_editor : chibi.editor.Chibi_behavior_editor
	{
		protected Piece_controller piece;

		public override void OnInspectorGUI()
		{
			if ( GUILayout.Button( "go_home"  ) )
			{
				if ( EditorApplication.isPlaying )
				{
					piece.go_home();
				}
			}
			base.OnInspectorGUI();
		}

		private void OnEnable()
		{
			piece = ( Piece_controller )target;
		}
	}
}
