using Godot;
using System;

namespace Characters
{
	public interface ICharacter
	{
		//Default for all properties characters should have
		double CharMs { get; set; }
		double CharAd { get; set; }
		double CharAs { get; set; }
		double CharMaxHp { get; set; }
		double CharMaxMp { get; set; }
		double CharCurrHp { get; set; }
		double CharCurrMp { get; set; }

		void BasicAttack();			//Default: Left Click + Undefined abilities
		void Ability0();				//Default: Q
		void Ability1();				//Default: E
		void Ability2();				//Default: X
		void Ability3();				//Default: Right Click
		void AbilityUltimate(); //Default: R
		void Skill0();					//Default: F
	}

	public partial class Character : CharacterBody3D, ICharacter
	{
		// Character properties
		public double CharMs { get; set; }
		public double CharAd { get; set; }
		public double CharAs { get; set; }
		public double CharMaxHp { get; set; }
		public double CharMaxMp { get; set; }
		public double CharCurrHp { get; set; }
		public double CharCurrMp { get; set; }
		
		public float Speed = 5.0f;
		public const float JumpVelocity = 4.5f;

		// Get the gravity from the project settings to be synced with RigidBody nodes.
		public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
		public override void _Process(double delta)
		{
			if(Input.IsActionJustPressed("left_click"))
			{
				BasicAttack();
			}
			if(Input.IsActionJustPressed("ability_q"))
			{
				Ability0();
			}
			if(Input.IsActionJustPressed("ability_e"))
			{
				Ability1();
			}
			if(Input.IsActionJustPressed("ability_x"))
			{
				Ability2();
			}
			if(Input.IsActionJustPressed("ability_rc"))
			{
				Ability3();
			}
			if(Input.IsActionJustPressed("ability_r"))
			{
				AbilityUltimate();
			}
			if(Input.IsActionJustPressed("skill_f"))
			{
				Skill0();
			}
		}
		
		public override void _PhysicsProcess(double delta)
		{
			Vector3 velocity = Velocity;

			// Add the gravity.
			if (!IsOnFloor())
				velocity.Y -= gravity * (float)delta;

			// Handle Jump.
			if (Input.IsActionJustPressed("jump") && IsOnFloor())
				velocity.Y = JumpVelocity;

			// Get the input direction and handle the movement/deceleration.
			// As good practice, you should replace UI actions with custom gameplay actions.
			Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
			Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
			if (direction != Vector3.Zero)
			{
				velocity.X = direction.X * Speed;
				velocity.Z = direction.Z * Speed;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
			}

			Velocity = velocity;
			MoveAndSlide();
		}
		
		public void BasicAttack()
		{
			GD.Print("Do Basic Attack");
		}
		public void Ability0()
		{
			GD.Print("No Ability0; Default to Basic Attack");
		}
		public void Ability1()
		{
			GD.Print("No Ability1; Default to Basic Attack");
		}
		public void Ability2()
		{
			GD.Print("No Ability2; Default to Basic Attack");
		}
		public void Ability3()
		{
			GD.Print("No Ability3; Default to Basic Attack");
		}
		public void AbilityUltimate()
		{
			GD.Print("No AbilityUltimate; Default to Basic Attack");
		}
		public void Skill0()
		{
			GD.Print("No Skill0; Default to Basic Attack");
		}
		
	}

}
