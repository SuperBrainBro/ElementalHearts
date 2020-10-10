using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Effects
{
    public class TeleportShockwave : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Teleport Shockwave");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 255;
        }
        private int rippleCount = 3;
        private int rippleSize = 40;
        private int rippleSpeed = 10;
        private float distortStrength = 200f;

        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.ai[0] = 1;

                if (Main.netMode != NetmodeID.Server && !Filters.Scene["BasicShockwave"].IsActive())
                {
                    Filters.Scene.Activate("BasicShockwave", projectile.Center).GetShader().UseColor(rippleCount, rippleSize, rippleSpeed).UseTargetPosition(projectile.Center);
                }
            }

            if (Main.netMode != NetmodeID.Server && Filters.Scene["BasicShockwave"].IsActive())
            {
                float progress = (255 - projectile.timeLeft) / 60f;
                Filters.Scene["BasicShockwave"].GetShader().UseProgress(progress).UseOpacity(distortStrength * (1 - progress / 3f));
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["BasicShockwave"].IsActive())
            {
                Filters.Scene["BasicShockwave"].Deactivate();
            }
        }
    }
}