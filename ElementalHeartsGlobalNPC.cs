using ElementalHearts.Items.Consumables;
using ElementalHearts.Items.Consumables.Bosses;
using ElementalHearts.Items.Consumables.Bosses.CrossMod;
using ElementalHearts.NPCs.Bosses.MenacingHeart;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts
{
    public class ElementalHeartsGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void NPCLoot(NPC npc)
        {
            #region Vanilla Bosses
            switch (npc.type) //Expert Drop of...
            {
                case NPCID.KingSlime when Main.expertMode: //King Slime
                    Item.NewItem(npc.getRect(), ItemType<RoyalSlimeHeart>());
                    break;
                case NPCID.EyeofCthulhu when Main.expertMode: //Eye of Cthulhu
                    Item.NewItem(npc.getRect(), ItemType<EyeHeart>());
                    break;
                case NPCID.BrainofCthulhu when Main.expertMode: //Brain of Cthulhu
                    Item.NewItem(npc.getRect(), ItemType<BrainHeart>());
                    break;
                case NPCID.DD2DarkMageT1 when Main.expertMode:
                case NPCID.DD2DarkMageT3 when Main.expertMode:
                    if (npc.type == NPCID.DD2DarkMageT1)
                    {
                        Item.NewItem(npc.getRect(), ItemType<Items.Consumables.Bosses.DarkHeart>());
                    }
                    else { Item.NewItem(npc.getRect(), ItemType<DarkHeart2>()); }
                    break;
                case NPCID.QueenBee when Main.expertMode: //Queen Bee
                    Item.NewItem(npc.getRect(), ItemType<HiveHeart>());
                    break;
                case NPCID.SkeletronHead when Main.expertMode: //Skeletron
                    Item.NewItem(npc.getRect(), ItemType<BoneHeart>());
                    break;
                case NPCID.WallofFlesh when Main.expertMode: //Wall of Flesh
                    Item.NewItem(npc.getRect(), ItemType<DemonHeartMK2>());
                    break;
                //case NPCID.QueenSlimeBoss when Main.expertMode: //Queen Slime
                //    Item.NewItem(npc.getRect(), ItemType<VolatileHeartIsntItSameAsMenacingHeartLol>());
                //    break;
                case NPCID.TheDestroyer when Main.expertMode: //The Destroyer
                    Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece2>());
                    break;
                case NPCID.SkeletronPrime when Main.expertMode: //Skeletron Prime
                    Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece3>());
                    break;
                case NPCID.DD2OgreT2 when Main.expertMode:
                case NPCID.DD2OgreT3 when Main.expertMode:
                    if (npc.type == NPCID.DD2OgreT2)
                    {
                        Item.NewItem(npc.getRect(), ItemType<SnotHeart>());
                    }
                    else { Item.NewItem(npc.getRect(), ItemType<SnotHeart2>()); }
                    break;
                case NPCID.Plantera when Main.expertMode: //Plantera
                    Item.NewItem(npc.getRect(), ItemType<PlantHeart>());
                    break;
                case NPCID.Golem when Main.expertMode: //Golem
                    Item.NewItem(npc.getRect(), ItemType<LihzhardianHeart>());
                    break;
                case NPCID.DukeFishron when Main.expertMode: //Duke Fishron
                    Item.NewItem(npc.getRect(), ItemType<TruffleHeart>());
                    break;
                //case NPCID.HallowBoss when Main.expertMode: //Empress of Light
                //    Item.NewItem(npc.getRect(), ItemType<SoaringHeartSameWithThatBoi>());
                //    break;
                case NPCID.CultistBoss when Main.expertMode: //Lunatic Cultist
                    Item.NewItem(npc.getRect(), ItemType<AncientHeart>());
                    break;
                case NPCID.MoonLordCore when Main.expertMode: //Moon Lord
                    Item.NewItem(npc.getRect(), ItemType<CelestialHeart>());
                    break;
                default:
                    break;
            }

            //Eater Of Worlds Expert Drop
            int HC = NPC.CountNPCS(NPCID.EaterofWorldsHead);
            int BC = NPC.CountNPCS(NPCID.EaterofWorldsBody);
            int TC = NPC.CountNPCS(NPCID.EaterofWorldsTail);
            if (HC == 0 && BC == 0 && TC == 1 && Main.expertMode) //incase the tail is the last thing killed
            {
                Item.NewItem(npc.getRect(), ItemType<WormHeart>());
            }
            if (HC == 0 && BC == 1 && TC == 0 && Main.expertMode) //incase the Body is the last thing killed
            {
                Item.NewItem(npc.getRect(), ItemType<WormHeart>());
            }
            if (HC == 1 && BC == 0 && TC == 0 && Main.expertMode) //incase the Head is the last thing killed
            {
                Item.NewItem(npc.getRect(), ItemType<WormHeart>());
            }

            //Mechanical Pieces
            int TS = NPC.CountNPCS(NPCID.Spazmatism);
            int TR = NPC.CountNPCS(NPCID.Retinazer);
            if (TS == 0 && TR == 1 && Main.expertMode) //incase Retinazer is the last thing killed
            {
                Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece1>());
            }
            if (TS == 1 && TR == 0 && Main.expertMode) //incase Spazmatism is the last thing killed
            {
                Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece1>());
            }
            #endregion

            #region Modded Bosses
            if (Main.expertMode)
            {
                #region Calamity Mod
                if (ModLoader.GetMod("CalamityMod") != null)
                {
                    Mod mod = ModLoader.GetMod("CalamityMod");
                    if (npc.type == mod.NPCType("DesertScourgeHead"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<OceanHeart>());
                    }
                    else if (npc.type == mod.NPCType("CrabulonIdle"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<FungalHeart>());
                    }
                    else if (npc.type == mod.NPCType("HiveMindP2"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<RottenHeart>());
                    }
                    else if (npc.type == mod.NPCType("PerforatorHive"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<BloodyWormHeart>());
                    }
                    else if (npc.type == mod.NPCType("SlimeGodCore"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<PolarizedHeart>());
                    }
                    else if (npc.type == mod.NPCType("Cryogen"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartOfCryogen>());
                    }
                    else if (npc.type == mod.NPCType("BrimstoneElemental"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<GehennaHeart>());
                    }
                    else if (npc.type == mod.NPCType("AquaticScourgeHead"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AquaticHeart>());
                    }
                    else if (npc.type == mod.NPCType("CalamitasRun3"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<VoidOfHeart>());
                    }
                    else if (npc.type == mod.NPCType("Siren"))
                    {
                        if (!NPC.AnyNPCs(mod.NPCType("Leviathan")))
                        {
                            Item.NewItem(npc.getRect(), ItemType<HeartAmbergris>());
                        }
                    }
                    else if (npc.type == mod.NPCType("Leviathan"))
                    {
                        if (!NPC.AnyNPCs(mod.NPCType("Siren")))
                        {
                            Item.NewItem(npc.getRect(), ItemType<HeartAmbergris>());
                        }
                    }
                    else if (npc.type == mod.NPCType("AstrumAureus"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<GravistarHeart>());
                    }
                    else if (npc.type == mod.NPCType("PlaguebringerGoliath"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<CrystallizedToxicHeart>());
                    }
                    else if (npc.type == mod.NPCType("RavagerBody"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<CorpusHeart>());
                    }
                    else if (npc.type == mod.NPCType("AstrumDeusHeadSpectral"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AstralBossHeart>());
                    }
                    else if (npc.type == mod.NPCType("ProfanedGuardianBoss"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<ProfanedHeart>());
                    }
                    else if (npc.type == mod.NPCType("Bumblefuck"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<DynamoStemHeart>());
                    }
                    else if (npc.type == mod.NPCType("Providence"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<BlazingHeart>());
                    }
                    else if (npc.type == mod.NPCType("StormWeaverHeadNaked"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<ArmoredHeart>());
                    }
                    else if (npc.type == mod.NPCType("CeaselessVoid"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<DarkPlasmicHeart>());
                    }
                    else if (npc.type == mod.NPCType("Signus"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<TwistingHeart>());
                    }
                    else if (npc.type == mod.NPCType("Polterghast"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AfflictedHeart>());
                    }
                    else if (npc.type == mod.NPCType("OldDuke"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<MutatedHeart>());
                    }
                    else if (npc.type == mod.NPCType("DevourerofGodsHeadS"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<NebulousHeart>());
                    }
                    else if (npc.type == mod.NPCType("Yharon"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<DraconicHeart>());
                    }
                    else if (npc.type == mod.NPCType("SupremeCalamitas"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<CalamitousHeart>());
                    }
                }
                #endregion
                #region Consolaria
                if (ModLoader.GetMod("Consolaria") != null)
                {
                    Mod mod = ModLoader.GetMod("Consolaria");
                    if (npc.type == mod.NPCType("Lepus"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<EasterHeart>());
                    }
                    else if (npc.type == mod.NPCType("TurkortheUngrateful"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartoPlenty>());
                    }
                    else if (npc.type == mod.NPCType("Ocram"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartoPlenty>());
                    }
                }
                #endregion
                #region Elemental Hearts
                if (npc.type == NPCType<MenacingHeart>())
                {
                    Item.NewItem(npc.getRect(), ItemType<MenacingHeartItem>());
                }
                #endregion
                #region Elements Awoken
                if (ModLoader.GetMod("ElementsAwoken") != null)
                {
                    Mod mod = ModLoader.GetMod("ElementsAwoken");
                    if (npc.type == mod.NPCType("Wasteland"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<VenomHeart>());
                    }
                    else if (npc.type == mod.NPCType("Infernace"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<InfernoHeart>());
                    }
                    else if (npc.type == mod.NPCType("ScourgeFighter"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<ScourgeHeart>());
                    }
                    else if (npc.type == mod.NPCType("RegarothHead"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartofHope>());
                    }
                    else if (npc.type == mod.NPCType("Permafrost"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartoftheFrost>());
                    }
                    else if (npc.type == mod.NPCType("Obsidious"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<SacredHeart>());
                    }
                    else if (npc.type == mod.NPCType("Aqueous"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AqueousHeart>());
                    }
                    else if (npc.type == mod.NPCType("AncientWyrmHead"))
                    {
                        if (!NPC.AnyNPCs(mod.NPCType("TheEye")))
                        {
                            Item.NewItem(npc.getRect(), ItemType<DrakonianHeart>());
                        }
                    }
                    else if (npc.type == mod.NPCType("TheEye"))
                    {
                        if (!NPC.AnyNPCs(mod.NPCType("AncientWyrmHead")))
                        {
                            Item.NewItem(npc.getRect(), ItemType<DrakonianHeart>());
                        }
                    }
                    else if (npc.type == mod.NPCType("TheGuardianFly"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<FieryHeart>());
                    }
                    else if (npc.type == mod.NPCType("Volcanox"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<CharredHeart>());
                    }
                    else if (npc.type == mod.NPCType("VoidLeviathan"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartofDespair>());
                    }
                    else if (npc.type == mod.NPCType("Azana"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartoftheInfection>());
                    }
                    else if (npc.type == mod.NPCType("AncientAmalgam"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<CrystallineHeart>());
                    }
                }
                #endregion
                #region Fargowiltas Souls
                if (ModLoader.GetMod("FargowiltasSouls") != null)
                {
                    Mod mod = ModLoader.GetMod("FargowiltasSouls");
                    if (npc.type == mod.NPCType("DeviBoss"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<DeviHeart>());
                    }
                    else if (npc.type == mod.NPCType("AbomBoss"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AbomHeart>());
                    }
                    else if (npc.type == mod.NPCType("MutantBoss"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<MutantHeart>());
                    }
                }
                #endregion
                #region Laugicality
                if (ModLoader.GetMod("Laugicality") != null)
                {
                    Mod mod = ModLoader.GetMod("Laugicality");
                    if (npc.type == mod.NPCType("DuneSharkron"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<Pyraheart>());
                    }
                    else if (npc.type == mod.NPCType("Hypothema"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<Hearthema>());
                    }
                    else if (npc.type == mod.NPCType("Ragnar"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<MoltenHeart>());
                    }
                    else if (npc.type == mod.NPCType("AnDio3"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AnDioBossHeart>());
                    }
                    else if (npc.type == mod.NPCType("TheAnnihilator"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece2>());
                    }
                    else if (npc.type == mod.NPCType("Slybertron"))
                    {
                        // MechanicalCrystalPiece4
                    }
                    else if (npc.type == mod.NPCType("SteamTrain"))
                    {
                        // MechanicalCrystalPiece5
                    }
                    else if (npc.type == mod.NPCType("Etheria"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<EtheriaHeart>());
                    }
                }
                #endregion
                #region Thorium Mod
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    Mod mod = ModLoader.GetMod("ThoriumMod");
                    if (npc.type == mod.NPCType("TheGrandThunderBirdv2"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<ZephyrsHeart>());
                    }
                    else if (npc.type == mod.NPCType("QueenJelly"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<SeaBreezeHeart>());
                    }
                    else if (npc.type == mod.NPCType("Viscount"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<VampiresHeart>());
                    }
                    else if (npc.type == mod.NPCType("GraniteEnergyStorm"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<HeartOfTheStorm>());
                    }
                    else if (npc.type == mod.NPCType("TheBuriedWarrior"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<ChampionsHeart>());
                    }
                    else if (npc.type == mod.NPCType("ThePrimeScouter"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<OmegaHeart>());
                    }
                    else if (npc.type == mod.NPCType("BoreanStriderPopped"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<IceBoundStriderHeart>());
                    }
                    else if (npc.type == mod.NPCType("FallenDeathBeholder2"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<BeholderHeart>());
                    }
                    else if (npc.type == mod.NPCType("LichHeadless"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<LichsHeart>());
                    }
                    else if (npc.type == mod.NPCType("AbyssionReleased"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<AbyssalHeart>());
                    }
                    else if (npc.type == mod.NPCType("RealityBreaker"))
                    {
                        Item.NewItem(npc.getRect(), ItemType<DormantHeart>());
                    }
                }
                #endregion
            }
            #endregion
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.PartyGirl)
            {
                shop.item[nextSlot].SetDefaults(ItemType<BubbleHeart>());
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
            }
            if (type == NPCID.Merchant)
            {
                shop.item[nextSlot].SetDefaults(ItemType<EmptyHeart>());
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
            }
            if (type == NPCID.Steampunker)
            {
                shop.item[nextSlot].SetDefaults(ItemType<CogHeart>());
                shop.item[nextSlot].shopCustomPrice = 70000;
                nextSlot++;
            }
        }
    }
}