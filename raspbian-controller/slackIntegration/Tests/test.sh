#!/bin/bash
curl -X POST \
    --data-urlencode  'payload={"text":"Hi","attachments": [ {"fallback": "hello", "image_url": "https://i.vimeocdn.com/portrait/58832_300x300" }  ] }' \
     https://hooks.slack.com/services/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
