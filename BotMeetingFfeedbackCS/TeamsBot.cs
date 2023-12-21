﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Teams;

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
        public TeamsBot(IConfiguration config)
        {
            _appId = config["MicrosoftAppId"];
            _appPassword = config["MicrosoftAppPassword"];
        }
        protected override async Task OnTeamsMeetingStartAsync(Microsoft.Bot.Schema.Teams.MeetingStartEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Meeting started");
        }

        protected override async Task OnTeamsMeetingEndAsync(Microsoft.Bot.Schema.Teams.MeetingEndEventDetails meeting, Microsoft.Bot.Builder.ITurnContext<Microsoft.Bot.Schema.IEventActivity> turnContext, System.Threading.CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Meeting ended");
        }
        //public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default) =>
        //    Task.CompletedTask;
    }
}
