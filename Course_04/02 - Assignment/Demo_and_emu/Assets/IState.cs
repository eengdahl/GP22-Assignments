using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IState : MonoBehaviour
{
    private ICharacterState _state = new GroundedCharacterState();

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _state = _state.Jump();
        _state = _state.Update(transform);
    }
    public interface ICharacterState
    {


        // Something that can happen to a character - i.e. it can jump
        // <returns>The new state resulted from the jump event</returns>
        ICharacterState Jump();

        // Update the state's internal properties
        // <param name="transform">The owner object's transformation</param>
        // <returns>The new state resulted from the update</returns>
        ICharacterState Update(Transform transform);
    }

    // State that represents that the character is on the ground
    public class GroundedCharacterState : ICharacterState
    {
        public ICharacterState Jump()
        {
            // Jumping while in the ground state will alter the owner object's current state into jumping
            return new JumpCharacterState(new Vector3(0, 2, 0));
        }

        public ICharacterState Update(Transform transform)
        {
            // Stand still and look pretty! (Time can never change a grounded state into any other state)
            return this;
        }
    }

    // State that represents that the character is jumping
    public class JumpCharacterState : ICharacterState
    {
        private Vector3 velocity;

        public JumpCharacterState(Vector3 initialVelocity)
        {
            velocity = initialVelocity;
        }

        public ICharacterState Jump()
        {
            // Jumping while already jumping will result in a new state that represents that we are
            // double jumping
            return new DoubleJumpCharacterState(new Vector3(0, 2, 0));
        }

        public ICharacterState Update(Transform transform)
        {
            transform.position += velocity * Time.deltaTime;
            velocity -= GameProperties.Gravity * Time.deltaTime;

            // If we are hitting the ground then change the state back to the ground state
            if (transform.position.y <= 0)
                return new GroundedCharacterState();

            // Otherwise assume that we are still jumping
            return this;
        }
    }

    // State that represents a double-jump
    public class DoubleJumpCharacterState : ICharacterState
    {
        private Vector3 velocity;

        public DoubleJumpCharacterState(Vector3 initialVelocity)
        {
            velocity = initialVelocity;
        }

        public ICharacterState Jump()
        {
            // Jumping while double jumping does not result in a new jump or any other state
            return this;
        }

        public ICharacterState Update(Transform transform)
        {
            transform.position += velocity * Time.deltaTime;
            velocity -= GameProperties.Gravity * Time.deltaTime;

            // If we are hitting the ground then change the state back to the ground state
            if (transform.position.y <= 0)
                return new GroundedCharacterState();

            // Otherwise assume that we are still jumping
            return this;
        }
    }
}
