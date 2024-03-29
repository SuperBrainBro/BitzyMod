using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BitzyFez : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault($"[c/FFFFFF:+1 minion slot]");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 150;
			item.rare = 2;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<BitzyBreastplate>() && legs.type == ItemType<BitzyLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = $"[c/FFFFFF: +15% minion damage] [c/FFFFFF:+2 minion slots]";
			player.maxMinions += 2;
			player.minionDamageMult += .15f;
		}
		
		public override void UpdateEquip(Player player)
        {
			player.maxMinions += 2;
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