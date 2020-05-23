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
		public int BubbleLife;
		public int CandyCaneLife;
		public int CoralstoneLife;
		public int DynastyLife;

		//Hardmode
		public int PearlstoneLife;
		public int RainbowLife;
		public int CobaltLife;
		public int PalladiumLife;
		public int MythrilLife;
		public int OrichalcumLife;
		public int AdamantiteLife;
		public int TitaniumLife;
		public int ChlorophyteLife;
		public int LuminiteLife;
		public int CrystalLife;
		public int CogLife;

		//Dev Stuff/Hearts
		public int HeartOfCAT;
		public int CrystalLite;

		//Multiplayer Thing
		public bool nonStopParty;

		public override void ResetEffects() 
		{
			//Pre-Hardmode
			player.statLifeMax2 += DirtLife;
			player.statLifeMax2 += StoneLife;
			player.statLifeMax2 += WoodLife;
			player.statLifeMax2 += CactusLife;

			player.statLifeMax2 += IceLife * 2;

			player.statLifeMax2 += TinLife * 3;
			player.statLifeMax2 += CopperLife * 3;

			player.statLifeMax2 += IronLife * 4;
			player.statLifeMax2 += LeadLife * 4;

			player.statLifeMax2 += SilverLife * 5;
			player.statLifeMax2 += TungstenLife * 5;
			player.statLifeMax2 += BubbleLife * 5;

			player.statLifeMax2 += GoldLife * 6;
			player.statLifeMax2 += PlatinumLife * 6;

			player.statLifeMax2 += DemoniteLife * 7;
			player.statLifeMax2 += CrimtaneLife * 7;
			player.statLifeMax2 += ObsidianLife * 7;

			player.statLifeMax2 += HellstoneLife * 8;
			player.statLifeMax2 += MeteoriteLife * 8;

			//Hardmode
			player.statLifeMax2 += PearlstoneLife * 5;

			player.statLifeMax2 += CobaltLife * 9;
			player.statLifeMax2 += PalladiumLife * 9;

			player.statLifeMax2 += MythrilLife * 10;
			player.statLifeMax2 += RainbowLife * 10;
			player.statLifeMax2 += OrichalcumLife * 10;

			player.statLifeMax2 += AdamantiteLife * 11;
			player.statLifeMax2 += TitaniumLife * 11;

			player.statLifeMax2 += ChlorophyteLife * 11;
			player.statLifeMax2 += LuminiteLife * 11;

			//Dev Hearts
			player.statLifeMax2 += HeartOfCAT * 20;
			player.statLifeMax2 += CrystalLite * 20;
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
			packet.Write(BubbleLife);
			packet.Write(nonStopParty);
			packet.Send(toWho, fromWho);

			//Hardmode
			packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(PearlstoneLife);
			packet.Write(RainbowLife);
			packet.Write(CobaltLife);
			packet.Write(PalladiumLife);
			packet.Write(MythrilLife);
			packet.Write(OrichalcumLife);
			packet.Write(AdamantiteLife);
			packet.Write(TitaniumLife);
			packet.Write(ChlorophyteLife);
			packet.Write(LuminiteLife);
			packet.Write(nonStopParty);
			packet.Send(toWho, fromWho);

			//Dev Hearts
			packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(HeartOfCAT);
			packet.Write(CrystalLite);
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
				{"BubbleLife", BubbleLife},

				{"nonStopParty", nonStopParty},

				//Hardmode
				{"PearlstoneLife", PearlstoneLife},
				{"RainbowLife", RainbowLife},
				{"CobaltLife", CobaltLife},
				{"RainbowLife", PalladiumLife},
				{"MythrilLife", MythrilLife},
				{"OrichalcumLife", OrichalcumLife},
				{"AdamantiteLife", AdamantiteLife},
				{"TitaniumLife", TitaniumLife},
				{"ChlorophyteLife", ChlorophyteLife},
				{"LuminiteLife", LuminiteLife},

				//Dev Hearts
				{"HeartOfCAT", HeartOfCAT},
				{"CrystalLite", CrystalLite},
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
			BubbleLife = tag.GetInt("BubbleLife");

			nonStopParty = tag.GetBool("nonStopParty");

			//Hardmode
			PearlstoneLife = tag.GetInt("PearlstoneLife");
			RainbowLife = tag.GetInt("RainbowLife");
			CobaltLife = tag.GetInt("CobaltLife");
			PalladiumLife = tag.GetInt("PalladiumLife");
			MythrilLife = tag.GetInt("MythrilLife");
			OrichalcumLife = tag.GetInt("OrichalcumLife");
			AdamantiteLife = tag.GetInt("AdamantiteLife");
			TitaniumLife = tag.GetInt("TitaniumLife");
			ChlorophyteLife = tag.GetInt("ChlorophyteLife");
			LuminiteLife = tag.GetInt("LuminiteLife");

			//Dev Hearts
			HeartOfCAT = tag.GetInt("HeartOfCAT");
			CrystalLite = tag.GetInt("CrystalLite");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
		}
	}
}
