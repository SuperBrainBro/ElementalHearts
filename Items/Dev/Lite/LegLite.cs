using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.Lite
{
    [AutoloadEquip(EquipType.Legs)]
    public class LegLite : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Leg Lite");
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