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

        ////Life Crystals////

        public const int ElementalHeartMax = 1;

        //Pre-Hardmode//

        //Basic
        public int DirtLife;
        public int StoneLife;
        public int GraniteLife;
        public int MarbleLife;
        public int IceLife;
        public int ObsidianLife;

        public int SandLife;
        public int EbonsandLife;
        public int CrimsandLife;
        public int GlassLife;

        //Other
        public int HoneyLife;
        public int SlimeLife;
        public int FossilLife;
        public int BubbleLife;
        public int CoralstoneLife;
        public int CandyCaneLife;
        public int MushroomLife;

        //Grown
        public int HayLife;
        public int CactusLife;
        public int PumpkinLife;

        //Wood
        public int WoodLife;
        public int RichMahoganyLife;
        public int EbonwoodLife;
        public int ShadewoodLife;
        public int BorealWoodLife;
        public int PalmWoodLife;
        public int DynastyLife;

        //Gems
        public int AmberLife;
        public int AmethystLife;
        public int TopazLife;
        public int SapphireLife;
        public int EmeraldLife;
        public int RubyLife;
        public int DiamondLife;

        //Basic Ores
        public int CopperLife;
        public int TinLife;
        public int IronLife;
        public int LeadLife;
        public int SilverLife;
        public int TungstenLife;
        public int GoldLife;
        public int PlatinumLife;

        //Other Ores
        public int MeteoriteLife;
        public int DemoniteLife;
        public int CrimtaneLife;
        public int HellstoneLife;

        //Hardmode//

        //Basic
        public int PearlstoneLife;
        public int PearlsandLife;

        //Wood
        public int PearlwoodLife;
        public int SpookyLife;

        //Other
        public int RainbowLife;
        public int CogLife;
        public int FleshLife;
        public int LesionLife;
        public int CrystalLife;

        //Basic Ores
        public int CobaltLife;
        public int PalladiumLife;
        public int MythrilLife;
        public int OrichalcumLife;
        public int AdamantiteLife;
        public int TitaniumLife;
        public int ChlorophyteLife;
        public int LuminiteLife;

        //Expert Hearts
        public int BrainLife;
        public int WormLife;
        public int DemonHeartMK2Life;
        public int MechanicalLife;

        //Dev Hearts
        public int HeartOfCAT;
        public int CrystalLite;

        //Multiplayer Thing
        public bool nonStopParty;

        public override void ResetEffects()
        {
            //Debuffs/Buffs
            curseCATsCurse = false;


            //Pre-Hardmode//

            //Basic
            DirtLife *= 1;
            StoneLife *= 1;
            GraniteLife *= 1;
            MarbleLife *= 1;
            IceLife *= 1;
            ObsidianLife *= 3;

            SandLife *= 1;
            EbonsandLife *= 1;
            CrimsandLife *= 1;
            GlassLife *= 1;

            //Other
            HoneyLife *= 2;
            SlimeLife *= 2;
            FossilLife *= 2;
            BubbleLife *= 2;
            CoralstoneLife *= 2;
            CandyCaneLife *= 2;
            MushroomLife *= 2;

            //Grown
            HayLife *= 1;
            CactusLife *= 1;
            PumpkinLife *= 1;

            //Wood
            WoodLife *= 1;
            RichMahoganyLife *= 1;
            EbonwoodLife *= 1;
            ShadewoodLife *= 1;
            BorealWoodLife *= 1;
            PalmWoodLife *= 1;
            DynastyLife *= 1;

            //Gems
            AmberLife *= 5;
            AmethystLife *= 2;
            TopazLife *= 3;
            SapphireLife *= 3;
            EmeraldLife *= 4;
            RubyLife *= 4;
            DiamondLife *= 5;

            //Basic Ores
            CopperLife *= 2;
            TinLife *= 2;
            IronLife *= 2;
            LeadLife *= 2;
            SilverLife *= 3;
            TungstenLife *= 3;
            GoldLife *= 3;
            PlatinumLife *= 3;

            //Other Ores
            MeteoriteLife *= 4;
            DemoniteLife *= 4;
            CrimtaneLife *= 4;
            HellstoneLife *= 5;

            //Hardmode//

            //Basic
            PearlstoneLife *= 5;
            PearlsandLife *= 5;

            //Wood
            PearlwoodLife *= 5;
            SpookyLife *= 7;

            //Other
            RainbowLife *= 5;
            CogLife *= 5;
            FleshLife *= 5;
            LesionLife *= 5;
            CrystalLife *= 5;

            //Basic Ores
            CobaltLife *= 5;
            PalladiumLife *= 5;
            MythrilLife *= 5;
            OrichalcumLife *= 5;
            AdamantiteLife *= 6;
            TitaniumLife *= 6;
            ChlorophyteLife *= 7;
            LuminiteLife *= 8;

            //Expert Hearts
            BrainLife *= 5;
            WormLife *= 5;
            DemonHeartMK2Life *= 10;
            MechanicalLife *= 10;

            //Dev Hearts
            HeartOfCAT *= 5;
            CrystalLite *= 5;
        }
        public override void UpdateDead()
        {
            curseCATsCurse = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (curseCATsCurse)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
                if (player.lifeRegen > 0)
                {
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

            //Pre-Hardmode//

            //Basic
            packet.Write(DirtLife);
            packet.Write(StoneLife);
            packet.Write(GraniteLife);
            packet.Write(MarbleLife);
            packet.Write(IceLife);
            packet.Write(ObsidianLife);

            packet.Write(SandLife);
            packet.Write(EbonsandLife);
            packet.Write(CrimsandLife);
            packet.Write(GlassLife);

            //Other
            packet.Write(HoneyLife);
            packet.Write(SlimeLife);
            packet.Write(FossilLife);
            packet.Write(BubbleLife);
            packet.Write(CoralstoneLife);
            packet.Write(CandyCaneLife);
            packet.Write(MushroomLife);

            //Grown
            packet.Write(HayLife);
            packet.Write(CactusLife);
            packet.Write(PumpkinLife);

            //Wood
            packet.Write(WoodLife);
            packet.Write(RichMahoganyLife);
            packet.Write(EbonwoodLife);
            packet.Write(ShadewoodLife);
            packet.Write(BorealWoodLife);
            packet.Write(PalmWoodLife);
            packet.Write(DynastyLife);

            //Gems
            packet.Write(AmberLife);
            packet.Write(AmethystLife);
            packet.Write(TopazLife);
            packet.Write(SapphireLife);
            packet.Write(EmeraldLife);
            packet.Write(RubyLife);
            packet.Write(DiamondLife);

            //Basic Ores
            packet.Write(CopperLife);
            packet.Write(TinLife);
            packet.Write(IronLife);
            packet.Write(LeadLife);
            packet.Write(SilverLife);
            packet.Write(TungstenLife);
            packet.Write(GoldLife);
            packet.Write(PlatinumLife);

            //Other Ores
            packet.Write(MeteoriteLife);
            packet.Write(DemoniteLife);
            packet.Write(CrimtaneLife);
            packet.Write(HellstoneLife);

            //Hardmode//

            //Basic
            packet.Write(PearlstoneLife);
            packet.Write(PearlsandLife);

            //Wood
            packet.Write(PearlwoodLife);
            packet.Write(SpookyLife);

            //Other
            packet.Write(RainbowLife);
            packet.Write(CogLife);
            packet.Write(FleshLife);
            packet.Write(LesionLife);
            packet.Write(CrystalLife);

            //Basic Ores
            packet.Write(CobaltLife);
            packet.Write(PalladiumLife);
            packet.Write(MythrilLife);
            packet.Write(OrichalcumLife);
            packet.Write(AdamantiteLife);
            packet.Write(TitaniumLife);
            packet.Write(ChlorophyteLife);
            packet.Write(LuminiteLife);

            //Expert Hearts
            packet.Write(BrainLife);
            packet.Write(WormLife);
            packet.Write(DemonHeartMK2Life);
            packet.Write(MechanicalLife);

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
                {"RichMahoganyLife", RichMahoganyLife},
                {"EbonwoodLife", EbonwoodLife},
                {"ShadewoodLife", ShadewoodLife},
                {"BorealWoodLife", BorealWoodLife},
                {"PalmWoodLife", PalmWoodLife},
                {"DynastyLife", DynastyLife},

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

                {"AmberLife", AmberLife},
                {"CoralstoneLife", CoralstoneLife},
                {"CandyCaneLife", CandyCaneLife},
                {"SandLife", SandLife},
                {"EbonsandLife", EbonsandLife},
                {"CrimsandLife", CrimsandLife},

				//Hardmode
				{"PearlsandLife", PearlsandLife},
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
                {"PearlwoodLife", PearlwoodLife},
                {"SpookyLife", SpookyLife},
                {"CrystalLife", CrystalLife},

				//Expert Hearts
				{"BrainLife", BrainLife},
                {"WormLife", WormLife},
                {"DemonHeartMK2Life", DemonHeartMK2Life},
				
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
            RichMahoganyLife = tag.GetInt("RichMahoganyLife");
            EbonwoodLife = tag.GetInt("EbonwoodLife");
            ShadewoodLife = tag.GetInt("ShadewoodLife");
            BorealWoodLife = tag.GetInt("BorealWoodLife");
            PalmWoodLife = tag.GetInt("PalmWoodLife");
            DynastyLife = tag.GetInt("DynastyLife");
            AmberLife = tag.GetInt("AmberLife");
            CoralstoneLife = tag.GetInt("CoralstoneLife");
            CandyCaneLife = tag.GetInt("CandyCaneLife");
            SandLife = tag.GetInt("SandLife");
            CrimsandLife = tag.GetInt("CrimsandLife");
            EbonsandLife = tag.GetInt("EbonsandLife");

            nonStopParty = tag.GetBool("nonStopParty");

            //Hardmode
            PearlsandLife = tag.GetInt("PearlsandLife");
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
            PearlwoodLife = tag.GetInt("PearlwoodLife");
            SpookyLife = tag.GetInt("SpookyLife");
            CrystalLife = tag.GetInt("CrystalLife");

            //Expert Hearts
            BrainLife = tag.GetInt("BrainLife");
            WormLife = tag.GetInt("WormLife");
            DemonHeartMK2Life = tag.GetInt("DemonHeartMK2Life");

            //Dev Hearts
            HeartOfCAT = tag.GetInt("HeartOfCAT");
            CrystalLite = tag.GetInt("CrystalLite");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            reader.ReadInt32();
        }
    }
}
