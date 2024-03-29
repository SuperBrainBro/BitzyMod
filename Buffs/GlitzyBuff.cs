using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Buffs
{
	public class GlitzyBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Glitzy");
			Description.SetDefault("Harmless!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<BitzyPlayer>().GlitzyPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.GlitzyProj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.GlitzyProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}