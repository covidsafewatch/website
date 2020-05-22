Title: Incorrect handling of a potential data breach
Status: Not submitted. Requires proof read and readability improvements.
IssueMaintainer: ghuntley
---


# May 9th, 2020 - Incident

Discussion about a S3 bucket starts circulating in the <a href="/">COVIDSafe.watch</a> community about an Amazon S3 bucket publically serving files without authentication. These files were named "CovidSafeUserData". 

Geoffrey Huntley reported the matter to ASD.Assist@defense.gov.au and again via phone.

Geoffrey Huntley reported the matter to support@covidsafe.gov.au as that is the nominated security contact at https://covidsafe.gov.au/.well-known/security.txt

```
-----BEGIN PGP SIGNED MESSAGE-----
Hash: SHA256

Contact: mailto:support@covidsafe.gov.au
Canonical: https://www.covidsafe.gov.au/.well-known/security.txt
Encryption: https://www.covidsafe.gov.au/.well-known/pgp-key.txt
-----BEGIN PGP SIGNATURE-----

iQFNBAEBCAA3FiEEbUgetBuPAas8w7zHDyQUNNekxBkFAl6xF6AZHHN1cHBvcnRA
Y292aWRzYWZlLmdvdi5hdQAKCRAPJBQ016TEGd+bCACLrYjCbKRsTsQQyZVVtGxj
wYKW2AWclnKZWX/sxnTexg6D1tlGbZbB0OJpw0gJ0NpMoOLFd0kRZXOzv8RocIdx
xd90Nwwl3NQ2ygGCDXR0Y7uRKX/P/Y1xO7XkyiYXAqVq3YWvI9M04pY/TCRvRZ/1
qBs/WDHv/6eRh2qNy/WGXD66CmTLHBcXilTeihcTZ/27Mny5SPthdfy8odQnhUja
NfFxDm+8gQuFKUUQmr9rd8FEMPSl6BWf/kQtn0YmTeZRzD01uT1ydeHkyPSgn+nq
k9us35AlkI7aZNfNkFVWJ2v5ZVAdTHDh3pgBRZETwVg1of5DEXhc5XJV6mLsu9bM
=tik2
-----END PGP SIGNATURE-----
```

Additionally the DTA has publically commented in the Australian media that all matters should be reported to support@covidsafe.gov.au.

<?# Twitter 1257506430476640256 /?>

Here's a screenshot showing that data was publically accessible without authentication.

Geoffrey Huntley did not download, access or conduct any analysis of this data.

<?# Twitter 1259103414316707840 /?>

Geoffrey Huntley logged an urgent incident with the ASD and called to confirm that they had received the matter.

<?# Twitter 1259105952030027776 /?>
<?# Twitter 1259111494072975363 /?>


# May 12th, 2020 - Response

support@covidsafe.gov.au, the designated security contact, replied two days later. The response was incorrect and directed Geoffrey Huntley where he could download the source code of the COVIDSafe application.


<?# Twitter 1260012514131099648 /?>


# Closing Remarks and Recommendations

Taking two days to respond to a potential data breach report is unacceptable.


Additionally, it is clear that support@covidsafe.gov.au is not the appropriate avenue for security and privacy researchers. It is industry best practice that security and privacy research is read, processed and triaged by engineers and not customer support presentatives whom maybe non-technical.

Establishing a proper bug bounty - with or without financial rewards must be done urgently. What matters outcome wise is the establishment of a known, publically documented process that is manned by engineers with response time SLAs of less than an hour no matter what time of day it is. 

<?# Twitter 1263581018566430720 /?>

Geoffrey Huntley recommends using a commerical offering such as https://bugcrowd.com or https://hackerone.com/

