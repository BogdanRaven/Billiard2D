using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class MotionTransmitter : MonoBehaviour
    {
        [SerializeField] private float maxAddForce;

        [SerializeField] private GameContext _gameContext;
        [SerializeField] private Slider _slider;
        [SerializeField] private GameObject cue;

        public void Push()
        {
            var force = maxAddForce * _slider.value;

            Push(_gameContext.MainBall.GetRigidBody2D(), _gameContext.MainBall.transform.up, force, (() =>
            {
                _gameContext.StateMachine.EnterState<StrikeState>();
                _gameContext.EnterStrikeWaitStateAfterDelay(7f);
                cue.gameObject.SetActive(false);
            }));
        }

        public void Push(Rigidbody2D targetObject, Vector2 direction, float force, Action onPush = null)
        {
            onPush?.Invoke();
            targetObject.AddForce(force * direction);
        }
    }
}