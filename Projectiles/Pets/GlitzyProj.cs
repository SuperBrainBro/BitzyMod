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
			projectile.penetrate = 1;
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 1f;
			projectile.tileCollide = false;
			projectile.alpha = 100;
			projectile.light = 1.4f;
			projectile.aiStyle = 11;
		}
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 100);

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BitzyPlayer modPlayer = player.GetModPlayer<BitzyPlayer>();
			if (player.dead)
			{
				modPlayer.GlitzyPet = false;
			}
			if (modPlayer.GlitzyPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}