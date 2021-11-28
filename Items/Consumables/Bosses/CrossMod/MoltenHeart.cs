﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Bosses.CrossMod
{
    internal class MoltenHeart : LaugicalityCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 5");
            DisplayName.SetDefault("Molten Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Expert;
            item.value = 0;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().MoltenLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 5;
            player.statLife += 5;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(5, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().MoltenLife += 1;
            return true;
        }
    }
}
