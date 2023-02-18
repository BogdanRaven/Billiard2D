using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;

namespace GameMechanics
{
   public class LevelTuner : MonoBehaviour
   {
      [SerializeField] private DataBallRelayTuner mainBall;
      [SerializeField] private List<DataBallRelayTuner> _balls;

      [SerializeField] private LevelData _levelData;

      public void TryTuneLevelData()
      {
         List<CueBallData> cueBallsData = new List<CueBallData>();
         try
         {
            _levelData.startMainBallPosition = mainBall.StartPosition;

            foreach (var ball in _balls)
            {
              CueBallData cueBallData = new CueBallData(ball.BallType,ball.StartPosition);
              cueBallsData.Add(cueBallData);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }

         _levelData.CueBallsData = cueBallsData;
      }

      public LevelData LevelData => _levelData;
   }
}
