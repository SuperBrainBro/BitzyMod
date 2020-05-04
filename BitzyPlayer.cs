using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace Bitzy
{

	public class BitzyPlayer : ModPlayer
	{
		//Life Fruits
		public const int BitzyLifeMax = 20;
		public int BitzyLife;

		//Pets
		public bool GlitzyPet;

		//Multiplayer Thing
		public bool nonStopParty;

		public override void ResetEffects() 
		{		
			player.statLifeMax2 += BitzyLife * 2;
		}

		public override void clientClone(ModPlayer clientClone)
		{
			BitzyPlayer clone = clientClone as BitzyPlayer;
			clone.nonStopParty = nonStopParty;
		}
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(BitzyLife);
			packet.Write(nonStopParty);
			packet.Send(toWho, fromWho);
		}

		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			BitzyPlayer clone = clientPlayer as BitzyPlayer;
			if (clone.nonStopParty != nonStopParty)
			{
				var packet = mod.GetPacket();
				packet.Write((byte)player.whoAmI);
				packet.Write(nonStopParty);
				packet.Send();
			}
		}

		public override TagCompound Save()
		{	
			return new TagCompound {
				{"BitzyLife", BitzyLife},
				{"nonStopParty", nonStopParty},
			};
		}

		public override void Load(TagCompound tag)
		{
			BitzyLife = tag.GetInt("BitzyLife");
			nonStopParty = tag.GetBool("nonStopParty");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
		}
	}
}
