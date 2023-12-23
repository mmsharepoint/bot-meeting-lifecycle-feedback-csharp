using AdaptiveCards;
using AdaptiveCards.Templating;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace BotMeetingFfeedbackCS.Controllers
{
    public class AdaptiveCardsConroller
    {
        private string _hosturl;
        public AdaptiveCardsConroller(string hosturl)
        {
            _hosturl = hosturl;
        }
        public IMessageActivity _GetInitialFeedback(string meetingId)
        {
            string templJson = @"
            {
                ""type"": ""AdaptiveCard"",
                ""version"": ""1.4"",
                ""body"": [
                    {
                        ""type"": ""ColumnSet"",
                        ""columns"": [
                            {
                                ""type"": ""Column"",
                                ""width"": ""stretch"",
                                ""items"": [
                                    {
                                        ""type"": ""TextBlock"",
                                        ""text"": ""Meeting ended, ${name}!!"",
                                        ""wrap"": true
                                    }
                                ]
                            },
                            {
                                ""type"": ""Column"",
                                ""width"": ""stretch"",
                                ""items"": [
                                    {
                                        ""type"": ""Image"",
                                        ""Url"": ""${host}/images/1.png""                                    }
                                ]
                            }
                        ]
                    }

                ]
            }";

            var myData = new
            {
                host = _hosturl,
                Name = "Markus"
            };

            AdaptiveCardTemplate template = new AdaptiveCardTemplate(templJson);
            string cardJson = template.Expand(myData);

            Attachment attachment = new Attachment();
            attachment.ContentType = AdaptiveCard.ContentType;
            attachment.Content = JsonConvert.DeserializeObject(cardJson);

            var messageActivity = MessageFactory.Attachment(attachment);

            return messageActivity;
        }
        public IMessageActivity GetInitialFeedback(string meetingId)
        {
            string cardJson = GetInitialFeedbackJson(meetingId);
            Attachment attachment = new Attachment();
            attachment.ContentType = AdaptiveCard.ContentType;
            attachment.Content = JsonConvert.DeserializeObject(cardJson);

            var messageActivity = MessageFactory.Attachment(attachment);

            return messageActivity;
        }
        public string __GetInitialFeedback(string meetingId)
        {
            string json = GetInitialFeedbackJson(meetingId);
            return "Meeting ended !!";
        }
        private string GetInitialFeedbackJson(string meetingID)
        {
            return GetCard(@"..\BotMeetingFfeedbackCS\AdaptiveCards\VoteRequestDebug.json", meetingID, new string[] { "00000000-0000-0000-0000-000000000000" }, "0", "0", "0", "0", "0");
        }

        private string GetCard(string filePath, string meetingID, string[] votedPersons, string votes1, string votes2, string votes3, string votes4, string votes5)
        {
            string templateJson = File.ReadAllText(filePath);

            var template = new AdaptiveCardTemplate(templateJson);

            var adaptiveCardData = new
            {
                meetingID,
                votedPersons,
                votes1,
                votes2,
                votes3,
                votes4,
                votes5,
                _hosturl
            };

            string cardJson = template.Expand(adaptiveCardData);
            return cardJson;
        }
    }
}
