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
        //LITE DONT TOUCH THIS FILE!!!
        //ONLY EXCEPTION IS FIXES
        //ALSO, I MADE THIS FILE (before your 'fix')
        //HOW APPLE WANTED! (i suggest to him some
        //additions so i remade it)
        //
        //                  - Fox

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EvenFlame Wings");
            Tooltip.SetDefault("AppleInTheSky would be proud of you...");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 10000;
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.expertOnly = true;
            item.expert = true;
        }

        public void DamageReduction(Player player, bool hideVisual, NPC npc)
        {
            float dmgReduct = GetInstance<ElementalHeartsPlayer>().dmgReduct;
            if (NPC.downedMechBossAny)
            {
                dmgReduct = 2.5f;
            }
            if ((NPC.downedMechBoss1 && NPC.downedMechBoss2)
                || (NPC.downedMechBoss2 && NPC.downedMechBoss3)
                || (NPC.downedMechBoss3 && NPC.downedMechBoss1)
                )
            {
                dmgReduct = 5f;
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                dmgReduct = 7.5f;
            }
            if (NPC.downedPlantBoss)
            {
                dmgReduct = 10f;
            }
            if (NPC.downedGolemBoss)
            {
                dmgReduct = 12.5f;
            }
            if (NPC.downedFishron)
            {
                dmgReduct = 15f;
            }
            if (NPC.downedAncientCultist)
            {
                dmgReduct = 17.5f;
            }
            if (NPC.downedMoonlord)
            {
                dmgReduct = 20f;
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!player.HasItem(ItemID.MasterNinjaGear))
            {
                player.wingTimeMax = 150;
            }
            else
            {
                player.wingTimeMax = 10000;
            }
            DamageReduction(player, hideVisual, default);
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