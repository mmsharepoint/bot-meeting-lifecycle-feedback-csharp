using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Teams;
using Newtonsoft.Json;
using BotMeetingFfeedbackCS.Controllers;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

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
            _hosturl = server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault("");
        }
        protected override async Task OnTeamsMeetingStartAsync(Microsoft.Bot.Schema.Teams.MeetingStartEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            string url = turnContext.Activity.ServiceUrl;
            await turnContext.SendActivityAsync("Meeting started");
        }

        protected override async Task OnTeamsMeetingEndAsync(Microsoft.Bot.Schema.Teams.MeetingEndEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            AdaptiveCardsConroller adc = new AdaptiveCardsConroller(_hosturl);
            IMessageActivity initialCard = adc.GetInitialFeedback(meeting.Id);

            // await turnContext.SendActivityAsync(messageActivity);
            await turnContext.SendActivityAsync(initialCard);
        }
        //public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default) =>
        //    Task.CompletedTask;
    }
}
