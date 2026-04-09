using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "Attacks [target]", category: "Action", id: "d24b5afc676e2f7b5cc0bf56440dd9a6")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> target;

    protected override Status OnStart()
    {
        Player player = target.Value.GetComponent<Player>();
        if (player != null)
        {
            player.GetDamage();
        }
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

