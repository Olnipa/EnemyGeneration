using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkeletonAnimatorController
{
    public static class Parametr
    {
        public const string Speed = nameof(Speed);
        public const string IsAlive = nameof(IsAlive);
    }

    public static class State
    {
        public const string Idle = nameof(Idle);
        public const string IdleDeath = nameof(IdleDeath);
        public const string Move = nameof(Move);
        public const string Death = nameof(Death);
        public const string Attack = nameof(Attack);
    }
}
