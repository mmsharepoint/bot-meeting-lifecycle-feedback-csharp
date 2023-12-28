# bot meeting lifecycle feedback - Microsoft Teams App
Teams meeting bot app handling lifecycle events by requesting feedback from the user

## Summary
This sample is a Teams Bot meeting app  created using the Teams Toolkit with Visual Studio 2022. It acts on the real end date (not the scheduled ones) and posts an adaptive card requesting user feedback to the meeting's chat once each event is fired.
Once voted each (already voted) user sees the overall feedback result from all participating users.
App result:

|Meeting ended - Feedback request posted|
:-------------------------:
![Meeting ended - Feedback request](https://mmsharepoint.files.wordpress.com/2021/10/06meetingended_feedbackrequest.gif?w=358&zoom=2)

|Feedback given - Refreshed card shows result|
:-------------------------:
![Feedback given - Refresh card](https://mmsharepoint.files.wordpress.com/2021/10/07givefeedback-1.gif)

For further details see the author's [blog post](https://mmsharepoint.wordpress.com/2023/)

## Applies to

This sample was created [using the Teams Toolkit with Visual Studio 2022](https://learn.microsoft.com/en-us/microsoftteams/platform/toolkit/teams-toolkit-fundamentals?pivots=visual-studio&WT.mc_id=M365-MVP-5004617). Nearly the same sample was also realized with the [Yeoman Generator for Teams](https://github.com/pnp/generator-teams) and can be found [here](https://github.com/mmsharepoint/bot-meeting-lifecycle-feedback).

## Frameworks

![drop](https://img.shields.io/badge/Bot&nbsp;Framework-14.18-green.svg)

![drop](https://img.shields.io/badge/Teams&nbsp;Toolkit&nbsp;for&nbsp;VS&nbsp;17.7-green.svg)

![drop](https://img.shields.io/badge/Visual&nbsp;Studio&nbsp;2022-17.8-green.svg)


## Prerequisites

* [Office 365 tenant](https://dev.office.com/sharepoint/docs/spfx/set-up-your-development-environment)

## Version history

Version|Date|Author|Comments
-------|----|--------|--------
1.0|January 12, 2024|[Markus Moeller](http://www.twitter.com/moeller2_0)|Initial release

## Disclaimer

**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**

---
## Minimal Path to Awesome
- Clone the repository
    ```bash
    git clone https://github.com/mmsharepoint/bot-meeting-lifecycle-feedback-csharp.git
- Open bot-meeting-lifecycle-feedback-csharp.sln in Visual Studio
- Perform first actions in GettingStarted.txt (before hitting F5)
- ...



## Features
* Teams Toolkit for Visual Studio 2022 Bot Development 
* [Bot Meeting Lifecycle methods](https://learn.microsoft.com/en-us/microsoftteams/platform/apps-in-teams-meetings/meeting-apps-apis?tabs=channel-meeting%2Cguest-user%2Cone-on-one-call%2Cdotnet%2Cparticipant-join-event%2Cparticipant-join-event1#receive-real-time-teams-meeting-events&WT.mc_id=M365-MVP-5004617)
* [Post an adaptive card](https://adaptivecards.io/)
* Using the [Adaptive Cards Universal Action Model](https://learn.microsoft.com/en-us/adaptive-cards/authoring-cards/universal-action-model?WT.mc_id=M365-MVP-5004617)
