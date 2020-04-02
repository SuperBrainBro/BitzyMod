using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Weapons
{
	public class BitzyGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bitzy Blaster");
			Tooltip.SetDefault("Uses Bitzy Bullets as ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 41;
			item.crit = 10;
			item.ranged = true;
			item.width = 42;
			item.height = 30;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.value = 4700;
			item.rare = 2;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Bullet");
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.BitzyBulletProj>();
			item.shootSpeed = 6f;
			item.useAmmo = ItemType<BitzyBullet>();        //Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 40);
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 40);
			recipe.AddIngredient(ItemID.LeadBar, 15);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			// Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
			mult *= player.bulletDamage;
		}

		public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}
	}
}
