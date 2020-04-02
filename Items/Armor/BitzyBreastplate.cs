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
			Tooltip.SetDefault($"[c/FFFFFF:Immunity to 'Bleeding']");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 250;
			item.rare = 2;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.Bleeding] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 50);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}