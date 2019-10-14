

using System.Drawing;
/**
* @(#) RedPlayer.cs
*/
namespace GameServer.Models
{
	
	public class RedPlayer : Player
	{
        public Color Color { get; set; }
        public RedPlayer()
        {
            Color = Color.FromKnownColor(KnownColor.Blue);
        }
    }
	
}
