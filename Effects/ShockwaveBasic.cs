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
    public class ShockwaveBasic : ModProjectile {

        private int rippleCount = 3;
        private int rippleSize = 5;
        private int rippleSpeed = 15;
        private float distortStrength = 100f;

        public override void AI()
        {
            if (projectile.timeLeft <= 180)
            {
                if (projectile.ai[0] == 0)
                {
                    projectile.ai[0] = 1; // Set state to exploded
                    projectile.alpha = 255; // Make the projectile invisible.
                    projectile.friendly = false; // Stop the bomb from hurting enemies.
                    projectile.hostile = false;

                    if (Main.netMode != NetmodeID.Server && !Filters.Scene["ShockwaveBasic"].IsActive())
                    {
                        Filters.Scene.Activate("Shockwave", projectile.Center).GetShader().UseColor(rippleCount, rippleSize, rippleSpeed).UseTargetPosition(projectile.Center);
                    }
                }

                if (Main.netMode != NetmodeID.Server && Filters.Scene["ShockwaveBasic"].IsActive())
                {
                    float progress = (180f - projectile.timeLeft) / 60f;
                    Filters.Scene["Shockwave"].GetShader().UseProgress(progress).UseOpacity(distortStrength * (1 - progress / 3f));
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["ShockwaveBasic"].IsActive())
            {
                Filters.Scene["Shockwave"].Deactivate();
            }
        }
    }
}
