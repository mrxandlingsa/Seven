﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPlayerController;
namespace CMF
{
	//This script controls the character's animation by passing velocity values and other information ('isGrounded') to an animator component;
	public class AnimationControl : MonoBehaviour {

		Controller controller;
		Animator animator;
		Transform animatorTransform;
		Transform tr;
		private CustomMouseInput customMouseInput;

		private CharacterKeyboardInput characterKeyboardInput;
		//Whether the character is using the strafing blend tree;
		public bool useStrafeAnimations = false;

		private float smoothingFactor = 0.8f;
		Vector3 oldMovementVelocity = Vector3.zero;

		//Setup;
		void Awake () {
			controller = GetComponent<Controller>();
			animator = GetComponentInChildren<Animator>();
			animatorTransform = animator.transform;
			tr = transform;
			customMouseInput = GetComponent<CustomMouseInput>();
			characterKeyboardInput =  GetComponent<CharacterKeyboardInput>();
		}

		//OnEnable;
		void OnEnable()
		{
			//Connect events to controller events;
			controller.OnLand += OnLand;
			controller.OnJump += OnJump;
		}

		//OnDisable;
		void OnDisable()
		{
			//Disconnect events to prevent calls to disabled gameobjects;
			controller.OnLand -= OnLand;
			controller.OnJump -= OnJump;
		}
		
		//Update;
		void Update () {

			//Get controller velocity;
			Vector3 _velocity = controller.GetVelocity();

			//Split up velocity;
			Vector3 _horizontalVelocity = VectorMath.RemoveDotVector(_velocity, tr.up);
			Vector3 _verticalVelocity = _velocity - _horizontalVelocity;

			//Smooth horizontal velocity for fluid animation;
			_horizontalVelocity = Vector3.Lerp(oldMovementVelocity, _horizontalVelocity, smoothingFactor);
			oldMovementVelocity = _horizontalVelocity;

			animator.SetFloat("VerticalSpeed", _verticalVelocity.magnitude * VectorMath.GetDotProduct(_verticalVelocity.normalized, tr.up));
			animator.SetFloat("HorizontalSpeed", _horizontalVelocity.magnitude);

			//If animator is strafing, split up horizontal velocity;
			if(useStrafeAnimations)
			{
				Vector3 _localVelocity = animatorTransform.InverseTransformVector(_horizontalVelocity);
				animator.SetFloat("ForwardSpeed", _localVelocity.z);
				animator.SetFloat("StrafeSpeed", _localVelocity.x);
			}

			//Pass values to animator;
			animator.SetBool("IsGrounded", controller.IsGrounded());
			animator.SetBool("IsStrafing", useStrafeAnimations);
			
			//attack animator settings
			animator.SetBool("Attack01",customMouseInput.IsLeftMouseClicked() && controller.IsGrounded());
			//animator.SetBool("Attack06",customMouseInput.IsLeftShiftPressed());
			
			animator.SetBool("UnequipWeaon",characterKeyboardInput.IsEquipedKeyPressed());
		}


		void OnLand(Vector3 _v)
		{
			animator.SetTrigger("OnLand");
		}

		void OnJump(Vector3 _v)
		{
			
		}
	}
}
