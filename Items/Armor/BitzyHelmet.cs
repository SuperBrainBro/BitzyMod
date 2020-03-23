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
			Tooltip.SetDefault($"[c/FFFFFF:Immunity to 'On Fire!']\n[c/FFFFFF:+20 max mana]\n[c/FFFFFF:+1 max minions]\n[c/FFFFFF:+5% damage]\n[c/FFFFFF:+5% critical strike chance]");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 30;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<BitzyBreastplate>() && legs.type == ItemType<BitzyLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = $"[c/FFFFFF: +15% increased movement speed][c/FFFFFF: +2 life regen]";
			player.moveSpeed += 0.15f;
			player.lifeRegen += 2;
		}
		
		public override void UpdateEquip(Player player)
        {
			player.magicCrit += 5;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.buffImmune[BuffID.OnFire] = true;
			player.allDamage += 0.05f;
			player.maxMinions += 1;
		}
		//public override void AddRecipes() {
		//ModRecipe recipe = new ModRecipe(mod);
		//recipe.AddIngredient(ItemType<EquipMaterial>(), 30);
		//recipe.AddTile(TileType<ExampleWorkbench>());
		//recipe.SetResult(this);
		//recipe.AddRecipe();
		//}
	}
}