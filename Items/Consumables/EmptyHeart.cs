using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class EmptyHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently Resets All Elemental Heart Stats");
            DisplayName.SetDefault("Heart Emptier");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.White;
            item.value = 0;
        }

        /// <summary>
        /// This block need for easier system of clearing hearts.
        ///'Type' is for choosing type/category
        /// </summary>
        /// <param name="player"></param>
        /// <param name="type"></param>
        private void TypeToClear(Player player, int type = 0)
        {
            switch (type)
            {
                //Pre-Hardmode
                case 1: //Basic
                    player.GetModPlayer<ElementalHeartsPlayer>().DirtLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().StoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CrimstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EbonstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().GraniteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MarbleLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().IceLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ObsidianLife = 0;

                    player.GetModPlayer<ElementalHeartsPlayer>().SandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EbonsandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CrimsandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().GlassLife = 0;
                    break;
                case 2: //Other
                    player.GetModPlayer<ElementalHeartsPlayer>().HoneyLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SlimeLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().FossilLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().BubbleLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CoralstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CandyCaneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MushroomLife = 0;
                    break;
                case 3: //Grown
                    player.GetModPlayer<ElementalHeartsPlayer>().HayLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CactusLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PumpkinLife = 0;
                    break;
                case 4: //Wood
                    player.GetModPlayer<ElementalHeartsPlayer>().WoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().RichMahoganyLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EbonwoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ShadewoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().BorealWoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PalmWoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().DynastyLife = 0;
                    break;
                case 5: //Gems
                    player.GetModPlayer<ElementalHeartsPlayer>().AmberLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AmethystLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().TopazLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SapphireLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EmeraldLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().RubyLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().DiamondLife = 0;
                    break;
                case 6: //Basic Ores
                    player.GetModPlayer<ElementalHeartsPlayer>().CopperLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().TinLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().IronLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LeadLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SilverLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().TungstenLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().GoldLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PlatinumLife = 0;
                    break;
                case 7: //Other Ores
                    player.GetModPlayer<ElementalHeartsPlayer>().MeteoriteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().DemoniteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CrimtaneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().HellstoneLife = 0;
                    break;
                //Hardmode
                case 8: //Basic
                    player.GetModPlayer<ElementalHeartsPlayer>().PearlstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PearlsandLife = 0;
                    break;
                case 9: //Wood
                    player.GetModPlayer<ElementalHeartsPlayer>().PearlwoodLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SpookyLife = 0;
                    break;
                case 10: //Souls
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofLightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofNightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofFlightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofFrightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofMightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofSightLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoulofBlightLife = 0;
                    break;
                case 11: //Other
                    player.GetModPlayer<ElementalHeartsPlayer>().RainbowLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CogLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().FleshLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LesionLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CrystalLife = 0;
                    break;
                case 12: //Basic Ores
                    player.GetModPlayer<ElementalHeartsPlayer>().CobaltLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PalladiumLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MythrilLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().OrichalcumLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AdamantiteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LuminiteLife = 0;
                    break;
                case 13: //Expert Hearts
                    player.GetModPlayer<ElementalHeartsPlayer>().BrainLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().WormLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().DemonHeartMK2Life = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MechanicalLife = 0;
                    break;
                case 14: //Dev Hearts
                    player.GetModPlayer<ElementalHeartsPlayer>().HeartOfCAT = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CrystalLite = 0;
                    break;

                case 1000: //Boss Hearts
                    player.GetModPlayer<ElementalHeartsPlayer>().MenacingLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().RoyalSlimeLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EyeLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().HiveLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().BoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().VolatileLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PlantLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LihzhardianLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SoaringLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AncientLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CelestialLife = 0;
                    break;

                case 10000: //Thorium Mod hearts
                    player.GetModPlayer<ElementalHeartsPlayer>().AquaiteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().BrackishClumpLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().DepthsRockLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().IllumiteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LifeQuartzLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().LodestoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MagmaLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().MossyMarineRockLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().OnyxLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().OpalLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PearlLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PermafrostLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SmoothCoalLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ThoriumLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ValadiumLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().YewWoodLife = 0;
                    break;
                case 10001: //Calamity Mod hearts
                    player.GetModPlayer<ElementalHeartsPlayer>().AbyssGravelLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AerialiteLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralClayLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralDirtLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralIceLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralMonolithLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralSandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralSandstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralSnowLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AstralStoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().AuricLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().BrimstoneSlagLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CelestialRemainsLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CharredLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CinderplateLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().CryonicLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().EutrophicSandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ExodiumClusterLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().HardenedAstralSandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().HardenedSulphurousSandstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().NavystoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().NovaeSlugLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PerennialLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().PlantyMushLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().ScoriaLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SeaPrismLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SulphurousSandLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().SulphurousSandstoneLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().TenebrisLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().UelibloomLife = 0;
                    player.GetModPlayer<ElementalHeartsPlayer>().VoidstoneLife = 0;
                    break;
                default:
                    break;
            }
        }

        public override bool UseItem(Player player)
        {

            Main.NewText("Cleared Elemental Heart stats!", Color.Orange);

            ////Life Crystals////

            TypeToClear(player, 1);
            TypeToClear(player, 2);
            TypeToClear(player, 3);
            TypeToClear(player, 4);
            TypeToClear(player, 5);
            TypeToClear(player, 6);
            TypeToClear(player, 7);

            TypeToClear(player, 8);
            TypeToClear(player, 9);
            TypeToClear(player, 10);
            TypeToClear(player, 11);
            TypeToClear(player, 12);
            TypeToClear(player, 13);
            TypeToClear(player, 14);

            TypeToClear(player, 10000);

            TypeToClear(player, 10001);

            TypeToClear(player, 1000);

            player.statLifeMax2 = 0;
            return true;
        }
    }
}
