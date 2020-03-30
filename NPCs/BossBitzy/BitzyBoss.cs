using Bitzy.Dusts;
using Bitzy.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.NPCs.BossBitzy
{
	//ported from my tAPI mod because I'm lazy
	// Abomination is a multi-stage boss.
	[AutoloadBossHead]
	public class BitzyBoss : ModNPC
	{
		public int rndAmount69;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bitzy");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 1;
			npc.stepSpeed = npc.stepSpeed * 2;
			
			npc.lifeMax = 2500;
			npc.damage = 40;
			npc.defense = 20;
			npc.knockBackResist = 0.1f;
			npc.width = 96;
			npc.height = 84;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			music = MusicID.Boss1;
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.HealingPotion;
			rndAmount69 = RandomNumber(25, 45);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BitzySoul>(), rndAmount69);
		}

		public int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			Dust.NewDust(npc.position, npc.width + (npc.width / 2), npc.height + (npc.height / 2), DustType<BitzyDust>());
		}

		// We use this method to inflict a debuff on a player on contact. OnFire is inflicted 100% of the time in expert, and 50% of the time on non-expert mode.
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				player.AddBuff(BuffID.Confused, 100, true);
			}
		}
	}
}