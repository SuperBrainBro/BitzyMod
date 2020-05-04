using Bitzy.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace Bitzy.Projectiles.Pets
{
	public class GlitzyProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glitzy");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;		
		}

		public override void SetDefaults() {
			projectile.width = 48;
			projectile.height = 48;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 1f;
			projectile.tileCollide = false;
			projectile.alpha = 200;
			projectile.light = 1.4f;
			projectile.aiStyle = 11;
		}

		private const int fadeInTicks = 100;
		private const int fullBrightTicks = 200;
		private const int fadeOutTicks = 100;
		private const int range = 100;
		private readonly int rangeHypoteneus = (int)Math.Sqrt(range * range + range * range);

		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);

		
		/*
		public override void AI() {
			Player player = Main.player[projectile.owner];
			BitzyPlayer modPlayer = player.GetModPlayer<BitzyPlayer>();
			if (!player.active) {
				projectile.active = false;
				return;
			}
			if (player.dead) {
				modPlayer.GlitzyPet = false;
			}
			if (modPlayer.GlitzyPet) {
				projectile.timeLeft = 2;
			}
			projectile.ai[1]++;
			if (projectile.ai[1] > 2000 && (int)projectile.ai[0] % 100 == 0) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Main.npc[i].active && !Main.npc[i].friendly && player.Distance(Main.npc[i].Center) < rangeHypoteneus) {
						Vector2 vectorToEnemy = Main.npc[i].Center - projectile.Center;
						projectile.velocity += 5f * Vector2.Normalize(vectorToEnemy);
						projectile.ai[1] = 0f;
						break;
					}
				}
			}
			//projectile.rotation += projectile.velocity.X / 20f;

			if (projectile.velocity.Length() > 1f) {
				projectile.velocity *= .98f;
			}
			if (projectile.velocity.Length() == 0) {
				projectile.velocity = Vector2.UnitX.RotatedBy(Main.rand.NextFloat() * Math.PI * 2);
				projectile.velocity *= 2f;
			}
			projectile.ai[0]++;
			if (projectile.ai[0] < fadeInTicks) {
				projectile.alpha = (int)(255 - 255 * projectile.ai[0] / fadeInTicks);
			}
			else if (projectile.ai[0] < fadeInTicks + fullBrightTicks) {
				projectile.alpha = 0;
				if (Main.rand.NextBool(6)) {
					int num145 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<BitzyDust>());
					Main.dust[num145].velocity *= 0.3f;
				}
			}
			else if (projectile.ai[0] < fadeInTicks + fullBrightTicks + fadeOutTicks) {
				projectile.alpha = (int)(255 * (projectile.ai[0] - fadeInTicks - fullBrightTicks) / fadeOutTicks);
			}
			else {
				projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
				projectile.ai[0] = 0;
				Vector2 vectorToPlayer = player.Center - projectile.Center;
				projectile.velocity = 2f * Vector2.Normalize(vectorToPlayer);
			}
			if (Vector2.Distance(player.Center, projectile.Center) > rangeHypoteneus) {
				projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
				projectile.ai[0] = 0;
				Vector2 vectorToPlayer = player.Center - projectile.Center;
				projectile.velocity += 2f * Vector2.Normalize(vectorToPlayer);
			}
			if ((int)projectile.ai[0] % 100 == 0) {
				projectile.velocity = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90));
			}
		}
		*/
	}
}