Title: Community engagement on critical security issues
Status: Not submitted. Requires proof read and readability improvements.
IssueMaintainer: ghuntley
---

# Overview

No industry best-practices were implemented at launch, including but not limited to:

* A bug bounty (which would provide a clear path for reporting issues)
* A security contact address, separate from general enquiries (allowing for prioritisation and triaging).
* Source code available at launch (making it easier for analysis)
* Engagement on reported issues to coordinate disclosure.


# Lack of a bug bounty or formal documented process

<?# Twitter 1258020825053065217 /?>


> Huntley has called upon those responsible for the app to implement formal customer service and developer community engagement tools, as he feels the app is a worthy weapon in Australia’s coronavirus response. However he has withdrawn his personal support for the app until the privacy issues he has identified are addressed.

Huntley also labelled the lack of a bug bounty program for the app “unusual” and said only personal relationships with government staff afforded him a channel through which to report his findings – after mailing government agencies' public email addresses with details of bugs and not receiving replies for a week.

Australia’s app uses some of Singapore’s open source contact-tracing code. Huntley said he found flaws in Singapore’s code, reported it to developers there and saw changes made on the same day. He said he’s since informed Australian authorities of the same problem and seen it left in place in an app update that he said has changed nothing of substance. His research and opinions are detailed in this Tweet and subsequent thread.

# Engagement on reported issues to coordinate disclosure

<?# Twitter 1257506430476640256 /?>

<?# Twitter 1256192209340133376 /?>


There has been no public acknowledgement of issues raised, nor has there been any communication around interim mitigations or workarounds.

<?# Twitter 1264738218739523585 /?>

<?# YouTube nrmZD3jNVJs /?>

This has been done better in other countries, e.g. UK’s NHSX recently described their engagement with the community in a <a href="https://www.ncsc.gov.uk/blog-post/nhs-covid-19-app-security-two-weeks-on">blog post</a>. See also the <a href="https://twitter.com/VTeagueAus/status/1262655345001820161">Twitter thread from Vanessa Teague</a>. They also have a <a href="https://hackerone.com/nhscovid19app">HackerOne bug bounty</a>, specifically for their COVID-19 tracker app, <a href="https://hackerone.com/sg-vdp">as does Singapore</a>.


In the case of the two long-term tracking issues that were fixed, neither recommended fixes were implemented. The recommendation was to remove the unnecessary features altogether to avoid any further risks, and also to add comments to prevent future regressions. Instead, workarounds were added to the existing fragile code.

It is worth noting how much better the response from the DTA was to the iPhone crash, compared to the privacy issues. As is to be expected, a crashing app is far easier for the public to understand than an invisible privacy leak. This difference was not just in terms of time-to-fix, but also in the engagement from the DTA.

<?# Twitter 1264712171734228993 /?>


<?# Twitter 1256952268206665730 /?>

<?# Twitter 1257600104183164929 /?>
<?# Twitter 1257506430476640256 /?>
<?# Twitter 1257506832140038145 /?>
<?# Twitter 1257507532173541378 /?>
<?# Twitter 1257524946361741317 /?>
<?# Twitter 1257532378320265216 /?>
<?# Twitter 1257537188540985349 /?>
<?# Twitter 1257537587306090498 /?>
<?# Twitter 1257540470613237765 /?>
<?# Twitter 1257540474048581632 /?>
<?# Twitter 1257541996874326018 /?>
<?# Twitter 1257547477542027270 /?>


# Atrribution

<a href="https://docs.google.com/document/d/17sVyBIG5CqhF9XtuEfeG2MfYsFNXuV4yxp3BERDTJoI/edit#">The COVIDSafe App - 4 week update</a> by Jim Mussared and Eleanor McMurtry was used as the baseline for this submissions.

