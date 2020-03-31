using Bitzy.Dusts;
using Bitzy.Items;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Bitzy.Projectiles.BossBitzy;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bitzy.NPCs.BossBitzy
{
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
			npc.value = Item.buyPrice(0, 1, 50, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = false;
			npc.HitSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BossHit");
			npc.DeathSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BossDeath");
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/BossFight");
		}


		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.LesserHealingPotion;
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

		public override void AI()
		{
			npc.TargetClosest(true);

			if (npc.life <= npc.lifeMax / 1.5)
			{
				npc.ai[0] = 1;
			}

			if (npc.ai[0] == 1)
			{
				npc.ai[2]++;
				npc.ai[3]++;
				//if (npc.ai[2] >= 30 + (npc.life / 800))
				//{
					//float Speed = 10f;
					//Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
					//int damage = 70;
					//int type = ProjectileType<BossBitzyBulletProj>();
					//float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f) - 50));
					//int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
					//rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f) + 50), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f) + 50));
					//Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
					//npc.ai[2] = 0;
				//}
				if (npc.ai[3] >= 32 + (npc.life / 800))
				{
					float Speed = 10f;
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
					int damage = 10;
					int type = ProjectileType<BossBitzyBulletProj>(); //Original is 129
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
					npc.ai[3] = 0;
				}
				//if (npc.ai[3] >= 60) //Nebula Laser
				//{
				//float Speed = 8f;
				//Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				//int damage = 30;
				//int type = 576;
				//float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				//int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
				//rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f) + 25), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f) + 25));
				//Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
				//rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f) - 25), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f) - 25));
				//Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
				//npc.ai[3] = 0;
				//}
			}
		}
	}
}