using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckPlayer", story: "[self] is checking for the player [Operator] [checkDistance] meters at an angle of [checkAngle] degrees", category: "Conditions", id: "79259f196e4261a9455e7574fabca287")]
public partial class CheckPlayerCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> self;
    [SerializeReference] public BlackboardVariable<float> checkDistance, checkAngle;
    [SerializeReference] public BlackboardVariable<ConditionOperator> Operator;
    Enemy enemy;

    public override bool IsTrue()
    {
        if(Operator.Value == ConditionOperator.Outside)
        {
            return !enemy.CheckPlayer(checkDistance.Value, checkAngle.Value);
        }

        return enemy.CheckPlayer(checkDistance.Value, checkAngle.Value);
    }

    public override void OnStart()
    {
       enemy = self.Value.GetComponent<Enemy>();
    }

    public override void OnEnd()
    {
    }
}

public enum ConditionOperator
{
    Inside,
    Outside
}
