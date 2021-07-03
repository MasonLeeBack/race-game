using Sandbox;

namespace RaceGame.Player
{
	public partial class CarPlayer : Sandbox.Player
	{
		public override void Respawn()
		{
			base.Respawn();
			SetModel( "models/vehicles/car.vmdl" );
			// Temporart - link to CarController class for pawn
			Controller = new CarController();
			// Temporary - create CarCamera class
			Camera = new CarCamera();
			
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			SimulateActiveChild( cl, ActiveChild );
		}

	}
}
