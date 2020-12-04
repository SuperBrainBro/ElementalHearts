using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using ElementalHearts.Items.Consumables.Bosses;
using ElementalHearts.NPCs.Bosses.MenacingHeart;
using ElementalHearts.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Graphics.Effects;
using Terraria.ID;
using ElementalHearts.Items.Consumables;
using ElementalHearts.Items.Consumables.Bosses.CrossMod;

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
                bossChecklist.Call("AddBoss", 5.5f, ModContent.NPCType<MenacingHeart>(), this, "Menacing Heart", (Func<bool>)(() =>
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
            Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
            Mod thorium = ModLoader.GetMod("ThoriumMod");
            if (bossChecklist == null)
                return;
            #region Vanilla
            AddLoot("AddToBossLoot", "Terraria", "KingSlime", ModContent.ItemType<RoyalSlimeHeart>());
            AddLoot("AddToBossLoot", "Terraria", "EyeofCthulhu", ModContent.ItemType<EyeHeart>());
            AddLoot("AddToBossLoot", "Terraria", "EaterofWorldsHead", ModContent.ItemType<WormHeart>());
            AddLoot("AddToBossLoot", "Terraria", "BrainofCthulhu", ModContent.ItemType<BrainHeart>());
            AddLoot("AddToBossLoot", "Terraria", "QueenBee", ModContent.ItemType<HiveHeart>());
            AddLoot("AddToBossLoot", "Terraria", "SkeletronHead", ModContent.ItemType<BoneHeart>());
            AddLoot("AddToBossLoot", "Terraria", "WallofFlesh", ModContent.ItemType<DemonHeartMK2>());
            AddLoot("AddToBossLoot", "Terraria", "TheTwins", ModContent.ItemType<MechanicalCrystalPiece1>());
            AddLoot("AddToBossLoot", "Terraria", "TheDestroyer", ModContent.ItemType<MechanicalCrystalPiece2>());
            AddLoot("AddToBossLoot", "Terraria", "SkeletronPrime", ModContent.ItemType<MechanicalCrystalPiece3>());
            AddLoot("AddToBossLoot", "Terraria", "Plantera", ModContent.ItemType<PlantHeart>());
            AddLoot("AddToBossLoot", "Terraria", "Golem", ModContent.ItemType<LihzhardianHeart>());
            AddLoot("AddToBossLoot", "Terraria", "DukeFishron", ModContent.ItemType<TruffleHeart>());
            AddLoot("AddToBossLoot", "Terraria", "CultistBoss", ModContent.ItemType<AncientHeart>());
            AddLoot("AddToBossLoot", "Terraria", "MoonLord", ModContent.ItemType<CelestialHeart>());
            #endregion

            #region Calamity Mod
            if (calamity != null)
            {
                AddLoot("AddToBossLoot", calamity.Name, "Desert Scourge", ModContent.ItemType<OceanHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Crabulon", ModContent.ItemType<FungalHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Hive Mind", ModContent.ItemType<RottenHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "The Perforators", ModContent.ItemType<BloodyWormHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Slime God", ModContent.ItemType<PolarizedHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Cryogen", ModContent.ItemType<HeartOfCryogen>());
                AddLoot("AddToBossLoot", calamity.Name, "Aquatic Scourge", ModContent.ItemType<AquaticHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Brimstone Elemental", ModContent.ItemType<GehennaHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Calamitas", ModContent.ItemType<VoidOfHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Leviathan", ModContent.ItemType<HeartAmbergris>());
                AddLoot("AddToBossLoot", calamity.Name, "Astrum Aureus", ModContent.ItemType<AstralBossHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Plaguebringer Goliath", ModContent.ItemType<CrystallizedToxicHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Ravager", ModContent.ItemType<CorpusHeart>());
                //AddLoot("AddToBossLoot", calamity.Name, "Astrum Deus", ModContent.ItemType<OceanHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Dragonfolly", ModContent.ItemType<DynamoStemHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Providence", ModContent.ItemType<BlazingHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Ceaseless Void", ModContent.ItemType<DarkPlasmicHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Storm Weaver", ModContent.ItemType<ArmoredHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Signus", ModContent.ItemType<TwistingHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Polterghast", ModContent.ItemType<AfflictedHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Old Duke", ModContent.ItemType<MutatedHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Devourer of Gods", ModContent.ItemType<NebulousHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Yharon", ModContent.ItemType<DraconicHeart>());
                AddLoot("AddToBossLoot", calamity.Name, "Supreme Calamitas", ModContent.ItemType<CalamitousHeart>());
            }
            #endregion
            #region Fargowiltas Souls
            if (fargoSouls != null)
            {
                AddLoot("AddToBossLoot", fargoSouls.Name, "Deviantt", ModContent.ItemType<DeviHeart>());
                AddLoot("AddToBossLoot", fargoSouls.Name, "Abominationn", ModContent.ItemType<AbomHeart>());
                AddLoot("AddToBossLoot", fargoSouls.Name, "Mutant", ModContent.ItemType<MutantHeart>());
            }
            #endregion
            #region Thorium Mod
            if (thorium != null)
            {
                AddLoot("AddToBossLoot", thorium.Name, "The Grand Thunder Bird", ModContent.ItemType<ZephyrsHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "The Queen Jellyfish", ModContent.ItemType<SeaBreezeHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Viscount", ModContent.ItemType<VampiresHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Granite Energy Storm", ModContent.ItemType<HeartOfTheStorm>());
                AddLoot("AddToBossLoot", thorium.Name, "Buried Champion", ModContent.ItemType<ChampionsHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Star Scouter", ModContent.ItemType<OmegaHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Borean Strider", ModContent.ItemType<IceBoundStriderHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Coznix, the Fallen Beholder", ModContent.ItemType<BeholderHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "The Lich", ModContent.ItemType<LichsHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "Abyssion, the Forgotten One", ModContent.ItemType<AbyssalHeart>());
                AddLoot("AddToBossLoot", thorium.Name, "The Primordials", ModContent.ItemType<DormantHeart>());
            }
            #endregion
        }

        private void AddLoot(string call, string modID, string bossName, int item)
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            bossChecklist.Call(new object[4] { call, modID, bossName, item });
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