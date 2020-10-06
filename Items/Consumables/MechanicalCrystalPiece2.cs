using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class MechanicalCrystalPiece2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Crystal Piece");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = -12;
            item.value = 5000;
            item.expert = true;
        }
    }
}
