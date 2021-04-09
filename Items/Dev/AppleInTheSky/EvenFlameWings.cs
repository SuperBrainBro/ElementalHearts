using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.AppleInTheSky
{
    [AutoloadEquip(EquipType.Wings)]
    public class EvenFlameWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EvenFlame Wings");
            Tooltip.SetDefault("AppleInTheSky would be proud of you...\nWe love you Apple!");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 10000;
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.vanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 200;
        }

        float fade = Main.GameUpdateCount % 200 / 60f;
        int index = (int)(Main.GameUpdateCount / 200 % 2);
        Color[] itemNameCycleColors = new Color[]{
            new Color(255, 61, 39),
            new Color(53, 57, 63)
        };

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(Main.DiscoG, 64, 64);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 2], fade);
                }
            }
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1f;
            ascentWhenRising = 0.1f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 2f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 5f;
            acceleration *= 2.5f;
        }
    }
}