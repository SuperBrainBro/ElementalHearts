using ElementalHearts.Items.Consumables;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts
{
    public class ElementalHeartsGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (type == 187)
            {
                if (Main.rand.Next(0, 30) == 0)
                {
                    Item.NewItem(i * 48, j * 32, 16, 16, ModContent.ItemType<EnchantedHeart>());
                    return false;
                }
                return true;
            }
            return base.Drop(i, j, type);
        }
    }
}
