using System;
using System.Collections.Generic;
using System.Linq;
using ElementalHearts.Items.Consumables;
using ElementalHearts.Items.Consumables.Bosses;
using ElementalHearts.Items.Consumables.Bosses.CrossMod;
using ElementalHearts.NPCs.Bosses.MenacingHeart;
using ElementalHearts.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ElementalHearts
{
    public class ElementalHearts : Mod
    {
        public static ModHotKey OpenHeartUI;
        public bool HeartUIOpen;
        public override void PostSetupContent()
        {
            // Showcases mod support with Boss Checklist without referencing the mod
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBoss", 5.5f, ModContent.NPCType<MenacingHeart>(), this, "Menacing Heart 2.0", (Func<bool>)(() =>
                ElementalHeartsWorld.downedMenacingHeart), ModContent.ItemType<MenacingLookingStatueItem>(), new List<int>() {
                    ModContent.ItemType<MenacingHeartTrophyItem>(), ModContent.ItemType<MHMb>() }, new List<int>() { ModContent.
                    ItemType<MenacingHeartItem>(), ModContent.ItemType<Items.Accessories.MenacingLookingPendant>(), ModContent.
                    ItemType<Items.Weapons.MenacingLifeStaff>(), ModContent.ItemType<Items.Weapons.MenacingHeartKeeper>(),
                        ModContent.ItemType<Items.Weapons.MenacingLifeStaff>() },
                "Find and activate a [i:" + ModContent.ItemType<MenacingLookingStatueItem>() + "]", "", "ElementalHearts/NPCs/" +
                "Bosses/MenacingHeart/MenacingHeartClone");
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

        //UI STUFF
        internal UserInterface MyInterface;
        internal TheUI MyUI;
        public const string MenacingHeart_Head_Boss = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss";
        public const string MenacingHeart_Head_Boss2 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss2";
        public const string MenacingHeart_Head_Boss3 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss3";
        public const string MenacingHeart_Head_Boss4 = "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeart_Head_Boss4";
        public override void Load()
        {
            // Registers a new hotkey
            OpenHeartUI = RegisterHotKey("Open Heart UI", "H"); // See https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb197781(v=xnagamestudio.41) for special keys

            if (!Main.dedServ)
            {
                MyInterface = new UserInterface();

                MyUI = new TheUI();
                MyUI.Activate(); // Activate calls Initialize() on the UIState if not initialized, then calls OnActivate and then calls Activate on every child element

                #region Music Boxes
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/MenacingHeartBossMusic"), ModContent.ItemType<MHMb>(), ModContent.TileType<MHMbTile>());
                #endregion
            }
            ElementalHeartsDyeInit.Load();
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

        public override void Unload()
        {
            MyUI?.UnLoadUI(); // If you hold data that needs to be unloaded, call it in OO-fashion
            MyUI = null;
            base.Unload();
        }

        private GameTime _lastUpdateUiGameTime;
        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (MyInterface?.CurrentState != null)
            {
                MyInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && MyInterface?.CurrentState != null)
                        {
                            MyInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }

        internal void ShowMyUI()
        {
            HeartUIOpen = true;
            MyInterface?.SetState(MyUI);
        }

        internal void HideMyUI()
        {
            HeartUIOpen = false;
            MyInterface?.SetState(null);
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

    //UI CLASS
    public class TheUI : UIState
    {
        //Panels
        public UIPanel startPanel;
        public UIText startHeader;

        public UIPanel preHardmodePanel;
        public UIText preHardmodeHeader;

        public UIPanel hardmodePanel;
        public UIText hardmodeHeader;

        public UIPanel calamityPanel;
        public UIText calamityHeader;

        public UIPanel thoriumPanel;
        public UIText thoriumHeader;

        //Buttons
        public UIPanel buttonPreHardmode;
        public UIText textPreHardmode;

        public UIPanel buttonHardmode;
        public UIText textHardmode;

        public UIPanel buttonCalamity;
        public UIText textCalamity;

        public UIPanel buttonThorium;
        public UIText textThorium;

        public UIPanel buttonExpert;
        public UIText textExpert;

        public Color buttonColor1;
        public Color buttonColor2;
        public Color buttonColor3;
        public Color buttonColor4;

        public bool preHardmodeOpen;
        public bool hardmodeOpen;
        public bool calamityOpen;
        public bool thoriumOpen;
        public bool expertOpen;


        public override void OnInitialize()
        {
            //Colors//
            Vector4 butCol1 = new Vector4(219, 68, 55, 255);
            butCol1 /= 255;
            buttonColor1 = new Color(butCol1);

            Vector4 butCol2 = new Vector4(15, 157, 88, 255);
            butCol2 /= 255;
            buttonColor2 = new Color(butCol2);

            Vector4 butCol3 = new Vector4(66, 133, 244, 255);
            butCol3 /= 255;
            buttonColor3 = new Color(butCol3);

            Vector4 butCol4 = new Vector4(244, 160, 0, 255);
            butCol4 /= 255;
            buttonColor4 = new Color(butCol4);

            //Bools//
            preHardmodeOpen = false;
            hardmodeOpen = false;
            calamityOpen = false;
            thoriumOpen = false;
            expertOpen = false;

            //Panels//

            //Start Panel
            startPanel = new UIPanel();
            startPanel.Width.Set(300, 0);
            startPanel.Height.Set(400, 0);
            startPanel.VAlign = .5f;
            startPanel.HAlign = .01575f;
            startPanel.PaddingLeft = 10f;
            startPanel.PaddingRight = 10f;
            startPanel.PaddingTop = 10f;
            startPanel.PaddingBottom = 10f;

            startPanel.BackgroundColor = Color.White * 0.25f;
            Append(startPanel);

            startHeader = new UIText("Elemental Hearts", .75f, true);
            startHeader.HAlign = 0.5f;
            startHeader.Top.Set(15, 0);
            startPanel.Append(startHeader);

            //Buttons//

            //Pre Hardmode
            buttonPreHardmode = new UIPanel();
            buttonPreHardmode.Width.Set(200, 0);
            buttonPreHardmode.Height.Set(50, 0);
            buttonPreHardmode.HAlign = 0.5f;
            buttonPreHardmode.Top.Set(50, 0);

            buttonPreHardmode.OnClick += OnButtonClick;

            buttonPreHardmode.BackgroundColor = buttonColor1 * 0.75f;
            startPanel.Append(buttonPreHardmode);

            textPreHardmode = new UIText("Pre-Hardmode");
            textPreHardmode.HAlign = 0.5f;
            textPreHardmode.VAlign = 0.5f;
            buttonPreHardmode.Append(textPreHardmode);


            //Hardmode
            buttonHardmode = new UIPanel();
            buttonHardmode.Width.Set(200, 0);
            buttonHardmode.Height.Set(50, 0);
            buttonHardmode.HAlign = 0.5f;
            buttonHardmode.Top.Set(110, 0);

            buttonHardmode.OnClick += OnButtonClick;

            buttonHardmode.BackgroundColor = buttonColor2 * 0.75f;
            startPanel.Append(buttonHardmode);

            textHardmode = new UIText("Hardmode");
            textHardmode.HAlign = 0.5f;
            textHardmode.VAlign = 0.5f;
            buttonHardmode.Append(textHardmode);


            //Calamity
            buttonCalamity = new UIPanel();
            buttonCalamity.Width.Set(200, 0);
            buttonCalamity.Height.Set(50, 0);
            buttonCalamity.HAlign = 0.5f;
            buttonCalamity.Top.Set(170, 0);

            buttonCalamity.OnClick += OnButtonClick;

            buttonCalamity.BackgroundColor = buttonColor3 * 0.75f;
            startPanel.Append(buttonCalamity);

            textCalamity = new UIText("Calamity");
            textCalamity.HAlign = 0.5f;
            textCalamity.VAlign = 0.5f;
            buttonCalamity.Append(textCalamity);

            //Thorium
            buttonThorium = new UIPanel();
            buttonThorium.Width.Set(200, 0);
            buttonThorium.Height.Set(50, 0);
            buttonThorium.HAlign = 0.5f;
            buttonThorium.Top.Set(230, 0);

            buttonThorium.OnClick += OnButtonClick;

            buttonThorium.BackgroundColor = buttonColor4 * 0.75f;
            startPanel.Append(buttonThorium);

            textThorium = new UIText("Thorium");
            textThorium.HAlign = 0.5f;
            textThorium.VAlign = 0.5f;
            buttonThorium.Append(textThorium);

            //Expert
            buttonExpert = new UIPanel();
            buttonExpert.Width.Set(200, 0);
            buttonExpert.Height.Set(50, 0);
            buttonExpert.HAlign = 0.5f;
            buttonExpert.Top.Set(290, 0);

            buttonExpert.OnClick += OnButtonClick;

            buttonExpert.BackgroundColor = Main.DiscoColor * 0.75f;
            startPanel.Append(buttonExpert);

            textExpert = new UIText("Expert");
            textExpert.HAlign = 0.5f;
            textExpert.VAlign = 0.5f;
            buttonExpert.Append(textExpert);
        }
        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            //Pre-Hardmode
            if (listeningElement == buttonPreHardmode)
            {
                if (preHardmodeOpen)
                {
                    Main.NewText("Closed Pre-Hardmode Section.", Color.Red);
                    preHardmodeOpen = false;
                }
                else
                {
                    Main.NewText("Opened Pre-Hardmode Section.", Color.Red);
                    preHardmodeOpen = true;
                }
            }

            //Hardmode
            if (listeningElement == buttonHardmode)
            {
                if (hardmodeOpen)
                {
                    Main.NewText("Closed Hardmode Section.", Color.Red);
                    hardmodeOpen = false;
                }
                else
                {
                    Main.NewText("Opened Hardmode Section.", Color.Red);
                    hardmodeOpen = true;
                }
            }

            //Calamity
            if (listeningElement == buttonCalamity)
            {
                if (calamityOpen)
                {
                    Main.NewText("Closed Calamity Section.", Color.Red);
                    calamityOpen = false;
                }
                else
                {
                    Main.NewText("Opened Calamity Section.", Color.Red);
                    calamityOpen = true;
                }
            }

            //Thorium
            if (listeningElement == buttonThorium)
            {
                if (thoriumOpen)
                {
                    Main.NewText("Closed Thorium Section.", Color.Red);
                    thoriumOpen = false;
                }
                else
                {
                    Main.NewText("Opened Thorium Section.", Color.Red);
                    thoriumOpen = true;

                }
            }

            //Expert
            if (listeningElement == buttonExpert)
            {
                if (Main.expertMode)
                {
                    if (expertOpen)
                    {
                        Main.NewText("Closed Expert Section.", Color.Red);
                        expertOpen = false;
                    }
                    else
                    {
                        Main.NewText("Opened Expert Section.", Color.Red);
                        expertOpen = true;
                    }
                }
                else
                {
                    Main.NewText("You Are Not In Expert Mode.", Color.Red);
                }
            }
        }
        public void PreHardmodePanelInit()
        {
            preHardmodePanel = new UIPanel();
            preHardmodePanel.Width.Set(300, 0);
            preHardmodePanel.Height.Set(400, 0);
            preHardmodePanel.VAlign = .5f;
            preHardmodePanel.HAlign = .01575f;
            preHardmodePanel.PaddingLeft = 10f;
            preHardmodePanel.PaddingRight = 10f;
            preHardmodePanel.PaddingTop = 10f;
            preHardmodePanel.PaddingBottom = 10f;

            preHardmodePanel.BackgroundColor = Color.White * 0.25f;
            Append(preHardmodePanel);

            preHardmodeHeader = new UIText("Elemental Hearts", .75f, true)
            {
                HAlign = 0.5f
            };
            preHardmodeHeader.Top.Set(15, 0);
            preHardmodePanel.Append(preHardmodeHeader);
        }
        public override void Update(GameTime gameTime)
        {
            //Disco Borders
            startPanel.BorderColor = Main.DiscoColor;
            buttonPreHardmode.BorderColor = Main.DiscoColor;
            buttonHardmode.BorderColor = Main.DiscoColor;
            buttonCalamity.BorderColor = Main.DiscoColor;
            buttonThorium.BorderColor = Main.DiscoColor;
            buttonExpert.BorderColor = Main.DiscoColor;

            //Disco Backgrounds
            buttonExpert.BackgroundColor = Main.DiscoColor;

            if (buttonPreHardmode.IsMouseHovering)
            {
                Main.hoverItemName = "Click to Open the Pre Hardmode Section.";
            }
        }
        public void UnLoadUI()
        {

        }
    }
}