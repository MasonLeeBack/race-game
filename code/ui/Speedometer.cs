//
// This is just a protototype speedometer,
// after full implementation it'll be image with
// needle rotation
//
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;


public class Speedometer : Panel {
	public float speed = 4.0f;
	public string Speed => $"{Local.Pawn.Velocity.Cross(Vector3.Up).Length * 0.0254f * 2.23694f:0} MPH";

	public Speedometer()
	{
		SetTemplate("code/ui/speedometer.html");
		StyleSheet.Load("code/ui/gamehud.scss");
		SetClass("speedometer", true);

	
	}
	public override void Tick()
	{
		base.Tick();

	}
}
