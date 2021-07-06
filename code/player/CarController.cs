using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Numerics;

namespace RaceGame.Player
{
	public partial class CarController : BasePlayerController
	{
		// Stats (to be moved to CarSelection/CarStats)
		public float Acceleration = 1000.0f;
		public float ReverseAcceleration = 200.0f;
		public float TurnDamping = 0.9f;

		// Input
		private float accel = 0.0f;
		private float turn = 0.0f;

		private float turnstuff;

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

		private float accelCurve = 0.0f;

		/// <summary>
		/// Accelerates/decelerates vehicle based off of input, and checks for collision and hills.
		/// </summary>
		void MoveVehicle()
		{
			// to do: gyro balance to keep vehicle vertical, slope handling/deceleration
			// and collision detection for hitting front/back so car doesn't keep accelerating into obj

			CarPlayer player = Pawn as CarPlayer;
			if ( player == null )
				return;

			turnstuff =  MathX.LerpTo( turnstuff, turn * -50, Time.Delta * 2 );
			Rotation *= Rotation.FromAxis( Vector3.Up, turnstuff) * Time.Delta;

			accelCurve = MathX.LerpTo( accelCurve, 1000 * accel, Time.Delta );

			player.PhysicsBody.Velocity += (new Vector3(1,1,1) * accelCurve);

			Position += Rotation.Forward * player.PhysicsBody.Velocity * Time.Delta;
		}

		
		/// <summary>
		/// This event will be called whenever the car crashes into an object, and disables
		/// acceleration if it's on front/back of vehicle.
		/// </summary>
		/// <param name="collisionPoint">Point of impact</param>
		[Event("racegame.crash")]
		public void OnCrash(Vector3 collisionPoint)
		{

		}

		public override void Simulate()
		{
			base.Simulate();

			DoInput();
			MoveVehicle();
		}

		public override void FrameSimulate()
		{
			base.FrameSimulate();

			if ( carcontroller_debug )
			{
				DebugOverlay.ScreenText( 10, "  CAR STATS  " );
				DebugOverlay.ScreenText( 11, $"    Position: {Position}" );
				DebugOverlay.ScreenText( 12, $"    Rotation: {Rotation}" );
				DebugOverlay.ScreenText( 13, $"    VphysRot: {(Pawn as CarPlayer).PhysicsBody.Rotation}" );
			}

		}
	}
}
