using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Tasks.PlayerTasks;
using SabberStoneCoreAi.Agent;
using SabberStoneCoreAi.POGame;

namespace SabberStoneCoreAi.src.Agent
{
	class Agent1 : AbstractAgent
	{
		private Random Rnd = new Random();

		public Agent1()
		{
		}

		public override void FinalizeAgent()
		{
		}

		public override void FinalizeGame()
		{
		}

		public override PlayerTask GetMove(POGame.POGame poGame)
		{
			
			PlayerTask option;

			List<PlayerTask> options = poGame.CurrentPlayer.Options();
			option = options[Rnd.Next(options.Count)];
			

			return option;
		}

		public override void InitializeAgent()
		{
			Rnd = new Random();
		}

		public override void InitializeGame()
		{
		}
	}
}
