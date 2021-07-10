using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpiritPre : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("???");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 9999999;
            npc.defense = 9999999;
            npc.damage = 0;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.alpha = 255;
            npc.dontTakeDamage = true;
        }

        public override void AI()
        {
            ++npc.ai[1];
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            npc.Center = player.Center;

            Dust dust;
            Vector2 position = npc.Center + new Vector2(800, 0);
            dust = Main.dust[Dust.NewDust(position, 100, 100, 191, 0f, 0f, 130, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.noLight = true;
            dust.fadeIn = 1.5f;

            switch (npc.ai[1])
            {
                case 100.0f:
                    Main.NewText("<" + npc.FullName + "> Ahhh...", Color.Goldenrod);
                    break;
                case 300.0f:
                    Main.NewText("<" + npc.FullName + "> Who called me--", Color.Goldenrod);
                    break;
                case 350.0f:
                    Main.NewText("<" + npc.FullName + "> Oh, so it's you, " + player.name + ".", Color.Goldenrod);
                    break;
                case 400.0f:
                    Main.NewText("<" + npc.FullName + "> Or should I say... " + Environment.UserName + ".", Color.Goldenrod);
                    break;
                case 500.0f:
                    Main.NewText("<" + npc.FullName + "> You killed a thousand bosses. That's a lot. Do you even have a life?", Color.Goldenrod);
                    break;
                case 700.0f:
                    float Speed = 15f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 1;
                    int type = ProjectileType<RSpiritPreHeart>();
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f) - 50));
                    rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height
                        * 0.5f) + 50), vector8.X - (player.position.X + (player.width * 0.5f) + 50));
                    Projectile.NewProjectile(vector8.X + 400f, vector8.Y + 400f, (float)(Math.Cos(rotation) * Speed * -1), (float)(Math.Sin(rotation) * Speed * -1), type, damage, 0f, 0);
                    Main.NewText("<" + npc.FullName + "> Either way, get the award you deserve.", Color.Goldenrod);
                    break;
                case 1200.0f:
                    if (!player.GetModPlayer<ElementalHeartsPlayerSpecial>().heartCatched)
                    {
                        Main.NewText("<" + npc.FullName + "> ... Hm?", Color.Goldenrod);
                    }
                    else
                    {
                        Main.NewText("<" + npc.FullName + "> Goodbye.", Color.Goldenrod);
                        npc.lifeMax = 0;
                        npc.life = 0;
                        player.GetModPlayer<ElementalHeartsPlayerSpecial>().heartCatched = false;
                    }
                    break;
                case 1400.0f:
                    Main.NewText("<" + npc.FullName + "> Why didn't you want to take the award?", Color.Lerp(Color.Goldenrod, Color.Red, 0.5f));
                    break;
                case 1600.0f:
                    Main.NewText("<" + npc.FullName + "> Oh, I think I understand why. You want to get a better reward than last time.", Color.Lerp(Color.Goldenrod, Color.Red, 0.5f));
                    break;
                case 1800.0f:
                    Main.NewText("<" + npc.FullName + "> But then you have to fight me.", Color.Red);
                    npc.Transform(NPCType<RSpirit>());
                    break;
            }
        }
    }
}
