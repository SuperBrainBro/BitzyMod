using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Weapons
{
	public class BitzyBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Ammo compatible with the Bitzy Gun");
		}

		public override void SetDefaults() {
			item.damage = 6;
			item.ranged = true;
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 3;
			item.shoot = ProjectileType<Projectiles.BitzyBulletProj>();
			item.ammo = item.type; // The first item in an ammo class sets the AmmoID to it's type
		}

		public override void AddRecipes() {
			WispRecipe recipe = new WispRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 1);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}

	public class WispRecipe : ModRecipe
	{
		public WispRecipe(Mod mod) : base(mod) {
		}

		public override bool RecipeAvailable() {
			return Main.LocalPlayer.HasItem(ItemType<BitzyGun>());
		}

		public override int ConsumeItem(int type, int numRequired) {
			if (type == ItemType<BitzySoul>() && Main.LocalPlayer.adjTile[TileID.Furnaces]) {
				Main.PlaySound(2, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Bullet"));
				return Main.rand.NextBool() ? 0 : 1; //You have half chance to not consume your materials
			}
			return base.ConsumeItem(type, numRequired);
		}
	}
}
