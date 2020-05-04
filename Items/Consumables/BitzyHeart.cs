using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Consumables
{
	internal class BitzyHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 2\nUp to 20 can be used");
			DisplayName.SetDefault("Bitzy's Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 2;
			item.value = 100;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<BitzyPlayer>().BitzyLife < BitzyPlayer.BitzyLifeMax;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 2;
			player.statLife += 2;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(2, true);
			}
			player.GetModPlayer<BitzyPlayer>().BitzyLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 20);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
