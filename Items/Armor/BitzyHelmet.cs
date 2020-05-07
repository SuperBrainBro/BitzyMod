using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BitzyHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault($"[c/FFFFFF:+4% damage]");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 150;
			item.rare = 2;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<BitzyBreastplate>() && legs.type == ItemType<BitzyLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = $"[c/FFFFFF: +2 life regen] [c/FFFFFF:+5% critical strike chance]";
			player.lifeRegen += 2;
			player.magicCrit += 5;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
		}
		
		public override void UpdateEquip(Player player)
        {
			player.allDamageMult += 0.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 30);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}