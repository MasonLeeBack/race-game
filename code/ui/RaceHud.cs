using Sandbox;
using Sandbox.UI;

[Library]
public partial class RaceHud : HudEntity<RootPanel>
{
	public RaceHud() {
		// Only load on client-side
		if (!IsClient)
			return;
		
		RootPanel.StyleSheet.Load("/ui/mainpane.scss");
		
		RootPanel.AddChild<MainPane>();
		RootPanel.AddChild<ChatBox>();
	}
}
