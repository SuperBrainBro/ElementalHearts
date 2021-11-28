using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.Lite
{
    [AutoloadEquip(EquipType.Wings)]
    public class WingLite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wing Lite");
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.rare = ItemRarityID.Cyan;
            item.accessory = true;
            item.vanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 150;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 5f;
            acceleration *= 2.5f;
        }
    }
}