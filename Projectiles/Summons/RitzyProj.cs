using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bitzy.Projectiles.Summons
{
	public class RitzyProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ritzy");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.BabySlime);
			aiType = ProjectileID.BabySlime;
			projectile.width = 32;
			projectile.height = 32;
			projectile.minion = true;
			projectile.friendly = true;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			return true;
		}

		//public override void AI() {
			//Player player = Main.player[projectile.owner];
			//BitzyPlayer modPlayer = player.GetModPlayer<BitzyPlayer>();
			//if (player.dead) {
				//modPlayer.Ritzy = false;
			//}
			//if (modPlayer.Ritzy) {
				//projectile.timeLeft = 2;
			//}
		//}
	}
}