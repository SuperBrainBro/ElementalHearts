using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.AncientLifeThings
{
    class LifePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Life Pick");
            Tooltip.SetDefault("Can mine Meteorite");
        }

        public override void SetDefaults()
        {
            item.damage = 7;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = 4250;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
            item.pick = 57;
        }
    }
}
