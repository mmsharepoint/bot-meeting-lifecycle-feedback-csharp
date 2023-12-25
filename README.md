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

This sample was created [using the Teams Toolkit with Visual Studio 2022](https://learn.microsoft.com/en-us/microsoftteams/platform/toolkit/teams-toolkit-fundamentals?pivots=visual-studio&WT.mc_id=M365-MVP-5004617). Nearly the same sample was also realized with the [Yeoman Generator for Teams](https://github.com/pnp/generator-teams) and can be found [here](https://github.com/mmsharepoint/teams-ext-action-azure-config).

## Frameworks

![drop](https://img.shields.io/badge/Bot&nbsp;Framework-x.y-green.svg)

![drop](https://img.shields.io/badge/Teams&nbsp;Toolkit&nbsp;for&nbsp;VS&nbsp;Code-17.7-green.svg)

![drop](https://img.shields.io/badge/Visual&nbsp;Studiot&nbsp;2022&nbsp;2022-17.8-green.svg)


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
    git clone https://github.com/mmsharepoint/tab-sso-graph-upload-pdf-csharp.git
- Open msgext-graph-search-config.sln in Visual Studio
- Perform first actions in GettingStarted.txt (before hitting F5)
- Copy .\msgext-graph-action-config-csharp\MsgextGraphActCfg\.fx\states\state.local.json to .\msgext-graph-action-config-csharp\MsgextGraphActCfg\.fx\states\state.dev.json
Nevertheless, even when debugging locally Bot Emulator does not support SSO with OAuthConnection so a Bot Service is needed
- So execute Teams Toolkit \ Provision in the Cloud
- This should [provison a Bot in Azure](https://learn.microsoft.com/en-us/microsoftteams/platform/toolkit/provision?pivots=visual-studio&WT.mc_id=M365-MVP-5004617#create-resources-1)
- Ensure there is an app registration for the bot
  - with redirect uri https://token.botframework.com/.auth/web/redirect
  - with SignInAudience multi-tenant
  - with client secret
  - with **delegated** permission Sites.Read.All
  - With exposed Api "access_as_user" and App ID Uri api://~YourNgrokUrl~/<App ID>
  - With the client IDs for Teams App and Teams Web App 1fec8e78-bce4-4aaf-ab1b-5451cc387264 and 5e3ce6c0-2b1f-4285-8d4b-75ee78787346
- Find/Add the app registration ClientId, ClientSecret as BOT_ID, BOT_PASSWORD to your appsettings.json (or a appsettings.Development.json)
- Also add to .\msgext-graph-action-config-csharp\MsgextGraphActCfg\.fx\states\state.dev.json
- Generate an Azure App Configuration resource and copy the Primary Key Connection String to appsettings.json (or a appsettings.Development.json) as "AZURE_CONFIG_CONNECTION_STRING": 
- Execute Teams Toolkit \ ZIP App Package \ For Azure
- Press F5
- When Teams opens in Browser and tries to add the app, skip that
- Instead manually upload .\msgext-graph-action-config-csharp\MsgextGraphActCfg\build\appPackage\appPackage.dev as app to a Team
- In channel conversation open "Messaging extensions ..."
- Right click the app icon and configure with valid siteID, listID to a document library of your choice
- Left click app icon to retrieve and select document as Adaptive Card


## Features
* [Post an adaptive card](https://adaptivecards.io/)
* Configuraton storage in [Azure App Configuration](https://learn.microsoft.com/en-us/azure/azure-app-configuration/overview?WT.mc_id=M365-MVP-5004617)
* Secret Storage and consumption in [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/general/overview?WT.mc_id=M365-MVP-5004617)
