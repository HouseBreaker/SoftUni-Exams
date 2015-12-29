using System;
using Exam.Engine.Events;
using Exam.Models.Behaviors;
using Exam.Models.Interfaces;

namespace Exam.Models
{
	public delegate void LifeStateChangeEventHandler(Blob sender, LifeReportEventArgs args);

	public delegate void BehaviorStateChangeEventHandler(Blob sender, LifeReportEventArgs args);

	public class Blob : IBlob
	{
		// todo: implement event
		public event LifeStateChangeEventHandler LifeStateChange;
		public event BehaviorStateChangeEventHandler BehaviorStateChange;

		private bool isAlive;
		private string name;

		private int health;
		private int damage;

		public int InitialDamage { get; }
		public int InitialHealth { get; }
		public IAttack BlobAttack { get; }
		public IBehavior BlobBehavior { get; set; }

		public Blob(string name, int health, int damage, IBehavior blobBehavior, IAttack blobAttack)
		{
			Name = name;
			Health = health;
			InitialHealth = Health;

			Damage = damage;
			InitialDamage = Damage;

			BlobBehavior = blobBehavior;
			BlobAttack = blobAttack;

			IsAlive = true;
			BlobBehavior.HasBeenTriggered = false;
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Name", "Name cannot be null, empty or whitespace.");
				}
				this.name = value;
			}
		}

		public int Health
		{
			get { return this.health; }
			set
			{
				if (value <= 0)
				{
					health = 0;
				}
				this.health = value;
			}
		}

		public int Damage
		{
			get { return this.damage; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Damage", "Damage cannot be less than or equal to zero.");
				}
				this.damage = value;
			}
		}

		public bool IsAlive
		{
			get { return isAlive; }
			set
			{
				LifeStateChange?.Invoke(this, new LifeReportEventArgs("Name", isAlive, value));
				isAlive = value;
			}
		}


		public override string ToString()
		{
			return IsAlive
				? $"Blob {Name}: {Health} HP, {Damage} Damage"
				: $"Blob {Name} KILLED";
		}

		public void Attack(Blob targetBlob)
		{
			if (IsAlive && targetBlob.IsAlive)
			{
				BlobAttack.Attack(this, targetBlob);
				if (this.BlobBehavior is AggressiveBehavior && targetBlob.Health <= targetBlob.InitialHealth)
				{
					this.BlobBehavior.Trigger(this);
				}
			}
		}

		public void EndTurnAction()
		{
			BlobBehavior.EndTurnAction(this);
		}
	}
}