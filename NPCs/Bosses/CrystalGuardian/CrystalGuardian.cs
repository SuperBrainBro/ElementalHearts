using ElementalHearts.Projectiles.Bosses.CrystalGuardian;
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
            npc.lifeMax = 15000;
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
            //npc.alpha = 255;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.6f);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            //position = npc.Center - new Vector2(-14, -24);
            return true;
        }

        public override bool CheckDead()
        {
            Main.NewText("<The Crystal Guardian> I-I... I c..can't under..stand... w..hy are you d-doing this?", Color.Goldenrod);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Bosses/CrystalGuardian/CrystalGuardianLB"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Bosses/CrystalGuardian/CrystalGuardianLT"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Bosses/CrystalGuardian/CrystalGuardianRB"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/Bosses/CrystalGuardian/CrystalGuardianRT"), 1f);
            return true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public static Color colorLT = Color.White;
        public static Color colorLB = Color.White;
        public static Color colorRT = Color.White;
        public static Color colorRB = Color.White;
        public static int redColoredCorners = 0;
        public static int blueColoredCorners = 0;
        public static int greenColoredCorners = 0;
        public static int yellowColoredCorners = 0;
        public static int orangeColoredCorners = 0;
        public int changeCorners = -1;
        public static int changeCornersMax = 60 * 10;
        public override void AI()
        {
            DoChangeColor();

            ShootBullets();
            if (orangeColoredCorners > 0 && Main.rand.NextBool(16 / orangeColoredCorners))
                Projectile.NewProjectile(npc.position, npc.velocity, ModContent.ProjectileType<CrystalFire>(), npc.damage / 4, 0f);
            if (blueColoredCorners > 0 && Main.rand.NextBool(6 / blueColoredCorners))
                Projectile.NewProjectile(npc.position + new Vector2(Main.rand.Next(-800, 800), -720), npc.velocity,
                    ModContent.ProjectileType<CrystalMana>(), npc.damage / 8, 0f);
            #region Corner Attacks
            if (colorLT == Color.Red)
            {
            }
            else if (colorLT == Color.Blue)
            {
            }
            else if (colorLT == Color.Green)
            {
            }
            else if (colorLT == Color.Yellow)
            {
            }
            if (colorLB == Color.Red)
            {
            }
            else if (colorLB == Color.Blue)
            {
            }
            else if (colorLB == Color.Green)
            {
            }
            else if (colorLB == Color.Yellow)
            {
            }
            if (colorRT == Color.Red)
            {
            }
            else if (colorRT == Color.Blue)
            {
            }
            else if (colorRT == Color.Green)
            {
            }
            else if (colorRT == Color.Yellow)
            {
            }
            if (colorRB == Color.Red)
            {
            }
            else if (colorRB == Color.Blue)
            {
            }
            else if (colorRB == Color.Green)
            {
            }
            else if (colorRB == Color.Yellow)
            {
            }
            #endregion
        }

        private void DoChangeColor()
        {
            if (changeCorners == -1)
            {
                ChangeColors();
                changeCorners = 0;
                return;
            }
            if (++changeCorners > changeCornersMax)
            {
                redColoredCorners = 0;
                blueColoredCorners = 0;
                greenColoredCorners = 0;
                yellowColoredCorners = 0;
                orangeColoredCorners = 0;
                ChangeColors();
                changeCorners = 0;
            }
        }
        private void ChangeColors()
        {
            int doChangeColors = 5;
            #region Left Top
            if (Main.rand.NextBool(doChangeColors))
            {
                colorLT = Color.Red;
                redColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLT = Color.Blue;
                blueColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLT = Color.Green;
                greenColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLT = Color.Orange;
                orangeColoredCorners += 1;
            }
            else
            {
                colorLT = Color.Yellow;
                yellowColoredCorners += 1;
            }
            #endregion
            #region Left Bottom
            if (Main.rand.NextBool(doChangeColors))
            {
                colorLB = Color.Red;
                redColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLB = Color.Blue;
                blueColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLB = Color.Green;
                greenColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorLB = Color.Orange;
                orangeColoredCorners += 1;
            }
            else
            {
                colorLB = Color.Yellow;
                yellowColoredCorners += 1;
            }
            #endregion
            #region Right Top
            if (Main.rand.NextBool(doChangeColors))
            {
                colorRT = Color.Red;
                redColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRT = Color.Blue;
                blueColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRT = Color.Green;
                greenColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRT = Color.Orange;
                orangeColoredCorners += 1;
            }
            else
            {
                colorRT = Color.Yellow;
                yellowColoredCorners += 1;
            }
            #endregion
            #region Right Bottom
            if (Main.rand.NextBool(doChangeColors))
            {
                colorRB = Color.Red;
                redColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRB = Color.Blue;
                blueColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRB = Color.Green;
                greenColoredCorners += 1;
            }
            else if (Main.rand.NextBool(doChangeColors))
            {
                colorRB = Color.Orange;
                orangeColoredCorners += 1;
            }
            else
            {
                colorRB = Color.Yellow;
                yellowColoredCorners += 1;
            }
            #endregion
        }
        private void ShootBullets()
        {
            Player player = Main.player[npc.target];
            Vector2 vector2_1 = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            Vector2 center = npc.Center;
            float num2 = 5f * npc.life / npc.lifeMax;
            Vector2 vector2_2 = Vector2.Add(Vector2.Subtract(vector2_1, center), new Vector2(Utils.NextFloat(Main.rand, -num2, num2), Utils.NextFloat(Main.rand, -num2, num2)));
            vector2_2.Normalize();
            Vector2 vector2_3 = Vector2.Multiply(vector2_2, 2.5f);
            for (int index = 0; index < yellowColoredCorners; ++index)
                if (Main.rand.NextBool(32))
                    Projectile.NewProjectile(center.X + Main.rand.NextFloat(-25f * yellowColoredCorners, 25f * yellowColoredCorners),
                        center.Y + Main.rand.NextFloat(-25f * yellowColoredCorners, 25f * yellowColoredCorners),
                        vector2_3.X, vector2_3.Y, ProjectileID.DeathLaser, npc.damage / 8, 0f, byte.MaxValue, 0.0f, 0.0f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D textureCornerLT = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianLT");
            Texture2D textureCornerLB = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianLB");
            Texture2D textureCornerRT = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianRT");
            Texture2D textureCornerRB = mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardianRB");
            Vector2 vector2_1 = Vector2.Subtract(npc.Center, Main.screenPosition);

            spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/CrystalGuardian/CrystalGuardian"),
                            vector2_1 + new Vector2(-13, -9), new Rectangle?(npc.frame),
                            drawColor, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerLT, vector2_1 + new Vector2(-45, -45), new Rectangle?(),
                            colorLT, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerLB, vector2_1 + new Vector2(-45, 19), new Rectangle?(npc.frame),
                            colorLB, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerRT, vector2_1 + new Vector2(19, -45), new Rectangle?(npc.frame),
                            colorRT, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureCornerRB, vector2_1 + new Vector2(19, 19), new Rectangle?(npc.frame),
                            colorRB, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            return true;
        }
    }
}
