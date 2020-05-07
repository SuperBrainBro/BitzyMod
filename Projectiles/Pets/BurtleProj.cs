using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bitzy.Projectiles.Pets
{
	public class BurtleProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Burtle");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Turtle);
			aiType = ProjectileID.Turtle;
			projectile.width = 116;
			projectile.height = 76;	
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			BitzyPlayer modPlayer = player.GetModPlayer<BitzyPlayer>();
			if (player.dead) {
				modPlayer.BurtlePet = false;
			}
			if (modPlayer.BurtlePet) {
				projectile.timeLeft = 2;
			}
		}
	}
}