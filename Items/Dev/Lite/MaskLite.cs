using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.Lite
{
	[AutoloadEquip(EquipType.Head)]
	public class MaskLite : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Mask Lite");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<ChestLite>() && legs.type == ItemType<LegLite>();
		}
	}
}