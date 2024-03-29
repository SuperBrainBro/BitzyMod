using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BitzyLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault($"[c/FFFFFF:+10% increased movement speed]");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 200;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 40);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}