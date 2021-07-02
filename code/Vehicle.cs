using Sandbox;

[Library("ent_vehicle", Title = "Vehicle", Spawnable = true)]
[Hammer.EditorModel("models/vehicles/car.vmdl")]
public partial class Vehicle : Prop, IPhysicsUpdate, IUse {

	public string ModelPath => "models/vehicles/car.vmdl";
	public bool InUse {get; set;} = false;
	public Entity currentUser;

	public override void Spawn()
	{
		base.Spawn();
		SetModel( ModelPath );
	}

	public bool IsUsable(Entity user)
	{
		if (InUse == false) {
			return true;
		}
		
		// Check to see if the current driver is
		// the one requesting
		if (user == currentUser) {
			return true;
		}
		
		return false;
	}

	void IPhysicsUpdate.OnPostPhysicsStep(float dt)
	{

	}
	
	public bool OnUse(Entity user)
	{
		Log.Info( "Player trying to use vroom" );
		if (user == currentUser) {
			InUse = true;
			currentUser = null;
			return true;
		}

		return false;
	}
	
	private void SetCharacterInVehicle(bool bActive) {
		// Set camera for behind vehicle (also can allow for
		// first-person if VehicleCamera says it is supported)
	}
	
	private void CalcCamera()
	{
		// If the camera is third-person, make sure it's not completely locked onto
		// the rotation of the vehicle on the Y axis. 
	}
}
