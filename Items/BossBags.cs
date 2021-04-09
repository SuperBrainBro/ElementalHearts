using ElementalHearts.Items.Dev.CAT;
using ElementalHearts.Items.Dev.Lite;
using ElementalHearts.Items.Dev.AppleInTheSky;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items
{
    public class BossBags : GlobalItem
    {
        private void DevSetToDrop(string type, Player player)
        {
            switch (type)
            {
                case "Lite":
                    player.QuickSpawnItem(ItemType<LegLite>());
                    player.QuickSpawnItem(ItemType<ChestLite>());
                    player.QuickSpawnItem(ItemType<MaskLite>());
                    player.QuickSpawnItem(ItemType<WingLite>());
                    break; 

                case "Fox":
                    player.QuickSpawnItem(ItemType<MaskOfCAT>());
                    player.QuickSpawnItem(ItemType<RobeOfCAT>());
                    player.QuickSpawnItem(ItemType<WingsOfCAT>());
                    break;

                case "Apple":
                    player.QuickSpawnItem(ItemType<EvenFlameWings>());
                    break;
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag")
            {
                if (Main.rand.NextBool(100))
                {
                    DevSetToDrop("Fox", player);
                }
                if (Main.rand.NextBool(100))
                {
                    DevSetToDrop("Lite", player);
                }
                if (Main.rand.NextBool(100))
                {
                    DevSetToDrop("Apple", player);
                }
            }
        }
    }
}