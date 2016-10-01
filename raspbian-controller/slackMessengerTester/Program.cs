using System;
using SlackIntegration;
using Newtonsoft.Json;

namespace slackMessengerTester
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new SlackMessenger().PostMessageWithPic ("Ich klau euer C#!");
		}
	}
}
