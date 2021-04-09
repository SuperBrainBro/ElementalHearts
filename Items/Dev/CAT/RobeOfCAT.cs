using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.CAT
{
    [AutoloadEquip(EquipType.Body)]
    public class RobeOfCAT : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Robe Of Luxure");
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }
    }
}