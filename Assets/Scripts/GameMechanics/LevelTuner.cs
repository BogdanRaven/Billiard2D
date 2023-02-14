using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;

namespace GameMechanics
{
   public class LevelTuner : MonoBehaviour
   {
      [SerializeField] private CueBall mainBall;
      [SerializeField] private List<CueBall> _balls;

      [SerializeField] private LevelData _levelData;

      public void TryTuneLevelData()
      {
         List<CueBallData> cueBallsData = new List<CueBallData>();
         try
         {
            _levelData.startMainBallPosition = mainBall.transform.position;

            foreach (var ball in _balls)
            {
               ball.Initialize(new CueBallData(ball.GetData().BallType, (Vector2) ball.transform.position));
               cueBallsData.Add(ball.GetData());
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }

         _levelData.CueBallsData = cueBallsData;

      }
   }
}
