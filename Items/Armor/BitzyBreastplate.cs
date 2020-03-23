using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BitzyBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			Tooltip.SetDefault($"[c/FFFFFF:Immunity to 'Bleeding']\n[c/FFFFFF:+20 max mana]\n[c/FFFFFF:+1 max minions]");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 60;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.Bleeding] = true;
			player.statManaMax2 += 20;
			player.maxMinions += 1;
		}

		//public override void AddRecipes() {
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemType<EquipMaterial>(), 60);
			//recipe.AddTile(TileType<ExampleWorkbench>());
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		//}
	}
}