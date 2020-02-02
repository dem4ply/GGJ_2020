using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using space_beaver.controller;

namespace space_beaver.stuff
{
	public class Pieces_check : chibi.Chibi_behaviour
	{
		public Piece_controller[] pieces;
		public UnityEvent when_closed_all_pieces = new UnityEvent();

		protected override void _init_cache()
		{
			base._init_cache();
			pieces = GameObject.FindObjectsOfType<space_beaver.controller.Piece_controller>();
		}

		protected void Update()
		{
			bool are_closed = pieces.All(
				( Piece_controller piece ) => piece.is_closed );
			if ( are_closed )
			{
				debug.log( "all pieces are closed" );
				when_closed_all_pieces.Invoke();
				enabled = false;
			}
		}

	}
}
