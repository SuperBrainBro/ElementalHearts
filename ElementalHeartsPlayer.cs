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
		//Debuffs/Buffs
		public bool curseCATsCurse;

		//Life Crystals

		//Pre-Hardmode
		public const int maxDirtLife = 1;
		public int DirtLife;
		public const int maxStoneLife = 1;
		public int StoneLife;
		public const int maxWoodLife = 1;
		public int WoodLife;
		public const int maxGraniteLife = 1;
		public int GraniteLife;
		public const int maxMarbleLife = 1;
		public int MarbleLife;
		public const int maxIceLife = 1;
		public int IceLife;
		public const int maxGlassLife = 1;
		public int GlassLife;
		public const int maxFossilLife = 1;
		public int FossilLife;
		public const int maxMushroomLife = 1;
		public int MushroomLife;
		public const int maxHayLife = 1;
		public int HayLife;
		public const int maxCactusLife = 1;
		public int CactusLife;
		public const int maxPumpkinLife = 1;
		public int PumpkinLife;
		public const int maxHoneyLife = 1;
		public int HoneyLife;
		public const int maxAmethystLife = 1;
		public int AmethystLife;
		public const int maxTopazLife = 1;
		public int TopazLife;
		public const int maxSapphireLife = 1;
		public int SapphireLife;
		public const int maxEmeraldLife = 1;
		public int EmeraldLife;
		public const int maxRubyLife = 1;
		public int RubyLife;
		public const int maxDiamondLife = 1;
		public int DiamondLife;
		public const int maxCopperLife = 1;
		public int CopperLife;
		public const int maxTinLife = 1;
		public int TinLife;
		public const int maxIronLife = 1;
		public int IronLife;
		public const int maxLeadLife = 1;
		public int LeadLife;
		public const int maxSilverLife = 1;
		public int SilverLife;
		public const int maxTungstenLife = 1;
		public int TungstenLife;
		public const int maxGoldLife = 1;
		public int GoldLife;
		public const int maxPlatinumLife = 1;
		public int PlatinumLife;
		public const int maxMeteoriteLife = 1;
		public int MeteoriteLife;
		public const int maxDemoniteLife = 1;
		public int DemoniteLife;
		public const int maxCrimtaneLife = 1;
		public int CrimtaneLife;
		public const int maxObsidianLife = 1;
		public int ObsidianLife;
		public const int maxHellstoneLife = 1;
		public int HellstoneLife;
		public const int maxBubbleLife = 1;
		public int BubbleLife;
		public const int maxCandyCaneLife = 1;
		public int CandyCaneLife;
		public const int maxCoralstoneLife = 1;
		public int CoralstoneLife;
		public const int maxDynastyLife = 1;
		public int DynastyLife;
		public const int maxSlimeLife = 1;
		public int SlimeLife;

		//Hardmode
		public const int maxPearlstoneLife = 1;
		public int PearlstoneLife;
		public const int maxRainbowLife = 1;
		public int RainbowLife;
		public const int maxCobaltLife = 1;
		public int CobaltLife;
		public const int maxPalladiumLife = 1;
		public int PalladiumLife;
		public const int maxMythrilLife = 1;
		public int MythrilLife;
		public const int maxOrichalcumLife = 1;
		public int OrichalcumLife;
		public const int maxAdamantiteLife = 1;
		public int AdamantiteLife;
		public const int maxTitaniumLife = 1;
		public int TitaniumLife;
		public const int maxChlorophyteLife = 1;
		public int ChlorophyteLife;
		public const int maxLuminiteLife = 1;
		public int LuminiteLife;
		public const int maxCrystalLife = 1;
		public int CrystalLife;
		public const int maxCogLife = 1;
		public int CogLife;

		public const int maxFleshLife = 1;
		public int FleshLife;
		public const int maxLesionLife = 1;
		public int LesionLife;

		//Expert Hearts
		public const int maxBrainLife = 1;
		public int BrainLife;

		//Dev Stuff/Hearts
		public const int maxHeartOfCAT = 1;
		public int HeartOfCAT;
		public const int maxCrystalLite = 1;
		public int CrystalLite;

		//Multiplayer Thing
		public bool nonStopParty;

		public override void ResetEffects() 
		{
			//Debuffs/Buffs
			curseCATsCurse = false;

			//Pre-Hardmode
			player.statLifeMax2 += DirtLife;
			player.statLifeMax2 += StoneLife;
			player.statLifeMax2 += WoodLife;
			player.statLifeMax2 += CactusLife;

			player.statLifeMax2 += IceLife * 2;

			player.statLifeMax2 += TinLife * 3;
			player.statLifeMax2 += CopperLife * 3;
			player.statLifeMax2 += SlimeLife * 3;

			player.statLifeMax2 += IronLife * 4;
			player.statLifeMax2 += LeadLife * 4;

			player.statLifeMax2 += SilverLife * 5;
			player.statLifeMax2 += TungstenLife * 5;
			player.statLifeMax2 += BubbleLife * 5;
			player.statLifeMax2 += CogLife * 5;

			player.statLifeMax2 += GoldLife * 6;
			player.statLifeMax2 += PlatinumLife * 6;
			player.statLifeMax2 += FleshLife * 6;
			player.statLifeMax2 += LesionLife * 6;

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

			//Expert Hearts
			player.statLifeMax2 += BrainLife * 5;

			//Dev Hearts
			player.statLifeMax2 += HeartOfCAT * 20;
			player.statLifeMax2 += CrystalLite * 20;
		}

		public override void UpdateDead() {
			curseCATsCurse = false;
		}
		public override void UpdateBadLifeRegen() {
			if (curseCATsCurse) {
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 128;
			}
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
			
			//Hardmode
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
			packet.Write(CogLife);

			packet.Write(FleshLife);
			packet.Write(LesionLife);

			//Expert Hearts
			packet.Write(BrainLife);

			//Dev Hearts
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

				//Hardmode
				{"BubbleLife", BubbleLife},
				{"PearlstoneLife", PearlstoneLife},
				{"RainbowLife", RainbowLife},
				{"CobaltLife", CobaltLife},
				{"PalladiumLife", PalladiumLife},
				{"MythrilLife", MythrilLife},
				{"OrichalcumLife", OrichalcumLife},
				{"AdamantiteLife", AdamantiteLife},
				{"TitaniumLife", TitaniumLife},
				{"ChlorophyteLife", ChlorophyteLife},
				{"LuminiteLife", LuminiteLife},
				{"CogLife", CogLife},

				{"FleshLife", FleshLife},
				{"LesionLife", LesionLife},

				//Expert Hearts
				{"BrainLife", BrainLife},
				
				//Dev Hearts
				{"HeartOfCAT", HeartOfCAT},
				{"CrystalLite", CrystalLite},

				//Other
				{"nonStopParty", nonStopParty},
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

			//Hardmode
			BubbleLife = tag.GetInt("BubbleLife");
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
			CogLife = tag.GetInt("CogLife");

			FleshLife = tag.GetInt("FleshLife");
			LesionLife = tag.GetInt("LesionLife");

			//Expert Hearts
			BrainLeaf = tag.GetInt("BrainLife");			
			
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
