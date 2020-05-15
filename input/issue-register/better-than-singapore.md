Title: Better than Singapore?
ReportedAt: 2020/04/23
---

# Claim

> Australia’s forthcoming contact tracing app will be fundamentally different to Singapore’s TraceTogether, with improvements having already been made to the latter's functionality.
>
> Acting health department secretary Caroline Edwards told a senate inquiry into COVID-19 on Thursday that although the app is derived from TraceTogether, its code base will be unique.
>
> “I don’t think the Singapore TraceTogether app is the model,” she said in response to questions from Labor senator Murray Watt, adding that it has been an “important contributor”
> 
> But Australia’s app, which is being developed by the Digital Transformation Agency, is expected to build on TraceTogether elements, particularly around Bluetooth on iPhones.
>
> Edwards said that the DTA app would not need to constantly run in the foreground for contacts to be recorded, although he admitted Bluetooth would work better with the app open.

From: https://www.itnews.com.au/news/australias-covid-tracing-app-better-than-singapores-health-chief-547126

# Technical Analysis

> Jim Mussared is one Australian developer who's been working on uncovering the app's flaws to ensure it's doing what it's meant to. For him, it's made one thing particularly clear — the DTA hasn't been easy to work with when it comes to disclosing bugs.
>
> "Seeing the source code allows us to do a direct comparison to the Singapore [TraceTogether] code," Mussared said to Gizmodo Australia over email.
>
> "One very clear result of this is that there were zero functional changes to the iOS BLE backgrounding behaviour (CentralController.swift). We know that the Singapore team knew that background-to-background iPhone didn't work, so any claims by the DTA that they 'fixed it' indicate that either they never actually tested [or] investigated it, or their testing methodology was flawed."

From: https://www.gizmodo.com.au/2020/05/covidsafe-bug-reporting-problems/

<?# Twitter 1259091209848410112 /?>
