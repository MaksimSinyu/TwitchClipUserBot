import requests
from twitchio.ext import commands

# Set up the Twitch bot
bot = commands.Bot(
    token='YOUR TOKEN',
    client_id='YOUR CLIENT ID',
    nick='YOUR USERNAME',
    prefix='!',
    initial_channels=['CHANNEL']
)

def get_clip_id():
    params = {
        'broadcaster_id': 'YOUR_BROADCASTER_ID',
        'has_delay': 'false',
        'duration': 60
    }

    headers = {
        'Authorization': 'Bearer YOUR BEARER TOKEN',
        'Client-Id': 'YOUR CLIENT ID',
    }

    response = requests.post('https://api.twitch.tv/helix/clips', params=params, headers=headers)

    if response.status_code == 202:
        clip_id = response.json()['data'][0]['id']
        return clip_id
    else:
        print(f"Error creating clip: {response.text}")

@bot.command(name='clip')
async def clip_command(ctx):
    clip_id = get_clip_id()
    await ctx.send(f"Clip created successfully. Clip URL: https://clips.twitch.tv/{clip_id}")

if __name__ == "__main__":
    bot.run()
