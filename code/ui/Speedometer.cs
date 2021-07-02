//
// This is just a protototype speedometer,
// after full implementation it'll be image with
// needle rotation
//
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class Speedometer : Panel {
	public Label speed;
	
	public Speedometer()
	{
		Add.Label("🚗", "icon");
		speed = Add.Label( "0 MPH", "value" );
	}
	
	public override void Tick()
	{
	    // To do: Get velocity of vehicle and convert from u/s to mph
		speed.Text = "69 MPH";
	}
}
