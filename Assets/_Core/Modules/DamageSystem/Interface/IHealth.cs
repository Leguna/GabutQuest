using System;

namespace DamageSystem
{
    public interface IHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get;  }
    }
}