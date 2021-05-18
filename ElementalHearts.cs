using System;
using System.Collections.Generic;
using System.Linq;
using ElementalHearts.Items.Accessories;
using ElementalHearts.Items.Consumables;
using ElementalHearts.Items.Consumables.Bosses;
using ElementalHearts.Items.Consumables.Bosses.CrossMod;
using ElementalHearts.Items.Weapons;
using ElementalHearts.NPCs.Bosses.CrystalGuardian;
using ElementalHearts.NPCs.Bosses.MenacingHeart;
using ElementalHearts.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts
{
    public class ElementalHearts : Mod
    {
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBoss", 5.5f, ModContent.NPCType<MenacingHeart>(), this, "Menacing Heart", (Func<bool>)(() =>
                ElementalHeartsWorld.downedMenacingHeart), ModContent.ItemType<MenacingLookingStatueItem>(), new List<int>() {
                    ModContent.ItemType<MenacingHeartTrophyItem>(), ModContent.ItemType<MHMb>() }, new List<int>() { ModContent.
                    ItemType<MenacingHeartItem>(), ModContent.ItemType<MenacingLookingPendant>(), ModContent.
                    ItemType<MenacingLifeStaff>(), ModContent.ItemType<MenacingHeartKeeper>(),
                        ModContent.ItemType<MenacingLifeStaff>() },
                "Find and activate a [i:" + ModContent.ItemType<MenacingLookingStatueItem>() + "]", "", "ElementalHearts/NPCs/" +
                "Bosses/MenacingHeart/MenacingHeartClone");

                bossChecklist.Call("AddBoss", 7f, ModContent.NPCType<CrystalGuardian>(), this, "The Crystal Guardian", (Func<bool>)
                    (() => ElementalHeartsWorld.downedMenacingHeart), 0, new List<int>() { } /* Collections */,
                    new List<int> { } /* Loot */, "Summon", "",
                    "ElementalHearts/NPCs/Bosses/CrystalGuardian/CrystalGuardian_BossChecklist");
            }
            AddHeartsToBossChecklist();
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.musicVolume != 0)
            {
                if (Main.myPlayer != -1 && Main.LocalPlayer.active)
                {
                    if (Main.npc.Any(n => n.active && n.boss))
                    {
                        if (NPC.AnyNPCs(ModContent.NPCType<MenacingHeart>()))
                        {
                            music = GetSoundSlot(SoundType.Music, "Sounds/Music/MenacingHeartBossMusic");
                            priority = MusicPriority.BossHigh;
                        }
                    }
                }
            }
        }

        public const string MenacingHeart_Head_Boss = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss";
        public const string MenacingHeart_Head_Boss2 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss2";
        public const string MenacingHeart_Head_Boss3 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss3";
        public const string MenacingHeart_Head_Boss4 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss4";
        public override void Load()
        {
            #region Boss Heads
            AddBossHeadTexture(MenacingHeart_Head_Boss);
            AddBossHeadTexture(MenacingHeart_Head_Boss2);
            AddBossHeadTexture(MenacingHeart_Head_Boss3);
            AddBossHeadTexture(MenacingHeart_Head_Boss4);
            #endregion

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.netMode != NetmodeID.Server)
                {
                    Ref<Effect> screenRef = new Ref<Effect>(GetEffect("Effects/ShockwaveEffect")); // The path to the compiled shader file.
                    Filters.Scene["TeleportShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                    Filters.Scene["TeleportShockwave"].Load();
                    Filters.Scene["PhaseChangeShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                    Filters.Scene["PhaseChangeShockwave"].Load();
                    Filters.Scene["BasicShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                    Filters.Scene["BasicShockwave"].Load();
                }
            }
            base.Load();
        }

        public void AddHeartsToBossChecklist()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");

            Mod calamity = ModLoader.GetMod("CalamityMod");
            Mod consolaria = ModLoader.GetMod("Consolaria");
            Mod elementsAwoken = ModLoader.GetMod("ElementsAwoken");
            Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
            Mod laugicality = ModLoader.GetMod("Laugicality");
            Mod thorium = ModLoader.GetMod("ThoriumMod");

            if (bossChecklist == null)
                return;
            #region Vanilla
            AddLoot("Terraria", "KingSlime", ModContent.ItemType<RoyalSlimeHeart>());
            AddLoot("Terraria", "EyeofCthulhu", ModContent.ItemType<EyeHeart>());
            AddLoot("Terraria", "EaterofWorldsHead", ModContent.ItemType<WormHeart>());
            AddLoot("Terraria", "BrainofCthulhu", ModContent.ItemType<BrainHeart>());
            AddLoot("Terraria", "QueenBee", ModContent.ItemType<HiveHeart>());
            AddLoot("Terraria", "SkeletronHead", ModContent.ItemType<BoneHeart>());
            AddLoot("Terraria", "WallofFlesh", ModContent.ItemType<DemonHeartMK2>());
            AddLoot("Terraria", "TheTwins", ModContent.ItemType<MechanicalCrystalPiece1>());
            AddLoot("Terraria", "TheDestroyer", ModContent.ItemType<MechanicalCrystalPiece2>());
            AddLoot("Terraria", "SkeletronPrime", ModContent.ItemType<MechanicalCrystalPiece3>());
            AddLoot("Terraria", "Plantera", ModContent.ItemType<PlantHeart>());
            AddLoot("Terraria", "Golem", ModContent.ItemType<LihzhardianHeart>());
            AddLoot("Terraria", "DukeFishron", ModContent.ItemType<TruffleHeart>());
            AddLoot("Terraria", "CultistBoss", ModContent.ItemType<AncientHeart>());
            AddLoot("Terraria", "MoonLord", ModContent.ItemType<CelestialHeart>());
            #endregion

            #region Calamity Mod
            if (calamity != null)
            {
                AddLoot(calamity.Name, "Desert Scourge", ModContent.ItemType<OceanHeart>());
                AddLoot(calamity.Name, "Crabulon", ModContent.ItemType<FungalHeart>());
                AddLoot(calamity.Name, "Hive Mind", ModContent.ItemType<RottenHeart>());
                AddLoot(calamity.Name, "The Perforators", ModContent.ItemType<BloodyWormHeart>());
                AddLoot(calamity.Name, "Slime God", ModContent.ItemType<PolarizedHeart>());
                AddLoot(calamity.Name, "Cryogen", ModContent.ItemType<HeartOfCryogen>());
                AddLoot(calamity.Name, "Aquatic Scourge", ModContent.ItemType<AquaticHeart>());
                AddLoot(calamity.Name, "Brimstone Elemental", ModContent.ItemType<GehennaHeart>());
                AddLoot(calamity.Name, "Calamitas", ModContent.ItemType<VoidOfHeart>());
                AddLoot(calamity.Name, "Leviathan", ModContent.ItemType<HeartAmbergris>());
                AddLoot(calamity.Name, "Astrum Aureus", ModContent.ItemType<GravistarHeart>());
                AddLoot(calamity.Name, "Plaguebringer Goliath", ModContent.ItemType<CrystallizedToxicHeart>());
                AddLoot(calamity.Name, "Ravager", ModContent.ItemType<CorpusHeart>());
                AddLoot(calamity.Name, "Astrum Deus", ModContent.ItemType<AstralBossHeart>());
                AddLoot(calamity.Name, "Dragonfolly", ModContent.ItemType<DynamoStemHeart>());
                AddLoot(calamity.Name, "Providence", ModContent.ItemType<BlazingHeart>());
                AddLoot(calamity.Name, "Ceaseless Void", ModContent.ItemType<DarkPlasmicHeart>());
                AddLoot(calamity.Name, "Storm Weaver", ModContent.ItemType<ArmoredHeart>());
                AddLoot(calamity.Name, "Signus", ModContent.ItemType<TwistingHeart>());
                AddLoot(calamity.Name, "Polterghast", ModContent.ItemType<AfflictedHeart>());
                AddLoot(calamity.Name, "Old Duke", ModContent.ItemType<MutatedHeart>());
                AddLoot(calamity.Name, "Devourer of Gods", ModContent.ItemType<NebulousHeart>());
                AddLoot(calamity.Name, "Yharon", ModContent.ItemType<DraconicHeart>());
                AddLoot(calamity.Name, "Supreme Calamitas", ModContent.ItemType<CalamitousHeart>());
            }
            #endregion
            #region Consolaria
            if (consolaria != null)
            {
                AddLoot(consolaria.Name, "Lepus", ModContent.ItemType<EasterHeart>());
                AddLoot(consolaria.Name, "Turkor The Ungrateful", ModContent.ItemType<HeartoPlenty>());
                AddLoot(consolaria.Name, "Ocram", ModContent.ItemType<CursedHeart>());
            }
            #endregion
            #region Elements Awoken
            if (elementsAwoken != null)
            {
                AddLoot(elementsAwoken.Name, "Wasteland", ModContent.ItemType<VenomHeart>());
                AddLoot(elementsAwoken.Name, "Infernace", ModContent.ItemType<InfernoHeart>());
                AddLoot(elementsAwoken.Name, "Scourge Fighter", ModContent.ItemType<ScourgeHeart>());
                AddLoot(elementsAwoken.Name, "Regaroth", ModContent.ItemType<HeartofHope>());
                AddLoot(elementsAwoken.Name, "Permafrost", ModContent.ItemType<HeartoftheFrost>());
                AddLoot(elementsAwoken.Name, "Obsidious", ModContent.ItemType<SacredHeart>());
                AddLoot(elementsAwoken.Name, "Aqueous", ModContent.ItemType<AqueousHeart>());
                AddLoot(elementsAwoken.Name, "Temple Keepers", ModContent.ItemType<DrakonianHeart>());
                AddLoot(elementsAwoken.Name, "The Guardian", ModContent.ItemType<CharredHeart>());
                AddLoot(elementsAwoken.Name, "Void Leviathan", ModContent.ItemType<HeartofDespair>());
                AddLoot(elementsAwoken.Name, "Azana", ModContent.ItemType<HeartoftheInfection>());
                AddLoot(elementsAwoken.Name, "The Ancients", ModContent.ItemType<CrystallineHeart>());
            }
            #endregion
            #region Fargowiltas Souls
            if (fargoSouls != null)
            {
                AddLoot(fargoSouls.Name, "Deviantt", ModContent.ItemType<DeviHeart>());
                AddLoot(fargoSouls.Name, "Abominationn", ModContent.ItemType<AbomHeart>());
                AddLoot(fargoSouls.Name, "Mutant", ModContent.ItemType<MutantHeart>());
            }
            #endregion
            #region Laugicality
            if (laugicality != null)
            {
                AddLoot(laugicality.Name, "Dune Sharkron", ModContent.ItemType<Pyraheart>());
                AddLoot(laugicality.Name, "Hypothema", ModContent.ItemType<Hearthema>());
                AddLoot(laugicality.Name, "Ragnar", ModContent.ItemType<MoltenHeart>());
                AddLoot(laugicality.Name, "Dioritus", ModContent.ItemType<AnDioBossHeart>());
                AddLoot(laugicality.Name, "Andesia", ModContent.ItemType<AnDioBossHeart>());
                AddLoot(laugicality.Name, "The Annihilator", ModContent.ItemType<MechanicalCrystalPiece2>());
                //AddLoot(laugicality.Name, "Slybertron", ModContent.ItemType<MechanicalCrystalPiece4>());
                //AddLoot(laugicality.Name, "Steam Train", ModContent.ItemType<MechanicalCrystalPiece5>());
                AddLoot(laugicality.Name, "Etheria", ModContent.ItemType<EtheriaHeart>());
            }
            #endregion
            #region Thorium Mod
            if (thorium != null)
            {
                AddLoot(thorium.Name, "The Grand Thunder Bird", ModContent.ItemType<ZephyrsHeart>());
                AddLoot(thorium.Name, "The Queen Jellyfish", ModContent.ItemType<SeaBreezeHeart>());
                AddLoot(thorium.Name, "Viscount", ModContent.ItemType<VampiresHeart>());
                AddLoot(thorium.Name, "Granite Energy Storm", ModContent.ItemType<HeartOfTheStorm>());
                AddLoot(thorium.Name, "Buried Champion", ModContent.ItemType<ChampionsHeart>());
                AddLoot(thorium.Name, "Star Scouter", ModContent.ItemType<OmegaHeart>());
                AddLoot(thorium.Name, "Borean Strider", ModContent.ItemType<IceBoundStriderHeart>());
                AddLoot(thorium.Name, "Coznix, the Fallen Beholder", ModContent.ItemType<BeholderHeart>());
                AddLoot(thorium.Name, "The Lich", ModContent.ItemType<LichsHeart>());
                AddLoot(thorium.Name, "Abyssion, the Forgotten One", ModContent.ItemType<AbyssalHeart>());
                AddLoot(thorium.Name, "The Primordials", ModContent.ItemType<DormantHeart>());
            }
            #endregion
        }

        private void AddLoot(string modID, string bossName, int item)
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            bossChecklist.Call(new object[4] { "AddToBossLoot", modID, bossName, item });
        }
    }
}