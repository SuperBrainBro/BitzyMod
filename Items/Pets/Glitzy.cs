using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Pets
{
	public class Glitzy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glitzy Light Pet");
			Tooltip.SetDefault("Summons Glitzy to provide light");
		}

		public override void SetDefaults() {
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = ProjectileType<Projectiles.Pets.GlitzyProj>();
			item.width = 16;
			item.height = 30;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 2;
			item.noMelee = true;
			//item.value = 
			item.buffType = BuffType<Buffs.GlitzyBuff>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 10);
			recipe.AddIngredient(ItemID.Blinkroot, 1);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}