using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.CAT
{
    [AutoloadEquip(EquipType.Head)]
    public class MaskOfCAT : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Mask Of Fox");
            Tooltip.SetDefault("'Great for impersonating devs!'\nThe Starbreaker... what under his mask?");
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