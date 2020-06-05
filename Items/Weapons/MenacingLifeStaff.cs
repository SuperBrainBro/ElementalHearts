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
		public bool speedEffect;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Casts heart shaped projectiles that suck life from anything it touches.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.magic = true;
			item.mana = 10;
			item.width = 48;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 6775;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item9;
			item.shoot = ProjectileType<FriendlyMenacingProjectile>();
			item.shootSpeed = 6f;
			item.autoReuse = true;

			speedEffect = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Dust.NewDust(position, 16, 16, 112, 0, 0, 0, Main.DiscoColor, 2);
			Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
			Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
			Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
			Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
			Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		public override void HoldItem(Player player)
		{
			if (item.shootSpeed > 12)
			{
				speedEffect = false;
			} else
			if (item.shootSpeed < 6)
			{
				speedEffect = true;
			}

			if (speedEffect)
			{
				item.shootSpeed += 0.1f;
			} else
			{
				item.shootSpeed -= 0.1f;
			}
			base.HoldItem(player);
		}
	}
}
