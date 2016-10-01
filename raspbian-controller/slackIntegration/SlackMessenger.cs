using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using Slack.Webhooks;

namespace SlackIntegration
{
	public class SlackMessenger
	{
		private SlackClient client = null;

		public SlackMessenger() : this ("https://hooks.slack.com/services/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") {

		}

		public SlackMessenger(string webhookURL) {
			this.client = new SlackClient (webhookURL);
		}

		public void PostMessage(string messageText, 
			string channel = null,
			string iconEmoji = null,
			string username = null ) {
			if (messageText == null)
				throw new ArgumentNullException ("messageText");
			
			sendMessage(messageText, 
				channel: channel,
				icon_emoji: iconEmoji,
				username: username);
		}

		private void sendMessage(string text,
		 	string username = null,
			string icon_emoji = null,
			string channel = null) {
			var payload = new SlackMessage {
				Channel = channel,
				Text = text,
				Username = username,
				IconEmoji = icon_emoji
			};
			client.Post (payload);
		}
	}
}
