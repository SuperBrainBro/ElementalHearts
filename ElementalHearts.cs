using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using ElementalHearts.Tiles;
using ElementalHearts.Items.Consumables.Bosses;
using System.Linq;
using ElementalHearts.NPCs.Bosses.MenacingHeart;

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
                bossChecklist.Call("AddBoss", 5.5f, ModContent.NPCType<NPCs.Bosses.MenacingHeart.MenacingHeart>(), this, "Menacing Heart", (Func<bool>)(() => ElementalHeartsWorld.downedMenacingHeart), ModContent.ItemType<Tiles.MenacingLookingStatueItem>(),
                new List<int>() { ModContent.ItemType<MenacingHeartTrophyItem>(), ModContent.ItemType<MHMb>() },
                new List<int>() { ModContent.ItemType<MenacingHeartItem>(), ModContent.ItemType<Items.Accessories.MenacingLookingPendant>(), ModContent.ItemType<Items.Weapons.MenacingLifeStaff>(),
                ModContent.ItemType<Items.Weapons.MenacingHeartKeeper>(), ModContent.ItemType<Items.Weapons.MenacingLifeStaff>() },
                "Find and activate a [i:" + ModContent.ItemType<MenacingLookingStatueItem>() + "]", "", "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeartClone");
            }
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

            preHardmodeHeader = new UIText("Elemental Hearts", .75f, true);
            preHardmodeHeader.HAlign = 0.5f;
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