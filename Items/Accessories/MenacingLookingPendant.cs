using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Mono.Cecil.Cil.OpCodes;

namespace ElementalHearts.Items.Accessories
{
	//[AutoloadEquip(EquipType.Front)]
	class MenacingLookingPendant : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Menacing Looking Pendant");
			Tooltip.SetDefault("Increases life regen by 5. \nIncreases HP by 25");
		}

		public override void SetDefaults()
		{
			//sbyte realBackSlot = item.backSlot;
			item.CloneDefaults(ItemID.PanicNecklace);
			item.value = Item.sellPrice(0, 5, 0, 0);
			//item.backSlot = realBackSlot;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 5;
			player.statLifeMax2 += 25;
		}
	}
}
