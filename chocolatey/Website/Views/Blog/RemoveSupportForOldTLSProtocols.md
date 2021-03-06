Url: remove-support-for-old-tls-versions
Title: Removing Support For Old TLS Versions On The Chocolatey Website
Author: Chocolatey Operations Team
Published: 20200123
Tags: News, Status, Infrastructure
Keywords: downtime, infrastructure, tls
Summary: We will be removing support for TLS 1.0 and TLS 1.1 from the Chocolatey Website on 3 February 2020.
---
You may have noticed that support for older TLS versions is being removed from websites all over the internet. With the ever evolving security landscape and the perpetual game of cat and mouse between attackers and cryptography we need to ensure that we keep abreast of industry best practice.

Cryptography attacks are nothing new. While there are workarounds for many of them available, what they tell us is that some protocols are best left behind when there is a better way forward.

TLS 1.0 and 1.1 have been around a very long time now. But it is time to move on and remove support for these older, less secure, protocols. As a result the Chocolatey website will remove support for TLS 1.0 and TLS 1.1 on 3 February 2020.

### Why are we doing this now?

While the removal of support for older TLS protocols started some time ago across the internet, we have committed to supporting out-of-the-box installs on Windows 7 SP1 and Windows Server 2008 which do not support TLS 1.2. With the Chocolatey software being installed first by many build scripts, removing support for these older protocols would have had a negative impact on our users.

With TLS 1.0 and 1.1 now responsible for less than 3.3% of traffic to Chocolatey.org and the end-of-life for [Windows Server 2008 (and R2)](https://support.microsoft.com/en-gb/help/4456235/end-of-support-for-windows-server-2008-and-windows-server-2008-r2) on-premises* and [Windows 7](https://support.microsoft.com/en-gb/help/4057281/windows-7-support-ended-on-january-14-2020) occurring on 14 January 2020, support for these older protocols over potential security issues no longer makes sense.

\*  Customers using Microsoft Azure may qualify for an additional 3 years of Critical and Important security updates at no additional charge - see "[end of support](https://support.microsoft.com/en-gb/help/4456235/end-of-support-for-windows-server-2008-and-windows-server-2008-r2)" for details.

### What does this mean for you?

With modern browsers (such as Firefox, Edge, Chrome etc.) supporting TLS 1.2 for many years now, there should not be anything for you to do when browsing Chocolatey.org. Many major websites today have already removed support for these older protocols so if there was an issue with your browser and TLS 1.2 you would know about it by now.

While your operating system may support TLS 1.2 it's important to remember that it may have to be enabled. If you are working from PowerShell you can find out which protocols your system supports by running this code:

```powershell
[Enum]::GetNames([Net.SecurityProtocolType]) -contains 'Tls12'
```

If the result is True then your system supports TLS 1.2. You can find out which protocols are being used by running:

```powershell
[System.Net.ServicePointManager]::SecurityProtocol.HasFlag([Net.SecurityProtocolType]::Tls12)
```

If the result is True then TLS 1.2 is being used . However, you can add TLS 1.2 explicitly by using:

```powershell
[Net.ServicePointManager]::SecurityProtocol = [Net.ServicePointManager]::SecurityProtocol -bor [Net.SecurityProtocolType]::Tls12
```

You can find more information on this [blog post](https://blog.pauby.com/post/force-powershell-to-use-tls-1-2/) around working with TLS 1.2 in PowerShell.

If you are using the Chocolatey Client, choco.exe, then all versions from [0.10.1 support TLS 1.2](https://github.com/chocolatey/choco/commit/2d39d97f01435d655fcc3675ab893bf71d60e6cb) without any additional configuration noted above (provided you have at least .NET 4.5 installed as well - you may also need [KB2919355](https://support.microsoft.com/en-us/help/2929781/update-adds-new-tls-cipher-suites-and-changes-cipher-suite-priorities) installed depending on your operating system). If you are using an older version then it is time to upgrade. The current version is 0.10.15.

### Provisioning Older Machines?

If you find yourself provisioning machines such as Windows 7, Windows Server 2008, or older, you will find that those machines will not be able to communicate with the Chocolatey Community Repository after we implement this change. For those instances, you will need to [use alternative installation methods](https://chocolatey.org/docs/installation) for Chocolatey. We strongly recommend using the [offline Chocolatey installation](https://chocolatey.org/docs/installation#completely-offline-install) as it provides the most flexibility and reliability.

### Conclusion

We understand that this change may put additional burden on a very small set of our user base. Given the number of major web sites who have already gone through this change we anticipate that the burden will be small. However, if you have any questions or concerns related to this announcement, please do not hesitate to [contact us](https://chocolatey.org/support) using the means are available to you depending on your edition - you'll find these contact methods listed on the [support page](https://chocolatey.org/support).