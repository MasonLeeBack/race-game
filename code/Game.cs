using RaceGame.Player;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RaceGame
{
	[Library( "race-test", Title = "Race Game" )]
	partial class RaceGame : Game
	{

		public RaceGame()
		{
			Log.Warning( "Hello!" );
			if ( IsServer )
			{
				new RaceHud();
			}
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			// To do: after Client is joined, don't spawn in CarPlayer until the race begins.
			base.ClientJoined( client );

			var player = new CarPlayer();
			client.Pawn = player;

			player.Respawn();
			player.HandleMusic();
		}
	}

}
