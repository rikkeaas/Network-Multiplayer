
using UnityEngine;

public class PlayerMovement : Bolt.EntityBehaviour<ICustomCubeState>
{
    public Animator playerAnimator;
    public PlayerHealth healthScript;

    // Same as start
    public override void Attached()
    {
        state.SetTransforms(state.CubeTransform, gameObject.transform);

        state.SetAnimator(playerAnimator);
    }

    // Same as update, only on owners computer
    public override void SimulateOwner()
    {
        if (!healthScript.IsAlive()) return;

        
        var speed = 4f;
        var movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            // movement.x -= 1f;
            movement = -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // movement.x += 1f;
            movement = transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            // movement.z += 1f;
            movement = transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // movement.z -= 1f;
            movement = -transform.forward;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.eulerAngles += new Vector3(0, 1, 0);
        }

        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
            state.IsMoving = true;
        }
        else 
        {
            state.IsMoving = false;
        }
    }

    private void Update() 
    {
        if (state.IsMoving)
            state.Animator.Play("MoveAnimation");
        else
            state.Animator.Play("IdleAnimation");
    }
}
