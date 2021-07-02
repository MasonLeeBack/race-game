using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

[Library("race-test", Title = "Race Game")]
partial class RaceGame : Game {
	
	public RaceGame()
	{
		Log.Warning( "Hello!" );
		if (IsServer)
		{
			new RaceHud();
		}
	}

	/// <summary>
	/// A client has joined the server. Make them a pawn to play with
	/// </summary>
	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var player = new MinimalPlayer();
		client.Pawn = player;

		player.Respawn();
	}
}
