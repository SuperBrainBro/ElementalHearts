using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Weapons
{
    class MenacingLifeBlade : ModItem
    {
        public bool speedEffect;
        public float speedValue;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sharp sword forged out of ancient life quartz. \nThe blade sucks life from anything it touches.");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 46;
            item.crit = 12;
            item.height = 50;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = 6775;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            //item.shoot = ProjectileType<FriendlyMenacingProjectile>();
            //item.shootSpeed = 6f;
            item.autoReuse = true;

            speedEffect = true;
            speedValue = 0;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Dust.NewDust(position, 16, 16, 112, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void HoldItem(Player player)
        {
            if (item.useTime >= 36)
            {
                speedEffect = true;
            }
            else if (item.useTime <= 18)
            {
                speedEffect = false;
            }

            if (speedEffect)
            {
                speedValue += 0.25f;
            }
            else if (!speedEffect)
            {
                speedValue -= 0.25f;
            }

            if (speedValue >= 1)
            {
                item.useTime -= 1;
                item.useAnimation -= 1;
                speedValue = 0;
            }
            else if (speedValue <= -1)
            {
                item.useTime += 1;
                item.useAnimation += 1;
                speedValue = 0;
            }

            base.HoldItem(player);
        }

        //Heal Player On Hit
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                int healAmount = damage / (10 + (int)Main.rand.NextFloat(4));
                healAmount /= 1 + (int)Main.rand.NextFloat(4);
                Main.player[item.owner].HealEffect(healAmount, true);
                Main.player[item.owner].statLife += healAmount;
                Main.PlaySound(SoundID.Item35, target.position);
            }
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }
}
