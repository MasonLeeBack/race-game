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
		[ConVar.Replicated]
		public static float carcamera_above { get; set; } = 50.0f;

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

			// Get center position and distance
			var center = pawn.Position + Vector3.Up * carcamera_carheight;
			float distance = carcamera_distance * pawn.Scale;

			Vector3 targetPos;
			targetPos = center;
			targetPos += pawn.LocalRotation.Forward * -distance;

			// Smooth Z height, and adjust to look over car
			Pos = targetPos.WithZ(MathX.LerpTo(Pos.z, targetPos.z + 50, 10* Time.Delta));
			FieldOfView = carcamera_fov;

			// Look at center of car, and smooth turns (bug, when crossing over 360 degs, snaps back to 0 and causes a shake)
			Vector3 forward = (center - Pos);
			Rot = Rotation.Lerp( Rot, Rotation.LookAt( forward, Vector3.Up ), 20 * Time.Delta );

			Viewer = null;
		}
	}
}
