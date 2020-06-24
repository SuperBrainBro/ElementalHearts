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
    class MenacingLifeBlade : ModItem
	{
		public bool speedEffect;
		public float speedValue;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Casts heart shaped projectiles that suck life from anything it touches.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.width = 46;
			item.height = 50;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 8;
			item.value = 6775;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item9;
			//item.shoot = ProjectileType<FriendlyMenacingProjectile>();
			//item.shootSpeed = 6f;
			item.autoReuse = true;

			speedEffect = true;
			speedValue = 0;
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
			if (item.useTime >= 36)
			{
				speedEffect = true;
			}
			else if (item.useTime <= 24)
			{
				speedEffect = false;
			}

			if (speedEffect)
			{
				speedValue += 0.1f;
			}
			else if (!speedEffect)
			{
				speedValue -= 0.1f;
			}
			
			if (speedValue >= 1)
			{
				item.useTime -= 1;
				item.useAnimation -= 1;
				speedValue = 0;
			} 
			else if(speedValue <= -1)
			{
				item.useTime += 1;
				item.useAnimation += 1;
				speedValue = 0;
			}
			
			base.HoldItem(player);
		}
	}
}
