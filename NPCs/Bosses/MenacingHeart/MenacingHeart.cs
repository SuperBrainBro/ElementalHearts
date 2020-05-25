using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.IO;
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
        public override void FindFrame(int frameHeight)
        {

            base.FindFrame(frameHeight);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {

            base.BossLoot(ref name, ref potionType);
        }
    }
}