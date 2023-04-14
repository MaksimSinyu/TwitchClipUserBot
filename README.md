# TwitchClipUserBot
This code tracks the chat of a specific streamer and if the word "!clip" appears in the chat, the userbot sends a link to a clip made in the last minute.

# Python Usage
The code uses the Twitch API to create the clip and the TwitchIO library to interact with the Twitch chat. You will also need to provide a valid Twitch API token, client ID, and the username of the streamer you want to track in the code.

To use this code, simply run the script and ensure that the Twitch streamer you want to track is live. When the "!clip" command is used in the chat, the userbot will create a clip and post the link in the chat. Please note that the Twitch API limits the number of clips that can be created per hour, so be sure to use this code responsibly.

If you want to use this code as a starting point for your own Twitch bot, feel free to modify it to suit your needs. You can also refer to the TwitchIO documentation for more information on how to interact with the Twitch chat using Python.

# CSharp Usage
To use this bot, you need to have a Twitch account and create an OAuth token and a client ID for authentication. You also need to know the broadcaster ID and your own Twitch username and channel name.

After filling in the necessary authentication information, you can run the program, which will initialize the Twitch client and connect to the Twitch chat. When a chat message is received, the bot checks if it starts with "!clip". If it does, the bot calls the CreateClip method and passes in the channel name.

The CreateClip method sends a POST request to the Twitch API to create a clip with a duration of 60 seconds. If the request is successful, the bot extracts the clip ID from the response and constructs a URL to the clip. The bot then sends a chat message to the specified channel with a link to the newly created clip.

If the request to create the clip is unsuccessful, the bot logs an error message and returns null.

To run the code, you need to have the necessary libraries installed and fill in the authentication information. 

# Make Sure
Make sure to replace "YOUR OAUTH TOKEN", "YOUR CLIENT ID", "YOUR BROADCASTER ID", "YOUR TWITCH USERNAME", "INITIAL_CHANNELS OR TWITCH_USERNAME_STREAMER" with your own values. This will ensure that other users cannot steal your authentication credentials.

# Installation
To install the required dependencies, simply run the following command:
```
pip install -r requirements.txt
```

```
dotnet restore
```
# Contributing
Contributions are welcome! If you would like to contribute to GrishaBot, please create a pull request with your changes.

# License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt) file for details.


![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)
[![GitHub](https://img.shields.io/badge/GitHub-%23323330.svg?&style=for-the-badge&logo=GitHub&logoColor=white)](https://github.com/MaksimSinyu)
[![LeetCode](https://img.shields.io/badge/LeetCode-%23F89F1B.svg?&style=for-the-badge&logo=LeetCode&logoColor=white)](https://leetcode.com/hardsuit/)
[![Twitch](https://img.shields.io/badge/Twitch-%239146FF.svg?&style=for-the-badge&logo=Twitch&logoColor=white)](https://www.twitch.tv/psychokaro)
[![Telegram](https://img.shields.io/badge/Telegram-%232CA5E0.svg?&style=for-the-badge&logo=Telegram&logoColor=white)](https://t.me/aaaaaaaaaoaao)


