using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine.TextCore.Text;

namespace KinematicCharacterController
{
    public class PlayerController : MonoBehaviour
    {
        public SCR_BaseCharController Character;
        public GameObject CharacterCamera;
        public GameObject bullet;

        //private const string MouseXInput = "Mouse X";
        //private const string MouseYInput = "Mouse Y";
        //private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Tell camera to follow transform
           // CharacterCamera.SetFollowTransform(Character.CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
          //  CharacterCamera.IgnoredColliders.Clear();
          //  CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            HandleCharacterInput();
        }

        private void LateUpdate()
        {
            //// Handle rotating the camera along with physics movers
            //if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
            //{
            //    CharacterCamera.PlanarDirection = Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * CharacterCamera.PlanarDirection;
            //    CharacterCamera.PlanarDirection = Vector3.ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
            //}

            //HandleCameraInput();
        }



        private void NormalAttack()
        {
            //Character.transform.position = Vector3.zero;

            AkSoundEngine.PostEvent("SFX_playerShoot", gameObject); // Play weapon sfx here
            GameObject instantBullet = Instantiate(bullet, Character.transform.position + new Vector3(0, 1, 0), Character.transform.rotation);
            instantBullet.GetComponent<Bullet>().SetBullet(this.gameObject, Bullet.BulletType.bullet);
            //````````````put these in the set bullet function``````````
            Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
            Vector3 targetDirection = Character.GetFacingDirection();
            bulletRigid.velocity = targetDirection * 80;
            //``````````````````````````````````````````````````````````
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = CharacterCamera.transform.rotation;
            characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
            characterInputs.JumpUp = Input.GetKeyUp(KeyCode.Space);
            characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.LeftShift);
            characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.LeftShift);
            characterInputs.AttackDown = Input.GetKeyDown(KeyCode.X);

            //-------------------
            if (characterInputs.AttackDown)
            {
                NormalAttack();
            }

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }
    }
}