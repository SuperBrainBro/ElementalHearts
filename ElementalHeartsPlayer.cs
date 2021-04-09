using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts
{
    public class ElementalHeartsPlayer : ModPlayer
    {
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

        //Souls
        public int SoulofLightLife;
        public int SoulofNightLife;
        public int SoulofFlightLife;
        public int SoulofFrightLife;
        public int SoulofMightLife;
        public int SoulofSightLife;
        public int SoulofBlightLife;

        //Other
        public int RainbowLife;
        public int CogLife;
        public int FleshLife;
        public int LesionLife;
        public int CrystalLife;
        public int EctoplasmLife;

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
        public int VolatileLife;
        public int PlantLife;
        public int LihzhardianLife;
        public int SoaringLife;
        public int FisharkLife;
        public int AncientLife;
        public int CelestialLife;
        public int ZephyrsLife;
        public int SeaBreezeLife;
        public int VampiresLife;
        public int LifeOfTheStorm;
        public int ChampionsLife;
        public int OmegaLife;
        public int IceBoundStriderLife;
        public int FallenLife;
        public int LichsLife;
        public int AbyssalLife;
        public int DormantLife;
        public int DD2DarkLifeT1;
        public int DD2DarkLifeT3;
        public int DD2SnotLifeT2;
        public int DD2SnotLifeT3;
        public int OceanLife;
        public int FungalLife;
        public int RottenLife;
        public int BloodyWormLife;
        public int PolarizedLife;
        public int LifeOfCryogen;
        public int GehennaLife;
        public int AquaticLife;
        public int VoidOfLife;
        public int LifeAmbergris;
        public int GravistarLife;
        public int CrystallizedToxicLife;
        public int CorpusLife;
        public int AstralBossLife;
        public int ProfanedLife;
        public int DynamoStemLife;
        public int BlazingLife;
        public int ArmoredLife;
        public int DarkPlasmicLife;
        public int TwistingLife;
        public int AfflictedLife;
        public int MutatedLife;
        public int NebulousLife;
        public int DraconicLife;
        public int CalamitousLife;
        public int DeviLife;
        public int AbomLife;
        public int MutantLife;

        //Stuff from the ElementalHeartsPlayer2//

        public int CursedFlameLife;
        public int IchorLife;
        public int VoiditeLife;

        public int SoulofFraughtLife;
        public int SoulofThoughtLife;
        public int SoulofWroughtLife;

        //Boss Hearts
        public int EasterLife;
        public int LifeoPlenty;
        public int CursedLife;
        public int VenomLife;
        public int InfernoLife;
        public int ScourgeLife;
        public int LifeofHope;
        public int LifeoftheFrost;
        public int SacredLife;
        public int AqueousLife;
        public int DrakonianLife;
        public int FieryLife;
        public int LifeofDespair;
        public int LifeoftheInfection;
        public int CrystallineLife;
        public int Pyralife;
        public int Lifethema;
        public int MoltenLife;
        public int AnDioLife;
        public int EtheriaLife;

        public override void ResetEffects()
        {
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

            //Souls
            player.statLifeMax2 += SoulofLightLife * 4;
            player.statLifeMax2 += SoulofNightLife * 4;
            player.statLifeMax2 += SoulofFlightLife * 4;
            player.statLifeMax2 += SoulofFrightLife * 5;
            player.statLifeMax2 += SoulofMightLife * 5;
            player.statLifeMax2 += SoulofSightLife * 5;
            player.statLifeMax2 += SoulofBlightLife * 5;

            //Other
            player.statLifeMax2 += RainbowLife * 5;
            player.statLifeMax2 += CogLife * 5;
            player.statLifeMax2 += FleshLife * 5;
            player.statLifeMax2 += LesionLife * 5;
            player.statLifeMax2 += CrystalLife * 7;
            player.statLifeMax2 += EctoplasmLife * 8;

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
            player.statLifeMax2 += VolatileLife * 10;
            player.statLifeMax2 += PlantLife * 10;
            player.statLifeMax2 += LihzhardianLife * 10;
            player.statLifeMax2 += SoaringLife * 10;
            player.statLifeMax2 += FisharkLife * 10;
            player.statLifeMax2 += AncientLife * 10;
            player.statLifeMax2 += CelestialLife * 10;
            player.statLifeMax2 += ZephyrsLife * 5;
            player.statLifeMax2 += SeaBreezeLife * 5;
            player.statLifeMax2 += VampiresLife * 5;
            player.statLifeMax2 += LifeOfTheStorm * 5;
            player.statLifeMax2 += ChampionsLife * 5;
            player.statLifeMax2 += OmegaLife * 5;
            player.statLifeMax2 += IceBoundStriderLife * 10;
            player.statLifeMax2 += FallenLife * 10;
            player.statLifeMax2 += LichsLife * 10;
            player.statLifeMax2 += AbyssalLife * 10;
            player.statLifeMax2 += DormantLife * 10;
            player.statLifeMax2 += DD2DarkLifeT1 * 5;
            player.statLifeMax2 += DD2DarkLifeT3 * 10;
            player.statLifeMax2 += DD2SnotLifeT2 * 5;
            player.statLifeMax2 += DD2SnotLifeT3 * 10;
            player.statLifeMax2 += OceanLife * 5;
            player.statLifeMax2 += FungalLife * 5;
            player.statLifeMax2 += RottenLife * 5;
            player.statLifeMax2 += BloodyWormLife * 5;
            player.statLifeMax2 += PolarizedLife * 5;
            player.statLifeMax2 += LifeOfCryogen * 10;
            player.statLifeMax2 += GehennaLife * 10;
            player.statLifeMax2 += AquaticLife * 10;
            player.statLifeMax2 += VoidOfLife * 10;
            player.statLifeMax2 += LifeAmbergris * 10;
            player.statLifeMax2 += GravistarLife * 10;
            player.statLifeMax2 += CrystallizedToxicLife * 10;
            player.statLifeMax2 += CorpusLife * 10;
            player.statLifeMax2 += AstralBossLife * 10;
            player.statLifeMax2 += ProfanedLife * 15;
            player.statLifeMax2 += DynamoStemLife * 15;
            player.statLifeMax2 += BlazingLife * 15;
            player.statLifeMax2 += ArmoredLife * 15;
            player.statLifeMax2 += DarkPlasmicLife * 15;
            player.statLifeMax2 += TwistingLife * 15;
            player.statLifeMax2 += AfflictedLife * 15;
            player.statLifeMax2 += MutatedLife * 15;
            player.statLifeMax2 += NebulousLife * 15;
            player.statLifeMax2 += DraconicLife * 15;
            player.statLifeMax2 += CalamitousLife * 15;
            player.statLifeMax2 += DeviLife * 5;
            player.statLifeMax2 += AbomLife * 15;
            player.statLifeMax2 += MutantLife * 15;

            //Stuff from the ElementalHeartsPlayer2//

            player.statLifeMax2 += CursedFlameLife * 5;
            player.statLifeMax2 += IchorLife * 5;
            player.statLifeMax2 += VoiditeLife * 1;

            player.statLifeMax2 += SoulofFraughtLife * 5;
            player.statLifeMax2 += SoulofThoughtLife * 5;
            player.statLifeMax2 += SoulofWroughtLife * 5;

            //Boss Hearts
            player.statLifeMax2 += EasterLife * 5;
            player.statLifeMax2 += LifeoPlenty * 5;
            player.statLifeMax2 += CursedLife * 10;
            player.statLifeMax2 += VenomLife * 5;
            player.statLifeMax2 += InfernoLife * 5;
            player.statLifeMax2 += ScourgeLife * 10;
            player.statLifeMax2 += LifeofHope * 10;
            player.statLifeMax2 += LifeoftheFrost * 10;
            player.statLifeMax2 += SacredLife * 10;
            player.statLifeMax2 += AqueousLife * 10;
            player.statLifeMax2 += DrakonianLife * 15;
            player.statLifeMax2 += FieryLife * 15;
            player.statLifeMax2 += CharredLife * 15;
            player.statLifeMax2 += LifeofDespair * 15;
            player.statLifeMax2 += LifeoftheInfection * 15;
            player.statLifeMax2 += CrystallineLife * 15;
            player.statLifeMax2 += Pyralife * 5;
            player.statLifeMax2 += Lifethema * 5;
            player.statLifeMax2 += MoltenLife * 5;
            player.statLifeMax2 += AnDioLife * 5;
            player.statLifeMax2 += EtheriaLife * 10;
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

            //Souls
            packet.Write(SoulofLightLife);
            packet.Write(SoulofNightLife);
            packet.Write(SoulofFlightLife);
            packet.Write(SoulofMightLife);
            packet.Write(SoulofSightLife);
            packet.Write(SoulofFrightLife);
            packet.Write(SoulofBlightLife);

            //Other
            packet.Write(RainbowLife);
            packet.Write(CogLife);
            packet.Write(FleshLife);
            packet.Write(LesionLife);
            packet.Write(CrystalLife);
            packet.Write(EctoplasmLife);

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
            packet.Write(VolatileLife);
            packet.Write(LihzhardianLife);
            packet.Write(SoaringLife);
            packet.Write(FisharkLife);
            packet.Write(AncientLife);
            packet.Write(CelestialLife);
            packet.Write(ZephyrsLife);
            packet.Write(SeaBreezeLife);
            packet.Write(VampiresLife);
            packet.Write(LifeOfTheStorm);
            packet.Write(ChampionsLife);
            packet.Write(OmegaLife);
            packet.Write(IceBoundStriderLife);
            packet.Write(FallenLife);
            packet.Write(LichsLife);
            packet.Write(AbyssalLife);
            packet.Write(DormantLife);
            packet.Write(DD2DarkLifeT1);
            packet.Write(DD2DarkLifeT3);
            packet.Write(DD2SnotLifeT2);
            packet.Write(DD2SnotLifeT3);
            packet.Write(OceanLife);
            packet.Write(FungalLife);
            packet.Write(RottenLife);
            packet.Write(BloodyWormLife);
            packet.Write(PolarizedLife);
            packet.Write(LifeOfCryogen);
            packet.Write(GehennaLife);
            packet.Write(AquaticLife);
            packet.Write(VoidOfLife);
            packet.Write(LifeAmbergris);
            packet.Write(GravistarLife);
            packet.Write(CrystallizedToxicLife);
            packet.Write(CorpusLife);
            packet.Write(AstralBossLife);
            packet.Write(ProfanedLife);
            packet.Write(DynamoStemLife);
            packet.Write(BlazingLife);
            packet.Write(ArmoredLife);
            packet.Write(DarkPlasmicLife);
            packet.Write(TwistingLife);
            packet.Write(MutatedLife);
            packet.Write(NebulousLife);
            packet.Write(DraconicLife);
            packet.Write(CalamitousLife);
            packet.Write(DeviLife);
            packet.Write(AbomLife);
            packet.Write(MutantLife);

            //Stuff from the ElementalHeartsPlayer2//

            packet.Write(CursedFlameLife);
            packet.Write(IchorLife);
            packet.Write(VoiditeLife);

            packet.Write(SoulofFraughtLife);
            packet.Write(SoulofThoughtLife);
            packet.Write(SoulofWroughtLife);

            //Boss Hearts
            packet.Write(EasterLife);
            packet.Write(LifeoPlenty);
            packet.Write(CursedLife);
            packet.Write(VenomLife);
            packet.Write(InfernoLife);
            packet.Write(ScourgeLife);
            packet.Write(LifeofHope);
            packet.Write(LifeoftheFrost);
            packet.Write(SacredLife);
            packet.Write(AqueousLife);
            packet.Write(DrakonianLife);
            packet.Write(FieryLife);
            packet.Write(CharredLife);
            packet.Write(LifeofDespair);
            packet.Write(LifeoftheInfection);
            packet.Write(CrystallineLife);
            packet.Write(Pyralife);
            packet.Write(Lifethema);
            packet.Write(MoltenLife);
            packet.Write(AnDioLife);
            packet.Write(EtheriaLife);

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

                //Souls
                { "SoulofLightLife", SoulofLightLife },
                { "SoulofNightLife", SoulofNightLife },
                { "SoulofFlightLife", SoulofFlightLife },
                { "SoulofFrightLife", SoulofFrightLife },
                { "SoulofMightLife", SoulofMightLife },
                { "SoulofSightLife", SoulofSightLife },
                { "SoulofBlightLife", SoulofBlightLife },

                //Other
                {"RainbowLife", RainbowLife},
                {"CogLife", CogLife},
                {"FleshLife", FleshLife},
                {"LesionLife", LesionLife},
                {"CrystalLife", CrystalLife},
                { "EctoplasmLife", EctoplasmLife },

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
                { "VolatileLife", VolatileLife },
                { "PlantLife", PlantLife},
                { "LihzhardianLife", LihzhardianLife },
                { "SoaringLife", SoaringLife },
                { "FisharkLife", FisharkLife },
                { "AncientLife", AncientLife},
                { "CelestialLife", CelestialLife},
                { "ZephyrsLife", ZephyrsLife },
                { "SeaBreezeLife", SeaBreezeLife },
                { "VampiresLife", VampiresLife },
                { "LifeOfTheStorm", LifeOfTheStorm },
                { "ChampionsLife", ChampionsLife },
                { "OmegaLife", OmegaLife },
                { "IceBoundStriderLife", IceBoundStriderLife},
                { "FallenLife", FallenLife },
                { "LichsLife", LichsLife },
                { "AbyssalLife", AbyssalLife },
                { "DormantLife", DormantLife },
                { "DD2DarkHeartT1", DD2DarkLifeT1 },
                { "DD2DarkHeartT3", DD2DarkLifeT3 },
                { "DD2SnotHeartT2", DD2SnotLifeT2 },
                { "DD2SnotHeartT3", DD2SnotLifeT3 },
                { "OceanLife", OceanLife },
                { "FungalLife", FungalLife },
                { "RottenLife", RottenLife },
                { "BloodyWormLife", BloodyWormLife },
                { "PolarizedLife", PolarizedLife },
                { "LifeOfCryogen", LifeOfCryogen },
                { "GehennaLife", GehennaLife },
                { "AquaticLife", AquaticLife },
                { "VoidOfLife", VoidOfLife },
                { "LifeAmbergris", LifeAmbergris },
                { "GravistarLife", GravistarLife },
                { "CrystallizedToxicLife", CrystallizedToxicLife },
                { "CorpusLife", CorpusLife },
                { "AstralBossLife", AstralBossLife },
                { "ProfanedLife", ProfanedLife },
                { "DynamoStemLife", DynamoStemLife },
                { "BlazingLife", BlazingLife },
                { "ArmoredLife", ArmoredLife },
                { "DarkPlasmicLife", DarkPlasmicLife },
                { "TwistingLife", TwistingLife },
                { "AfflictedLife", AfflictedLife },
                { "MutatedLife", MutatedLife },
                { "NebulousLife", NebulousLife },
                { "DraconicLife", DraconicLife },
                { "CalamitousLife", CalamitousLife },
                { "DeviLife", DeviLife },
                { "AbomLife", AbomLife },
                { "MutantLife", MutantLife },
                
                //Stuff from the ElementalHeartsPlayer2//

                {"CursedFlameLife", CursedFlameLife },
                {"IchorLife", IchorLife },
                {"VoiditeLife", VoiditeLife },

                {"SoulofFraughtLife", SoulofFraughtLife },
                {"SoulofThoughtLife", SoulofThoughtLife },
                {"SoulofWroughtLife", SoulofWroughtLife },

                //Boss Hearts
                {"EasterLife", EasterLife},
                {"LifeoPlenty", LifeoPlenty},
                {"CursedLife", CursedLife},
                {"VenomLife", VenomLife },
                {"InfernoLife", InfernoLife },
                {"ScourgeLife", ScourgeLife },
                {"LifeofHope", LifeofHope },
                {"LifeoftheFrost", LifeoftheFrost },
                {"SacredLife", SacredLife },
                {"AqueousLife", AqueousLife },
                {"DrakonianLife", DrakonianLife },
                {"FieryLife", FieryLife },
                {"CharredLife", CharredLife },
                {"LifeofDespair", LifeofDespair },
                {"LifeoftheInfection", LifeoftheInfection },
                {"CrystallineLife", CrystallineLife },
                {"Pyralife", Pyralife },
                {"Lifethema", Lifethema },
                {"MoltenLife", MoltenLife },
                {"AnDioLife", AnDioLife },
                {"EtheriaLife", EtheriaLife },

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

            //Souls
            SoulofLightLife = tag.GetInt("SoulofLightLife");
            SoulofNightLife = tag.GetInt("SoulofNightLife");
            SoulofFlightLife = tag.GetInt("SoulofFlightLife");
            SoulofFrightLife = tag.GetInt("SoulofFrightLife");
            SoulofMightLife = tag.GetInt("SoulofMightLife");
            SoulofSightLife = tag.GetInt("SoulofSightLife");
            SoulofBlightLife = tag.GetInt("SoulofBlightLife");

            //Other
            RainbowLife = tag.GetInt("RainbowLife");
            CogLife = tag.GetInt("CogLife");
            FleshLife = tag.GetInt("FleshLife");
            LesionLife = tag.GetInt("LesionLife");
            CrystalLife = tag.GetInt("CrystalLife");
            EctoplasmLife = tag.GetInt("EctoplasmLife");

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
            VolatileLife = tag.GetInt("VolatileLife");
            PlantLife = tag.GetInt("PlantLife");
            LihzhardianLife = tag.GetInt("LihzhardianLife");
            SoaringLife = tag.GetInt("SoaringLife");
            FisharkLife = tag.GetInt("FisharkLife");
            AncientLife = tag.GetInt("AncientLife");
            CelestialLife = tag.GetInt("CelestialLife");
            ZephyrsLife = tag.GetInt("ZephyrsLife");
            SeaBreezeLife = tag.GetInt("SeaBreezeLife");
            VampiresLife = tag.GetInt("VampiresLife");
            LifeOfTheStorm = tag.GetInt("LifeOfTheStorm");
            ChampionsLife = tag.GetInt("ChampionsLife");
            OmegaLife = tag.GetInt("OmegaLife");
            IceBoundStriderLife = tag.GetInt("IceBoundStriderLife");
            FallenLife = tag.GetInt("FallenLife");
            LichsLife = tag.GetInt("LichsLife");
            AbyssalLife = tag.GetInt("AbyssalLife");
            DormantLife = tag.GetInt("DormantLife");
            DD2DarkLifeT1 = tag.GetInt("DD2DarkLifeT1");
            DD2DarkLifeT3 = tag.GetInt("DD2DarkLifeT3");
            DD2SnotLifeT2 = tag.GetInt("DD2SnotLifeT2");
            DD2SnotLifeT3 = tag.GetInt("DD2SnotLifeT3");
            OceanLife = tag.GetInt("OceanLife");
            FungalLife = tag.GetInt("FungalLife");
            RottenLife = tag.GetInt("RottenLife");
            BloodyWormLife = tag.GetInt("BloodyWormLife");
            PolarizedLife = tag.GetInt("PolarizedLife");
            LifeOfCryogen = tag.GetInt("LifeOfCryogen");
            GehennaLife = tag.GetInt("GehennaLife");
            AquaticLife = tag.GetInt("AquaticLife");
            VoidOfLife = tag.GetInt("VoidOfLife");
            LifeAmbergris = tag.GetInt("LifeAmbergris");
            GravistarLife = tag.GetInt("GravistarLife");
            CrystallizedToxicLife = tag.GetInt("CrystallizedToxicLife");
            CorpusLife = tag.GetInt("CorpusLife");
            AstralBossLife = tag.GetInt("AstralBossLife");
            ProfanedLife = tag.GetInt("ProfanedLife");
            DynamoStemLife = tag.GetInt("DynamoStemLife");
            BlazingLife = tag.GetInt("BlazingLife");
            ArmoredLife = tag.GetInt("ArmoredLife");
            DarkPlasmicLife = tag.GetInt("DarkPlasmicLife");
            TwistingLife = tag.GetInt("TwistingLife");
            AfflictedLife = tag.GetInt("AfflictedLife");
            MutatedLife = tag.GetInt("MutatedLife");
            NebulousLife = tag.GetInt("NebulousLife");
            DraconicLife = tag.GetInt("DraconicLife");
            CalamitousLife = tag.GetInt("CalamitousLife");
            DeviLife = tag.GetInt("DeviLife");
            AbomLife = tag.GetInt("AbomLife");
            MutantLife = tag.GetInt("MutantLife");

            //Stuff from the ElementalHeartsPlayer2//

            CursedFlameLife = tag.GetInt("CursedFlameLife");
            IchorLife = tag.GetInt("IchorLife");
            VoiditeLife = tag.GetInt("VoiditeLife");

            SoulofFraughtLife = tag.GetInt("SoulofFraughtLife");
            SoulofThoughtLife = tag.GetInt("SoulofThoughtLife");
            SoulofWroughtLife = tag.GetInt("SoulofWroughtLife");

            //Boss Hearts
            EasterLife = tag.GetInt("EasterLife");
            LifeoPlenty = tag.GetInt("LifeoPlenty");
            CursedLife = tag.GetInt("CursedLife");
            VenomLife = tag.GetInt("VenomLife");
            InfernoLife = tag.GetInt("InfernoLife");
            ScourgeLife = tag.GetInt("ScourgeLife");
            LifeofHope = tag.GetInt("LifeofHope");
            LifeoftheFrost = tag.GetInt("LifeoftheFrost");
            SacredLife = tag.GetInt("SacredLife");
            AqueousLife = tag.GetInt("AqueousLife");
            DrakonianLife = tag.GetInt("DrakonianLife");
            FieryLife = tag.GetInt("FieryLife");
            CharredLife = tag.GetInt("CharredLife");
            LifeofDespair = tag.GetInt("LifeofDespair");
            LifeoftheInfection = tag.GetInt("LifeoftheInfection");
            CrystallineLife = tag.GetInt("CrystallineLife");
            Pyralife = tag.GetInt("Pyralife");
            Lifethema = tag.GetInt("Lifethema");
            MoltenLife = tag.GetInt("MoltenLife");
            AnDioLife = tag.GetInt("AnDioLife");
            EtheriaLife = tag.GetInt("EtheriaLife");

            nonStopParty = tag.GetBool("nonStopParty");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            reader.ReadInt32();
        }
    }
}
