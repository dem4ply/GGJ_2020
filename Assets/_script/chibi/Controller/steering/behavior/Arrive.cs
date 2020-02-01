using UnityEngine;
using chibi.controller.handler;

namespace chibi.controller.steering.behavior
{
	[CreateAssetMenu( menuName = "chibi/steering/behavior/arrive" )]
	public class Arrive : Behavior
	{
		public float deacceleration_distant = 0.05f;

		public override Vector3 desire_direction(
			Steering controller, Transform target,
			Steering_properties properties )
		{
			var ds = desire_speed( controller, target, properties );
			if ( ds == 0f )
				return Vector3.zero;
			var direction = seek( controller, target.position );
			direction.Normalize();
			debug( controller.controller, target, direction );
			return direction.normalized;
		}

		public override float desire_speed(
			Steering controller, Transform target,
			Steering_properties properties )
		{
			var distance = target.position - controller.transform.position;
			if ( distance.magnitude < deacceleration_distant )
			{
				if ( distance.magnitude < 0.1f )
				{
					var c = controller.controller as space_beaver.controller.Piece_controller;
					if ( c )
						c.on_home();
					return 0f;
				}

			}
			return 1f;
		}

		public virtual void debug(
			Controller controller, Transform target, Vector3 direction )
		{
			controller.debug.draw.arrow( direction, seek_color );
		}
	}
}
