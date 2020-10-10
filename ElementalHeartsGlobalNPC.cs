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

        public bool curseCATsCurse;

        public override void ResetEffects(NPC npc)
        {
            curseCATsCurse = false;
        }
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
                #region Elemental Hearts
                if (npc.type == NPCType<MenacingHeart>())
                {
                    Item.NewItem(npc.getRect(), ItemType<MenacingHeartItem>());
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

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (curseCATsCurse)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 128;
                if (damage < 24)
                {
                    damage = 24;
                }
            }
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