using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Tasks;
using SabberStoneCoreAi.POGame;
using SabberStoneCore.Tasks.PlayerTasks;


namespace SabberStoneCoreAi.Agent
{
	class MCTSAgent : AbstractAgent
	{
		private double remainingSeconds = 12;
		private int actionCount = 0;

		public override void InitializeAgent()
		{
			
		}

		public override void InitializeGame()
		{
			remainingSeconds = 12;
			actionCount = 0;

		}

		public override PlayerTask GetMove(POGame.POGame poGame)
		{
			DateTime start = DateTime.Now;

			List<PlayerTask> options = poGame.CurrentPlayer.Options();
			PlayerTask t = options[0];
			if (options.Count == 1)
			{
				t = options[0];
			}
			else if (options.Count == 2)
			{
				t = options[1];
			}
			else
			{
				t = MCTS.MCTS.GetBestAction(poGame, remainingSeconds / (Math.Max(options.Count - actionCount, 1)));
			}

			double seconds = (DateTime.Now - start).TotalSeconds;

			if (t.PlayerTaskType == PlayerTaskType.END_TURN)
			{
				remainingSeconds = 12;
				actionCount = 0;
			}
			else
			{
				remainingSeconds -= seconds;
				actionCount++;
			}
			return t;

		}

		public override void FinalizeGame()
		{
			
		}

		public override void FinalizeAgent()
		{
			
		}
	}
}
