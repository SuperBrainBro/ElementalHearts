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

        public int ElementalHeartMax = 1;

        ////Life Crystals////

        //Pre-Hardmode//

        //Basic
        public int DirtLife;
        public int StoneLife;
        public int CrimstoneLife;
        public int EbonstoneLife;
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
            ElementalHeartsConfig config = new ElementalHeartsConfig();
            ElementalHeartMax = config.MaxElementalHeartConfig;

            //Debuffs/Buffs
            curseCATsCurse = false;

            //Pre-Hardmode//

            //Basic
            player.statLifeMax2 += DirtLife * 1;
            player.statLifeMax2 += StoneLife * 1;
            player.statLifeMax2 += CrimstoneLife * 1;
            player.statLifeMax2 += EbonstoneLife * 1;
            player.statLifeMax2 += GraniteLife * 1;
            player.statLifeMax2 += MarbleLife * 1;
            player.statLifeMax2 += IceLife * 1;
            player.statLifeMax2 += ObsidianLife * 3;

            player.statLifeMax2 += SandLife * 1;
            player.statLifeMax2 += EbonsandLife * 1;
            player.statLifeMax2 += CrimsandLife * 1;
            player.statLifeMax2 += GlassLife * 1;

            //Other
            player.statLifeMax2 += HoneyLife * 2;
            player.statLifeMax2 += SlimeLife * 2;
            player.statLifeMax2 += FossilLife * 2;
            player.statLifeMax2 += BubbleLife * 2;
            player.statLifeMax2 += CoralstoneLife * 2;
            player.statLifeMax2 += CandyCaneLife * 2;
            player.statLifeMax2 += MushroomLife * 2;

            //Grown
            player.statLifeMax2 += HayLife * 1;
            player.statLifeMax2 += CactusLife * 1;
            player.statLifeMax2 += PumpkinLife * 1;

            //Wood
            player.statLifeMax2 += WoodLife *= 1;
            player.statLifeMax2 += RichMahoganyLife * 1;
            player.statLifeMax2 += EbonwoodLife * 1;
            player.statLifeMax2 += ShadewoodLife * 1;
            player.statLifeMax2 += BorealWoodLife * 1;
            player.statLifeMax2 += PalmWoodLife * 1;
            player.statLifeMax2 += DynastyLife * 1;

            //Gems
            player.statLifeMax2 += AmberLife * 5;
            player.statLifeMax2 += AmethystLife * 2;
            player.statLifeMax2 += TopazLife * 3;
            player.statLifeMax2 += SapphireLife * 3;
            player.statLifeMax2 += EmeraldLife * 4;
            player.statLifeMax2 += RubyLife * 4;
            player.statLifeMax2 += DiamondLife * 5;

            //Basic Ores
            player.statLifeMax2 += CopperLife * 2;
            player.statLifeMax2 += TinLife * 2;
            player.statLifeMax2 += IronLife * 2;
            player.statLifeMax2 += LeadLife * 2;
            player.statLifeMax2 += SilverLife * 3;
            player.statLifeMax2 += TungstenLife * 3;
            player.statLifeMax2 += GoldLife * 3;
            player.statLifeMax2 += PlatinumLife * 3;

            //Other Ores
            player.statLifeMax2 += MeteoriteLife * 4;
            player.statLifeMax2 += DemoniteLife * 4;
            player.statLifeMax2 += CrimtaneLife * 4;
            player.statLifeMax2 += HellstoneLife * 5;

            //Hardmode//

            //Basic
            player.statLifeMax2 += PearlstoneLife * 5;
            player.statLifeMax2 += PearlsandLife * 5;

            //Wood
            player.statLifeMax2 += PearlwoodLife * 5;
            player.statLifeMax2 += SpookyLife * 7;

            //Other
            player.statLifeMax2 += RainbowLife * 5;
            player.statLifeMax2 += CogLife * 5;
            player.statLifeMax2 += FleshLife * 5;
            player.statLifeMax2 += LesionLife * 5;
            player.statLifeMax2 += CrystalLife * 7;

            //Basic Ores
            player.statLifeMax2 += CobaltLife * 5;
            player.statLifeMax2 += PalladiumLife * 5;
            player.statLifeMax2 += MythrilLife * 6;
            player.statLifeMax2 += OrichalcumLife * 6;
            player.statLifeMax2 += AdamantiteLife * 7;
            player.statLifeMax2 += TitaniumLife * 7;
            player.statLifeMax2 += ChlorophyteLife * 8;
            player.statLifeMax2 += LuminiteLife * 9;

            //Expert Hearts
            player.statLifeMax2 += BrainLife * 5;
            player.statLifeMax2 += WormLife * 5;
            player.statLifeMax2 += DemonHeartMK2Life * 10;
            player.statLifeMax2 += MechanicalLife * 10;

            //Dev Hearts
            player.statLifeMax2 += HeartOfCAT * 5;
            player.statLifeMax2 += CrystalLite * 5;
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
            packet.Write(CrimstoneLife);
            packet.Write(EbonstoneLife);
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

                //Pre-Hardmode//

                //Basic
                {"DirtLife", DirtLife},
                {"StoneLife", StoneLife},
                {"CrimstoneLife", CrimstoneLife},
                {"EbonstoneLife", EbonstoneLife},
                {"GraniteLife", GraniteLife},
                {"MarbleLife", MarbleLife},
                {"IceLife", IceLife},
                {"ObsidianLife", ObsidianLife},
                {"SandLife", SandLife},
                {"EbonsandLife", EbonsandLife},
                {"CrimsandLife", CrimsandLife},
                {"GlassLife", GlassLife},

                //Other
                {"HoneyLife", HoneyLife},
                {"SlimeLife", SlimeLife},
                {"FossilLife", FossilLife},
                {"BubbleLife", BubbleLife},
                {"CoralstoneLife", CoralstoneLife},
                {"CandyCaneLife", CandyCaneLife},
                {"MushroomLife", MushroomLife},

                //Grown
                {"HayLife", HayLife},
                {"CactusLife", CactusLife},
                {"PumpkinLife", PumpkinLife},

                //Wood
                {"WoodLife", WoodLife},
                {"RichMahoganyLife", RichMahoganyLife},
                {"EbonwoodLife", EbonwoodLife},
                {"ShadewoodLife", ShadewoodLife},
                {"BorealWoodLife", BorealWoodLife},
                {"PalmWoodLife", PalmWoodLife},
                {"DynastyLife", DynastyLife},

                //Gems
                {"AmberLife", AmberLife},
                {"AmethystLife", AmethystLife},
                {"TopazLife", TopazLife},
                {"SapphireLife", SapphireLife},
                {"EmeraldLife", EmeraldLife},
                {"RubyLife", RubyLife},
                {"DiamondLife", DiamondLife},

                //Basic Ores
                {"CopperLife", CopperLife},
                {"TinLife", TinLife},
                {"IronLife", IronLife},
                {"LeadLife", LeadLife},
                {"SilverLife", SilverLife},
                {"TungstenLife", TungstenLife},
                {"GoldLife", GoldLife},
                {"PlatinumLife", PlatinumLife},

                //Other Ores
                {"MeteoriteLife", MeteoriteLife},
                {"DemoniteLife", DemoniteLife},
                {"CrimtaneLife", CrimtaneLife},
                {"HellstoneLife", HellstoneLife},

                //Hardmode//

                //Basic
                {"PearlstoneLife", PearlstoneLife},
                {"PearlsandLife", PearlsandLife},

                //Wood
                {"PearlwoodLife", PearlwoodLife},
                {"SpookyLife", SpookyLife},

                //Other
                {"RainbowLife", RainbowLife},
                {"CogLife", CogLife},
                {"FleshLife", FleshLife},
                {"LesionLife", LesionLife},
                {"CrystalLife", CrystalLife},

                //Basic Ores
                {"CobaltLife", CobaltLife},
                {"PalladiumLife", PalladiumLife},
                {"MythrilLife", MythrilLife},
                {"OrichalcumLife", OrichalcumLife},
                {"AdamantiteLife", AdamantiteLife},
                {"TitaniumLife", TitaniumLife},
                {"ChlorophyteLife", ChlorophyteLife},
                { "LuminiteLife", LuminiteLife},

                //Expert Hearts
                { "BrainLife", BrainLife},
                { "WormLife", WormLife},
                { "DemonHeartMK2Life", DemonHeartMK2Life},
                { "MechanicalLife", MechanicalLife},

                //Dev Hearts
                { "HeartOfCAT", HeartOfCAT},
                { "CrystalLite", CrystalLite},

                //Other
                {"nonStopParty", nonStopParty},
                };
        }

        public override void Load(TagCompound tag)
        {
            ////Life Crystals////

            //Pre-Hardmode//

            //Basic
            DirtLife = tag.GetInt("DirtLife");
            StoneLife = tag.GetInt("StoneLife");
            CrimstoneLife = tag.GetInt("CrimstoneLife");
            EbonstoneLife = tag.GetInt("EbonstoneLife");
            GraniteLife = tag.GetInt("GraniteLife");
            MarbleLife = tag.GetInt("MarbleLife");
            IceLife = tag.GetInt("IceLife");
            ObsidianLife = tag.GetInt("ObsidianLife");

            SandLife = tag.GetInt("SandLife");
            EbonsandLife = tag.GetInt("EbonsandLife");
            CrimsandLife = tag.GetInt("CrimsandLife");
            GlassLife = tag.GetInt("GlassLife");

            //Other
            HoneyLife = tag.GetInt("HoneyLife");
            SlimeLife = tag.GetInt("SlimeLife");
            FossilLife = tag.GetInt("FossilLife");
            BubbleLife = tag.GetInt("BubbleLife");
            CoralstoneLife = tag.GetInt("CoralstoneLife");
            CandyCaneLife = tag.GetInt("CandyCaneLife");
            MushroomLife = tag.GetInt("MushroomLife");

            //Grown
            HayLife = tag.GetInt("HayLife");
            CactusLife = tag.GetInt("CactusLife");
            PumpkinLife = tag.GetInt("PumpkinLife");

            //Wood
            WoodLife = tag.GetInt("WoodLife");
            RichMahoganyLife = tag.GetInt("RichMahoganyLife");
            EbonwoodLife = tag.GetInt("EbonwoodLife");
            ShadewoodLife = tag.GetInt("ShadewoodLife");
            BorealWoodLife = tag.GetInt("BorealWoodLife");
            PalmWoodLife = tag.GetInt("PalmWoodLife");
            DynastyLife = tag.GetInt("DynastyLife");

            //Gems
            AmberLife = tag.GetInt("AmberLife");
            AmethystLife = tag.GetInt("AmethystLife");
            TopazLife = tag.GetInt("TopazLife");
            SapphireLife = tag.GetInt("SapphireLife");
            EmeraldLife = tag.GetInt("EmeraldLife");
            RubyLife = tag.GetInt("RubyLife");
            DiamondLife = tag.GetInt("DiamondLife");

            //Basic Ores
            CopperLife = tag.GetInt("CopperLife");
            TinLife = tag.GetInt("TinLife");
            IronLife = tag.GetInt("IronLife");
            LeadLife = tag.GetInt("LeadLife");
            SilverLife = tag.GetInt("SilverLife");
            TungstenLife = tag.GetInt("TungstenLife");
            GoldLife = tag.GetInt("GoldLife");
            PlatinumLife = tag.GetInt("PlatinumLife");

            //Other Ores
            MeteoriteLife = tag.GetInt("MeteoriteLife");
            DemoniteLife = tag.GetInt("DemoniteLife");
            CrimtaneLife = tag.GetInt("CrimtaneLife");
            HellstoneLife = tag.GetInt("HellstoneLife");

            //Hardmode//

            //Basic
            PearlstoneLife = tag.GetInt("PearlstoneLife");
            PearlsandLife = tag.GetInt("PearlsandLife");

            //Wood
            PearlwoodLife = tag.GetInt("PearlwoodLife");
            SpookyLife = tag.GetInt("SpookyLife");

            //Other
            RainbowLife = tag.GetInt("RainbowLife");
            CogLife = tag.GetInt("CogLife");
            FleshLife = tag.GetInt("FleshLife");
            LesionLife = tag.GetInt("LesionLife");
            CrystalLife = tag.GetInt("CrystalLife");

            //Basic Ores
            CobaltLife = tag.GetInt("CobaltLife");
            PalladiumLife = tag.GetInt("PalladiumLife");
            MythrilLife = tag.GetInt("MythrilLife");
            OrichalcumLife = tag.GetInt("OrichalcumLife");
            AdamantiteLife = tag.GetInt("AdamantiteLife");
            TitaniumLife = tag.GetInt("TitaniumLife");
            ChlorophyteLife = tag.GetInt("ChlorophyteLife");
            LuminiteLife = tag.GetInt("LuminiteLife");

            //Expert Hearts
            BrainLife = tag.GetInt("BrainLife");
            WormLife = tag.GetInt("WormLife");
            DemonHeartMK2Life = tag.GetInt("DemonHeartMK2Life");
            MechanicalLife = tag.GetInt("MechanicalLife");

            //Dev Hearts
            HeartOfCAT = tag.GetInt("HeartOfCAT");
            CrystalLite = tag.GetInt("CrystalLite");

            nonStopParty = tag.GetBool("nonStopParty");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            reader.ReadInt32();
        }
    }
}
