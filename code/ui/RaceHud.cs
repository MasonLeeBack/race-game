using Sandbox;
using Sandbox.UI;

[Library]
public partial class RaceHud : HudEntity<RootPanel>
{
	public RaceHud() {
		// Only load on client-side
		if (!IsClient)
			return;
		
		RootPanel.StyleSheet.Load("/ui/RaceHud.scss");
		
		RootPanel.AddChild<Speedometer>();
		RootPanel.AddChild<ChatBox>();
	}
}
