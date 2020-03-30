using Bitzy.NPCs.BossBitzy;
using Bitzy.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.Items.BossBitzy
{
	//imported from my tAPI mod because I'm lazy
	public class BitzyBeacon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a busy friend. Please don't bother him.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(NPCType<BitzyBoss>());
		}

		public override bool UseItem(Player player) {
			NPC.NewNPC((int)player.position.X, ((int)player.position.Y) - 1250, NPCType<BitzyBoss>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BitzySoul>(), 10);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}