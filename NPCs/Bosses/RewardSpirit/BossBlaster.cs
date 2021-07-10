using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpiritBlaster : ModProjectile
    {
        public bool vertical;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blaster");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            vertical = false;
            projectile.width = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Width;
            projectile.height = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Height / Main.projFrames[projectile.type];
            projectile.damage = 80;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            Player player = Main.LocalPlayer;
            bool shoot = false;

            int x = -16; int y = 120;
            if (vertical == true) { x = 120; y = -16; }

            projectile.ai[1] += 1;
            if (projectile.ai[1] > 90)
            {
                for (int i = 1; i < 40; i++)
                {
                    Projectile.NewProjectile(projectile.position + new Vector2(x + 50, -projectile.height + y - 16
                        * i), new Vector2(0, 0), ModContent.ProjectileType<RSpiritBlasterLaser>(), projectile.damage * 2, 0f);
                }
                projectile.ai[1] = 90;
                projectile.alpha += 5;
            }
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }

            if (shoot == false && projectile.ai[1] < 70)
            {
                projectile.position = player.position + new Vector2(x, y);
            }
        }
    }

    public class RSpiritBlasterLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blaster");
        }

        public override void SetDefaults()
        {
            projectile.width = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Width;
            projectile.height = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Height;
            projectile.damage = 160;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.2f / 60)
            {
                Dust dust;
                Vector2 position = projectile.Center;
                dust = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, 76, 0f, 0f, 0, new Color(255, 255, 255), 1.052632f)];
                dust.noGravity = true;
                dust.noLight = true;
                dust.fadeIn = 0.5921053f;
            }

            projectile.alpha += 5;
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }
        }
    }
}
