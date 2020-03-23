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
			Tooltip.SetDefault($"[c/FFFFFF:Immunity to 'Poisoned']\n[c/FFFFFF:+15% increased movement speed]");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 45;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.Poisoned] = true;
			player.moveSpeed += 0.15f;
		}

		//public override void AddRecipes() {
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemType<EquipMaterial>(), 45);
			//recipe.AddTile(TileType<ExampleWorkbench>());
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		//}
	}
}