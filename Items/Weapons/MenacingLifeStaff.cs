using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;
using System.Data;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Friendly;

namespace ElementalHearts.Items.Weapons
{
    class MenacingLifeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Casts life sucking projectiles.");
		}

		public override void SetDefaults()
		{
			item.damage = 145;
			item.magic = true;
			item.mana = 10;
			item.width = 26;
			item.height = 26;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 6775;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item9;
			item.shoot = ProjectileType<FriendlyMenacingProjectile>();
			item.shootSpeed = 10f;
		}

	}
}
