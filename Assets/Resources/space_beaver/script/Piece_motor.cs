using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace space_beaver.motor
{
	public class Piece_motor : chibi.motor.Motor
	{
		public Transform home;
		public bool stay_in_home = false;
		protected bool _motor_own_physics = false;
		protected Collider[] colliders;

		public bool motor_own_physics
		{
			get {
				return _motor_own_physics;
			}
			set {
				_motor_own_physics = value;
				use_gravity = !motor_own_physics;
				enable_coliders = !motor_own_physics;
			}
		}

		public bool enable_coliders
		{
			set {
				foreach ( var collider in colliders )
					collider.enabled = value;
			}
		}


		public bool use_gravity
		{
			set {
				var r = GetComponent<Rigidbody>();
				r.useGravity = value;
			}
		}

		protected override void _proccess_gravity( ref Vector3 velocity_vector )
		{
			//base._proccess_gravity( ref velocity_vector );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			colliders = GetComponents<Collider>();
		}

		protected override void update_motion()
		{
			if ( motor_own_physics )
			{
				use_gravity = false;
				base.update_motion();
				var distant_to_home = Vector3.Distance( transform.position, home.position );
				transform.rotation = Quaternion.Lerp( transform.rotation, home.rotation, 1 / distant_to_home );
			}
			if ( stay_in_home )
			{
				var r = GetComponent<Rigidbody>();
				r.velocity = Vector3.zero;
			}
		}

		protected void Update()
		{
			if ( stay_in_home )
			{
				//debug.log( "c {0}", transform.position );
				//debug.log( "h {0}", home.position );
				transform.position = home.position;
				transform.rotation = home.rotation;
				//debug.log( "p {0}", transform.position );
			}
		}

		public void clean_gravity()
		{
				var r = GetComponent<Rigidbody>();
				r.velocity = new Vector3( r.velocity.x, 0, r.velocity.z );
		}

		protected void OnDrawGizmos()
		{
			if ( home && !stay_in_home  )
			{
				helper.draw.arrow.gizmo(
					transform.position, home.transform.position - transform.position, Color.green );
			}
		}
	}
}
