using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
    public class CatastrophicEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catastrophic Edge");
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.TerraBlade);
            item.damage = 70;
            item.magic = true;
            item.width = 44;            //Weapon's texture's width
            item.height = 68;           //Weapon's texture's height
            item.useTime = 31;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 31;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = ItemUseStyleID.SwingThrow;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 5.25f;         //The force of knockback of the weapon. Maximum is 20
            item.rare = ItemRarityID.Cyan;              //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item1;      //The sound when the weapon is using
            item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
            item.scale = 1.2f;
            item.shoot = ProjectileType<CatastrophicBeam>();
            item.mana = 5;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(30))
            {
                target.AddBuff(BuffType<CATsCurse>(), 10 * 60);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 5;
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }
    }
}
