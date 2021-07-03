using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Numerics;

namespace RaceGame.Player
{
	public partial class CarController : BasePlayerController
	{
		// Input
		private float accel = 0.0f;
		private float turn = 0.0f;

		[ConVar.Replicated]
		public static bool carcontroller_debug { get; set; } = false;

		/// <summary>
		/// Grab input from the InputSystem and translate it into floats to use.
		/// </summary>
		void DoInput()
		{
			accel = (Input.Down( InputButton.Forward ) ? 1.0f : 0.0f) + (Input.Down( InputButton.Back ) ? -1.0f : 0.0f);
			turn = (Input.Down( InputButton.Left ) ? -1.0f : 0.0f) + (Input.Down( InputButton.Right ) ? 1.0f : 0.0f);
		}

		void MoveVehicle()
		{
			Rotation *= Rotation.FromAxis( new Vector3( 0f, 0f, 1f ), turn*-50 * Time.Delta );

			var accelCurve = MathX.LerpTo( Velocity.x, 1000 * accel, Time.Delta );

			WishVelocity = accelCurve;
			Velocity = BaseVelocity + WishVelocity;

			Position += Rotation.Forward * Velocity * Time.Delta;
		}

		public override void Simulate()
		{
			base.Simulate();

			DoInput();
			MoveVehicle();
		}
		public override void FrameSimulate()
		{

			if ( carcontroller_debug )
			{
				DebugOverlay.ScreenText( 0, $"    Position: {Position}" );
				DebugOverlay.ScreenText( 1, $"    Velocity: {Velocity}" );
				DebugOverlay.ScreenText( 2, $"WishVelocity: {WishVelocity}" );
				DebugOverlay.ScreenText( 3, $"BaseVelocity: {BaseVelocity}" );
			}

		}
	}
}
