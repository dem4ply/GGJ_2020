using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using space_beaver.motor;

namespace space_beaver.controller
{
	public class Piece_controller : chibi.controller.Controller_motor
	{
		public Transform home;
		public Piece_controller left, right;
		public bool is_right_leaf = true;
		public bool is_left_leaf = true;
		public VrGrabber.VrgGrabber grabber;

		public sound.Sound attach;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !home )
				debug.error( "la piesa no tiene home" );

			prepare_motor();

			grabber = GameObject.FindObjectOfType<VrGrabber.VrgGrabber>();
			if ( !grabber )
				debug.error( "no tiene el grabber asignado" );
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
			if ( grabber )
				grabber.Release();
		}

		public void on_home()
		{
			if ( !motor_piece.stay_in_home )
			{
				debug.log( "on home" );
				close();
				if ( left )
					left.close();
				if ( right )
					right.close();
				if ( attach )
					attach.play();
			}
			motor_piece.motor_own_physics = false;
			motor_piece.use_gravity = false;
			motor_piece.stay_in_home = true;
			motor_piece.enable_coliders = false;

			steering.enabled = false;
			Destroy( steering );

		}

		public void on_grab()
		{
			motor_piece.motor_own_physics = true;
			motor_piece.use_gravity = true;
			motor_piece.stay_in_home = false;
			motor_piece.enable_coliders = true;
		}

		private void OnTriggerEnter( Collider other )
		{
			if ( other.transform == home )
			{
				motor_piece.motor_own_physics = true;
				motor_piece.clean_gravity();
				go_home();
			}
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
				motor_piece = GetComponent<Piece_motor>();
			if ( !motor_piece )
				debug.error( "no tiene un piece motor" );
			else
			{
				motor_piece.home = home;
			}
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

		public void close()
		{
			debug.log( "close" );
		}

		public void open()
		{
			debug.log( "open" );
		}
		protected void OnDrawGizmos()
		{
			if ( left )
				helper.draw.arrow.gizmo(
					transform.position, left.transform.position - transform.position,
					Color.black);

			if ( right )
				helper.draw.arrow.gizmo(
					transform.position, right.transform.position - transform.position,
					Color.blue );
		}
	}
}
