using ElementalHearts.Items.Dev.CAT;
using ElementalHearts.Items.Dev.Lite;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items
{
    public class BossBags : GlobalItem
    {
        //NOTE for devs:
        //              I made "DevSetToDrop" for making code easier
        private void DevSetToDrop(string type, Player player)
        {
            switch (type)
            {
                case "Lite":
                    player.QuickSpawnItem(ItemType<ChestLite>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<MaskLite>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<WingLite>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<BowLite>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<CrystalLite>(), Main.rand.Next(1, 1));
                    break;
                case "Fox":
                    if (Main.rand.NextBool(1465))
                    {
                        player.QuickSpawnItem(ItemType<MaskOfCAT2>(), 1);
                    }
                    else
                    {
                        player.QuickSpawnItem(ItemType<MaskOfCAT>(), Main.rand.Next(1, 1));
                    }
                    player.QuickSpawnItem(ItemType<RobeOfCAT>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<WingsOfCAT>(), Main.rand.Next(1, 1));
                    if (Main.rand.NextBool(5))
                    {
                        player.QuickSpawnItem(ItemType<CatastrophicEdge>(), Main.rand.Next(1, 1));
                    }
                    else if (Main.rand.NextBool(5))
                    {
                        player.QuickSpawnItem(ItemType<CATsThrow>(), Main.rand.Next(1, 1));
                    }
                    else if (Main.rand.NextBool(5))
                    {
                        player.QuickSpawnItem(ItemType<HeartOfCAT>(), Main.rand.Next(1, 1));
                    }
                    else if (Main.rand.NextBool(5))
                    {
                        player.QuickSpawnItem(ItemType<TyrantsTear>(), Main.rand.Next(1, 1));
                    }
                    else
                    {
                        player.QuickSpawnItem(ItemType<AstralStars>(), Main.rand.Next(1, 1));
                    }
                    break;
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            //Reroll for devs
            if (context == "bossBag" && Main.hardMode)
            {
                if (player.name == "CAT" || player.name == "AstralCat" || player.name == "Fox" || player.name == "FOX" || player.name == "Cat")
                {
                    if (Main.rand.NextBool(10))
                    {
                        DevSetToDrop("Fox", player);
                    }
                }
                if (player.name == "Lite")
                {
                    if (Main.rand.NextBool(10))
                    {
                        DevSetToDrop("Lite", player);
                    }
                }
            }
            //Normal roll for normies
            if (context == "bossBag" && Main.hardMode &&
                //Wont repeat roll for devs
                !(player.name == "Lite") &&
                !(player.name == "CAT" || player.name == "AstralCat" || player.name == "Fox" || player.name == "FOX" || player.name == "Cat")
                )
            {
                if (Main.rand.NextBool(50))
                {
                    DevSetToDrop("Fox", player);
                }
                if (Main.rand.NextBool(50))
                {
                    DevSetToDrop("Lite", player);
                }
            }
        }
    }
}