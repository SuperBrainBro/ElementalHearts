using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class TooLongForRealNameID : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 69");
            DisplayName.SetDefault("AAABWBCCCCCCCCCCCCCCFDDDDDEEEEEEEFFGGGHHHIIILLLMMMMMOOPPWPPPPPRRCRMRSSSSSSCSBSFSFSLSMSNSSSSSTTTTTTWZAGAACADAAIAMASASASASABSCRCCESECHASHSSNNSPPMSSPSSSSTUVVSFSTSWABCDRILQLMMGMMRMPOOPPSCTVYWABBBBCDDEEHHLMMBRRSSSTVXWAAAAAAAABBBWCCCCCCTCDPSDDDDSEEFFGGIBSILMPMNOOPPRSSSTVVVoZ Heart MK2 AoZoDoHotFotIotSP");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Quest;
            item.value = 0;
            item.color = Main.DiscoColor;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TooLongForRealNameID <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 69;
            player.statLife += 69;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(69, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().TooLongForRealNameID += 1;
            return true;
        }
    }
}
