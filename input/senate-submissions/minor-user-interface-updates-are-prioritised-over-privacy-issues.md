Title:  Minor user interface updates are prioritised over privacy issues
Status: Not submitted. Requires proof read and readability improvements.
IssueMaintainer: ghuntley
---

# Overview

Minor user interface updates are prioritised over privacy issues, with the justification of "sprint planning". This is not how "agile software development" is supposed to work.

<?# Twitter 1264091038194348032 /?>

> When it comes to knowledge work, the type of items that teams get to work on varies in urgency, requirements, perceived business value and level of priority.
> 
> For example, a software development team has just gone live with their application. The team is now expected to work on both enhancements and maintenance work. At the start of the workday, they are scheduled to work on features for a planned release version and a few minor production issues. Midday comes and a security vulnerability has been reported, putting client data at risk. The team focuses attention to the production issue and works on it immediately. If this affects the teams work capacity, other work items might be halted to address the critical issue.
>
> This is much similar to the medical triage concept being used in the emergency department of hospitals. The triage nurse assesses each patient that arrives. Based on the severity of their condition, the triage nurse determines the order of patient treatment. A patient suffering from cardiac arrest will be considered a higher priority than a patient with a tummy ache.
> 
> Establishing a set of rules that govern how incoming work is treated enables teams to work in the best interest of the customer. Teams will also decrease the amount of time a task remains in the backlog.

From: https://kanbanzone.com/resources/kanban/classes-of-service/

<?# Twitter 1264456160406470656 /?>


# Branding instead of resolution of privacy policy breach

Initially Geoffrey Huntley was <a href="https://www.gizmodo.com.au/2020/04/covidsafe-source-code-teardown-privacy-security">supportive of the application</a> but <a href="https://www.youtube.com/watch?v=r9nF9-KYx2o">publically withdrew</a> his support after the first update (v1.0.15) of COVIDSafe was released as the privacy breaches were not resolved and the update primarily focused adjusting the application branding.

<?# YouTube r9nF9-KYx2o /?>

> Geoffrey Huntley, a security researcher who with colleagues and acquaintances has decompiled the app’s Android .APK and observed the iOS app running with a debugger, told The Register he has found a flaw in the app’s use of unique identifiers that retains one value instead of making a change every two hours. He also said the app’s Bluetooth implementation makes it possible to read device names with a Bluetooth beacon.
>
> Australia’s app uses some of Singapore’s open source contact-tracing code. Huntley said he found flaws in Singapore’s code, reported it to developers there and saw changes made on the same day. He said he’s since informed Australian authorities of the same problem and seen it left in place in an app update that he said has changed nothing of substance. His research and opinions are detailed in this Tweet and subsequent thread.

From : https://www.theregister.co.uk/2020/05/07/covidsafe_australia_contact_tracing_app_issues/

<#? Youtube LWkurIhCiVY /?>

## Issue 1 - CVE-2020-12857

> The first issue is that the COVIDSafe app caches the characteristic value that will be read by a remote device using the MAC address of the remote device. Due to a logic error, this cache is only cleared when a successful transaction takes place (i.e. the remote device subsequently writes its own payload back to the characteristic). Importantly, the cache entry is not removed when: 
> 
> - The two-hour expiry finishes for the TempID
> - After any sort of short time limit.
> 
> This means that a remote device using a static address that never completes the transaction will always see the same cached TempID. This cached value will last until the app is restarted (likely due to a phone reboot).
> 

This is a breach of the privacy policy which states:

> An encrypted user ID will be created every 2 hours. This will be logged in the National COVIDSafe data store (data store), operated by the Digital Transformation Agency, in case you need to be identified for contact tracing.

From: https://www.health.gov.au/using-our-websites/privacy/privacy-policy-for-covidsafe-app

This issue was first reported to privacy@health.gov.au at 1:19am on 27/04/2020, and subsequently by in-app feedback later that day. It was also reported to asd.assist@defence.gov.au at 4:52pm on 27/04/2020.

This issue was first reported to the Singapore OpenTrace team at 12:38am on 30/04/2020 and was fixed <a href="https://github.com/opentrace-community/opentrace-android/commit/0c7f7f6c4b265140f86b91f8e9e1ec70f5cd67ba">in this commit</a> to the opentrace-android repository at 7:11pm on the same day.

This issue was fixed in v1.0.17 released on 14/05/2020.

> Note on the fix: When this issue was fixed, instead of removing the cache, there was additional logic added to the disconnection event to remove the entry. I'm not aware of any way that this event can fail to fire, but it would have been far more robust and easy to reason about the fix if the cache had been removed altogether.


## Issue #2 - CVE-2020-12858

