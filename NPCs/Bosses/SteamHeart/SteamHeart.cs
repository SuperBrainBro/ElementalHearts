using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.SteamHeart
{
    class SteamHeart : ModNPC
    {
        public override string Texture => "ElementalHearts/NPCs/Bosses/SteamHeart/SteamHeartGame";
        public int bossScaleLifePerPhase;
        public bool P1;
        public bool P2;
        public bool P3;
        public bool P4;
        private string bossName = /*"Steampunk Heart"*/"Mods.ElementalHearts.NPCName.SteamHeart";
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault($"Steampunk Heart");
            DisplayName.SetDefault("Mods.ElementalHearts.NPCName.SteamHeart");
            Main.npcFrameCount[npc.type] = 4;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.width = 132;
            npc.height = 132;
            npc.lifeMax = 40050;
            npc.damage = 150;
            npc.defense = 15;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/MenacingHeartBossMusic");
            musicPriority = MusicPriority.BossLow;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.netAlways = true;
            npc.timeLeft = 0;
            bossScaleLifePerPhase = npc.lifeMax / 4;
            Main.npcFrameCount[npc.type] = 4;
            base.SetDefaults();
        }

        public override void AI()
        {
            CheckPhase();
            P1Attacks();
            P2Attacks();
            P3Attacks();
            P4Attacks();
            base.AI();
        }

        #region Phase 1
        /// <summary>
        /// Boss P1 stages, attacks, summons and etch.
        /// </summary>
        private void P1Attacks()
        {
            if (P1)
            {
            }
        }
        #endregion
        #region Phase 2
        public bool messageP2 = false;
        /// <summary>
        /// Boss P2 stages, attacks, summons and etch.
        /// </summary>
        private void P2Attacks()
        {
            if (P2)
            {
                if (!messageP2)
                {
                    Main.NewText("<" + bossName + "> Hmm ... and you are stronger than I thought, but nothing! You're just as weak anyway! Gear, come out!!", Color.Goldenrod);
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteamGear>());
                    messageP2 = true;
                }
                if (NPC.AnyNPCs(ModContent.NPCType<SteamGear>()))
                {
                    npc.dontTakeDamage = true;
                }
                else { npc.dontTakeDamage = false; }
            }
        }
        #endregion
        #region Phase 3
        public bool messageP3 = false;
        /// <summary>
        /// Boss P3 stages, attacks, summons and etch.
        /// </summary>
        private void P3Attacks()
        {
            if (P3)
            {
                totalHP = npc.lifeMax / 100;
                if (!messageP3 && npc.life < totalHP * 30)
                {
                    Main.NewText("<" + bossName + "> Hah, second gear, go out and hit everyone here!", Color.Goldenrod);
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteamGear>());
                    messageP3 = true;
                }
                if (NPC.AnyNPCs(ModContent.NPCType<SteamGear>()))
                {
                    npc.dontTakeDamage = true;
                }
                else { npc.dontTakeDamage = false; }
            }
        }
        #endregion
        #region Phase 4
        public bool message = false;
        public bool message2 = false;
        public int totalHP;
        public bool harder = false;
        /// <summary>
        /// Boss P4 stages, attacks, summons and etch.
        /// </summary>
        private void P4Attacks()
        {
            if (P4)
            {
                totalHP = npc.lifeMax / 100;
                if (npc.life < totalHP * 15)
                {
                    if (!message)
                    {
                        Main.NewText("<" + bossName + "> Gears... rise from the broken ones and [c/FF0000:defeat] [c/FF0000:this] [c/FF0000:Terrarian]!", new Color(218, 165, 32));
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteamGear>());
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteamGear>());
#pragma warning disable IDE0059
                        message = true;
#pragma warning restore IDE0059
                    }
                    if (NPC.AnyNPCs(ModContent.NPCType<SteamGear>()))
                    {
                        npc.dontTakeDamage = true;
                    }
                    else
                    {
                        if (!message2)
                        {
                            Main.NewText("<" + bossName + "> Huh?! How did they lose to [c/FF0000:YOU]?! You're just a weak Terrarian! OK OK! Wait until my minions get up to kill you again! Or try at least...", new Color(218 + 16, 165 - 32, 0));
                            message2 = true;
                        }
                        if (!harder)
                        {
                            npc.damage *= 2;
                            npc.lifeRegen += 25;
                            npc.lifeRegenCount += 25;
                            npc.life = totalHP * 25;
                            harder = true;
                        }
                        npc.dontTakeDamage = false;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// This thing need for checking boss phase.
        /// </summary>
        private void CheckPhase()
        {
            if (npc.life > bossScaleLifePerPhase * 4)
            {
                npc.ai[0] = 1;
                P1 = true;
                P2 = false;
                P3 = false;
                P4 = false;
            }
            else if (npc.life > bossScaleLifePerPhase * 3 && npc.life < bossScaleLifePerPhase * 4)
            {
                npc.ai[0] = 2;
                P1 = false;
                P2 = true;
                P3 = false;
                P4 = false;
            }
            else if (npc.life > bossScaleLifePerPhase * 2 && npc.life < bossScaleLifePerPhase * 3)
            {
                npc.ai[0] = 3;
                P1 = false;
                P2 = false;
                P3 = true;
                P4 = false;
            }
            else if (npc.life > bossScaleLifePerPhase && npc.life < bossScaleLifePerPhase * 2)
            {
                npc.ai[0] = 4;
                P1 = false;
                P2 = false;
                P3 = false;
                P4 = true;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.7f);
        }

        public override void FindFrame(int frameHeight)
        {
            if (P1 == true)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            else if (P2 == true)
            {
                if (npc.spriteDirection == -1)
                {
                    npc.frame.Y = 1 * frameHeight;
                }
                else
                {
                    npc.frame.Y = 2 * frameHeight;
                }
            }
            else if (P3 == true)
            {
                npc.frame.Y = 3 * frameHeight;
            }
            base.FindFrame(frameHeight);
        }
    }
}
