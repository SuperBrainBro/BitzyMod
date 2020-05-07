using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Buffs
{
	public class BurtleBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Burtle Pet");
			Description.SetDefault("A gullible little pet turtle!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<BitzyPlayer>().BurtlePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.BurtleProj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y, 0f, 0f, ProjectileType<Projectiles.Pets.BurtleProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}