using System;
using Bitzy.Dusts;
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
			Tooltip.SetDefault($"[c/FFFFFF:Allows slow fall]\n[c/FFFFFF:Negates fall damage]");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 400;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 24;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 15f;
			ascentWhenRising = .5f;
			maxCanAscendMultiplier = .5f;
			maxAscentMultiplier = .5f;
			constantAscend = .5f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 5f;
			acceleration *= 2.5f;
		}

		public override bool WingUpdate(Player player, bool inUse)
		{
            if (inUse)
            {
                Dust dust = Dust.NewDustDirect(player.position - player.velocity, player.width, player.height, DustType<BitzyDust>());
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 80);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}