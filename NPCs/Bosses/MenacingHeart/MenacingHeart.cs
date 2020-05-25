using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    [AutoloadBossHead]
    public class MenacingHeart : ModNPC
    {
        public float bossPhaseHealth;

        public float P1;
        public float P2;
        public float P3;
        public float P4;

        public bool BP1;
        public bool BP2;
        public bool BP3;
        public bool BP4;
        public override void SetDefaults()
        {
            npc.width = 128;
            npc.height = 128;
            npc.aiStyle = 0;
            npc.damage = 200;
            npc.defense = 24;
            npc.lifeMax = 16000;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 20f;
            npc.boss = true;
            npc.netAlways = true;
            base.SetDefaults();
        }
        public override bool PreAI()
        {            
            //This float, bossPhaseHealth, is the amount of health divided by 4. Since there are 4 phases, there are 4 equal amounts. (See below code for example)          
            bossPhaseHealth = npc.lifeMax / 4;

            return base.PreAI();
        }
        public override void AI()
        {
            if (npc.life > bossPhaseHealth * 3)
            {
                //Set phase to 1.
                npc.ai[0] = 1;
                
            }
            else if (npc.life > bossPhaseHealth * 2)
            {
                //Set phase to 2.
                npc.ai[0] = 2;
            }
            else if (npc.life > bossPhaseHealth * 1)
            {
                //Set phase to 3.
                npc.ai[0] = 3;
            }
            else if (npc.life > bossPhaseHealth * 0)
            {
                //Set phase to 4.
                npc.ai[0] = 4;
            }

            //npc.ai[0] is the current phase. So the below code, checks for if it is phase 1. If it is in phase 1, then npc.ai[1] goes up (which is the timer for phase 10
            if (npc.ai[0] == 1)
            {
                P1++;
            }
            else if (npc.ai[0] == 2)
            {
                P2++;
            }
            else if (npc.ai[0] == 3)
            {
                P3++;
            }
            else if (npc.ai[0] == 4)
            {
                P4++;
            }

            //This is the phase code, the one below, is the phase 1 code.
            if (P1 >= 200)
            {
                npc.TargetClosest(true);

                //This generates a random tp position.
                float tpPosRand1;
                tpPosRand1 = Main.rand.NextFloat(8);

                if (tpPosRand1 > 6)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(200, 0);
                } else if (tpPosRand1 > 4)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(0, 200);
                } else if (tpPosRand1 > 2)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                } else if (tpPosRand1 > 0)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                ShootProjectile(1);
                P1 = 0;
            }
            else
            //Phase 2.
            if (P2 >= 150)
            {
                npc.TargetClosest(true);

                //This generates a random tp position.
                float tpPosRand2;
                tpPosRand2 = Main.rand.NextFloat(8);

                if (tpPosRand2 > 6)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(200, 0);
                }
                else if (tpPosRand2 > 4)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(0, 200);
                }
                else if (tpPosRand2 > 2)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                else if (tpPosRand2 > 0)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                ShootProjectile(2);
                P2 = 0;
            }
            else
            //Phase 3.
            if (P3 >= 100)
            {
                npc.TargetClosest(true);

                //This generates a random tp position.
                float tpPosRand3;
                tpPosRand3 = Main.rand.NextFloat(8);

                if (tpPosRand3 > 6)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(200, 0);
                }
                else if (tpPosRand3 > 4)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(0, 200);
                }
                else if (tpPosRand3 > 2)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                else if (tpPosRand3 > 0)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                ShootProjectile(3);
                P3 = 0;
            }
            else
            //Phase 4.
            if (P4 >= 50)
            {
                npc.TargetClosest(true);

                //This generates a random tp position.
                float tpPosRand4;
                tpPosRand4 = Main.rand.NextFloat(8);

                if (tpPosRand4 > 6)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(200, 0);
                }
                else if (tpPosRand4 > 4)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(0, 200);
                }
                else if (tpPosRand4 > 2)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                else if (tpPosRand4 > 0)
                {
                    npc.position = Main.player[npc.target].position + new Vector2(-200, 0);
                }
                P4 = 0;
            }
            ShootProjectile(4);
            base.AI();
        }
        public void ShootProjectile(int phase)
        {
            //In here, I want to shoot mini life crystals at the player. They will be shooting multiple times, maybe in groups of 3?
        }

        public override void HitEffect(int hitDirection, double damage)
        {

            base.HitEffect(hitDirection, damage);
        }

        // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
        private const int Frame_P1 = 0;
        private const int Frame_P2 = 1;
        private const int Frame_P3 = 2;

        // Phase 4 has 11 frames
        private const int Frame_P4_1 = 3;
        private const int Frame_P4_2 = 4;
        private const int Frame_P4_3 = 5;
        private const int Frame_P4_4 = 6;
        private const int Frame_P4_5 = 7;
        private const int Frame_P4_6 = 8;
        private const int Frame_P4_7 = 9;
        private const int Frame_P4_8 = 10;
        private const int Frame_P4_9 = 11;
        private const int Frame_P4_10 = 12;
        private const int Frame_P4_11 = 13;
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            //npc.spriteDirection = npc.direction;

            // For the most part, our animation matches up with our states.
            if (BP1 == true)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                npc.frame.Y = Frame_P1 * frameHeight;
            }
            else if (BP2 == true)
            {
                npc.frame.Y = Frame_P2 * frameHeight;
            }
            else if (BP3 == true)
            {
                npc.frame.Y = Frame_P3 * frameHeight;
            }
            else if (BP4 == true)
            {
                // Here we have 3 frames that we want to cycle through.
                npc.frameCounter++;
                if (npc.frameCounter < 10)
                {
                    npc.frame.Y = Frame_Flutter_1 * frameHeight;
                }
                else if (npc.frameCounter < 20)
                {
                    npc.frame.Y = Frame_Flutter_2 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = Frame_Flutter_3 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }  
            base.FindFrame(frameHeight);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {

            base.BossLoot(ref name, ref potionType);
        }
    }
}