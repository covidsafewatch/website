Title: Privacy preserving formula to determine COVIDSafe usage
Status: Submitted, pending confirmation of receipt.
IssueMaintainer: ghuntley
---


# Overview

There has been a large focus on "amount of downloads" and "amount of registrations" of COVIDSafe. This is concerning because these are not are not industry standard metrics.

The industry standard metric is daily active users:

> Daily active users (DAU) is the total number of users that engage in some way with a web or mobile product on a given day. In most cases, to be considered “active,” users simply have to view or open the product. Web and mobile app businesses typically consider DAU as their primary measure of growth or engagement.

From: https://amplitude.com/blog/2016/01/14/measuring-active-users


Members of government have stated in media interviews and as responses to questions asked by the Senate that they don't have data and it cannot be calculated.

This is concerning because it is possible to calculate effectiveness of COVIDSafe in a privacy preserving way. The specifics on how this is possible is found in the application privacy policy:


> <b>An encrypted user ID will be created every 2 hours.</b> This will be logged in the National COVIDSafe data store (data store), operated by the Digital Transformation Agency, in case you need to be identified for contact tracing.

From: https://www.health.gov.au/using-our-websites/privacy/privacy-policy-for-covidsafe-app

Every two hours COVIDSafe makes a request to the server and rotates the encrypted "tempID" identifier.

The formula is as follows:

- Daily amount of encrypted "tempID" identifiers rotated in a singular day (measured by count of requests to the servers)
- Divide that amount by 12 (as in 12 hours)

Then you will know exactly how many people are using the application every day.