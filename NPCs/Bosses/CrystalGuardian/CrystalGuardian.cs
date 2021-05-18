using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.CrystalGuardian
{
    [AutoloadBossHead]
    public class CrystalGuardian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Crystal Guardian");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.lifeMax = 60000;
            npc.width = npc.height = 26;
            npc.damage = 76;
            npc.defense = 10;
            music = MusicID.Boss3;
            musicPriority = MusicPriority.BossLow;
            npc.value = 400000;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.netAlways = true;
            npc.timeLeft = 0;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.25f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.4f);
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public static Color colorLT = Color.White;
        public static Color colorLB = Color.White;
        public static Color colorRT = Color.White;
        public static Color colorRB = Color.White;
        public int changeCorners = 0;
        public static int changeCornersMax = 600;
        public override void AI()
        {
            if (++changeCorners > changeCornersMax)
            {
                ChangeColors();
            }
        }

        private void ChangeColors()
        {
            if (Main.rand.NextBool(4))
            {
                colorLT = Color.Red;
            }
            else if (Main.rand.NextBool(4))
            {
                colorLT = Color.Blue;
            }
            else if (Main.rand.NextBool(4))
            {
                colorLT = Color.Green;
            }
            else
            {
                colorLT = Color.Yellow;
            }
            if (Main.rand.NextBool(4))
            {
                colorLB = Color.Red;
            }
            else if (Main.rand.NextBool(4))
            {
                colorLB = Color.Blue;
            }
            else if (Main.rand.NextBool(4))
            {
                colorLB = Color.Green;
            }
            else
            {
                colorLB = Color.Yellow;
            }
            if (Main.rand.NextBool(4))
            {
                colorRT = Color.Red;
            }
            else if (Main.rand.NextBool(4))
            {
                colorRT = Color.Blue;
            }
            else if (Main.rand.NextBool(4))
            {
                colorRT = Color.Green;
            }
            else
            {
                colorRT = Color.Yellow;
            }
            if (Main.rand.NextBool(4))
            {
                colorRB = Color.Red;
            }
            else if (Main.rand.NextBool(4))
            {
                colorRB = Color.Blue;
            }
            else if (Main.rand.NextBool(4))
            {
                colorRB = Color.Green;
            }
            else
            {
                colorRB = Color.Yellow;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D textureCornerLT = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianLT");
            Texture2D textureCornerLB = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianLB");
            Texture2D textureCornerRT = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianRT");
            Texture2D textureCornerRB = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianRB");
            Vector2 vector2_1 = Vector2.Subtract(npc.Center, Main.screenPosition);

            spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardian"),
                            vector2_1 + new Vector2(-32, 32), new Rectangle?(npc.frame),
                            colorLT, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerLT, vector2_1 + new Vector2(-32, -32), new Rectangle?(),
                            colorLT, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerLB, vector2_1 + new Vector2(-32, 32), new Rectangle?(npc.frame),
                            colorLB, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerRT, vector2_1 + new Vector2(32, -32), new Rectangle?(npc.frame),
                            colorRT, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerRB, vector2_1 + new Vector2(32, 32), new Rectangle?(npc.frame),
                            colorRB, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            return true;
        }
    }
}
