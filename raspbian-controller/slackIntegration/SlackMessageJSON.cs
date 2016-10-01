using System;
using Newtonsoft.Json;

namespace SlackIntegration
{
	public class SlackMessageJSON
	{
		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}

