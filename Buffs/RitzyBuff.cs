using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Buffs
{
	public class RitzyBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Ritzy");
			Description.SetDefault("Harmfull!");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<BitzyPlayer>().Ritzy = true;
			bool projectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Summons.RitzyProj>()] <= 0;
			if (projectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Summons.RitzyProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}