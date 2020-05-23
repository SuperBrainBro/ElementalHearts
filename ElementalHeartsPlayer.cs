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

namespace ElementalHearts
{

	public class ElementalHeartsPlayer : ModPlayer
	{
		//Life Crystals

		//Pre-Hardmode
		public int DirtLife;
		public int StoneLife;
		public int WoodLife;
		public int GraniteLife;
		public int MarbleLife;
		public int IceLife;
		public int GlassLife;
		public int SlimeLife;
		public int FossilLife;
		public int MushroomLife;
		public int HayLife;
		public int CactusLife;
		public int PumpkinLife;
		public int HoneyLife;
		public int AmethystLife;
		public int TopazLife;
		public int SapphireLife;
		public int EmeraldLife;
		public int RubyLife;
		public int DiamondLife;
		public int CopperLife;
		public int TinLife;
		public int IronLife;
		public int LeadLife;
		public int SilverLife;
		public int TungstenLife;
		public int GoldLife;
		public int PlatinumLife;
		public int MeteoriteLife;
		public int DemoniteLife;
		public int CrimtaneLife;
		public int ObsidianLife;
		public int HellstoneLife;

		//Hardmode

		//Dev Stuff/Hearts
		public int HeartOfCAT;

		//Multiplayer Thing
		public bool nonStopParty;

		public override void ResetEffects() 
		{
			player.statLifeMax2 += DirtLife;

			player.statLifeMax2 += StoneLife * 2;
			player.statLifeMax2 += WoodLife * 2;
			player.statLifeMax2 += IceLife * 2;

			player.statLifeMax2 += TinLife * 3;
			player.statLifeMax2 += CopperLife * 3;

			player.statLifeMax2 += LeadLife * 4;

			player.statLifeMax2 += SilverLife * 5;

			//Dev Hearts
			player.statLifeMax2 += HeartOfCAT;
		}

		public override void clientClone(ModPlayer clientClone)
		{
			ElementalHeartsPlayer clone = clientClone as ElementalHeartsPlayer;
			clone.nonStopParty = nonStopParty;
		}
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);

			//Pre-Hardmode
			packet.Write(DirtLife);
			packet.Write(StoneLife);
			packet.Write(WoodLife);
			packet.Write(GraniteLife);
			packet.Write(MarbleLife);
			packet.Write(IceLife);
			packet.Write(GlassLife);
			packet.Write(SlimeLife);
			packet.Write(FossilLife);
			packet.Write(MushroomLife);
			packet.Write(HayLife);
			packet.Write(CactusLife);
			packet.Write(PumpkinLife);
			packet.Write(HoneyLife);
			packet.Write(AmethystLife);
			packet.Write(TopazLife);
			packet.Write(SapphireLife);
			packet.Write(EmeraldLife);
			packet.Write(RubyLife);
			packet.Write(DiamondLife);
			packet.Write(CopperLife);
			packet.Write(TinLife);
			packet.Write(IronLife);
			packet.Write(LeadLife);
			packet.Write(SilverLife);
			packet.Write(TungstenLife);
			packet.Write(GoldLife);
			packet.Write(PlatinumLife);
			packet.Write(MeteoriteLife);
			packet.Write(DemoniteLife);
			packet.Write(CrimtaneLife);
			packet.Write(HellstoneLife);
			packet.Write(nonStopParty);
			packet.Send(toWho, fromWho);

			//Dev Hearts
			packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(HeartOfCAT);
			packet.Write(nonStopParty);
			packet.Send(toWho, fromWho);
		}
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			ElementalHeartsPlayer clone = clientPlayer as ElementalHeartsPlayer;
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

				//Pre-Hardmode
				{"DirtLife", DirtLife},
				{"StoneLife", StoneLife},
				{"WoodLife", WoodLife},
				{"GraniteLife", GraniteLife},
				{"MarbleLife", MarbleLife},
				{"IceLife", IceLife},
				{"GlassLife", GlassLife},
				{"SlimeLife", SlimeLife},
				{"FossilLife", FossilLife},
				{"MushroomLife", MushroomLife},
				{"HayLife", HayLife},
				{"CactusLife", CactusLife},
				{"PumpkinLife", PumpkinLife},
				{"HoneyLife", HoneyLife},
				{"AmethystLife", AmethystLife},
				{"TopazLife", TopazLife},
				{"SapphireLife", SapphireLife},
				{"EmeraldLife", EmeraldLife},
				{"RubyLife", RubyLife},
				{"DiamondLife", DiamondLife},
				{"CopperLife", CopperLife},
				{"TinLife", TinLife},
				{"IronLife", IronLife},
				{"LeadLife", LeadLife},
				{"SilverLife", SilverLife},
				{"TungstenLife", TungstenLife},
				{"GoldLife", GoldLife},
				{"PlatinumLife", PlatinumLife},
				{"MeteoriteLife", MeteoriteLife},
				{"DemoniteLife", DemoniteLife},
				{"CrimtaneLife", CrimtaneLife},
				{"ObsidianLife", ObsidianLife},
				{"HellstoneLife", HellstoneLife},

				{"nonStopParty", nonStopParty},

				//Dev Hearts
				{"HeartOfCAT", HeartOfCAT},
			};
		}

		public override void Load(TagCompound tag)
		{

			//Pre-Hardmode
			DirtLife = tag.GetInt("DirtLife");
			StoneLife = tag.GetInt("StoneLife");
			WoodLife = tag.GetInt("WoodLife");
			GraniteLife = tag.GetInt("GraniteLife");
			MarbleLife = tag.GetInt("MarbleLife");
			IceLife = tag.GetInt("IceLife");
			GlassLife = tag.GetInt("GlassLife");
			SlimeLife = tag.GetInt("SlimeLife");
			FossilLife = tag.GetInt("FossilLife");
			MushroomLife = tag.GetInt("MushroomLife");
			HayLife = tag.GetInt("HayLife");
			CactusLife = tag.GetInt("CactusLife");
			PumpkinLife = tag.GetInt("PumpkinLife");
			HoneyLife = tag.GetInt("HoneyLife");
			AmethystLife = tag.GetInt("AmethystLife");
			TopazLife = tag.GetInt("TopazLife");
			SapphireLife = tag.GetInt("SapphireLife");
			EmeraldLife = tag.GetInt("EmeraldLife");
			RubyLife = tag.GetInt("RubyLife");
			DiamondLife = tag.GetInt("DiamondLife");
			CopperLife = tag.GetInt("CopperLife");
			TinLife = tag.GetInt("TinLife");
			IronLife = tag.GetInt("IronLife");
			LeadLife = tag.GetInt("LeadLife");
			SilverLife = tag.GetInt("SilverLife");
			TungstenLife = tag.GetInt("TungstenLife");
			GoldLife = tag.GetInt("GoldLife");
			PlatinumLife = tag.GetInt("PlatinumLife");
			MeteoriteLife = tag.GetInt("MeteoriteLife");
			DemoniteLife = tag.GetInt("DemoniteLife");
			CrimtaneLife = tag.GetInt("CrimtaneLife");
			ObsidianLife = tag.GetInt("ObsidianLife");
			HellstoneLife = tag.GetInt("HellstoneLife");

			nonStopParty = tag.GetBool("nonStopParty");

			//Dev Hearts
			HeartOfCAT = tag.GetInt("HeartOfCAT");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
		}
	}
}
