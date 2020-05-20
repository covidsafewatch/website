Title: Breaches of Privacy Policy
Status: Work in Progress
---

The COVIDSafe app’s basic operation is to transmit and receive encrypted user IDs (UniqueID) with other users of the app. We understand that UniqueIDs received by the app are stored locally on the phone and the list of received UniqueIDs is only transmitted when explicitly uploaded by the user..

The app’s Privacy Policy describes how the app will collect, store, use and store the user’s information. We have found that key parts of the policy do not reflect the real-world behaviour of the COVIDSafe app.


# Tracking of the encrypted user ID (UniqueID)
The Privacy Impact Assessment has stated the following:
8.18	The App will only accept the new Unique IDs if it is open and running. If the App successfully accepts the new Unique ID, an automatic message will be generated and sent back to the National COVIDSafe Data Store. This message will only effectively indicate a “yes (new Unique ID successfully delivered)” response to the National COVIDSafe Data Store. If the App is not open and running, it will not be able to accept a new Unique ID. It will continue to store the previous Unique ID and use this when the App is opened, until a new Unique ID is generated and accepted.

The Privacy Policy states that “An encrypted user ID will be created every 2 hours”, and this represents a major flaw, in which it is possible for someone to be traced for more than 2 hours. This can lead to the same UniqueID being used for multiple days.

# Misrepresentation of stored data
The Privacy Policy has stated that the app only records the following contact data:
The encrypted user ID
Date and time of contact; and
Bluetooth signal strength of other COVIDSafe users with which you come into contact

It has also stated that “No user will be able to see the contact data stored on their device as it will be encrypted.” This is not true:
The database also stores the model of the phone that sent the data
The database contents are stored in plaintext aside from the encrypted user ID. 

Example of database log
Epoch date
Human-readable date (GMT)
v
message
org
modelP
modelC
RSSI
txpower
1587917327
2020-04-26 16:08:47
1
<<msg>>
AU_DTA
Nexus 5X
iPhone 7
-48
1

The app is not collecting enough data or the right data to be able to detect “close contact” (distance of 1.5m for more than 15 minutes), even with server-side processing. Instead it collects and stores data from any phone within Bluetooth range, regardless of proximity. This is not what the general public would reasonably believe to be happening and breaches the implicit permission they are giving that their data only be collected by phones that are possible “close contacts” and not any phone within Bluetooth range, which could be in another room or on a different floor or even in a different building.

# Collection of Android device ID
On Android, the app collects the user's device ID as part of the onboarding process. On versions of Android 8.0 and higher, this device ID is unique per app. However, on devices prior to Android 8.0, this device ID is only unique to the device (not per app) and can be easily obtained with access to the device. The collection of the device ID should be included in the privacy policy along with the other personal information the app collects.

