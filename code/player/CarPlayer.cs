using Sandbox;

namespace RaceGame.Player
{
	public partial class CarPlayer : Sandbox.Player
	{
		public PhysicsBody body = new PhysicsBody();
		public override void Respawn()
		{
			base.Respawn();
			SetModel( "models/vehicles/gokart.vmdl" );
			body.Enabled = true;
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic, true );

			Controller = new CarController();
			Camera = new CarCamera();
		}

		public async void HandleMusic()
		{
			//PlaySound( "hardbass" );
			await Task.Delay( 216000 );
			//HandleMusic();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			SimulateActiveChild( cl, ActiveChild );
		}

	}
}
