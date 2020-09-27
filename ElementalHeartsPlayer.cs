using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool shadowFox = false;
        public bool shadowFoxB = false;
        public bool setBonusFox = false;
        //Debuffs/Buffs
        public bool curseCATsCurse;

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

        //Thorium Mod
        public int AquaiteLife;
        public int BrackishClumpLife;
        public int DepthsRockLife;
        public int IllumiteLife;
        public int LifeQuartzLife;
        public int LodestoneLife;
        public int MagmaLife;
        public int MossyMarineRockLife;
        public int OnyxLife;
        public int OpalLife;
        public int PearlLife;
        public int PermafrostLife;
        public int SmoothCoalLife;
        public int ThoriumLife;
        public int ValadiumLife;
        public int YewWoodLife;

        //Calamity Mod
        public int AbyssGravelLife;
        public int AerialiteLife;
        public int AstralClayLife;
        public int AstralDirtLife;
        public int AstralLife;
        public int AstralIceLife;
        public int AstralMonolithLife;
        public int AstralSandLife;
        public int AstralSandstoneLife;
        public int AstralSnowLife;
        public int AstralStoneLife;
        public int AuricLife;
        public int BrimstoneSlagLife;
        public int CelestialRemainsLife;
        public int CharredLife;
        public int CinderplateLife;
        public int CryonicLife;
        public int EutrophicSandLife;
        public int ExodiumClusterLife;
        public int HardenedAstralSandLife;
        public int HardenedSulphurousSandstoneLife;
        public int NavystoneLife;
        public int NovaeSlugLife;
        public int PerennialLife;
        public int PlantyMushLife;
        public int ScoriaLife;
        public int SeaPrismLife;
        public int SulphurousSandLife;
        public int SulphurousSandstoneLife;
        public int TenebrisLife;
        public int UelibloomLife;
        public int VoidstoneLife;

        //Boss Hearts
        public int MenacingLife;
        public int RoyalSlimeLife;
        public int EyeLife;
        public int HiveLife;
        public int BoneLife;
        public int PlantLife;
        public int AncientLife;
        public int CelestialLife;

        public override void ResetEffects()
        {
            //ElementalHeartsConfig config = new ElementalHeartsConfig();
            shadowFox = false;
            shadowFoxB = false;
            setBonusFox = false;

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

            //Thorium Mod
            player.statLifeMax2 += AquaiteLife * 1;
            player.statLifeMax2 += BrackishClumpLife * 1;
            player.statLifeMax2 += DepthsRockLife * 1;
            player.statLifeMax2 += IllumiteLife * 1;
            player.statLifeMax2 += LifeQuartzLife * 1;
            player.statLifeMax2 += LodestoneLife * 1;
            player.statLifeMax2 += MagmaLife * 1;
            player.statLifeMax2 += MossyMarineRockLife * 1;
            player.statLifeMax2 += OnyxLife * 1;
            player.statLifeMax2 += OpalLife * 1;
            player.statLifeMax2 += PearlLife * 1;
            player.statLifeMax2 += PermafrostLife * 1;
            player.statLifeMax2 += SmoothCoalLife * 1;
            player.statLifeMax2 += ThoriumLife * 1;
            player.statLifeMax2 += ValadiumLife * 1;
            player.statLifeMax2 += YewWoodLife * 1;

            //Calamity Mod
            player.statLifeMax2 += AbyssGravelLife * 1;
            player.statLifeMax2 += AerialiteLife * 1;
            player.statLifeMax2 += AstralClayLife * 1;
            player.statLifeMax2 += AstralDirtLife * 1;
            player.statLifeMax2 += AstralLife * 1;
            player.statLifeMax2 += AstralIceLife * 1;
            player.statLifeMax2 += AstralMonolithLife * 1;
            player.statLifeMax2 += AstralSandLife * 1;
            player.statLifeMax2 += AstralSandstoneLife * 1;
            player.statLifeMax2 += AstralSnowLife * 1;
            player.statLifeMax2 += AstralStoneLife * 1;
            player.statLifeMax2 += AuricLife * 1;
            player.statLifeMax2 += BrimstoneSlagLife * 1;
            player.statLifeMax2 += CelestialRemainsLife * 1;
            player.statLifeMax2 += CharredLife * 1;
            player.statLifeMax2 += CinderplateLife * 1;
            player.statLifeMax2 += CryonicLife * 1;
            player.statLifeMax2 += EutrophicSandLife * 1;
            player.statLifeMax2 += ExodiumClusterLife * 1;
            player.statLifeMax2 += HardenedAstralSandLife * 1;
            player.statLifeMax2 += HardenedSulphurousSandstoneLife * 1;
            player.statLifeMax2 += NavystoneLife * 1;
            player.statLifeMax2 += NovaeSlugLife * 1;
            player.statLifeMax2 += PerennialLife * 1;
            player.statLifeMax2 += PlantyMushLife * 1;
            player.statLifeMax2 += ScoriaLife * 1;
            player.statLifeMax2 += SeaPrismLife * 1;
            player.statLifeMax2 += SulphurousSandLife * 1;
            player.statLifeMax2 += SulphurousSandstoneLife * 1;
            player.statLifeMax2 += TenebrisLife * 1;
            player.statLifeMax2 += UelibloomLife * 1;
            player.statLifeMax2 += VoidstoneLife * 1;

            //Boss Hearts
            player.statLifeMax2 += MenacingLife * 5;
            player.statLifeMax2 += RoyalSlimeLife * 5;
            player.statLifeMax2 += EyeLife * 5;
            player.statLifeMax2 += HiveLife * 5;
            player.statLifeMax2 += BoneLife * 5;
            player.statLifeMax2 += PlantLife * 10;
            player.statLifeMax2 += AncientLife * 10;
            player.statLifeMax2 += CelestialLife * 10;
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

            //Thorium Mod
            packet.Write(AquaiteLife);
            packet.Write(BrackishClumpLife);
            packet.Write(DepthsRockLife);
            packet.Write(IllumiteLife);
            packet.Write(LifeQuartzLife);
            packet.Write(LodestoneLife);
            packet.Write(MagmaLife);
            packet.Write(MossyMarineRockLife);
            packet.Write(OnyxLife);
            packet.Write(OpalLife);
            packet.Write(PearlLife);
            packet.Write(PermafrostLife);
            packet.Write(SmoothCoalLife);
            packet.Write(ThoriumLife);
            packet.Write(ValadiumLife);
            packet.Write(YewWoodLife);

            //Calamity Mod
            packet.Write(AbyssGravelLife);
            packet.Write(AerialiteLife);
            packet.Write(AstralClayLife);
            packet.Write(AstralDirtLife);
            packet.Write(AstralLife);
            packet.Write(AstralIceLife);
            packet.Write(AstralMonolithLife);
            packet.Write(AstralSandLife);
            packet.Write(AstralSandstoneLife);
            packet.Write(AstralSnowLife);
            packet.Write(AstralStoneLife);
            packet.Write(AuricLife);
            packet.Write(BrimstoneSlagLife);
            packet.Write(CelestialRemainsLife);
            packet.Write(CharredLife);
            packet.Write(CinderplateLife);
            packet.Write(CryonicLife);
            packet.Write(EutrophicSandLife);
            packet.Write(ExodiumClusterLife);
            packet.Write(HardenedAstralSandLife);
            packet.Write(HardenedSulphurousSandstoneLife);
            packet.Write(NavystoneLife);
            packet.Write(NovaeSlugLife);
            packet.Write(PerennialLife);
            packet.Write(PlantyMushLife);
            packet.Write(ScoriaLife);
            packet.Write(SeaPrismLife);
            packet.Write(SulphurousSandLife);
            packet.Write(SulphurousSandstoneLife);
            packet.Write(TenebrisLife);
            packet.Write(UelibloomLife);
            packet.Write(VoidstoneLife);


            //Boss Hearts
            packet.Write(MenacingLife);
            packet.Write(RoyalSlimeLife);
            packet.Write(EyeLife);
            packet.Write(HiveLife);
            packet.Write(BoneLife);
            packet.Write(PlantLife);
            packet.Write(AncientLife);
            packet.Write(CelestialLife);

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

                //Thorium Mod
                { "AquaiteLife", AquaiteLife},
                { "BrackishClumpLife", BrackishClumpLife},
                { "DepthsRockLife", DepthsRockLife},
                { "IllumiteLife", IllumiteLife},
                { "LifeQuartzLife", LifeQuartzLife},
                { "LodestoneLife", LodestoneLife},
                { "MagmaLife", MagmaLife},
                { "MossyMarineRockLife", MossyMarineRockLife},
                { "OnyxLife", OnyxLife},
                { "OpalLife", OpalLife},
                { "PearlLife", PearlLife},
                { "PermafrostLife", PermafrostLife},
                { "SmoothCoalLife", SmoothCoalLife},
                { "ThoriumLife", ThoriumLife},
                { "ValadiumLife", ValadiumLife},
                { "YewWoodLife", YewWoodLife},

                //Calamity Mod
                { "AbyssGravelLife", AbyssGravelLife},
                { "AerialiteLife", AerialiteLife},
                { "AstralClayLife", AstralClayLife},
                { "AstralDirtLife", AstralDirtLife},
                { "AstralLife", AstralLife},
                { "AstralIceLife", AstralIceLife},
                { "AstralMonolithLife", AstralMonolithLife},
                { "AstralSandLife", AstralSandLife},
                { "AstralSandstoneLife", AstralSandstoneLife},
                { "AstralSnowLife", AstralSnowLife},
                { "AstralStoneLife", AstralStoneLife},
                { "AuricLife", AuricLife},
                { "BrimstoneSlagLife", BrimstoneSlagLife},
                { "CelestialRemainsLife", CelestialRemainsLife},
                { "CharredLife", CharredLife},
                { "CinderplateLife", CinderplateLife},
                { "CryonicLife", CryonicLife},
                { "EutrophicSandLife", EutrophicSandLife},
                { "ExodiumClusterLife", ExodiumClusterLife},
                { "HardenedAstralSandLife", HardenedAstralSandLife},
                { "HardenedSulphurousSandstoneLife", HardenedSulphurousSandstoneLife},
                { "NavystoneLife", NavystoneLife},
                { "NovaeSlugLife", NovaeSlugLife},
                { "PerennialLife", PerennialLife},
                { "PlantyMushLife", PlantyMushLife},
                { "ScoriaLife", ScoriaLife},
                { "SeaPrismLife", SeaPrismLife},
                { "SulphurousSandLife", SulphurousSandLife},
                { "SulphurousSandstoneLife", SulphurousSandstoneLife},
                { "TenebrisLife", TenebrisLife},
                { "UelibloomLife", UelibloomLife},
                { "VoidstoneLife", VoidstoneLife},
    
                //Boss Hearts                          
                { "MenacingLife", MenacingLife},
                { "RoyalSlimeLife", RoyalSlimeLife},
                { "EyeLife", EyeLife},
                { "HiveLife", HiveLife},
                { "BoneLife", BoneLife},
                { "PlantLife", PlantLife},
                { "AncientLife", AncientLife},
                { "CelestialLife", CelestialLife},

                //Other
                { "nonStopParty", nonStopParty},
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

            //Thorium Mod
            AquaiteLife = tag.GetInt("AquaiteLife");
            BrackishClumpLife = tag.GetInt("BrackishClumpLife");
            DepthsRockLife = tag.GetInt("DepthsRockLife");
            IllumiteLife = tag.GetInt("IllumiteLife");
            LifeQuartzLife = tag.GetInt("LifeQuartzLife");
            LodestoneLife = tag.GetInt("LodestoneLife");
            MagmaLife = tag.GetInt("MagmaLife");
            MossyMarineRockLife = tag.GetInt("MossyMarineRockLife");
            OnyxLife = tag.GetInt("OnyxLife");
            OpalLife = tag.GetInt("OpalLife");
            PearlLife = tag.GetInt("PearlLife");
            PermafrostLife = tag.GetInt("PermafrostLife");
            SmoothCoalLife = tag.GetInt("SmoothCoalLife");
            ThoriumLife = tag.GetInt("ThoriumLife");
            ValadiumLife = tag.GetInt("ValadiumLife");
            YewWoodLife = tag.GetInt("YewWoodLife");

            //Calamity Mod
            AbyssGravelLife = tag.GetInt("AbyssGravelLife");
            AerialiteLife = tag.GetInt("AerialiteLife");
            AstralClayLife = tag.GetInt("AstralClayLife");
            AstralDirtLife = tag.GetInt("AstralDirtLife");
            AstralLife = tag.GetInt("AstralLife");
            AstralIceLife = tag.GetInt("AstralIceLife");
            AstralMonolithLife = tag.GetInt("AstralMonolithLife");
            AstralSandLife = tag.GetInt("AstralSandLife");
            AstralSandstoneLife = tag.GetInt("AstralSandstoneLife");
            AstralSnowLife = tag.GetInt("AstralSnowLife");
            AstralStoneLife = tag.GetInt("AstralStoneLife");
            AuricLife = tag.GetInt("AuricLife");
            BrimstoneSlagLife = tag.GetInt("BrimstoneSlagLife");
            CelestialRemainsLife = tag.GetInt("CelestialRemainsLife");
            CharredLife = tag.GetInt("CharredLife");
            CinderplateLife = tag.GetInt("CinderplateLife");
            CryonicLife = tag.GetInt("CryonicLife");
            EutrophicSandLife = tag.GetInt("EutrophicSandLife");
            ExodiumClusterLife = tag.GetInt("ExodiumClusterLife");
            HardenedAstralSandLife = tag.GetInt("HardenedAstralSandLife");
            HardenedSulphurousSandstoneLife = tag.GetInt("HardenedSulphurousSandstoneLife");
            NavystoneLife = tag.GetInt("NavystoneLife");
            NovaeSlugLife = tag.GetInt("NovaeSlugLife");
            PerennialLife = tag.GetInt("PerennialLife");
            PlantyMushLife = tag.GetInt("PlantyMushLife");
            ScoriaLife = tag.GetInt("ScoriaLife");
            SeaPrismLife = tag.GetInt("SeaPrismLife");
            SulphurousSandLife = tag.GetInt("SulphurousSandLife");
            SulphurousSandstoneLife = tag.GetInt("SulphurousSandstoneLife");
            TenebrisLife = tag.GetInt("TenebrisLife");
            UelibloomLife = tag.GetInt("UelibloomLife");
            VoidstoneLife = tag.GetInt("VoidstoneLife");

            //Boss Hearts
            MenacingLife = tag.GetInt("MenacingLife");
            RoyalSlimeLife = tag.GetInt("RoyalSlimeLife");
            EyeLife = tag.GetInt("EyeLife");
            HiveLife = tag.GetInt("HiveLife");
            BoneLife = tag.GetInt("BoneLife");
            PlantLife = tag.GetInt("PlantLife");
            AncientLife = tag.GetInt("AncientLife");
            CelestialLife = tag.GetInt("CelestialLife");

            nonStopParty = tag.GetBool("nonStopParty");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            reader.ReadInt32();
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ElementalHearts.OpenHeartUI.JustPressed)
            {
                if (GetInstance<ElementalHearts>().HeartUIOpen)
                {
                    Main.NewText("Closed Heart UI", Color.Red);
                    GetInstance<ElementalHearts>().HideMyUI();
                }
                else
                {
                    Main.NewText("Opened Heart UI", Color.Red);
                    GetInstance<ElementalHearts>().ShowMyUI();
                }
            }
            base.ProcessTriggers(triggersSet);
        }
    }
}
