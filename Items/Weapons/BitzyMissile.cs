using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Weapons
{
	public class BitzyMissile : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a controllable missile\nIncreased damage during the night\nDecreased damage during the day");
		}

		public override void SetDefaults() {
			item.damage = 50;
			item.magic = true;
			item.mana = 20;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.noMelee = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.knockBack = 8;
			item.value = 6775;
			item.rare = 2;
			item.UseSound = SoundID.Item9;
			item.shoot = ProjectileType<Projectiles.BitzyMissileProj>();
			item.shootSpeed = 10f;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			double currentTime = Main.time;
			// The time at which it changes from day to night and vice versa.
			double maxTime = Main.dayTime ? Main.dayLength : Main.nightLength;
			// More mana during day, less at night
			int direction = Main.dayTime ? 1 : -1;
			// Sine goes from 0 to 1 to 0 over a period of pi, so we match that to the length of the day/night.
			float timeMult = (float)Math.Sin(currentTime / maxTime * Math.PI);
			// Then we multiply by direction so it goes between 1 and -1 through the entire day, then multiply by 0.5 and add 1 to make it go between 1.5 and 0.5.
			timeMult = (1 + timeMult * -direction * 0.25f);
			// Last, we multiply the current mana cost multiplier of the item by our multiplier.
			add *= timeMult;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 35);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 35);
			recipe.AddIngredient(ItemID.LeadBar, 6);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}