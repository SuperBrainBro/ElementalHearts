using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
	public class TyrantsTear : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tyrant's Tear");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Tsunami);
			item.damage = 20;
			item.ranged = true;
			item.width = 30;
			item.height = 70;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0f;
			item.crit = 0;
			item.rare = ItemRarityID.Cyan;
			item.autoReuse = true;
			item.shoot = ProjectileType<TyrantsTear_Arrow>();
			item.shootSpeed = 15f;
			item.useAmmo = 0;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			// Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
			mult *= player.arrowDamage;
		}

		public override Vector2? HoldoutOffset() {
			return Vector2.Zero;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            target.AddBuff(BuffType<CATsCurse>(), 3 * 60);
		}
	}
	public class TyrantsTear2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tyrant's Tear");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Tsunami);
			item.damage = 20;
			item.ranged = true;
			item.width = 30;
			item.height = 70;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0f;
			item.crit = 0;
			item.rare = ItemRarityID.Cyan;
			item.autoReuse = true;
			item.shoot = ProjectileType<TyrantsTear_Arrow>();
			item.shootSpeed = 15f;
			item.useAmmo = 40;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			// Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
			mult *= player.arrowDamage;
		}

		public override Vector2? HoldoutOffset() {
			return Vector2.Zero;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            target.AddBuff(BuffType<CATsCurse>(), 3 * 60);
		}
	}
	public class TyrantsTear_Arrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tyrant's Tear");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			aiType = ProjectileID.WoodenArrowFriendly;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = ProjectileID.Starfury;
			return true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			for (int i = 0; i < 5; i++) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, mod.ProjectileType("TyrantsTear_Star"), (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
	public class TyrantsTear_Star : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tyrant's Tear");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Starfury);
			aiType = ProjectileID.Starfury;
			projectile.damage = 40;
			projectile.scale = 1.25f;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = ProjectileID.Starfury;
			return true;
		}
	}
}
