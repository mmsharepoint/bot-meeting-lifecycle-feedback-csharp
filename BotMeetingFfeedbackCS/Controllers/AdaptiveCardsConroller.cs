using AdaptiveCards;
using AdaptiveCards.Templating;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace BotMeetingFfeedbackCS.Controllers
{
    public class AdaptiveCardsConroller
    {
        public string GetInitialFeedback(string meetingId)
        {
            string json = GetInitialFeedbackJson(meetingId);
            return "Meeting ended !!";
        }
        private string GetInitialFeedbackJson(string meetingID)
        {

            return GetCard(@"..\BotMeetingFfeedbackCS\AdaptiveCards\VoteRequest.json", meetingID, new string[] { "00000000-0000-0000-0000-000000000000" }, "0", "0", "0", "0", "0");
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
                votes5
            };

            string cardJson = template.Expand(adaptiveCardData);
            return cardJson;
        }
    }
}
