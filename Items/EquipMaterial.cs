using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items
{
	public class EquipMaterial : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Equipment Item");
			Tooltip.SetDefault("Used to craft equipment");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 5);
			recipe.AddIngredient(ItemID.SilverCoin, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool CanBurnInLava() {
			return true;
		}
	}
}