Title: Unneeded incompatibility with Android 5.0
Status: Work in Progress
---

Android 5.0 Lollipop was launched by Google back in late 2014 preceded by 5.1 Lollipop in early 2015. As of April 2020 both run on 2.64% of Australia’s Android Devices which make 55% of the wider Market. (Source) The COVIDSafe app has found to have an unneeded compatibility with those devices as it’s minimum version supported is 6.0.



Android 5.0 introduced the functionality of Bluetooth Low Energy Broadcasts, which is what the COVIDSafe app uses to emit the identifiers. The method used to code this functionality in the COVIDSafe app should run without a problem on both Android 5.0 & 5.1.



The other thing is that the libraries (Sets of prewritten code) that are available to the public of which the COVIDSafe app is dependent upon are compatible with Android 5.0.

Library | Compatibility with Android 5.0
--- | ---
ProgressButton by Razir | ✅
Lottie-android by Airbnb | ✅
OkHttp by Square | ✅
Okio by Square | ✅
EasyPermissions by Google | ✅
Retrofit by Square | ✅
RxAndroid | ✅

One item that no one in the community can figure out is the closed source (meaning private) library called “com.atlassian.mobilekit” of which the COVIDSafe app is dependent upon. There is speculation that since the COVIDSafe app is dependent on this library, that it is forced to make the minimum version 6.0. 
Atlassian, the creators of this library, could potentially make a derivative that works on 5.0 & 5.1 devices.

The Digital Transformation Agency is working with Apple and Google on their improved bluetooth connectivity to implement into the COVIDSafe app. As of the preliminary documentation released by Google in April describing how this technology works on Android, it has outlined the minimum Android version required would be 5.0.

If there are no issues with dependencies that the COVIDSafe app is reliant upon, the modification to the code is not difficult. Simply adjust the “minSdkVersion” number from 23 to 21. 
This small change could enable the COVIDSafe app to reach that 3% that might really need it.