> The second issue is much simpler. The advertising payload is generated once at startup and used for the lifetime of the app. Due to requirements by the iPhone app, there are additional bytes included in this payload added to the manufacturer field. However, <b>specifically in the Australian app, these bytes are generated once at startup, and then the same data is used continuously for the lifetime of the app</b>. This means that the advertising payload will consistently identify the same device.
>
> The OpenTrace app appears to behave in a similar way. See <a href="https://github.com/opentrace-community/opentrace-android/blob/master/app/src/main/java/io/bluetrace/opentrace/bluetooth/BLEAdvertiser.kt#L90">this function</a> where the random data is generated and then appended to the manufacturer field, however this data is generated every time advertising is restarted (every 180 seconds). <b>There is a small but crucial difference introduced in the Australian app where the data is then cached and used for the lifetime of the app.</b> This is evident in the disassembly.

From: https://docs.google.com/document/d/1u5a5ersKBH6eG362atALrzuXo3zuZ70qrGomWVEC27U/edit

This issue was first reported via in-app feedback subsequently by in-app-feedback on 27/04/2020. It was also reported to asd.assist@defence.gov.au at 4:52pm on 27/04/2020.

This issue was fixed in v1.0.17 released on 14/05/2020.

> Note on the fix: The implemented fix was just to undo the regression, the payload is no longer cached.

# Issue #3 - CVE-2020-12859

> The phone model name included in the OpenTrace JSON payload is weakly identifiable. There are enough different models of phones, that it gives a high probability of identifying someone, especially in non-crowded environments. If a house has three residents, each with a different phone, it would allow someone outside the house to trivially identify which of those people were currently at home.
> 
> Additionally, the fact that this information is exchanged is <b>not mentioned in the privacy policy</b> at https://www.health.gov.au/using-our-websites/privacy/privacy-policy-for-covidsafe-app
> 
> The use of this field in the payload is documented and designed into the BlueTrace protocol, so this is not specific to the Australian app. The reason it is included is for calibration of signal strength to physical distance, however it is likely from my own experiments that this calculation does not actually work.
>
> Example values are "Pixel 2", or "Galaxy G8".

From: https://docs.google.com/document/d/1u5a5ersKBH6eG362atALrzuXo3zuZ70qrGomWVEC27U/edit

This issue was first reported to privacy@health.gov.au at 1:19am on 27/04/2020, and subsequently by in-app feedback later that day. It was also reported to asd.assist@defence.gov.au at 4:52pm on 27/04/2020.

It has not yet been fixed.

## Issue #4 -  CVE-2020-12860

> A BLE device can be any combination of the four roles: Advertiser, Peripheral, Scanner, Central. Typical combinations are:
> - Advertiser-only (a beacon)
> - Advertiser+Peripheral (a device like a heart rate monitor)
> - Scanner (phone app, looking for beacons)
> - Scanner+Central (phone app talking to a device)
>
> COVIDSafe runs in a fairly unique "all of the above" configuration.
> 
> When you are a peripheral, you must also be a "connectable advertiser" -- that is, you must advertise, and set the advertisement type to "connectable" -- and then you run a GATT server.
>
> A peripheral must include a set of services containing characteristics and descriptors (the COVIDSafe service is described above). There are several generic services that contain characteristics with useful metadata about the device. One example is 0x1800 "Generic Access" which contains 0x2a00 "Device Name". On iPhones, there's an additional service 0x180a "Device Information" which contains 0x2a24 "Model Number String".
>
> The device name on Android is set by the user. On most Android phones it appears to default to some variant of the phone model, either exactly, e.g. "Samsung Galaxy S7" or "My new Pixel 2". In this sense it's very similar to Issue #3 but might provide further uniqueness in combination.
>
> However, many people do something like "Jim's Pixel 2" as this is the string that shows up in for example a car hands free system -- "Connected to Jim's Pixel 2". I have even seen cases of "Firstname Lastname's Phone Model".
>
> Normally, phones are not peripherals, so unless any app asks to be a Peripheral, there will be no registered services and the device will not be connectable. So although the existence of this data is actually leaked by the OS, unless COVIDSafe was running, the phone would not be connectable and this data would not be available. For most people, their phone never would have been connectable during normal operation, and certainly not in background operation.
> 
> Note: It's worth being aware of <a href="https://hexway.io/research/apple-bleee/">Apple bleee</a> which was published in October 2019 which contains a very detailed analysis of what's available in the additional services registered by an iPhone, due to the AirDrop service, so in many cases this data was already accessible if Airdrop is enabled. However, COVIDSafe forces it for all phones, Android or iPhone.
>
> Many thanks to John Evershed of ProjectComputing, who contacted me from a Facebook post I had written for my friends explaining how the COVIDSafe app works. He noticed in some of his own experiments that the device name he had assigned his iPhone was available when connecting to a peripheral which prompted both of us to look into this in more detail.

From: https://docs.google.com/document/d/1u5a5ersKBH6eG362atALrzuXo3zuZ70qrGomWVEC27U/edit


This issue was first reported to privacy@health.gov.au, ASD/ACSC, and Cybersecurity CRC at 4:30pm on 02/05/2020.

It has not yet been fixed.

