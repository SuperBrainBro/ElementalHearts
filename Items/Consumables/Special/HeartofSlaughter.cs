using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Special
{
    internal class HeartofSlaughter : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"Permanently increases maximum life by 10

Even after spending several hours, or even days, on this heart, you received it.
Did you get pleasure or happiness? I do not know this.
But please stop.

Thank you.");
            DisplayName.SetDefault("Heart of Slaughter");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Red;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayerSpecial>().LifeofSlaughter <
                   1; //ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 10;
            player.statLife += 10;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(10, true);
            }
            player.GetModPlayer<ElementalHeartsPlayerSpecial>().LifeofSlaughter += 1;
            return true;
        }
    }
    internal class HeartofSlaughter2 : ConsumableHeartItem
    {
        public override string Texture => base.Texture.Replace("Slaughter2", "Slaughter");
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"Permanently increases maximum life by 20

Even after spending several hours, or even days, on this heart, you received it.
Did you get pleasure or happiness? I do not know this.
But please stop.

Thank you.");
            DisplayName.SetDefault("Heart of Slaughter");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Red;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayerSpecial>().LifeofSlaughter <
                   1; //ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 20;
            player.statLife += 20;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(20, true);
            }
            player.GetModPlayer<ElementalHeartsPlayerSpecial>().LifeofSlaughter += 1;
            return true;
        }
    }
}
