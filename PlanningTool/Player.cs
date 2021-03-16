using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayHelper
{
    [Serializable] //make it serializeable to being able to save it as binary at the end
    class Character : ICharacterEvents
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private float health;

        public float Health
        {
            get { return health; }
        }

        private float maxHealth;

        public float MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        private float armor;

        public float Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        private float strength;

        public float Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        private ARMORTYPE armorType;

        public ARMORTYPE ArmorType
        {
            get { return armorType; }
            set { armorType = value; }
        }

        public List<Stat> stats;

        private readonly EventHandler<float> onHealthChange;
        private readonly EventHandler onDeath;

        public enum ARMORTYPE
        {
            ArmorAsPercentage,
            ArmorAsSubstractive
        }

        public Character(string _name, float _maxHealth, float _armor = 0, float _strength = 0, ARMORTYPE _armorType = ARMORTYPE.ArmorAsPercentage)
        {
            if (_name == null || _name == "")
                throw new Exception("Name cannot be empty or null");
            else name = _name;

            if (_maxHealth > 0)
                maxHealth = _maxHealth;
            else throw new Exception("The health can't be 0 or negativ");

            armor = _armor;
            strength = _strength;
            armorType = _armorType;

            stats = new List<Stat>();

            onHealthChange += OnHealthChange;
            onDeath += OnDeath;
        }

        public void Damage(float amount)
        {

            switch (ArmorType)
            {
                case ARMORTYPE.ArmorAsPercentage: //Check ArmorType for the correct calculation
                    if (Math.Abs(health - (amount * armor)) > 1e-5f)
                    {  //Check if enough health is available
                        onHealthChange?.Invoke(this, amount * armor);
                        health -= amount * armor;
                    }
                    else
                    {
                        onHealthChange?.Invoke(this, health);
                        onDeath?.Invoke(this, null);
                        health = 0;
                    }
                    break;
                case ARMORTYPE.ArmorAsSubstractive:
                    if (Math.Abs(health - (amount - armor)) > 1e-5f)
                    {
                        onHealthChange?.Invoke(this, amount - armor);
                        health -= amount - armor;
                    }
                    else
                    {
                        onHealthChange?.Invoke(this, health);
                        onDeath?.Invoke(this, null);
                        health = 0;
                    }
                    break;
            }
        }

        public void Heal(float amount, float factor = 1) //factor should be a value between 0 and 1
        {
            if (factor < 0 || factor > 1)
                throw new Exception("Factor should be a value between 0 and 1");

            if (health + (amount * factor) <= maxHealth)
            {
                health += amount * factor;
            }
            else
            {
                health = maxHealth;
            }
        }

        public virtual void OnHealthChange(object sender, float amount) { }

        public virtual void OnDeath(object sender, EventArgs e) { }
    }

    interface ICharacterEvents
    {
        public void OnHealthChange(object sender, float amount);
        public void OnDeath(object sender, EventArgs e);
    }
}
