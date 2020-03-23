using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class BitzyWings : ModItem
	{
		//public override bool Autoload(ref string name)
		//{
			//return !GetInstance<ExampleConfigServer>().DisableExampleWings;
		//}

		public override void SetStaticDefaults() {
			Tooltip.SetDefault($"[c/FFFFFF:Allows Hovering When Used With Rocket Boots Or Any Upgrades.]\n[c/FFFFFF:Allows Slow Fall]\n[c/FFFFFF:Negates Fall Damage.]");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 100;
			item.rare = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 3;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 30f;
			ascentWhenRising = .1f;
			maxCanAscendMultiplier = .1f;
			maxAscentMultiplier = .1f;
			constantAscend = .1f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 5f;
			acceleration *= 2f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EquipMaterial>(), 15);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}