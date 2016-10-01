#!/usr/bin/env python
from imgurpython import ImgurClient
import sys
from subprocess import call
filename = 'einbrecher.jpeg'

call(['streamer','-f', 'jpeg', '-o', filename])

client_id = 'b4085d2a4e1e1ff'
client_secret = '0536ded103976b9ffcbce530ab186b3557a4e1ef'

client = ImgurClient(client_id, client_secret)
custom_url = client.upload_from_path(filename)['link']
messageText = sys.argv[1]
api_url = 'https://hooks.slack.com/services/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'
payload = {'text':messageText, 'icon_url':custom_url }

import json
import requests
requests.post(api_url, data=json.dumps(payload))
