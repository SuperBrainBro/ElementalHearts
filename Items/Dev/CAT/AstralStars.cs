using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
    public class AstralStars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Stars");
            Tooltip.SetDefault("Summons Stars from sky!"
                            + "\n'Great for impersonating devs!'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Starfury);
            item.shootSpeed *= 2f;
            item.summon = true;
            item.damage = 45;
            item.rare = ItemRarityID.Cyan;
            item.autoReuse = true;
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.noMelee = true;
            item.mana = 15;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.NextBool(2))
            {
                type = ProjectileType<DreamerStarSmall>();
            }
            else if (Main.rand.NextBool(4))
            {
                type = ProjectileType<DreamerStarMedium>();
            }
            else if (Main.rand.NextBool(6))
            {
                type = ProjectileType<DreamerStarLarge>();
            }
            else if (Main.rand.NextBool(8))
            {
                type = ProjectileType<DreamerStarMega2>();
            }
            else if (Main.rand.NextBool(10))
            {
                type = ProjectileType<DreamerStarUltra>();
            }
            else { type = ProjectileType<DreamerStarSmall>(); }
            if (player.name == "Fox")
            {
                type = ProjectileType<DreamerStarUltra>();
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}