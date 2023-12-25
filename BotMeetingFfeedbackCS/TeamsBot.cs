using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Teams;
using Newtonsoft.Json;
using BotMeetingFfeedbackCS.Controllers;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Bot.Schema.Teams;

namespace BotMeetingFfeedbackCS
{
    /// <summary>
    /// An empty bot handler.
    /// You can add your customization code here to extend your bot logic if needed.
    /// </summary>
    public class TeamsBot : TeamsActivityHandler
    {
        string _appId;
        private string _appPassword;
        protected string _hosturl;
        public TeamsBot(IConfiguration config, IServer server)
        {
            _appId = config["MicrosoftAppId"];
            _appPassword = config["MicrosoftAppPassword"];
            _hosturl = config["BotEndpoint"];
        }
        protected override async Task OnTeamsMeetingStartAsync(Microsoft.Bot.Schema.Teams.MeetingStartEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Meeting started");
        }

        protected override async Task OnTeamsMeetingEndAsync(Microsoft.Bot.Schema.Teams.MeetingEndEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            AdaptiveCardsConroller adc = new AdaptiveCardsConroller(_hosturl);
            IMessageActivity initialCard = adc.GetInitialFeedback(meeting.Id);

            // await turnContext.SendActivityAsync(messageActivity);
            await turnContext.SendActivityAsync(initialCard);
        }

        protected override async Task<AdaptiveCardInvokeResponse> OnAdaptiveCardInvokeAsync(ITurnContext<IInvokeActivity> turnContext, AdaptiveCardInvokeValue invokeValue, CancellationToken cancellationToken)
        {
            string verb = invokeValue.Action.Verb;
            if (verb == "alreadyVoted")
            {

            }
            else
            {
                switch (verb)
                {
                    case "vote_1":
                        // votes1 += 1;
                        break;
                    case "vote_2":
                        // votes2 += 1;
                        break;
                    case "vote_3":
                        // votes3 += 1;
                        break;
                    case "vote_4":
                        // votes4 += 1;
                        break;
                    case "vote_5":
                        // votes5 += 1;
                        break;
                }
            }
                await turnContext.SendActivityAsync("Voted 2!!");
            return new AdaptiveCardInvokeResponse
            {
                StatusCode = 200,
                Value = "Voted 2!"
            }; 
        }
        //protected override async Task<InvokeResponse> OnInvokeActivityAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        //{
            
        //}
        //public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default) =>
        //    Task.CompletedTask;
    }
}
