using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;

namespace SlackIntegration
{
	public static class SlackMessenger
	{
		public static void PostMessage(string messageText) {
			sendMessage(messageText);
		}

		public static void PostMessage(string messageText, string channel) {
			sendMessage(messageText, channel: channel);
		}

		private static void sendMessage(string text,
		 	string username = null,
			string icon_url = null,
			string icon_emoji = null,
			string channel = null) {
			SlackMessageJSON payload = new SlackMessageJSON()
			{
				Channel = channel,
				Username = username,
				Text = text
			};
			sendJSON(payload);
		}

		private static void sendJSON(SlackMessageJSON json) {
			string payloadJson = JsonConvert.SerializeObject(json);
			const string targetURL = "https://hooks.slack.com/services/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";
			Encoding encoding = new UTF8Encoding();

			using (WebClient client = new WebClient())
			{
				NameValueCollection data = new NameValueCollection();
				data["payload"] = payloadJson;

				var response = client.UploadValues(targetURL, "POST", data);

				//The response text is usually "ok"
				string responseText = encoding.GetString(response);
			}
		}
	}
}
