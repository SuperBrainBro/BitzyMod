using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bitzy.Dusts
{
	public class BitzyDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.color = new Color(255, 255, 255);
			dust.scale = 1.2f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.alpha = 100;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.1f, 0.1f, 0.1f);
			dust.scale -= 0.0175f;
			if (dust.scale < 0.4f) {
				dust.active = false;
			}
			return false;
		}
	}
}