# Account Checker

This is an account checker tool that can be used to check the validity of accounts across different websites and services. While this tool has gained notoriety in blackhat and cracking forums for its potential misuse, this repository is intended solely for educational purposes and to help protect APIs and platforms from unauthorized access.

> ![](https://i.imgur.com/rlME8KK.png)



## Features & Purposes

|Feature | Purpose |
| ------ | ------ |
| Combolist | A list of combinations of emails and passwords that are used to check the validity of accounts across different websites and services. |
| Proxylist | A list of (often public) proxies that can be used to hide the user's IP address and avoid detection. |
| Threading | The ability to check multiple accounts simultaneously to speed up the process. |
| Hits Saving | The tool appends correct combinations to a .txt file, making it easy to keep track of successful checks. |
| RPC | This feature is used to display statistics and lure potential customers on Discord.|
| CUI | The tool includes a command-line user interface, which makes it easy for inexperienced users to navigate and use the tool effectively. |

## Prevention

Below is a list of effective ways to protect your API and platform from cracking attacks, ranked in order of effectiveness with #1 being the most effective. Note that there are many other ways to protect but these are the most common known harder protections in the cracking industry.

|Rank | Method |
| ------ | ------ |
| **#1** | **Akamai**: Offers security features similar to Cloudflare, but with higher cost and complexity. |
| **#2** | **HCaptcha**: Detects bots and malicious traffic, but with potential false positives.
| **#3**| **Cloudflare**: DDoS protection, WAF, and bot detection.  |
| **#4** | **Salt/Encryption**: Protects sensitive data with unreadable encryption.|
| **#5** | **ReCaptcha (V2)**: Effectively detects bots and automated attacks.|
| **#6** | **Rate Limiting**: Provides a good level of protection against brute-force attacks.|

# Concept Explained

The account checker is a program that checks if email and password combinations are correct for a website. It does this by sending a request to the website's API and seeing if it says "true" or "false" in response. The program uses a list of email and password combinations, which it gets from another part of the program. It also uses a proxy (another computer that hides your computer's IP address) to make sure the website can't tell where the request is coming from.

The code above is part of the account checker program. It takes an email and password combination from the list, splits them up, and sends them to the website's API. It then checks the response to see if it says "true" or "false". If it says "true", it means the email and password are correct, so the program saves that combination to a file. If it says "false", it means the email and password are incorrect, so the program saves that combination to a different file. If the response contains an error, the program puts the email and password back in the list to check later. The program keeps doing this until it has checked all the combinations in the list.
# Dependencies

- Leaf.xNet: HTTP library for making web requests. (Most known library for Cracking; Previously Extreme.Net)
- System.Security.Cryptography.X509Certificates: Namespace containing X509Certificate2 class used for SSL certificate validation. Used to prevent sniffing api's thru intercepters.
- Colorful.Console: Used to add color and formatting to console output in .NET applications.




