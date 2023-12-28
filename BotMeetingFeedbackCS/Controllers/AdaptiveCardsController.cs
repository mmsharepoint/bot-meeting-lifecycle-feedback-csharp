using AdaptiveCards;
using AdaptiveCards.Templating;
using BotMeetingFfeedbackCS.Model;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace BotMeetingFfeedbackCS.Controllers
{
    public class AdaptiveCardsController
    {
        private string _hosturl;
        public AdaptiveCardsController(string hosturl)
        {
            _hosturl = hosturl;
        }
        //public IMessageActivity _GetInitialFeedback(string meetingId)
        //{
        //    string templJson = @"
        //    {
        //        ""type"": ""AdaptiveCard"",
        //        ""version"": ""1.4"",
        //        ""body"": [
        //            {
        //                ""type"": ""ColumnSet"",
        //                ""columns"": [
        //                    {
        //                        ""type"": ""Column"",
        //                        ""width"": ""stretch"",
        //                        ""items"": [
        //                            {
        //                                ""type"": ""TextBlock"",
        //                                ""text"": ""Meeting ended, ${name}!!"",
        //                                ""wrap"": true
        //                            }
        //                        ]
        //                    },
        //                    {
        //                        ""type"": ""Column"",
        //                        ""width"": ""stretch"",
        //                        ""items"": [
        //                            {
        //                                ""type"": ""Image"",
        //                                ""Url"": ""${host}/images/1.png""                                    }
        //                        ]
        //                    }
        //                ]
        //            }

        //        ]
        //    }";

        //    var myData = new
        //    {
        //        host = _hosturl,
        //        Name = "Markus"
        //    };

        //    AdaptiveCardTemplate template = new AdaptiveCardTemplate(templJson);
        //    string cardJson = template.Expand(myData);

        //    Attachment attachment = new Attachment();
        //    attachment.ContentType = AdaptiveCard.ContentType;
        //    attachment.Content = JsonConvert.DeserializeObject(cardJson);

        //    var messageActivity = MessageFactory.Attachment(attachment);

        //    return messageActivity;
        //}
        public IMessageActivity GetInitialFeedback(string meetingId)
        {
            string cardJson = GetInitialFeedbackJson(meetingId);
            Attachment attachment = new Attachment();
            attachment.ContentType = AdaptiveCard.ContentType;
            attachment.Content = JsonConvert.DeserializeObject(cardJson);

            var messageActivity = MessageFactory.Attachment(attachment);

            return messageActivity;
        }
        public IMessageActivity GetDeactivatedFeedback(Feedback feedback)
        {
            string cardJson = GetDeactivatedCardJson(feedback);
            Attachment attachment = new Attachment();
            attachment.ContentType = AdaptiveCard.ContentType;
            attachment.Content = JsonConvert.DeserializeObject(cardJson);

            var messageActivity = MessageFactory.Attachment(attachment);

            return messageActivity;
        }
        //public string __GetInitialFeedback(string meetingId)
        //{
        //    string json = GetInitialFeedbackJson(meetingId);
        //    return "Meeting ended !!";
        //}
        private string GetInitialFeedbackJson(string meetingID)
        {
            return GetCard(@"..\BotMeetingFeedbackCS\AdaptiveCards\VoteRequestDebug.json", meetingID, new string[] { "00000000-0000-0000-0000-000000000000" }, 0, 0, 0, 0, 0);
        }

        private string GetDeactivatedCardJson(Feedback feedback)
        {
            return GetCard(@"..\BotMeetingFeedbackCS\AdaptiveCards\VoteResult.json", feedback.meetingID, feedback.votedPersons, feedback.votes1, feedback.votes2, feedback.votes3, feedback.votes4, feedback.votes5);
        }

        //private string GetDeactivatedCard(Feedback feedback)
        //{
        //    return GetCard(@"..\BotMeetingFeedbackCS\AdaptiveCards\VoteResult.json", feedback.meetingID, feedback.votedPersons, feedback.votes1, feedback.votes2, feedback.votes3, feedback.votes4, feedback.votes5);
        //}

        private string GetCard(string filePath, string meetingID, string[] votedPersons, int votes1, int votes2, int votes3, int votes4, int votes5)
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
