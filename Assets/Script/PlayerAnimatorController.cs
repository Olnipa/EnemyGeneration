using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimatorController
{
    public static class Parametr
    {
        public const string IsAlsive = nameof(IsAlsive);
    }

    public static class State
    {
        public const string Idle = nameof(Idle);
        public const string Cast = nameof(Cast);
        public const string Death = nameof(Death);
        public const string DeathIdle = nameof(DeathIdle);
    }
}
