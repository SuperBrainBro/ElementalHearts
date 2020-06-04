using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;
using System.Data;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Friendly;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Items.Weapons
{
    class MenacingLifeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Casts heart shaped projectiles that suck life from anything it touches.");
		}

		public override void SetDefaults()
		{
			item.damage = 90;
			item.magic = true;
			item.mana = 10;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 6775;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item9;
			item.shoot = ProjectileType<FriendlyMenacingProjectile>();
			item.shootSpeed = 1f;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Dust.NewDust(position, 16, 16, 112, 0, 0, 0, Main.DiscoColor, 2);
			
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
