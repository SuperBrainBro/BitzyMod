using Bitzy.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Weapons
{
	public class BitzySword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Hits heal for health");
		}

		public override void SetDefaults() {
			item.damage = 36;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 22;
			item.useAnimation = 22;
			item.knockBack = 5;
			item.value = 6175;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = 1;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 35);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 35);
			recipe.AddIngredient(ItemID.LeadBar, 20);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<BitzyDust>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			player.HealEffect(1 + (damage / 25), true);
			Item.NewItem(target.getRect(), ItemID.Beenade, 20);
		}
	}
}
