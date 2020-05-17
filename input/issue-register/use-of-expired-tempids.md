Title: Unique IDs are broadcast long after they expire
ReportedAt: 2020-05-17
ResolvedAt: 
Status: Disclosed
---

# Overview

There are two issues in the mobile COVIDSafe apps that allow for Unique IDs / TempIDs to be broadcast after they expire.

The first issue relates to how the iOS app obtains new TempIDs.

The second issue identifies the parts of the codebase where the apps continue to use TempIDs that it already knows have expired.

The use of TempIDs beyond their 2-hour lifespan may make it easier for third-parties to track COVIDSafe app users.

# Obtaining new TempIDs on iOS

When requesting a TempID from the National COVIDSafe Data Store, the response contains three fields:

1. The TempID itself.
1. A refresh time, which is 1 hour from the current time, after which the application should attempt to obtain a new TempID.
1. An expiry time, which is 2 hours from the current time, after which the application must cease to use this TempID.

This interpretation of these fields is supported by the Android codebase, which includes the comment `// Only attempt to write BM back to peripheral if it is still valid` in [StreetPassWorker.kt#L586](https://github.com/AU-COVIDSafe/mobile-android/blob/b827cf3ccef72a3d38c6fc37466a99868823540f/app/src/main/java/au/gov/health/covidsafe/streetpass/StreetPassWorker.kt#L586), as well as the various logging messages in both the iOS and Android codebase.

In the Android app, the app appears to set up a timer to obtain a new TempID after the refresh time is reached. However, the iOS app does not do this, and only attempts to obtain a new TempID once the _expiry_ time is reached.

This means that if there are any intermittent communications issues, such as a loss of network connectivity or server outage, the Android app has a whole hour as a grace window to attempt to re-establish communications and obtain a new TempID. However, the iOS app has no such grace window, and immediately has only two choices - broadcast an expired TempID, or broadcast nothing.

# Using Expired TempIDs

In both these codebases, the app will continue to broadcast an expired TempID after it has expired, if a new one cannot be obtained.

In the Android codebase, this is due to the function `bmValid`, which is supposed to check the validity of a Broadcast Message (BM), i.e. a TempID, always returning true in [Utils.kt#L245](https://github.com/AU-COVIDSafe/mobile-android/blob/696e4ed498623a763b3fefc6982d2567691ea48d/app/src/main/java/au/gov/health/covidsafe/Utils.kt#L245), _even if it has determined just two lines above that the TempID has indeed already expired._ Therefore, if the app determines that the TempID has expired, it will nevertheless continue to re-use the old TempID indefinitely.

In the iOS codebase, this is due to the function `fetchTempIdFromApi` returning the previously-acquired TempID if any error is encountered talking to the National COVIDSafe Data Store. This behaviour is defined in [EncounterMessageManager.swift#L97-107](https://github.com/AU-COVIDSafe/mobile-ios/blob/3640e52eb2c29b55a8daab304c214750c389d1b2/CovidSafe/EncounterMessageManager.swift#L97-L107). This function is called by `getAdvertisementPayload` when the TempID has expired, and can therefore return a "new" token whose expiry is never re-evaluated. Therefore, if the app determines that the TempID has expired, and fails to obtain a new TempID, it will nevertheless continue to re-use the old TempID indefinitely.

# Relevance to Privacy Policy

Combining these two issues means that:

- The Android app has only an hour tolerance for intermittent networking or client-server communication, and if the issue persists beyond the expiry then it will continue to broadcast an expired TempID indefinitely. If the issue is resolved between the refresh and expiry times then the app still performs as expected.
- The iOS app has _zero_ tolerance for intermittent networking or client-server communication, if the issue persists beyond the expiry then it will continue to broadcast an expired TempID indefinitely.

This appears to be in breach of the [Privacy Policy for COVIDSafe App](https://www.health.gov.au/using-our-websites/privacy/privacy-policy-for-covidsafe-app#when-you-use-covidsafe), which clearly states that:

> An encrypted user ID will be created every 2 hours. This will be logged in the National COVIDSafe data store (**data store**), operated by the Digital Transformation Agency, in case you need to be identified for contact tracing.

Quite clearly, from the above behaviours, an encrypted user ID may not necessarily be created every 2 hours, such as users on iPods or iPads away from their home Wi-Fi, users with Airplane Mode in cinemas, users in shopping centers or other building that have weak cellular signals due to thick walls or underground levels, server outages, connections pending captive portals, etc.

This also appears to run somewhat contrary to the [Privacy Impact Assessment](https://www.health.gov.au/resources/publications/covidsafe-application-privacy-impact-assessment), which states:

> 8.17 We understand that the National COVIDSafe Data Store will automatically generate new Unique IDs for each User every two hours and send these new Unique IDs to the User’s App.

> 8.18 The App will only accept the new Unique IDs if it is open and running. If the App successfully accepts the new Unique ID, an automatic message will be generated and sent back to the National COVIDSafe Data Store. This message will only effectively indicate a “yes (new Unique ID successfully delivered)” response to the National COVIDSafe Data Store. If the App is not open and running, it will not be able to accept a new Unique ID. It will continue to store the previous Unique ID and use this when the App is opened, until a new Unique ID is generated and accepted.

# Impact

As has been interpreted from the code and has also been observed from performing functional testing on a running app:

1. There are a range of actual and potential scenarios in which the app is open and running, but is still not able to accept a new Unique ID.
1. The iOS app does not even make a best-effort attempt to obtain new Unique IDs before the old one has expired.
1. Both the iOS and Android apps can (and do) broadcast expired TempIDs.
1. In these scenarios, users broadcasting TempIDs longer than their expiry become quite easy to track with third-party tools, which may amount to a breach of privacy.

# Recommendations

1. Prevent the broadcast of expired TempIDs,
1. Display a warning to the user to connect to the internet if the TempID has expired and the app is unable to obtain a fresh one,
1. Restore the original Singapore (OpenTrace) behaviour of downloading a large batch of TempIDs and cycling through them, instead of downloading them one at a time, and
1. On iOS, make use of the window between the TempID refresh time and its expiry time to obtain a new TempID.

# Timeline
- 17th May 2020: Reported to support@covidsafe.gov.au
