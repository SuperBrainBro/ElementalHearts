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
    class MenacingHeartKeeper : ModItem
	{
		public int shootCountInt;
		public bool speedEffect;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A mystic staff forged out of ancient life quartz. \nSeeking heart shaped projectiles, which accompany arrows, suck life from anything it touches.");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.ranged = true;
			item.crit = 12;
			item.width = 26;
			item.height = 36;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 6775;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item5;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.useAmmo = AmmoID.Arrow;
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

			if (shootCountInt == 1)
			{
				Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileType<SeekingFriendlyMenacingProjectile>(), damage, knockBack, Main.myPlayer);
				shootCountInt = 0;
			}
			else
			{
				if (shootCountInt == 0)
				{
					shootCountInt = 1;
				}
			}
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
