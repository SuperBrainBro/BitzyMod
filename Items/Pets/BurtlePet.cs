using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Pets
{
	public class BurtlePet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Burtle Pet");
			Tooltip.SetDefault("Summons a gullible turtle.");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Seaweed);
			item.shoot = ProjectileType<Projectiles.Pets.BurtleProj>();
			item.buffType = BuffType<Buffs.BurtleBuff>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{
			//position.Y -= 100;
			//return true;
		//}
	}
}