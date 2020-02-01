using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using space_beaver.motor;

namespace space_beaver.controller
{
	public class Piece_controller : chibi.controller.Controller_motor
	{
		public Transform home;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !home )
				debug.error( "la piesa no tiene home" );

			prepare_motor();
		}

		public Piece_motor motor_piece
		{
			get {
				var result = motor as Piece_motor;
				return result;
			}
			set {
				motor = value;
			}
		}

		public void go_home()
		{
			seek( home );
		}

		public void on_home()
		{
			motor_piece.motor_own_physics = false;
			motor_piece.use_gravity = false;
			motor_piece.stay_in_home = true;
			motor_piece.enable_coliders = false;
		}

		private void OnTriggerEnter( Collider other )
		{
			motor_piece.motor_own_physics = true;
			motor_piece.clean_gravity();
			go_home();
		}

		public chibi.controller.steering.Steering steering
		{
			get {
				var steering = GetComponent<
					chibi.controller.steering.Steering>();
				if ( !steering )
				{
					steering = gameObject.AddComponent<
						chibi.controller.steering.Steering>();
					steering.controller = this;
				}
				return steering;
			}
		}

		public virtual void prepare_motor()
		{
			if ( !motor_piece )
				motor_piece = find_child_platforms();
			if ( !motor_piece )
				motor_piece = GetComponent<Piece_motor>();
			if ( !motor_piece )
				debug.error( "no tiene un platform motor" );
			else
			{
				motor_piece.home = home;
			}
		}

		public virtual Piece_motor find_child_platforms()
		{
			Piece_motor motor = null;

			if ( transform.childCount < 1 )
			{
				debug.warning( "la plataforma no tiene hijos" );
			}
			else
			{
				Transform platform = transform.GetChild( 0 );
				motor = platform.GetComponent<Piece_motor>();
			}
			return motor;
		}

		public void seek( Transform target )
		{
			var seek = chibi.controller.steering.behavior.Arrive.CreateInstance<
				chibi.controller.steering.behavior.Arrive>();
			steering.target = target;
			steering.behaviors.Clear();
			steering.behaviors.Add( seek );
			steering.reload();
		}

		protected void OnDrawGizmos()
		{
			if ( home )
			{
				helper.draw.arrow.gizmo(
					transform.position, home.transform.position - transform.position, Color.green );
			}
		}

	}
}
