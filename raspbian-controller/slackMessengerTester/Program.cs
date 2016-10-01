using System;
using SlackIntegration;
using Newtonsoft.Json;

namespace slackMessengerTester
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SlackMessenger.PostMessage ("Should be the last test now, gonna stop soon.", "@alexander-hoischen");
		}
	}
}
