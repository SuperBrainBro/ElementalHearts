using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.Lite
{
	public class MissileLite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Great for impersonating devs!' \nCasts a controllable missile \nShoots chlorophyte bullets in all directions which do high amounts of damage. \nHas a chance to spawn an array of extra homing chlorophyte bullets on impact. \nHas a chance to inflict Midas on enemies. \nHas a chance to inflict Shadowflame on enemies. \nKills have a chance to spawn killer bees.");
		}

		public override void SetDefaults() {
			item.damage = 600;
			item.magic = true;
			item.mana = 100;
			item.width = 26;
			item.height = 26;
			item.useTime = 500;
			item.useAnimation = 500;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.knockBack = 16;
			item.value = 0;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item9;
			item.shoot = ProjectileType<MissileLiteProj>();
			item.shootSpeed = 1f;
		}
	}
}