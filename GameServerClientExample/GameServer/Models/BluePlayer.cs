

using System.Drawing;
/**
* @(#) BluePlayer.cs
*/
namespace GameServer.Models
{
	
	public class BluePlayer : Player
	{
        public Color Color { get; set; }
        public BluePlayer()
        {
            Color = Color.FromKnownColor(KnownColor.Blue);
        }

    }
	
}
