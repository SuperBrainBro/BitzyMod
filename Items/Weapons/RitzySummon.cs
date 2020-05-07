using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Weapons
{
	public class RitzySummon : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ritzy Beacon");
			Tooltip.SetDefault("Summons Ritzy to fight for you");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.useStyle = 1;
			item.shoot = ProjectileType<Projectiles.Summons.RitzyProj>();
			item.width = 16;
			item.height = 30;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 2;
			item.noMelee = true;
			//item.summon = true;
			//item.value = 
			item.buffType = BuffType<Buffs.RitzyBuff>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 10);
			recipe.AddIngredient(ItemID.LifeCrystal	, 1);
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