using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items
{
	public class WitzySoul : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Witzy Soul");
			Tooltip.SetDefault("Used to craft hardmode Witzy equipment.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = 25;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 10);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		public override bool CanBurnInLava() {
			return true;
		}
	}
}