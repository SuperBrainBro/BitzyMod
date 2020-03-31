using Bitzy.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Projectiles.BossBitzy
{
	//ported from my tAPI mod because I'm lazy
	public class BossBitzyBulletProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.alpha = 255;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			//projectile.ranged = true;
		}

		public override void AI()
		{
			if (projectile.alpha > 70)
			{
				projectile.alpha -= 15;
				if (projectile.alpha < 70)
				{
					projectile.alpha = 70;
				}
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < Main.maxPlayers; k++)
			{
				if (Main.player[k].active && !Main.player[k].dead)
				{
					Vector2 newMove = Main.player[k].Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
			if (projectile.alpha <= 100)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<BitzyDust>());
				Main.dust[dust].velocity /= 2f;
			}
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
	}
}