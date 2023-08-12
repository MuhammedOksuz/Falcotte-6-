using UnityEngine;
using AngryKoala.Inputs;

namespace AngryKoala.PlayerControls
{
    public class PlayerRootController : PlayerController
    {
        [SerializeField] private float moveSpeed;

        private void LateUpdate()
        {
            playerAnimator.speed = moveSpeed;

            transform.position = playerAnimator.transform.position;

            playerAnimator.transform.localPosition = Vector3.zero;
            playerAnimator.transform.localRotation = Quaternion.identity;
        }

        #region Movement

        protected override void HandleMovement()
        {
            if(InputManager.Instance.InputAreas[0].IsTouching)
            {
                moveDirection = SetMovementDirection(InputManager.Instance.InputAreas[0].Direction);

                if(moveDirection.sqrMagnitude > 0f)
                {
                    moveEmission.enabled = true;

                    isMoving = true;
                }
                else
                {
                    StopMovement();
                }
            }
            else
            {
                StopMovement();
            }

            playerAnimator.SetBool("IsMoving", isMoving);
        }

        protected override void StopMovement()
        {
            moveEmission.enabled = false;

            isMoving = false;
        }

        #endregion
    }
}
