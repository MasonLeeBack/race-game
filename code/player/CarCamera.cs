using Sandbox;
using System;

namespace RaceGame.Player
{

	public class CarCamera : Camera
	{
		[ConVar.Replicated]
		public static float carcamera_fov { get; set; } = 90.0f;
		[ConVar.Replicated]
		public static float carcamera_distance { get; set; } = 1000.0f;
		[ConVar.Replicated]
		public static float carcamera_carheight { get; set; } = 64.0f;

		public CarCamera()
		{
			// to do: grab from settings
			carcamera_fov = 90.0f;
			carcamera_distance = 300.0f;

			// Different vehicles will need different height adjustments- keep this in mind.
			carcamera_carheight = 64.0f;
		}

		public override void Update()
		{
			var pawn = Local.Pawn as AnimEntity;

			if ( pawn == null )
				return;

			Pos = pawn.Position;
			var center = pawn.Position + Vector3.Up * carcamera_carheight;
			Pos = center;
			float distance = carcamera_distance * pawn.Scale;
			
			

			Vector3 targetPos;
			targetPos = Pos;
			targetPos += pawn.LocalRotation.Forward * -distance;
			targetPos += new Vector3( 0, 0, 50 );

			Pos = targetPos;
			FieldOfView = carcamera_fov;

			Vector3 forward = (center - Pos);
			Rot = Rotation.LookAt( forward, Vector3.Up );

			Viewer = null;
		}
	}
}
