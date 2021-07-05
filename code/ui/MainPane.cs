//
// This is just a protototype speedometer,
// after full implementation it'll be image with
// needle rotation
//
using RaceGame.Player;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;


public class MainPane : Panel
{
	public MainPane()
	{
		SetTemplate( "code/ui/mainpane.html" );
		StyleSheet.Load( "code/ui/mainpane.scss" );
		SetClass( "mainpane", true );
	}
}
